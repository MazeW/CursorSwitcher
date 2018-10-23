using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CursorSwitcher
{
    public partial class OsuCursorSwitcher : Form
    {
        private string SelectedSkin { get; set; }
        private string SelectedSkinName { get; set; }
        private string SelectedCursor { get; set; }
        private Dictionary<string, string> SkinsFolder { get; set; }
        private bool IsCustomCursorFolder { get => Properties.Settings.Default.boxChecked && Path.IsPathRooted(Properties.Settings.Default.cursorLocation); }
        private Dictionary<int, string> listIndexToPath = new Dictionary<int, string>();

        public OsuCursorSwitcher()
        {
            InitializeComponent();
            Text = "osu! cursor switcher";
            Skins();
        }

        public void Skins()
        {
            if (!Directory.Exists(Properties.Settings.Default.osuLocation))
            {
                SetDirectory directoryForm = new SetDirectory();
                directoryForm.ShowDialog();
            }

            var skinDirectories = Directory.GetDirectories(Path.Combine(Properties.Settings.Default.osuLocation, "skins"));

            SkinsFolder = new Dictionary<string, string>();

            if (!skinDirectories.Any())
                SkinsFolder.Add("0", "No skins found!");

            foreach (var x in skinDirectories)
            {
                var iniPath = Path.Combine(x, "skin.ini");

                if (!File.Exists(iniPath))
                    continue;

                string[] lines;

                try { lines = File.ReadAllLines(iniPath); }
                catch (Exception) { continue; }

                var nameLine = lines.FirstOrDefault(y => y.StartsWith("Name:"));

                if (nameLine == null)
                    continue;

                SkinsFolder.Add(x, nameLine.Split(':')[1].Trim());
            }

            comboBox1.DataSource = new BindingSource(SkinsFolder, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            PopulateCursors();
        }

        public void PopulateCursors()
        {
            ImageList imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(90, 90)
            };

            listIndexToPath.Clear();

            var items = IsCustomCursorFolder ? Directory.GetFiles(Properties.Settings.Default.cursorLocation).Where(x => x.EndsWith(".png")).ToArray() 
                : SkinsFolder.Select(x => x.Key).ToArray();

            if (!items.Any())
            {
                listView1.Items.Add("No cursors found!", 0);
                return;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (IsCustomCursorFolder)
                {
                    imageList.Images.Add(Image.FromFile(items[i]));
                }
                else
                {
                    var cursorPath = items[i] + @"\cursor.png";
                    imageList.Images.Add(File.Exists(cursorPath) ? Image.FromFile(cursorPath) :  Properties.Resources.nope);
                }

                listView1.Items.Add(IsCustomCursorFolder ? Path.GetFileName(items[i]) : SkinsFolder[items[i]], i);
                listIndexToPath.Add(i, items[i]);
            }

            listView1.SmallImageList = imageList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("Cursors", 150);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
            SelectedSkin = key;
            SelectedSkinName = value;
            Debug.WriteLine($"[skin selection value:{value}] [key:{key}]");
        }

        private void ButtonTrail_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
                return;

            int selectedIndex = listView1.SelectedIndices[0];

            if (selectedIndex >= 0)
                SelectedCursor = listIndexToPath[selectedIndex];
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"You have selected skin: {SelectedSkin} and cursor {SelectedCursor}");

            if (String.IsNullOrEmpty(SelectedCursor))
            {
                MessageBox.Show("Select a cursor!", "lol", MessageBoxButtons.OK);
                return;
            }

            DialogResult result = MessageBox.Show($"This will change {SelectedSkinName}'s cursor to {SelectedCursor}! Are you sure?\n(Your current cursor will be saved as cursor_backup.png)", "Are you really sure?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    File.Copy($"{SelectedSkin}\\cursor.png", $"{SelectedSkin}\\cursor_backup.png", true);

                    if (IsCustomCursorFolder)
                        File.Copy(SelectedCursor, SelectedSkin + "\\cursor.png", true);
                    else
                        File.Copy(SelectedCursor + "\\cursor.png", SelectedSkin + "\\cursor.png", true);

                    MessageBox.Show("Press CTRL + SHIT + ALT + S in-game to see changes!", "Cursor changed!", MessageBoxButtons.OK);
                }
                catch (Exception err)
                {
                    MessageBox.Show($"OOF! {err.Message}");
                }
            }
        }

        private void SetOsuDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDirectory form = new SetDirectory();
            form.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            aboutForm form = new aboutForm();
            form.ShowDialog();
        }
    }
}
