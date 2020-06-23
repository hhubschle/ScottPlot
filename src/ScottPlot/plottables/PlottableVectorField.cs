using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using ScottPlot.Config;
using ScottPlot.Drawing;
using ScottPlot.Statistics;

namespace ScottPlot
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class PlottableVectorField : Plottable
    {
        public Vector2[,] vectors;
        public double[] xs;
        public double[] ys;
        public string label;
        public Color color;
        private Colormap colormap;

        private Pen pen;
        private Color[] arrowColors;
        private double scaleFactor;

        public double ArrowheadLength { get; set; } = 0.5;
        public double ArrowheadWidth { get; set; } = 0.15;
        public bool Centered { get; set; } = true;
        public bool FancyTip { get; set; }


        public PlottableVectorField(Vector2[,] vectors, double[] xs, double[] ys, string label, Color color, Colormap colormap, double scaleFactor)
        {
            //the magnitude squared is faster to compute than the magnitude
            double minMagnitudeSquared = vectors[0, 0].Length();
            double maxMagnitudeSquared = vectors[0, 0].Length();
            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    if (vectors[i, j].LengthSquared() > maxMagnitudeSquared)
                    {
                        maxMagnitudeSquared = vectors[i, j].LengthSquared();
                    }
                    else if (vectors[i, j].LengthSquared() < minMagnitudeSquared)
                    {
                        minMagnitudeSquared = vectors[i, j].LengthSquared();
                    }
                }
            }
            double minMagnitude = Math.Sqrt(minMagnitudeSquared);
            double maxMagnitude = Math.Sqrt(maxMagnitudeSquared);
            double[,] intensities = new double[xs.Length, ys.Length];

            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    if (colormap != null)
                    {
                        intensities[i, j] = (vectors[i, j].Length() - minMagnitude) / (maxMagnitude - minMagnitude);
                    }
                    vectors[i, j] = Vector2.Multiply(vectors[i, j], (float)(scaleFactor / (maxMagnitude * 1.2))); //This is not a true normalize
                }
            }

            if (colormap != null)
            {
                double[] flattenedIntensities = intensities.Cast<double>().ToArray();
                arrowColors = Colormap.GetColors(flattenedIntensities, colormap);
            }

            this.vectors = vectors;
            this.xs = xs;
            this.ys = ys;
            this.label = label;
            this.color = color;
            this.colormap = colormap;
            this.scaleFactor = scaleFactor;

            pen = new Pen(color);
            pen.CustomEndCap = new AdjustableArrowCap(2, 2);
        }

        public override LegendItem[] GetLegendItems()
        {
            return new LegendItem[] { new LegendItem(label, color, lineWidth: 10, markerShape: MarkerShape.none) };
        }

        public override AxisLimits2D GetLimits()
        {
            return new AxisLimits2D(xs.Min() - 1, xs.Max() + 1, ys.Min() - 1, ys.Max() + 1);
        }

        public override int GetPointCount()
        {
            return vectors.Length;
        }

        public override void Render(Settings settings)
        {
            if (FancyTip)
                pen.EndCap = LineCap.Flat;
            else
                pen.CustomEndCap = new AdjustableArrowCap(2, 2);

            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    if (this.colormap != null)
                    {
                        pen.Color = arrowColors[i * ys.Length + j];
                    }
                    if (FancyTip)
                        PlotVectorFancy(vectors[i, j], xs[i], ys[j], settings);
                    else
                        PlotVector(vectors[i, j], xs[i], ys[j], settings);
                }
            }
        }

        private void PlotVector(Vector2 v, double tailX, double tailY, Settings settings)
        {
            PointF tail, end;
            if (Centered)
            {
                tail = settings.GetPixel(tailX - v.X / 2, tailY - v.Y / 2);
                end = settings.GetPixel(tailX + v.X / 2, tailY + v.Y / 2);
            }
            else
            {
                tail = settings.GetPixel(tailX, tailY);
                end = settings.GetPixel(tailX + v.X, tailY + v.Y);
            }

            settings.gfxData.DrawLine(pen, tail, end);
        }
        private void PlotVectorFancy(Vector2 v, double tailX, double tailY, Settings settings)
        {
            double baseX = tailX - (Centered ? 0 : v.X / 2);
            double baseY = tailY - (Centered ? 0 : v.Y / 2);
            double tipX = tailX + (Centered ? v.X / 2 : v.X);
            double tipY = tailY + (Centered ? v.Y / 2 : v.Y);

            var dx = tipX - baseX;
            var dy = tipY - baseY;
            var arrowAngle = Math.Atan2(dy, dx);
            var headAngle = Math.Atan2(ArrowheadWidth, ArrowheadLength);
            var sinA1 = Math.Sin(headAngle - arrowAngle);
            var cosA1 = Math.Cos(headAngle - arrowAngle);
            var sinA2 = Math.Sin(headAngle + arrowAngle);
            var cosA2 = Math.Cos(headAngle + arrowAngle);
            var len = Math.Sqrt(dx * dx + dy * dy);
            var hypLen = len * Math.Sqrt(ArrowheadLength * ArrowheadLength + ArrowheadWidth * ArrowheadWidth);

            var corner1X = tipX - hypLen * cosA1;
            var corner1Y = tipY + hypLen * sinA1;
            var corner2X = tipX - hypLen * cosA2;
            var corner2Y = tipY - hypLen * sinA2;

            var pts = new PointF[]
            {
                settings.GetPixel(baseX, baseY),
                settings.GetPixel(tipX, tipY),
                settings.GetPixel(corner1X, corner1Y),
                settings.GetPixel(tipX, tipY),
                settings.GetPixel(corner2X, corner2Y),
            };

            settings.gfxData.DrawLines(pen, pts);
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.label) ? "" : $" ({this.label})";
            return $"PlottableVectorField{label} with {GetPointCount()} vectors";
        }
    }
}
