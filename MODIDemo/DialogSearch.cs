using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DocumentProcessing
{
	public delegate void SearchButtonPressedHandler(object sender, EventArgs e);
	public delegate void CloseButtonPressedHandler(object sender, EventArgs e);

	public class DialogSearch : System.Windows.Forms.Form
	{
		public event SearchButtonPressedHandler SearchButtonPressed;
		public event CloseButtonPressedHandler CloseButtonPressed;

		protected virtual void OnSearchButtonPressed(EventArgs e)
		{
			if (SearchButtonPressed != null)
				SearchButtonPressed(this, e);
		}

		protected virtual void OnCloseButtonPressed(EventArgs e)
		{
			if (CloseButtonPressed != null)
				CloseButtonPressed(this, e);
		}

	
		public MODISearchArguments Properties
		{
			get {
				((MODISearchArguments) propertyGrid1.SelectedObject).Pattern = comboBox1.Text;
				return (MODISearchArguments) propertyGrid1.SelectedObject;
				
			}
			set {
				propertyGrid1.SelectedObject = (MODISearchArguments) value;
				comboBox1.Text = ((MODISearchArguments) value).Pattern;
			}
		}

		private System.Windows.Forms.Button bSearch;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button bClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;

		private System.ComponentModel.Container components = null;

		public DialogSearch()
		{
			InitializeComponent();
		}
		protected override void Dispose( bool disposing )
		{
			if (!_hiding)
			{
				if( disposing )
				{
					if(components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
				_hiding = false;
			}
		}

		#region Vom Windows Form-Designer generierter Code
		private void InitializeComponent()
		{
			this.bSearch = new System.Windows.Forms.Button();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.bClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// bSearch
			// 
			this.bSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSearch.Location = new System.Drawing.Point(392, 8);
			this.bSearch.Name = "bSearch";
			this.bSearch.Size = new System.Drawing.Size(88, 23);
			this.bSearch.TabIndex = 1;
			this.bSearch.Text = "Search";
			this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(8, 72);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(368, 272);
			this.propertyGrid1.TabIndex = 1;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// bClose
			// 
			this.bClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bClose.Location = new System.Drawing.Point(392, 40);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(88, 23);
			this.bClose.TabIndex = 2;
			this.bClose.Text = "Close";
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "MODI Search Arguments:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Search for:";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(8, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(368, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
			// 
			// DialogSearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(490, 352);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bClose);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.bSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DialogSearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DialogSearch_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void bSearch_Click(object sender, System.EventArgs e)
		{
			OnSearchButtonPressed(new EventArgs());
		}

		private void bClose_Click(object sender, System.EventArgs e)
		{
			OnCloseButtonPressed(new EventArgs());
		}

		private bool _hiding = false;
		private void DialogSearch_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_hiding = true;
			OnCloseButtonPressed(new EventArgs());
		}

		private void comboBox1_TextChanged(object sender, System.EventArgs e)
		{
			this.Properties.Pattern = comboBox1.Text;
			propertyGrid1.Refresh();
		}

		public void MyUpdate()
		{
			propertyGrid1.Refresh();
		}

	}
}
