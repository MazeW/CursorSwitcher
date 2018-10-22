using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CursorSwitcher
{
    public partial class Form1 : Form
    {

        public Form1()
        {           
            InitializeComponent();
            this.Text = "osu! cursor switcher";
            string[] directories = Directory.GetDirectories(@"C:\Users\Maze\Desktop\skins");
            Dictionary<string, string> boxitem = new Dictionary<string, string>();
            if (directories.Length < 1)
            {
                boxitem.Add("0","No skins found!");
            }
            try
            {
                for (int i = 0; i < directories.Length; i++)
                {
                    boxitem.Add(directories[i], new DirectoryInfo(directories[i]).Name);
                }
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            comboBox1.DataSource = new BindingSource(boxitem, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            Cursors();
        }

        private void Cursors()
        {
            ImageList img = new ImageList();
            img.ImageSize = new Size(89, 89);
            string[] items = Directory.GetFiles(@"C:\Users\Maze\Desktop\cursors");
            if(items.Length < 1)
            {
                listView1.Items.Add("No cursors found!",0);
                return;
            }
            try
            {
                for (int i = 0; i < items.Length; i++)
                {
                    Debug.WriteLine($"there's {new FileInfo(items[i])}");
                    img.Images.Add(Image.FromFile(items[i]));
                    listView1.Items.Add(items[i], i);
                }
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            listView1.SmallImageList = img;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("Cursors", 150);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        string SelectedSkin { get; set; }
        string SelectedSkinName { get; set; }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
            SelectedSkin = key;
            SelectedSkinName = value;
            Debug.WriteLine($"[skin selection value:{value}] [key:{key}]");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string SelectedCursor { get; set; }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                SelectedCursor = listView1.Items[intselectedindex].Text;
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"You have selected skin: {SelectedSkin} and cursor {SelectedCursor}");
            if(string.IsNullOrEmpty(SelectedCursor))
            {
                MessageBox.Show("Select a cursor!","lol",MessageBoxButtons.OK);
                return;
            }
            DialogResult result = MessageBox.Show($"This will change {SelectedSkinName}'s cursor to {SelectedCursor}! Are you sure? \n (your current cursor will be saved as cursor_backup.png)", "Are you really sure?",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    File.Copy($"{SelectedSkin}\\cursor.png", $"{SelectedSkin}\\cursor_backup.png", true);
                    File.Copy(SelectedCursor, SelectedSkin + "\\cursor.png", true);
                    MessageBox.Show("Press CTRL + SHIT + ALT + S in-game to see changes!", "Cursor changed!", MessageBoxButtons.OK);
                } catch (Exception err)
                {
                    MessageBox.Show($"OOF! {err.Message}");
                }
                }
            else if (result == DialogResult.Cancel)
            {
                Debug.WriteLine("didnt copy");
            } 
        }

        private void setOsuDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("yeet nigga");
            setDir ss = new setDir();
            ss.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            aboutForm af = new aboutForm();
            af.ShowDialog();
        }
    }
}
