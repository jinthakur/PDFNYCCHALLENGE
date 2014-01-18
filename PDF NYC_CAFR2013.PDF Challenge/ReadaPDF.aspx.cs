using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


public partial class ReadaPDF : System.Web.UI.Page
{
    static ArrayList list = new ArrayList();
    //static stringoutout ;
    
    protected void Page_Load(object sender, EventArgs e)

    {
        for (int j = 1; j < 400; j++)
            DropDownList1.Items.Add(new ListItem(j.ToString()));
        for (int i = 0; i < 10; i++)
            list.Add(i);
        string str = ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\NYC_CAFR2013.pdf", Convert.ToInt32(DropDownList1.SelectedValue));
       TextBox1.Text = str;
       Timer1_Tick(sender, e);

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Response.Redirect("Procedure.aspx");
    }
    
 

    public static string ExtractTextFromPDFPage(string pdfFile, int pageNumber)
    {
        PdfReader reader = new PdfReader(pdfFile);
        string text = PdfTextExtractor.GetTextFromPage(reader, pageNumber);
        try { reader.Close(); }
        catch {}
        return text;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = "Panel refreshed at: " +
            DateTime.Now.ToLongTimeString() + " -- PageNumber " + DropDownList1.SelectedValue + " -- Line Number " + DateTime.Now.Second.ToString();
        string str = ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\NYC_CAFR2013.pdf", Convert.ToInt32(DropDownList1.SelectedValue));
        string[] stringSeparators = new string[] { "\r\n" };
        string[] a = str.Split(stringSeparators, StringSplitOptions.None);
       
        
        TextBox1.Text = a[0].Replace("$ " ,"");
        TextBox1.Enabled = false;
        list.Add(slider1_display.Text);
        int icount = 0;
        for (int i = 0; i < 1; i++)
            list.Add(i);
        String[] Data = new String[40];
        Random rnd = new Random();
        for (int i = 0; i < 40; i++)
        {
            Data[i] = i.ToString() + " Units";

        }
         icount = 1;
        foreach (string dow in Data)
        {
            double totalSalesForDOW = rnd.NextDouble() * 1 * rnd.NextDouble() * 5 + 1;
            //chtSalesPerDOW.Series[0].Points.AddXY(dow, totalSalesForDOW);
            //  sw.WriteLine(icount.ToString() + ":" + totalSalesForDOW.ToString());
            icount++;
        }
    }
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Edit Switched On ";
    }
    protected void Button2_Click(object sender, System.EventArgs e)
    {   string[] stringSeparators = new string[] { " " };
        string[] a = TextBox1.Text.Split(stringSeparators, StringSplitOptions.None);
        string output= "";
        string temps ="";
        foreach(  string  s in a )
        {
            temps = "";
           if ( s.Contains(',')
               )

               temps = '"' + s + '"' + ",";
           else
           temps = temps +s + ",";
           output = output + temps;

        }

        System.IO.File.Delete(Server.MapPath("PDF") + @"\Output\WriteText" + DropDownList1.SelectedValue + ".csv");
        System.IO.File.WriteAllText(Server.MapPath("PDF") + @"\Output\WriteText" + DropDownList1.SelectedValue + ".csv", output);
        TextBox1.Enabled = true;
        Label1.Text = "Data Saved";
    }
    protected void Button4_Click(object sender, System.EventArgs e)
    {
       
        string output = TextBox1.Text;


        System.IO.File.Delete(Server.MapPath("PDF") + @"\Output\WriteText" + DropDownList1.SelectedValue + "ASITIS.csv");
        System.IO.File.WriteAllText(Server.MapPath("PDF") + @"\Output\WriteText" + DropDownList1.SelectedValue + "ASITIS.csv", output);
        TextBox1.Enabled = true;
        Label1.Text = "Data Saved";
    }
    protected void Button3_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Send For Approval and Saved";
    }
}
