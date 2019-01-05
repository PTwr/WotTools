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
                listxml = xmlSerializerHelper.DeserializeFromXml<listxml>(xml);

                BindGrid();
            }

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
                var xml = xmlSerializerHelper.SerializeToXml(listxml, encoding: Encoding.ASCII);
                File.WriteAllText(saveFileDialog1.FileName, xml);
            }
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
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                var cell = row.Cells[colName];

                var c = RGBAstringToColor(cell.Value.ToString());
                ColourizeCell(cell, c);
            }
        }

        private void ColourizeCell(DataGridViewCell cell, Color c)
        {
            cell.Value = $"{c.R} {c.G} {c.B} {c.A}";
            c = Color.FromArgb(255, c.R, c.G, c.B);
            cell.Style.BackColor = c;
            cell.Style.ForeColor = ContrastColor(c);
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
    }
}
