namespace PlotServer
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
		if(disposing && (components != null))
		{
		components.Dispose();
		}
		base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPlus = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMinus = new System.Windows.Forms.ToolStripButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.plotContainer1 = new PlotServer.PlotContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.toolStrip1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButtonPlus,
            this.toolStripButtonMinus});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButtonPlus
			// 
			this.toolStripButtonPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonPlus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlus.Image")));
			this.toolStripButtonPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPlus.Name = "toolStripButtonPlus";
			this.toolStripButtonPlus.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonPlus.Text = "+";
			this.toolStripButtonPlus.Click += new System.EventHandler(this.toolStripButtonPlus_Click);
			// 
			// toolStripButtonMinus
			// 
			this.toolStripButtonMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonMinus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMinus.Image")));
			this.toolStripButtonMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMinus.Name = "toolStripButtonMinus";
			this.toolStripButtonMinus.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMinus.Text = "-";
			this.toolStripButtonMinus.Click += new System.EventHandler(this.toolStripButtonMinus_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "CSV files|*.csv|XML fiels|*.xml|TXT files|*.txt";
			this.openFileDialog1.Title = "Open file";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.plotContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(792, 399);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "main";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// plotContainer1
			// 
			this.plotContainer1.AllowDrop = true;
			this.plotContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plotContainer1.Location = new System.Drawing.Point(3, 3);
			this.plotContainer1.Name = "plotContainer1";
			this.plotContainer1.Size = new System.Drawing.Size(786, 393);
			this.plotContainer1.TabIndex = 0;
			this.plotContainer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.plotContainer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			// 
			// tabControl1
			// 
			this.tabControl1.AllowDrop = true;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 25);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 425);
			this.tabControl1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Plot server";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripButton toolStripButtonPlus;
		private System.Windows.Forms.ToolStripButton toolStripButtonMinus;
		private System.Windows.Forms.TabPage tabPage1;
		private PlotContainer plotContainer1;
		private System.Windows.Forms.TabControl tabControl1;
	}
}

