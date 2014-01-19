// Written by Martin Welker, www.martinwelker.com
//
//Main reference: 
//http://msdn.microsoft.com/library/default.asp?url=/library/en-us/Mspauto/html/dihowUsingMODIObjectModel_HV01049396.asp
// 
//    
//Please note:
//The Microsoft® Office Document Imaging Library 2003 (MODI) object model makes 
//it possible to develop custom applications for managing document images 
//(such as scanned and faxed documents) and the recognizable text that they 
//contain. The MODI components include the MODI Viewer Control, an ActiveX® control 
//that you can use to display MODI documents. 
//
//Important: The MODI programmability features described in this document are 
//available only in Microsoft Office Document Imaging 2003. The Microsoft Office XP 
//version of document imaging does not include a programmable object model." 
//
//
//The whole process in 6 lines..
//
//[STAThread]
//  static void Main(string[] args)
//  {
//    MODI.Document doc = new Document();
//    doc.Create(@"example.tif");
//    doc.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH,false,false);
//    doc.Save();
//    MODI.Image img = (MODI.Image)doc.Images[0];
//    Console.WriteLine(img.Layout.Text);
//  }



using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using DocumentProcessing;


namespace DocumentProcessing
{

	public class Form1 : System.Windows.Forms.Form
	{

		private MODIOCRArguments _MODIParameters = new MODIOCRArguments();
		private MODI.Document _MODIDocument = null;
		private DialogSearch _DialogSearch = null;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miOpen;
		private AxMODI.AxMiDocView axMiDocView1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miCopy;
		private System.Windows.Forms.MenuItem miAnalyse;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miOCRParameters;
		private System.Windows.Forms.MenuItem miStatistic;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem miFind;

		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

			InitSearchDialog();

			axMiDocView1.FitMode = MODI.MiFITMODE.miByWindow;

