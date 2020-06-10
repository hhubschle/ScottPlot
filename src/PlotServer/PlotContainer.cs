using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AXBase;
using ScottPlot;

namespace PlotServer
{
	public partial class PlotContainer : UserControl
	{
		PlottableText _highlightedText = null;
		private RectWithVector[] toPlot;
		private float plotScale = 100;
		private int unitScale = 1000;
		private int maxCount = 7500;
		private IReadOnlyList<RectWithVector> field1;
		private Plot Plt => formsPlot?.plt;

		public PlotContainer()
		{
			InitializeComponent();
			Plt.AxisAuto();
			Plt.Style(Style.Seaborn);
		}

		public void SetData(IReadOnlyList<RectWithVector> field)
		{
			Plt.Clear();
			_highlightedText = null;
			field1 = field;
			PlotVectorField(field);
		}


		private void PlotVectorField(IReadOnlyList<RectWithVector> field)
		{
			if (field == null)
				return;

			if (field.Count > maxCount)
			{
				toPlot = GetSubSet(field, maxCount).ToArray();
			}
			else
			{
				if (field is RectWithVector[] tt)
					toPlot = tt;
				else
					toPlot = field.ToArray();
			}

			Render();
		}

		private void Render()
		{
			if (toPlot.IsNullOrEmpty())
				return;

			var xs = new double[toPlot.Length];
			var ys = new double[toPlot.Length];
			formsPlot.cursor = Cursors.Cross;

			Plt.Clear();
			_highlightedText = null;
			for (var index = 0; index < toPlot.Length; index++)
			{
				var vector = toPlot[index];
				var d = vector.Distortion;
				Plt.PlotQuiver(
					vector.CenterOfGravity.X,
					vector.CenterOfGravity.Y,
					vector.CenterOfGravity.X + plotScale * d.X,
					vector.CenterOfGravity.Y + plotScale * d.Y,
					color: Color.DodgerBlue);
				xs[index] = vector.CenterOfGravity.X;
				ys[index] = vector.CenterOfGravity.Y;
			}

			Plt.PlotScatter(xs, ys, lineWidth: 0, markerShape: MarkerShape.none);
			// highlightedText = Plt.PlotText("", 0, 0, fontSize: 15, color: Color.Black,
			// 	frameColor: Color.AliceBlue, frame: true);
			// highlightedText.visible = false;
			formsPlot.Render();
		}

		private static IEnumerable<T> GetSubSet<T>(IReadOnlyList<T> l, int maxCount)
		{
			var cnt = l.Count;

			if (cnt <= maxCount)
			{
				foreach (var item in l)
					yield return item;
			}
			else
			{
				var ratio = (double) maxCount / cnt;
				var rnd = new Random();
				int resCount = 0;
				for (int i = 0; i < cnt; i++)
				{
					if (rnd.NextDouble() <= ratio)
					{
						yield return l[i];
						if (++resCount >= maxCount)
							break;
					}
				}
			}
		}

		public void ChangeArrowLength(bool longer)
		{
			if (longer)
				plotScale *= 1.75f;
			else
				plotScale /= 1.75f;
			Render();
		}

		private void formsPlot_MouseMoved(object sender, MouseEventArgs e)
		{
			// don't attempt to change things while we are click-dragging
			if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
				return;
			if (toPlot == null)
				return;

			// determine where the mouse is in coordinate space
			(double mouseX, double mouseY) = formsPlot.GetMouseCoordinates();

			// determine which point is closest to the mouse
			int closestIndex = 0;
			double closestDistance = double.PositiveInfinity;
			for (int i = 0; i < toPlot.Length; i++)
			{
				var pt = toPlot[i].CenterOfGravity;
				var dx = pt.X - mouseX;
				var dy = pt.Y - mouseY;
				double distance = dx * dx + dy * dy;
				if (distance < closestDistance)
				{
					closestIndex = i;
					closestDistance = distance;
				}
			}

			var closest = toPlot[closestIndex];
			var closestItem = closest.CenterOfGravity;
			var closestItemPixel = Plt.CoordinateToPixel(closestItem);
			if (closestItemPixel.Dist(e.Location) < 8)
			{
				double x = closestItem.X;
				double y = closestItem.Y;

				var r = closest.Distortion.R() * unitScale;
				var txt1 = $"{Math.Round(x, 3)}, {Math.Round(y, 3)}\n{(int) Math.Round(r)}";
				
				_highlightedText = _highlightedText ?? Plt.PlotText("", 0, 0, fontSize: 15, color: Color.Black,
				 	frameColor: Color.AliceBlue, frame: true);
				_highlightedText.visible = true;
				_highlightedText.text = txt1;
				var pt = Plt.CoordinateToPixel(new PointF((float) x, (float) y));
				pt += new SizeF(8, -8);
				_highlightedText.x = Plt.CoordinateFromPixelX(pt.X);
				_highlightedText.y = Plt.CoordinateFromPixelY(pt.Y);
			}
			else
			{
				if (_highlightedText != null)
					_highlightedText.visible = false;
			}

			formsPlot.Render();

		}
	}
}
