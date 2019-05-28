using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ModsetPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_ChooseGameDirectory_Click(object sender, EventArgs e)
        {
            dialog_ChooseDirectory.SelectedPath = textBox_GameDirectory.Text;
            if (dialog_ChooseDirectory.ShowDialog() == DialogResult.OK)
            {
                //TODO validate if wot directory
                textBox_GameDirectory.Text = dialog_ChooseDirectory.SelectedPath;
                Properties.Settings.Default["wot_path"] = textBox_GameDirectory.Text;
                Properties.Settings.Default.Save();

                ListModsSets(textBox_GameDirectory.Text);
                GetCurrentDirs(textBox_GameDirectory.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += " v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

            textBox_GameDirectory.Text = Properties.Settings.Default["wot_path"].ToString();

            ListModsSets(textBox_GameDirectory.Text);
            GetCurrentDirs(textBox_GameDirectory.Text);
        }

        private string ModsDirectory = @"mods";
        private string ResModsDirectory = @"res_mods";
        private void ListModsSets(string path)
        {
            listBox_Mods.Items.Clear();
            listBox_ResMods.Items.Clear();

            if (!Directory.Exists(textBox_GameDirectory.Text))
            { return; }

            var modsPath = Path.Combine(path, ModsDirectory);
            var resModsPath = Path.Combine(path, ResModsDirectory);

            var modsModsets = new DirectoryInfo(modsPath).GetDirectories().Select(i => i.FullName).ToList();
            var resModsModsets = new DirectoryInfo(resModsPath).GetDirectories().Select(i => i.FullName).ToList();

            modsModsets.ForEach(i => listBox_Mods.Items.Add(i));
            resModsModsets.ForEach(i => listBox_ResMods.Items.Add(i));
        }

        IXmlSerializerHelper xmlSerializerHelper = new XmlSerializerHelper();
        private string CurrentModsDir = "";
        private string CurrentResModsDir = "";
        private void GetCurrentDirs(string path)
        {
            if (!Directory.Exists(textBox_GameDirectory.Text))
            { return; }

            PathsXmlModel.root pathsModel = GetPathXmlModel(path);

            var dirPaths = pathsModel
                .Paths
                .Items
                .Select(i => i as PathsXmlModel.rootPathsPath)
                .Where(i => i != null)
                .ToList();

            var ModsDir = dirPaths
                .SingleOrDefault(i => i.Value.StartsWith("./mods/"))
                .Value
                .Replace("./mods/", "");
            var ResModsDir = dirPaths
                .SingleOrDefault(i => i.Value.StartsWith("./res_mods/"))
                .Value
                .Replace("./res_mods/", "");

            listBox_Mods.SelectedItem = listBox_Mods
                .Items
                .Cast<string>()
                .FirstOrDefault(i => i.EndsWith("\\" + ModsDir));
            listBox_ResMods.SelectedItem = listBox_ResMods
                .Items
                .Cast<string>()
                .FirstOrDefault(i => i.EndsWith("\\" + ResModsDir));
        }

        private PathsXmlModel.root GetPathXmlModel(string path)
        {
            path = PathsXmlPath(path);

            var pathsModel = xmlSerializerHelper.DeserializeFromXml<PathsXmlModel.root>(File.ReadAllText(path), Encoding.ASCII);
            return pathsModel;
        }

        private static string PathsXmlPath(string path)
        {
            path = Path.Combine(path, "paths.xml");
            return path;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            var modsPath = listBox_Mods.SelectedItem.ToString();
            var resModsPath = listBox_ResMods.SelectedItem.ToString();

            modsPath = modsPath.Split('\\').Last();
            resModsPath = resModsPath.Split('\\').Last();

            var pathsModel = GetPathXmlModel(textBox_GameDirectory.Text);
            var dirPaths = pathsModel
                .Paths
                .Items
                .Select(i => i as PathsXmlModel.rootPathsPath)
                .Where(i => i != null)
                .ToList();


            var ModsDir = dirPaths
                .SingleOrDefault(i => i.Value.StartsWith("./mods/"));
            var ResModsDir = dirPaths
                .SingleOrDefault(i => i.Value.StartsWith("./res_mods/"));

            ModsDir.Value = "./mods/" + modsPath;
            ResModsDir.Value = "./res_mods/" + resModsPath;

            var xmlString = xmlSerializerHelper.SerializeToXml<PathsXmlModel.root>(pathsModel, encoding: Encoding.ASCII);
            xmlString = xmlString
                .Replace("<?xml version=\"1.0\" encoding=\"us-ascii\"?>", "")
                .Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "")
                .Trim();

            var pathXmlPath = PathsXmlPath(textBox_GameDirectory.Text);
            File.Copy(pathXmlPath, Path.Combine(textBox_GameDirectory.Text, "paths.xml.old"), overwrite: true);
            File.WriteAllText(pathXmlPath, xmlString);
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            RunWithArgs();
        }

        private void RunWithArgs(string arguments = "")
        {
            if (!string.IsNullOrWhiteSpace(replayFile))
            {
                if (string.IsNullOrWhiteSpace(arguments))
                {
                    arguments = replayFile;
                }
                else
                {
                    arguments = $"\"{replayFile}\" {arguments}";
                }
            }

            var wotexe = Path.Combine(textBox_GameDirectory.Text, "WorldOfTanks.exe");
            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = textBox_GameDirectory.Text,
                    FileName = wotexe,
                    Arguments = arguments,
                }
            };
            process.Start();
        }

        private void button_RunInSafeMode_Click(object sender, EventArgs e)
        {
            RunWithArgs("-safe");
        }

        private void textBox_GameDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Properties.Settings.Default["wot_path"] = textBox_GameDirectory.Text;
                Properties.Settings.Default.Save();

                ListModsSets(textBox_GameDirectory.Text);
                GetCurrentDirs(textBox_GameDirectory.Text);
            }
        }

        private void replayDropBox_DragEnter(object sender, DragEventArgs e)
        {
        }

        string replayFile = "";
        private void replayDropBox_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void button_ClearReplay_Click(object sender, EventArgs e)
        {
            replayFile = "";
            label_ReplayFile.Text = "no file";
        }

        private void label_ReplayFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var file = files.First();
            replayFile = file;
            label_ReplayFile.Text = replayFile;
        }

        private void label_ReplayFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
