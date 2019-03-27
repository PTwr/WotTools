namespace ColourListEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.moddingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFromWoTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyColorsFromOldXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createwotmodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historicalDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glossDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metallicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleFilterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listxmlItemGroupPaintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listxmlItemGroupPaintBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moddingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "list.xml";
            this.openFileDialog1.Filter = "Xml|*.xml";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.FileName = "list.xml";
            this.saveFileDialog1.Filter = "Xml|*.xml";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paintGroupDataGridViewTextBoxColumn,
            this.historicalDataGridViewCheckBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.textureDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.glossDataGridViewTextBoxColumn,
            this.metallicDataGridViewTextBoxColumn,
            this.userStringDataGridViewTextBoxColumn,
            this.vehicleFilterDataGridViewTextBoxColumn,
            this.tagsDataGridViewTextBoxColumn,
            this.seasonDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listxmlItemGroupPaintBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(1159, 709);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "c:\\games\\world_of_tanks";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // moddingToolStripMenuItem
            // 
            this.moddingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractFromWoTToolStripMenuItem,
            this.applyColorsFromOldXmlToolStripMenuItem,
            this.createwotmodToolStripMenuItem});
            this.moddingToolStripMenuItem.Name = "moddingToolStripMenuItem";
            this.moddingToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.moddingToolStripMenuItem.Text = "Modding";
            // 
            // extractFromWoTToolStripMenuItem
            // 
            this.extractFromWoTToolStripMenuItem.Name = "extractFromWoTToolStripMenuItem";
            this.extractFromWoTToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.extractFromWoTToolStripMenuItem.Text = "Extract from WoT";
            this.extractFromWoTToolStripMenuItem.Click += new System.EventHandler(this.extractFromWoTToolStripMenuItem_Click);
            // 
            // applyColorsFromOldXmlToolStripMenuItem
            // 
            this.applyColorsFromOldXmlToolStripMenuItem.Name = "applyColorsFromOldXmlToolStripMenuItem";
            this.applyColorsFromOldXmlToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.applyColorsFromOldXmlToolStripMenuItem.Text = "Apply colors from old xml";
            this.applyColorsFromOldXmlToolStripMenuItem.Click += new System.EventHandler(this.applyColorsFromOldXmlToolStripMenuItem_Click);
            // 
            // createwotmodToolStripMenuItem
            // 
            this.createwotmodToolStripMenuItem.Name = "createwotmodToolStripMenuItem";
            this.createwotmodToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.createwotmodToolStripMenuItem.Text = "Create .wotmod";
            // 
            // paintGroupDataGridViewTextBoxColumn
            // 
            this.paintGroupDataGridViewTextBoxColumn.DataPropertyName = "PaintGroup";
            this.paintGroupDataGridViewTextBoxColumn.HeaderText = "PaintGroup";
            this.paintGroupDataGridViewTextBoxColumn.Name = "paintGroupDataGridViewTextBoxColumn";
            this.paintGroupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // historicalDataGridViewCheckBoxColumn
            // 
            this.historicalDataGridViewCheckBoxColumn.DataPropertyName = "Historical";
            this.historicalDataGridViewCheckBoxColumn.HeaderText = "Historical";
            this.historicalDataGridViewCheckBoxColumn.Name = "historicalDataGridViewCheckBoxColumn";
            this.historicalDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // textureDataGridViewTextBoxColumn
            // 
            this.textureDataGridViewTextBoxColumn.DataPropertyName = "texture";
            this.textureDataGridViewTextBoxColumn.HeaderText = "texture";
            this.textureDataGridViewTextBoxColumn.Name = "textureDataGridViewTextBoxColumn";
            this.textureDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            // 
            // glossDataGridViewTextBoxColumn
            // 
            this.glossDataGridViewTextBoxColumn.DataPropertyName = "gloss";
            this.glossDataGridViewTextBoxColumn.HeaderText = "gloss";
            this.glossDataGridViewTextBoxColumn.Name = "glossDataGridViewTextBoxColumn";
            // 
            // metallicDataGridViewTextBoxColumn
            // 
            this.metallicDataGridViewTextBoxColumn.DataPropertyName = "metallic";
            this.metallicDataGridViewTextBoxColumn.HeaderText = "metallic";
            this.metallicDataGridViewTextBoxColumn.Name = "metallicDataGridViewTextBoxColumn";
            // 
            // userStringDataGridViewTextBoxColumn
            // 
            this.userStringDataGridViewTextBoxColumn.DataPropertyName = "userString";
            this.userStringDataGridViewTextBoxColumn.HeaderText = "userString";
            this.userStringDataGridViewTextBoxColumn.Name = "userStringDataGridViewTextBoxColumn";
            this.userStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicleFilterDataGridViewTextBoxColumn
            // 
            this.vehicleFilterDataGridViewTextBoxColumn.DataPropertyName = "vehicleFilter";
            this.vehicleFilterDataGridViewTextBoxColumn.HeaderText = "vehicleFilter";
            this.vehicleFilterDataGridViewTextBoxColumn.Name = "vehicleFilterDataGridViewTextBoxColumn";
            this.vehicleFilterDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tagsDataGridViewTextBoxColumn
            // 
            this.tagsDataGridViewTextBoxColumn.DataPropertyName = "tags";
            this.tagsDataGridViewTextBoxColumn.HeaderText = "tags";
            this.tagsDataGridViewTextBoxColumn.Name = "tagsDataGridViewTextBoxColumn";
            this.tagsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seasonDataGridViewTextBoxColumn
            // 
            this.seasonDataGridViewTextBoxColumn.DataPropertyName = "season";
            this.seasonDataGridViewTextBoxColumn.HeaderText = "season";
            this.seasonDataGridViewTextBoxColumn.Name = "seasonDataGridViewTextBoxColumn";
            this.seasonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listxmlItemGroupPaintBindingSource
            // 
            this.listxmlItemGroupPaintBindingSource.DataSource = typeof(ColourListEditor.listxmlItemGroupPaint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 733);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Colour list editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listxmlItemGroupPaintBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource listxmlItemGroupPaintBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn paintGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn historicalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn glossDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn metallicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleFilterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem moddingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractFromWoTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyColorsFromOldXmlToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem createwotmodToolStripMenuItem;
    }
}

