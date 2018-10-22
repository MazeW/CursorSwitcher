using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CursorSwitcher
{
    public partial class setDir : Form
    {
        public setDir()
        {
            InitializeComponent();
            this.Text = "Please select your osu! directory.";
            if(File.Exists(Properties.Settings.Default.osuLocation + @"\osu!.exe"))
            {
                osuDirBox.Text = Properties.Settings.Default.osuLocation;
            }
            else
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\osu!\osu!.exe"))
                {
                    Properties.Settings.Default.osuLocation = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\osu!";
                    osuDirBox.Text = Properties.Settings.Default.osuLocation;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    osuDirBox.Text = $"Please select osu folder.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = osuDirBrowser.ShowDialog();
            if(res == DialogResult.OK)
            {
                String osuPath = osuDirBrowser.SelectedPath;
                Debug.WriteLine(string.Format("You have selected {0}", osuPath));
                if(File.Exists(osuPath + "\\osu!.exe"))
                {
                    Properties.Settings.Default.osuLocation = osuPath;
                    osuDirBox.Text = osuPath;
                }
                else
                {
                    MessageBox.Show("Couldn't find osu installation in selected folder! :(");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Debug.WriteLine($"Saving dir test: ${Properties.Settings.Default.osuLocation}");
            this.Close();
            Form1 reload = new Form1();
            reload.Skins();
            
        }
    }
}
