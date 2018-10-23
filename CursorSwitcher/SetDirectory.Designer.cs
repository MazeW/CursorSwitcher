namespace CursorSwitcher
{
    partial class SetDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.osuDirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.osuDirBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxCustom = new System.Windows.Forms.CheckBox();
            this.cursorDir = new System.Windows.Forms.TextBox();
            this.buttonCursorDir = new System.Windows.Forms.Button();
            this.cursorBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // osuDirBox
            // 
            this.osuDirBox.Location = new System.Drawing.Point(26, 54);
            this.osuDirBox.Name = "osuDirBox";
            this.osuDirBox.Size = new System.Drawing.Size(290, 20);
            this.osuDirBox.TabIndex = 1;
            this.osuDirBox.Text = "osu dir here";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select osu! location";
            // 
            // checkBoxCustom
            // 
            this.checkBoxCustom.AutoSize = true;
            this.checkBoxCustom.Location = new System.Drawing.Point(26, 95);
            this.checkBoxCustom.Name = "checkBoxCustom";
            this.checkBoxCustom.Size = new System.Drawing.Size(136, 17);
            this.checkBoxCustom.TabIndex = 4;
            this.checkBoxCustom.Text = "Custom cursor directory";
            this.checkBoxCustom.UseVisualStyleBackColor = true;
            this.checkBoxCustom.CheckedChanged += new System.EventHandler(this.checkBoxCustom_CheckedChanged);
            // 
            // cursorDir
            // 
            this.cursorDir.Location = new System.Drawing.Point(26, 118);
            this.cursorDir.Name = "cursorDir";
            this.cursorDir.Size = new System.Drawing.Size(290, 20);
            this.cursorDir.TabIndex = 5;
            // 
            // buttonCursorDir
            // 
            this.buttonCursorDir.Location = new System.Drawing.Point(323, 118);
            this.buttonCursorDir.Name = "buttonCursorDir";
            this.buttonCursorDir.Size = new System.Drawing.Size(75, 23);
            this.buttonCursorDir.TabIndex = 6;
            this.buttonCursorDir.Text = "Browse";
            this.buttonCursorDir.UseVisualStyleBackColor = true;
            this.buttonCursorDir.Click += new System.EventHandler(this.buttonCursorDir_Click);
            // 
            // cursorBrowser
            // 
            this.cursorBrowser.ShowNewFolderButton = false;
            // 
            // SetDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 191);
            this.Controls.Add(this.buttonCursorDir);
            this.Controls.Add(this.cursorDir);
            this.Controls.Add(this.checkBoxCustom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.osuDirBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDirectory";
            this.Text = "SetDirectory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog osuDirBrowser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox osuDirBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxCustom;
        private System.Windows.Forms.TextBox cursorDir;
        private System.Windows.Forms.Button buttonCursorDir;
        private System.Windows.Forms.FolderBrowserDialog cursorBrowser;
    }
}