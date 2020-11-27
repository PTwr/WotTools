using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniLauncher
{
    public partial class LauncherForm : Form
    {
        public string WotDirectory { get; set; }

        public LauncherForm()
        {
            InitializeComponent();

            WotDirectory = Properties.Settings.Default.WotDirectory;
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            cbLaunch64bit.Enabled = Environment.Is64BitOperatingSystem;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SetWotDirectory(folderBrowserDialog1.SelectedPath);
            }
        }

        private void SetWotDirectory(string path)
        {
            WotDirectory = path;
            Properties.Settings.Default.WotDirectory = path;
            Properties.Settings.Default.Save();
        }
    }
}
