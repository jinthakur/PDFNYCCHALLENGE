using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

using Bytescout.PDFExtractor;
using System.Diagnostics;


public partial class ReadaPDF : System.Web.UI.Page
{
    static ArrayList list = new ArrayList();
    
    protected void Page_Load(object sender, EventArgs e)

    {
        
        for (int i = 0; i < 10; i++)
            list.Add(i);
        //string str = ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\NYC_CAFR2013.pdf", Convert.ToInt32(DropDownList1.SelectedValue));
       TextBox1.Text = "";
       Timer1_Tick(sender, e);

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Response.Redirect("Procedure.aspx");
    }
    
 

    public  void ExtractTextFromPDFPage(string pdfFile, int pageNumber)
    {


        CSVExtractor extractor = new CSVExtractor();
        extractor.RegistrationName = "demo";
        extractor.RegistrationKey = "demo";

        TableDetector tdetector = new TableDetector();
        tdetector.RegistrationKey = "demo";
        tdetector.RegistrationName = "demo";

        // we should define what kind of tables we should detect
        // so we set min required number of columns to 3
        tdetector.DetectionMinNumberOfColumns = 1;

        // and we set min required number of columns to 3
        tdetector.DetectionMinNumberOfRows = 3;

        // Load sample PDF document
        extractor.LoadDocumentFromFile(pdfFile);
        tdetector.LoadDocumentFromFile(pdfFile);

        // Get page count
        int pageCount = tdetector.GetPageCount();

        for (int j = 1; j < pageCount; j++)
            DropDownList1.Items.Add(new ListItem(j.ToString()));

        for (int i = 0; i <= pageCount; i++)
        {
            int j = 1;
            
            // find first table and continue if found
            if (tdetector.FindTable(i))
                do
                {
                    // set extraction area for CSV extractor to rectangle given by table detector
                    extractor.SetExtractionArea(tdetector.GetFoundTableRectangle_Left(),
                        tdetector.GetFoundTableRectangle_Top(),
                        tdetector.GetFoundTableRectangle_Width(),
                        tdetector.GetFoundTableRectangle_Height()
                    );

                    // and finally save the table into CSV file
                    extractor.SavePageCSVToFile(i, Server.MapPath("PDF") + @"\outputpage-" + i + "-table-" + j + ".csv");
                    j++;
                } while (tdetector.FindNextTable()); // search next table
        }

        // Open first output file in default associated application
        //System.Diagnostics.Process.Start("page-0-table-1.csv");

    


    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = "Panel refreshed at: " +
            DateTime.Now.ToLongTimeString() + " -- PageNumber " + DropDownList1.SelectedValue + " -- Line Number " + DateTime.Now.Second.ToString();
       // ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\NYC_CAFR2013.pdf", Convert.ToInt32(DropDownList1.SelectedValue));
        
    }
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Edit Switched On ";
    }
    protected void Button2_Click(object sender, System.EventArgs e)
    {
        ExtractTextFromPDFPage(Server.MapPath("PDF") + @"\\1Q-4Q-2010-HCP-Fee-Disclosure-Report-033111.pdf", Convert.ToInt32(DropDownList1.SelectedValue));
        TextBox1.Enabled = true;
        Label1.Text = "Data Saved";
    }
    protected void Button3_Click(object sender, System.EventArgs e)
    {
        TextBox1.Enabled = true;
        Label1.Text = "Send For Approval and Saved";
    }
}
