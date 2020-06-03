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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonOPen = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPlus = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMinus = new System.Windows.Forms.ToolStripButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOPen,
            this.toolStripButtonPlus,
            this.toolStripButtonMinus});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(521, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonOPen
			// 
			this.toolStripButtonOPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonOPen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOPen.Image")));
			this.toolStripButtonOPen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonOPen.Name = "toolStripButtonOPen";
			this.toolStripButtonOPen.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonOPen.Text = "Open file";
			this.toolStripButtonOPen.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButtonPlus
			// 
			this.toolStripButtonPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonPlus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlus.Image")));
			this.toolStripButtonPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPlus.Name = "toolStripButtonPlus";
			this.toolStripButtonPlus.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonPlus.Text = "+";
			this.toolStripButtonPlus.ToolTipText = "Lengthen arrows";
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
			this.toolStripButtonMinus.ToolTipText = "Shorten arrows";
			this.toolStripButtonMinus.Click += new System.EventHandler(this.toolStripButtonMinus_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "CSV files|*.csv|XML fiels|*.xml|TXT files|*.txt";
			this.openFileDialog1.Title = "Open file";
			// 
			// tabControl1
			// 
			this.tabControl1.AllowDrop = true;
			this.tabControl1.Location = new System.Drawing.Point(324, 418);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(522, 95);
			this.tabControl1.TabIndex = 1;
			this.tabControl1.Visible = false;
			this.tabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.tabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			// 
			// dockPanel1
			// 
			this.dockPanel1.AllowDrop = true;
			this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
			this.dockPanel1.Location = new System.Drawing.Point(0, 25);
			this.dockPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.dockPanel1.Name = "dockPanel1";
			this.dockPanel1.Size = new System.Drawing.Size(521, 447);
			this.dockPanel1.TabIndex = 2;
			this.dockPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.dockPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(521, 472);
			this.Controls.Add(this.dockPanel1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Plot server";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonOPen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripButton toolStripButtonPlus;
		private System.Windows.Forms.ToolStripButton toolStripButtonMinus;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolTip toolTip1;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
	}
}