			statusBar1.Text = "Ready.";
		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miOpen = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miCopy = new System.Windows.Forms.MenuItem();
			this.miAnalyse = new System.Windows.Forms.MenuItem();
			this.miOCRParameters = new System.Windows.Forms.MenuItem();
			this.miStatistic = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miFind = new System.Windows.Forms.MenuItem();
			this.axMiDocView1 = new AxMODI.AxMiDocView();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			((System.ComponentModel.ISupportInitialize)(this.axMiDocView1)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miFile,
																					  this.menuItem1});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miOpen,
																				   this.miSave});
			this.miFile.Text = "File";
			// 
			// miOpen
			// 
			this.miOpen.Index = 0;
			this.miOpen.Text = "Open..";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// miSave
			// 
			this.miSave.Index = 1;
			this.miSave.Text = "Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miCopy,
																					  this.miAnalyse,
																					  this.miOCRParameters,
																					  this.miStatistic,
																					  this.menuItem2,
																					  this.miFind});
			this.menuItem1.Text = "Edit";
			// 
			// miCopy
			// 
			this.miCopy.Index = 0;
			this.miCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.miCopy.Text = "Copy text to clipboard";
			this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// miAnalyse
			// 
			this.miAnalyse.Index = 1;
			this.miAnalyse.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.miAnalyse.Text = "Start OCR";
			this.miAnalyse.Click += new System.EventHandler(this.miAnalyse_Click);
			// 
			// miOCRParameters
			// 
			this.miOCRParameters.Index = 2;
			this.miOCRParameters.Text = "Select OCR Parameters..";
			this.miOCRParameters.Click += new System.EventHandler(this.miOCRParameters_Click);
			// 
			// miStatistic
			// 
			this.miStatistic.Index = 3;
			this.miStatistic.Text = "Statistic";
			this.miStatistic.Click += new System.EventHandler(this.miStatistic_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 4;
			this.menuItem2.Text = "-";
			// 
			// miFind
			// 
			this.miFind.Index = 5;
			this.miFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.miFind.Text = "Find..";
			this.miFind.Click += new System.EventHandler(this.miFind_Click);
			// 
			// axMiDocView1
			// 
			this.axMiDocView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axMiDocView1.Enabled = true;
			this.axMiDocView1.Location = new System.Drawing.Point(0, 0);
			this.axMiDocView1.Name = "axMiDocView1";
			this.axMiDocView1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMiDocView1.OcxState")));
			this.axMiDocView1.Size = new System.Drawing.Size(752, 523);
			this.axMiDocView1.TabIndex = 2;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 523);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(752, 22);
			this.statusBar1.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(752, 545);
			this.Controls.Add(this.axMiDocView1);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OCR with MS Office 2003";
			((System.ComponentModel.ISupportInitialize)(this.axMiDocView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.  Application.EnableVisualStyles();
			System.Windows.Forms. Application.DoEvents();
			Application.Run(new Form1());
		}

		private void miOpen_Click(object sender, System.EventArgs e)
		{
			// open document file..
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image files|*.tif;*.tiff;*.bmp|All files (*.*)|*.*" ;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				SetImage(dialog.FileName);
			}
		}

		public void ShowProgress(int progress, ref bool cancel)
		{
			statusBar1.Text = progress.ToString() + "% processed.";
		}
	
		public void Analyse()
		{
			if (_MODIDocument == null) return;
			try 
			{
				// add event handler for progress visualisation
				_MODIDocument.OnOCRProgress +=  new MODI._IDocumentEvents_OnOCRProgressEventHandler(this.ShowProgress);
                
				// the MODI call for OCR
				_MODIDocument.OCR(_MODIParameters.Language,_MODIParameters.WithAutoRotation,_MODIParameters.WithStraightenImage);
				statusBar1.Text = "Ready.";
			}
			catch(Exception ee)
			{
				// simple exception "handling"
				MessageBox.Show(ee.Message);
			}
		}

	
		public void EnsureOCR(int page)
		{
			MODI.Image img = (MODI.Image) _MODIDocument.Images[page];
			try 
			{
				// just ask and expect an exception
				int voidReturn	= img.Layout.NumChars;
		
			}
			catch(Exception ee)
			{
				img.OCR(_MODIParameters.Language,_MODIParameters.WithAutoRotation,_MODIParameters.WithStraightenImage);
				MessageBox.Show("Error occurred: "+ee.Message);
			}
		}

		public void EnsureOCR()
		{
			if (_MODIDocument == null) return;
			for (int i = 0; i < _MODIDocument.Images.Count; i++)
			{
				EnsureOCR(i);
			}
		}
		
		private void Statistic()
		{	
			// iterating though the document's structure doing some statistic.
			string statistic = "";
			for (int i = 0 ; i < _MODIDocument.Images.Count; i++)
			{
				int numOfCharacters = 0;
				int charactersHeights = 0;
				MODI.Image image = (MODI.Image)_MODIDocument.Images[i];
				MODI.Layout layout = image.Layout;
				// getting the page's words
				for (int j= 0; j< layout.Words.Count; j++)
				{
					MODI.Word word = (MODI.Word) layout.Words[j];
					// getting the word's characters
					for (int k = 0; k < word.Rects.Count; k++)
					{
						MODI.MiRect rect = (MODI.MiRect) word.Rects[k];
						charactersHeights  += rect.Bottom-rect.Top;
						numOfCharacters++;
						
					}
				}
				float avHeight = (float )charactersHeights/numOfCharacters;
				statistic += "Page "+i+ ": Avarage character height is: "+avHeight.ToString("0.00") +" pixel!"+ "\r\n";
			}

			MessageBox.Show("Document Statistic:\r\n"+statistic);
				
		}

	
		private void SetImage(string filename)
		{
			// set the image..
			try 
			{
				_MODIDocument = new MODI.Document();
				_MODIDocument.Create(filename);
				axMiDocView1.Document = _MODIDocument;
				axMiDocView1.Refresh();
			}
			catch(System.Runtime.InteropServices.COMException ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

	
		private void miCopy_Click(object sender, System.EventArgs e)
		{
			// copy to clipboard..
			if (axMiDocView1.TextSelection != null)
			{
				axMiDocView1.TextSelection.CopyToClipboard();	
			}
		}

	
		private void miAnalyse_Click(object sender, System.EventArgs e)
		{
			// analyse document..
			if (_MODIDocument == null)
			{
				MessageBox.Show("No document selected!");
				return;
			}
			Analyse();
		}
	
	
		private void miSave_Click(object sender, System.EventArgs e)
		{
			// save as..
			if (_MODIDocument != null)
			{
				_MODIDocument.Save();
			}
		}

	
		private void miOCRParameters_Click(object sender, System.EventArgs e)
		{
			// simple dialog to modify the MODI OCR parameters..
			// !!no OK checking provided!!
			MODISettings dialog = new MODISettings();
			dialog.Settings = _MODIParameters;
			dialog.ShowDialog();
		}

	
		private void miStatistic_Click(object sender, System.EventArgs e)
		{
			Statistic();
		}

	
		#region Searching
		
		private void miFind_Click(object sender, System.EventArgs e)
		{
			_DialogSearch.Show();
			_DialogSearch.BringToFront();
		}

		private void Find()
		{
			if (_MODIDocument == null) return;
			if (_DialogSearch == null) return;
			if (_DialogSearch.Properties.Pattern.Trim() == "")  return;
			
			// our own method for 'lazy' OCR processing
			EnsureOCR();

			// convert our search dialog properties to corresponding MODI arguments
			object PageNum = _DialogSearch.Properties.PageNum;
			object WordIndex = _DialogSearch.Properties.WordIndex;
			object StartAfterIndex = _DialogSearch.Properties.StartAfterIndex;
			object Backward = _DialogSearch.Properties.Backward;
			bool MatchMinus = _DialogSearch.Properties.MatchMinus;
			bool MatchFullHalfWidthForm = _DialogSearch.Properties.MatchFullHalfWidthForm;
			bool MatchHiraganaKatakana = _DialogSearch.Properties.MatchHiraganaKatakana;
			bool IgnoreSpace =_DialogSearch.Properties.IgnoreSpace;

			// initialize MODI classes
			MODI.IMiSelectableItem SelectableItem = null;
			MODI.MiDocSearchClass search = new MODI.MiDocSearchClass();
						
			search.Initialize(
				_MODIDocument,
				_DialogSearch.Properties.Pattern,
				ref PageNum,
				ref WordIndex,
				ref StartAfterIndex,
				ref Backward,
				MatchMinus,
				MatchFullHalfWidthForm,
				MatchHiraganaKatakana,
				IgnoreSpace);

			// the one and only search call
			search.Search(null,ref SelectableItem);
				
			// parsing the search result
			if (SelectableItem != null)
			{
				MODI.Words words =(MODI.Words) SelectableItem.Words;
				int foundIndex = 0;
				for (int i = 0; i < words.Count; i++)
				{
					MODI.Word word = (MODI.Word) words[i];
					foundIndex = word.Id;
				}

				if (_DialogSearch.Properties.WordIndex < foundIndex )
				{
					_DialogSearch.Properties.WordIndex = foundIndex;
				}
				else
				{
					if (_DialogSearch.Properties.PageNum < _MODIDocument.Images.Count-1)
					{
						_DialogSearch.Properties.WordIndex = foundIndex;

						_DialogSearch.Properties.PageNum++;
					}
					else
					{
						_DialogSearch.Properties.PageNum = 0;
						_DialogSearch.Properties.WordIndex = foundIndex;
					}
				}
						
				// ensure visibility of found text mark
				axMiDocView1.TextSelection = SelectableItem;
				axMiDocView1.MoveSelectionToView(SelectableItem);
				SelectPage(_DialogSearch.Properties.PageNum);
			}
			// updating search dialog
			_DialogSearch.MyUpdate();
		}

		public void SelectPage(int page)
		{
			axMiDocView1.PageNum = page;
		}

		private void miSearch_Click(object sender, System.EventArgs e)
		{
			_DialogSearch.Show();
			_DialogSearch.BringToFront();
		}

		private void InitSearchDialog()
		{
			_DialogSearch = new DialogSearch();
			_DialogSearch.SearchButtonPressed += new SearchButtonPressedHandler(_DialogSearch_SearchButtonPressed);
			_DialogSearch.CloseButtonPressed +=new CloseButtonPressedHandler(_DialogSearch_CloseButtonPressed);
			_DialogSearch.Properties = new MODISearchArguments(); 
		}

		private void _DialogSearch_SearchButtonPressed(object sender, EventArgs e)
		{
			Find();
		}

		private void _DialogSearch_CloseButtonPressed(object sender, EventArgs e)
		{
			_DialogSearch.Hide();
		}

		
		#endregion
		
	}
}
