namespace PlotServer
{
	partial class PlotDoc
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
			this.Plot = new PlotContainer();
			this.SuspendLayout();
			// 
			// Plot
			// 
			this.Plot.AllowDrop = true;
			this.Plot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Plot.Location = new System.Drawing.Point(0, 0);
			this.Plot.Name = "Plot";
			this.Plot.Size = new System.Drawing.Size(800, 450);
			this.Plot.TabIndex = 0;
			// 
			// PlotDoc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Plot);
			this.Name = "PlotDoc";
			this.Text = "PlotDoc";
			this.ResumeLayout(false);

		}

		#endregion

		public PlotContainer Plot;
	}
}
