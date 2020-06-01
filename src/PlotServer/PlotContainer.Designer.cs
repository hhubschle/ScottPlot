namespace PlotServer
{
	partial class PlotContainer
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.formsPlot = new ScottPlot.FormsPlot();
			this.SuspendLayout();
			// 
			// formsPlot2
			// 
			this.formsPlot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.formsPlot.Location = new System.Drawing.Point(0, 0);
			this.formsPlot.Name = "formsPlot";
			this.formsPlot.Size = new System.Drawing.Size(790, 540);
			this.formsPlot.TabIndex = 0;
			this.formsPlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formsPlot_MouseMoved);
			// 
			// PlotContainer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.formsPlot);
			this.Name = "PlotContainer";
			this.Size = new System.Drawing.Size(790, 540);
			this.ResumeLayout(false);

		}

		#endregion

		private ScottPlot.FormsPlot formsPlot;
	}
}
