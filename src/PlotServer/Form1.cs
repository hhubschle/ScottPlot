using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AXBase;
using AXBase.GuiUtils;
using WeifenLuo.WinFormsUI.Docking;

namespace PlotServer
{
    public partial class Form1 : Form
    {
        private PlotServer _server;
        readonly Dictionary<string, int> _nextIndex = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            var file = openFileDialog1.FileName;
            LoadAndDisplayField(file);
        }

        private void LoadAndDisplayField(string file)
        {
            var field = LoadVectorField(file);

            CreateDoc(file, field);
        }

        private void CreateDoc(string file, RectWithVector[] field)
        {
            if (this.ExecuteOnUIThread(CreateDoc, file, field))
                return;

            try
            {
                var doc = CreateDoc(file);
                doc?.Plot?.SetData(field);
            }
            catch (Exception ex)
            {
                Messager.ShowError(this, ex);
            }
        }

        private PlotContainer ActivePlotContainer
        {
            get
            {
                var selDoc = dockPanel1.ActiveDocument as PlotDoc;
                return selDoc?.Plot;
            }
        }

        private RectWithVector[] LoadVectorField(string file)
        {
            RectWithVector[] field = null;
            if (Path.GetExtension(file).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    var interpolator = ArrayInterpolator.ReadFromXmlFile(file);
                    var (arrX, arrY) = interpolator.GetSourceArrays(false);

                    var len = arrX.Length;
                    field = new RectWithVector[len];
                    var index = 0;
                    foreach (var pos in arrX.PositionsInArea())
                    {
                        var dx = arrX.At(pos);
                        var dy = arrY.At(pos);
                        var pt = interpolator.Res.Scale(pos.Col, pos.Row) + interpolator.Offset;

                        var rwv = new RectWithVector(pt.ToPointF(), new PointF(dx, dy), 1);
                        field[index++] = rwv;
                    }
                }
                catch (Exception ex)
                {
                    Messager.ShowError(this, ex);
                }
            }
            else
            {
                try
                {
                    field = VectorField.ReadFile(file, 1);
                }
                catch (Exception ex)
                {
                    Messager.ShowError(this, ex);
                }
            }

            return field;
        }

        private void toolStripButtonPlus_Click(object sender, EventArgs e)
        {
            ActivePlotContainer?.ChangeArrowLength(true);
        }

        private void toolStripButtonMinus_Click(object sender, EventArgs e)
        {
            ActivePlotContainer?.ChangeArrowLength(false);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            var allowedExtensions = new[] {".csv", ".xml", ".txt"};

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (!data.IsNullOrEmpty() &&
                    (data ?? Array.Empty<string>()).All(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower())))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] data = e.Data.GetData(DataFormats.FileDrop) as string[];
            {
                if (data == null)
                    return;

                string filename = data[0];

                try
                {
                    var field = LoadVectorField(filename);
                    var doc = CreateDoc(filename);
                    doc.Plot.SetData(field);
                }
                catch (Exception ex)
                {
                    Messager.ShowFileOpenError(this, filename, ex);
                }
            }
        }

        private PlotDoc CreateDoc(string filename)
        {
            var doc = new PlotDoc();
            var plotContainer = doc.Plot;
            plotContainer.DragEnter += Form1_DragEnter;
            plotContainer.DragDrop += Form1_DragDrop;
            var txt = Path.GetFileName(filename);
            doc.Text = GetUniqueName(txt);
            doc.ToolTipText = filename;
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                doc.MdiParent = this;
                doc.Show();
            }
            else
                doc.Show(dockPanel1);

            return doc;
        }

        private string GetUniqueName(string name)
        {
            var res = name;

            if (_nextIndex.TryGetValue(name, out var nextIndex))
                res = $"{name}({nextIndex})";
            _nextIndex[name] = ++nextIndex;
            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _server = new PlotServer("localhost");
            _server.LoadFile += (o, args) => LoadAndDisplayField(args.FileName);
        }
    }
}
