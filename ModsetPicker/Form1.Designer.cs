﻿namespace ModsetPicker
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ChooseGameDirectory = new System.Windows.Forms.Button();
            this.textBox_GameDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dialog_ChooseDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_RunInSafeMode = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.listBox_ResMods = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_Mods = new System.Windows.Forms.ListBox();
            this.replayDropBox = new System.Windows.Forms.GroupBox();
            this.button_ClearReplay = new System.Windows.Forms.Button();
            this.label_ReplayFile = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.replayDropBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_ChooseGameDirectory);
            this.panel1.Controls.Add(this.textBox_GameDirectory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 36);
            this.panel1.TabIndex = 0;
            // 
            // button_ChooseGameDirectory
            // 
            this.button_ChooseGameDirectory.Location = new System.Drawing.Point(583, 7);
            this.button_ChooseGameDirectory.Name = "button_ChooseGameDirectory";
            this.button_ChooseGameDirectory.Size = new System.Drawing.Size(130, 23);
            this.button_ChooseGameDirectory.TabIndex = 2;
            this.button_ChooseGameDirectory.Text = "Choose game directory";
            this.button_ChooseGameDirectory.UseVisualStyleBackColor = true;
            this.button_ChooseGameDirectory.Click += new System.EventHandler(this.button_ChooseGameDirectory_Click);
            // 
            // textBox_GameDirectory
            // 
            this.textBox_GameDirectory.Location = new System.Drawing.Point(91, 10);
            this.textBox_GameDirectory.Name = "textBox_GameDirectory";
            this.textBox_GameDirectory.Size = new System.Drawing.Size(486, 20);
            this.textBox_GameDirectory.TabIndex = 1;
            this.textBox_GameDirectory.Text = "c:\\games\\World_of_Tanks";
            this.textBox_GameDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_GameDirectory_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game directory:";
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.Controls.Add(this.button_ClearReplay);
            this.panel2.Controls.Add(this.replayDropBox);
            this.panel2.Controls.Add(this.button_RunInSafeMode);
            this.panel2.Controls.Add(this.button_Run);
            this.panel2.Controls.Add(this.button_Save);
            this.panel2.Controls.Add(this.listBox_ResMods);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.listBox_Mods);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 414);
            this.panel2.TabIndex = 1;
            // 
            // button_RunInSafeMode
            // 
            this.button_RunInSafeMode.Location = new System.Drawing.Point(713, 53);
            this.button_RunInSafeMode.Name = "button_RunInSafeMode";
            this.button_RunInSafeMode.Size = new System.Drawing.Size(75, 23);
            this.button_RunInSafeMode.TabIndex = 6;
            this.button_RunInSafeMode.Text = "in safe mode";
            this.button_RunInSafeMode.UseVisualStyleBackColor = true;
            this.button_RunInSafeMode.Click += new System.EventHandler(this.button_RunInSafeMode_Click);
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(632, 53);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 5;
            this.button_Run.Text = "Run game";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(632, 23);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(156, 23);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Modify paths.xml";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // listBox_ResMods
            // 
            this.listBox_ResMods.FormattingEnabled = true;
            this.listBox_ResMods.Location = new System.Drawing.Point(323, 23);
            this.listBox_ResMods.Name = "listBox_ResMods";
            this.listBox_ResMods.Size = new System.Drawing.Size(303, 381);
            this.listBox_ResMods.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "legacy Modsets (./res_mods)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = ".wotmod Modsets (./mods)";
            // 
            // listBox_Mods
            // 
            this.listBox_Mods.FormattingEnabled = true;
            this.listBox_Mods.Location = new System.Drawing.Point(10, 23);
            this.listBox_Mods.Name = "listBox_Mods";
            this.listBox_Mods.Size = new System.Drawing.Size(303, 381);
            this.listBox_Mods.TabIndex = 0;
            // 
            // replayDropBox
            // 
            this.replayDropBox.Controls.Add(this.label_ReplayFile);
            this.replayDropBox.Location = new System.Drawing.Point(633, 83);
            this.replayDropBox.Name = "replayDropBox";
            this.replayDropBox.Size = new System.Drawing.Size(155, 134);
            this.replayDropBox.TabIndex = 7;
            this.replayDropBox.TabStop = false;
            this.replayDropBox.Text = "Drop replay here";
            this.replayDropBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.replayDropBox_DragDrop);
            this.replayDropBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.replayDropBox_DragEnter);
            // 
            // button_ClearReplay
            // 
            this.button_ClearReplay.Location = new System.Drawing.Point(633, 224);
            this.button_ClearReplay.Name = "button_ClearReplay";
            this.button_ClearReplay.Size = new System.Drawing.Size(155, 23);
            this.button_ClearReplay.TabIndex = 8;
            this.button_ClearReplay.Text = "Clear replay";
            this.button_ClearReplay.UseVisualStyleBackColor = true;
            this.button_ClearReplay.Click += new System.EventHandler(this.button_ClearReplay_Click);
            // 
            // label_ReplayFile
            // 
            this.label_ReplayFile.AllowDrop = true;
            this.label_ReplayFile.Location = new System.Drawing.Point(6, 16);
            this.label_ReplayFile.Name = "label_ReplayFile";
            this.label_ReplayFile.Size = new System.Drawing.Size(143, 115);
            this.label_ReplayFile.TabIndex = 0;
            this.label_ReplayFile.Text = "no replay";
            this.label_ReplayFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ReplayFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.label_ReplayFile_DragDrop);
            this.label_ReplayFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.label_ReplayFile_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "WoT Modset Switcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.replayDropBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ChooseGameDirectory;
        private System.Windows.Forms.TextBox textBox_GameDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dialog_ChooseDirectory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox_ResMods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_Mods;
        private System.Windows.Forms.Button button_RunInSafeMode;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox replayDropBox;
        private System.Windows.Forms.Button button_ClearReplay;
        private System.Windows.Forms.Label label_ReplayFile;
    }
}

