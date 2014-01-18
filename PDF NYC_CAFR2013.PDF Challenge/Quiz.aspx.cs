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


public partial class Quiz : System.Web.UI.Page
{
    static ArrayList list = new ArrayList();
    
    protected void Page_Load(object sender, EventArgs e)

    {
        
        for (int i = 0; i < 10; i++)
            list.Add(i);
        string str = ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\9780306822315-text.pdf",31);
       TextBox1.Text = str.Substring(20, 100);
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
       
        string str = ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\9780306822315-text.pdf",Convert.ToInt32( DropDownList1.SelectedValue));
        string[] stringSeparators = new string[] { "\r\n" };
        string[] a = str.Split(stringSeparators, StringSplitOptions.None);
        TextBox1.Text = str.Substring(20, 100);
        TextBox1.Enabled = false;
        //list.Add(slider1_display.Text);
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
       
    }
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Edit Switched On ";
    }
    protected void Button2_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Data Saved";
    }
    protected void Button3_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Send For Approval and Saved";
    }
}
