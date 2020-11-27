namespace MiniLauncher
{
    partial class LauncherForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbWotDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLocalVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCurentVersion = new System.Windows.Forms.TextBox();
            this.cbLaunch64bit = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Mini WoT launcher";
            this.notifyIcon1.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WoT directory";
            // 
            // tbWotDirectory
            // 
            this.tbWotDirectory.Location = new System.Drawing.Point(93, 10);
            this.tbWotDirectory.Name = "tbWotDirectory";
            this.tbWotDirectory.Size = new System.Drawing.Size(254, 20);
            this.tbWotDirectory.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Check updates";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Open WG launcher";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Local:";
            // 
            // tbLocalVersion
            // 
            this.tbLocalVersion.Location = new System.Drawing.Point(176, 45);
            this.tbLocalVersion.Name = "tbLocalVersion";
            this.tbLocalVersion.ReadOnly = true;
            this.tbLocalVersion.Size = new System.Drawing.Size(100, 20);
            this.tbLocalVersion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Curent:";
            // 
            // tbCurentVersion
            // 
            this.tbCurentVersion.Location = new System.Drawing.Point(328, 45);
            this.tbCurentVersion.Name = "tbCurentVersion";
            this.tbCurentVersion.ReadOnly = true;
            this.tbCurentVersion.Size = new System.Drawing.Size(100, 20);
            this.tbCurentVersion.TabIndex = 8;
            // 
            // cbLaunch64bit
            // 
            this.cbLaunch64bit.AutoSize = true;
            this.cbLaunch64bit.Location = new System.Drawing.Point(16, 269);
            this.cbLaunch64bit.Name = "cbLaunch64bit";
            this.cbLaunch64bit.Size = new System.Drawing.Size(91, 17);
            this.cbLaunch64bit.TabIndex = 9;
            this.cbLaunch64bit.Text = "Launch 64 bit";
            this.cbLaunch64bit.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(16, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(412, 162);
            this.button4.TabIndex = 10;
            this.button4.Text = "PLAY";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 296);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cbLaunch64bit);
            this.Controls.Add(this.tbCurentVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLocalVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbWotDirectory);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LauncherForm";
            this.Text = "Mini WoT launcher";
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWotDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLocalVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCurentVersion;
        private System.Windows.Forms.CheckBox cbLaunch64bit;
        private System.Windows.Forms.Button button4;
    }
}

