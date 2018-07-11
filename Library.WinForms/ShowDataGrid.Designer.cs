namespace Library.WinForms
{
    partial class ShowDataGrid
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
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.filePicker = new Library.WinForms.FilePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.imageButtonSettings = new Library.WinForms.ImageButton();
            this.imageButtonExport = new Library.WinForms.ImageButton();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.imageButtonSettings);
            this.panelToolbar.Controls.Add(this.imageButtonExport);
            this.panelToolbar.Controls.Add(this.filePicker);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(690, 49);
            this.panelToolbar.TabIndex = 0;
            // 
            // filePicker
            // 
            this.filePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePicker.CheckFileExists = false;
            this.filePicker.ChosenFile = "";
            this.filePicker.DialogTitle = "";
            this.filePicker.InitialDirectory = "";
            this.filePicker.Location = new System.Drawing.Point(6, 12);
            this.filePicker.Name = "filePicker";
            this.filePicker.Prompt = "Export To:";
            this.filePicker.SelectionFilter = "Excel Export File (*.csv)|*.csv|All Files|*.*";
            this.filePicker.SelectionMode = Library.FileSelectMode.Save;
            this.filePicker.Size = new System.Drawing.Size(560, 24);
            this.filePicker.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 49);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(690, 513);
            this.dataGridView.TabIndex = 1;
            // 
            // imageButtonSettings
            // 
            this.imageButtonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonSettings.ButtonImage = global::Library.WinForms.Properties.Resources.setting_tools;
            this.imageButtonSettings.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonSettings.DisabledImage = null;
            this.imageButtonSettings.Location = new System.Drawing.Point(635, 9);
            this.imageButtonSettings.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonSettings.Name = "imageButtonSettings";
            this.imageButtonSettings.Size = new System.Drawing.Size(34, 34);
            this.imageButtonSettings.TabIndex = 4;
            this.imageButtonSettings.TooltipText = "Settings";
            this.imageButtonSettings.Click += new System.EventHandler(this.imageButtonSettings_Click);
            // 
            // imageButtonExport
            // 
            this.imageButtonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonExport.ButtonImage = global::Library.WinForms.Properties.Resources.export_excel;
            this.imageButtonExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonExport.DisabledImage = null;
            this.imageButtonExport.Location = new System.Drawing.Point(589, 9);
            this.imageButtonExport.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonExport.Name = "imageButtonExport";
            this.imageButtonExport.Size = new System.Drawing.Size(34, 34);
            this.imageButtonExport.TabIndex = 3;
            this.imageButtonExport.TooltipText = "Save Excel Export File";
            this.imageButtonExport.Click += new System.EventHandler(this.imageButtonExport_Click);
            // 
            // ShowDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 562);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelToolbar);
            this.Name = "ShowDataGrid";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Display Data";
            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelToolbar;
        private Library.WinForms.FilePicker filePicker;
        private System.Windows.Forms.DataGridView dataGridView;
        private Library.WinForms.ImageButton imageButtonExport;
        private ImageButton imageButtonSettings;

    }
}