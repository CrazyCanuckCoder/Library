namespace Library.WinForms
{
    partial class ShowDataGridSettingsForm
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
            this.checkBoxIncludeHeaders = new System.Windows.Forms.CheckBox();
            this.checkedListBoxColumns = new System.Windows.Forms.CheckedListBox();
            this.groupBoxColumns = new System.Windows.Forms.GroupBox();
            this.radioButtonExportSelected = new System.Windows.Forms.RadioButton();
            this.radioButtonExportAll = new System.Windows.Forms.RadioButton();
            this.imageButtonSave = new Library.WinForms.ImageButton();
            this.groupBoxColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxIncludeHeaders
            // 
            this.checkBoxIncludeHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxIncludeHeaders.AutoSize = true;
            this.checkBoxIncludeHeaders.Checked = true;
            this.checkBoxIncludeHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeHeaders.Location = new System.Drawing.Point(24, 284);
            this.checkBoxIncludeHeaders.Name = "checkBoxIncludeHeaders";
            this.checkBoxIncludeHeaders.Size = new System.Drawing.Size(242, 17);
            this.checkBoxIncludeHeaders.TabIndex = 3;
            this.checkBoxIncludeHeaders.Text = "Include column names in first row of export file";
            this.checkBoxIncludeHeaders.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxColumns
            // 
            this.checkedListBoxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxColumns.Enabled = false;
            this.checkedListBoxColumns.FormattingEnabled = true;
            this.checkedListBoxColumns.Location = new System.Drawing.Point(18, 79);
            this.checkedListBoxColumns.Name = "checkedListBoxColumns";
            this.checkedListBoxColumns.Size = new System.Drawing.Size(200, 139);
            this.checkedListBoxColumns.TabIndex = 4;
            // 
            // groupBoxColumns
            // 
            this.groupBoxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxColumns.Controls.Add(this.radioButtonExportSelected);
            this.groupBoxColumns.Controls.Add(this.checkedListBoxColumns);
            this.groupBoxColumns.Controls.Add(this.radioButtonExportAll);
            this.groupBoxColumns.Location = new System.Drawing.Point(24, 21);
            this.groupBoxColumns.Name = "groupBoxColumns";
            this.groupBoxColumns.Size = new System.Drawing.Size(236, 240);
            this.groupBoxColumns.TabIndex = 5;
            this.groupBoxColumns.TabStop = false;
            this.groupBoxColumns.Text = "  Columns  ";
            // 
            // radioButtonExportSelected
            // 
            this.radioButtonExportSelected.AutoSize = true;
            this.radioButtonExportSelected.Location = new System.Drawing.Point(22, 56);
            this.radioButtonExportSelected.Name = "radioButtonExportSelected";
            this.radioButtonExportSelected.Size = new System.Drawing.Size(143, 17);
            this.radioButtonExportSelected.TabIndex = 1;
            this.radioButtonExportSelected.Text = "Export Selected Columns";
            this.radioButtonExportSelected.UseVisualStyleBackColor = true;
            this.radioButtonExportSelected.CheckedChanged += new System.EventHandler(this.radioButtonExportSelected_CheckedChanged);
            // 
            // radioButtonExportAll
            // 
            this.radioButtonExportAll.AutoSize = true;
            this.radioButtonExportAll.Checked = true;
            this.radioButtonExportAll.Location = new System.Drawing.Point(22, 32);
            this.radioButtonExportAll.Name = "radioButtonExportAll";
            this.radioButtonExportAll.Size = new System.Drawing.Size(112, 17);
            this.radioButtonExportAll.TabIndex = 0;
            this.radioButtonExportAll.TabStop = true;
            this.radioButtonExportAll.Text = "Export All Columns";
            this.radioButtonExportAll.UseVisualStyleBackColor = true;
            this.radioButtonExportAll.CheckedChanged += new System.EventHandler(this.radioButtonExportAll_CheckedChanged);
            // 
            // imageButtonSave
            // 
            this.imageButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonSave.ButtonImage = global::Library.WinForms.Properties.Resources.document_save;
            this.imageButtonSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonSave.DisabledImage = null;
            this.imageButtonSave.Location = new System.Drawing.Point(226, 321);
            this.imageButtonSave.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonSave.Name = "imageButtonSave";
            this.imageButtonSave.Size = new System.Drawing.Size(34, 34);
            this.imageButtonSave.TabIndex = 6;
            this.imageButtonSave.TooltipText = "Save";
            this.imageButtonSave.Click += new System.EventHandler(this.imageButtonSave_Click);
            // 
            // ShowDataGridSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 379);
            this.Controls.Add(this.imageButtonSave);
            this.Controls.Add(this.groupBoxColumns);
            this.Controls.Add(this.checkBoxIncludeHeaders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 417);
            this.Name = "ShowDataGridSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBoxColumns.ResumeLayout(false);
            this.groupBoxColumns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxIncludeHeaders;
        private System.Windows.Forms.CheckedListBox checkedListBoxColumns;
        private System.Windows.Forms.GroupBox groupBoxColumns;
        private System.Windows.Forms.RadioButton radioButtonExportSelected;
        private System.Windows.Forms.RadioButton radioButtonExportAll;
        private ImageButton imageButtonSave;
    }
}