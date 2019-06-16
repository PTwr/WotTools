using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WotTools.XmlModels;

namespace ColourListEditor
{
    public partial class Form1 : Form
    {
        private listxml listxml = null;

        public static List<listxmlItemGroupPaint> dataSource = new List<listxmlItemGroupPaint>();

        IXmlSerializerHelper xmlSerializerHelper = new XmlSerializerHelper();

        public Form1()
        {
            InitializeComponent();
            //dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //dataGridView1.RowHeadersVisible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var xml = File.ReadAllText(openFileDialog1.FileName);
                LoadXml(xml);
            }

        }

        private void LoadXml(string xml)
        {
            listxml = xmlSerializerHelper.DeserializeFromXml<listxml>(xml);

            BindGrid();
        }

        private void BindGrid()
        {
            //dataGridView1.Rows.Clear();
            dataSource.Clear();
            foreach (var itemgroup in listxml.itemGroup)
            {
                foreach (var paint in itemgroup.paint)
                {
                    paint.PaintGroup = itemgroup.name;
                    paint.Historical = itemgroup.historical;
                    dataSource.Add(paint);
                }
            }

            dataGridView1.DataSource = dataSource;
            ColourizeCells();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string xml = SerializeListToXml();
                File.WriteAllText(saveFileDialog1.FileName, xml);
            }
        }

        private string SerializeListToXml()
        {
            return xmlSerializerHelper.SerializeToXml(listxml, encoding: Encoding.ASCII);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if (columnName == "color")
            {
                var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                colorDialog1.Color = RGBAstringToColor(cell.Value.ToString());
                colorDialog1.FullOpen = true;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    var c = colorDialog1.Color;
                    ColourizeCell(cell, c);
                }
            }
        }

        void ColourizeCells()
        {
            var colName = "colorDataGridViewTextBoxColumn";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cell = row.Cells[colName];

                var c = RGBAstringToColor(cell.Value.ToString());
                ColourizeCell(cell, c);
            }
        }

        private void ColourizeCell(DataGridViewCell cell, Color c)
        {
            cell.Value = ColorToRGBAstring(c);
            c = Color.FromArgb(255, c.R, c.G, c.B);
            cell.Style.BackColor = c;
            cell.Style.ForeColor = ContrastColor(c);
        }

        private static string ColorToRGBAstring(Color c)
        {
            return $"{c.R} {c.G} {c.B} {c.A}";
        }

        //https://stackoverflow.com/a/1855903/3147740
        Color ContrastColor(Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (luminance > 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }

        public Color RGBAstringToColor(string s)
        {
            var parts = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();
            if (parts.Count != 4)
            {
                return Color.White;
            }
            int a, r, g, b;
            if (int.TryParse(parts[0], out r)
                &&
                int.TryParse(parts[1], out g)
                &&
                int.TryParse(parts[2], out b)
                &&
                int.TryParse(parts[3], out a)
                )
            {
                //a = 255;
                return Color.FromArgb(a, r, g, b);
            }
            return Color.White;
        }

        private void applyColorsFromOldXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var xml = File.ReadAllText(openFileDialog1.FileName);
                var oldXml = xmlSerializerHelper.DeserializeFromXml<listxml>(xml);

                foreach (var oldItemGroup in oldXml.itemGroup)
                {
                    var newItemGroup = listxml.itemGroup.FirstOrDefault(i => i.name == oldItemGroup.name);
                    if (newItemGroup != null)
                    {
                        foreach (var oldPaint in oldItemGroup.paint)
                        {
                            var newPaint = newItemGroup.paint.FirstOrDefault(i => i.id == oldPaint.id);
                            if (newPaint != null)
                            {
                                newPaint.color = oldPaint.color;
                            }
                        }
                    }
                }

                BindGrid();
            }
        }

        const string listFilename = @"scripts/item_defs/customization/paints/list.xml";
        private void extractFromWoTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                //TODO refactor to lib
                var scriptsPkgPath = Path.Combine(folderBrowserDialog1.SelectedPath, @"res\packages\scripts.pkg");
                if (File.Exists(scriptsPkgPath))
                {
                    using (var zipFile = System.IO.Compression.ZipFile.Open(scriptsPkgPath, System.IO.Compression.ZipArchiveMode.Read))
                    {
                        var x = zipFile.Entries.FirstOrDefault(i => i.FullName == listFilename);
                        var stream = x.Open();

                        var binaryReader = new BinaryReader(stream);
                        var head = binaryReader.ReadInt32();
                        if (head == Packed_Section.Packed_Header)
                        {
                            string xml = Ptwr.PackedXml.Reader.DecodePackedFile(binaryReader, Path.GetFileName(listFilename));

                            LoadXml(xml);
                        }
                    }
                }
            }
        }

        private void createwotmodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog2.FileName))
                {
                    File.Delete(saveFileDialog2.FileName);
                }

                using (ZipFile z = ZipFile.Create(saveFileDialog2.FileName))
                {
                    z.BeginUpdate();
                    
                    var filename = "res/" + listFilename;

                    var dirs = filename.Split('/').Reverse().Skip(1).Reverse();
                    var path = "";
                    foreach (var dir in dirs)
                    {
                        path = path + dir + "/";

                        z.AddDirectory(path);
                    }

                    var zipEntry = new ZipEntry(filename);
                    var xml = SerializeListToXml();
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                    File.WriteAllText(filename, xml);                   

                    z.Add(filename, CompressionMethod.Stored);
                    //var entry = z.GetEntry("list.xml");
                    //entry.CompressionMethod = CompressionMethod.Stored;
                    //z.GetEntry(filename).CompressionMethod = CompressionMethod.Stored;

                    z.CommitUpdate();
                }
                return;
                {
                    //FileStream fsOut = File.Create(saveFileDialog2.FileName);
                    //ZipOutputStream zipStream = new ZipOutputStream(fsOut);
                    //zipStream.SetLevel(0);

                    //var filename = "res/" + listFilename;

                    //var dirs = filename.Split('/').Reverse().Skip(1).Reverse();
                    //var path = "";
                    //foreach(var dir in dirs)
                    //{
                    //    path = path + dir + "/";
                    //    var dirEntry = new ZipEntry(path);
                    //    zipStream.PutNextEntry(dirEntry);
                    //    zipStream.CloseEntry();
                    //}

                    //FileInfo fi = new FileInfo(filename);
                    //var zipEntry = new ZipEntry(filename);
                    //var xml = SerializeListToXml();
                    //byte[] bytes = Encoding.ASCII.GetBytes(xml);
                    //zipEntry.Size = bytes.Length;

                    //zipStream.PutNextEntry(zipEntry);
                    //zipStream.Write(bytes, 0, bytes.Length);
                    //zipStream.CloseEntry();

                    //zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
                    //zipStream.Close();
                }
                return;
                //using (var zipFile = System.IO.Compression.ZipFile.Open(saveFileDialog2.FileName, ZipArchiveMode.Create))
                //{
                //    var entry = zipFile.CreateEntry("res/" + listFilename, CompressionLevel.NoCompression);
                //    var stream = entry.Open();
                //    using (var tw = new StreamWriter(stream))
                //    {
                //        var xml = SerializeListToXml();
                //        tw.Write(xml);
                //    }
                //}
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void setAllToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var itemGroup in listxml.itemGroup)
                {
                    foreach (var paint in itemGroup.paint)
                    {
                        paint.color = ColorToRGBAstring(colorDialog1.Color);
                    }
                }

                BindGrid();
            }
        }
    }
}
