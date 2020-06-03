using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PlotServer
{
	public partial class PlotDoc : DockContent
	{
		public PlotDoc()
		{
			InitializeComponent();
			AutoScaleMode = AutoScaleMode.Dpi;
			DockAreas = DockAreas.Document | DockAreas.Float;
		}
	}
}
