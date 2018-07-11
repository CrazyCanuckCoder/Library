namespace Library.WinForms
{
    partial class DateRangeSelector<T> where T : struct, System.IConvertible
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelDateRanges = new System.Windows.Forms.TableLayoutPanel();
            this.labelEndDateDesc = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelStartDateDesc = new System.Windows.Forms.Label();
            this.panelStartDate = new System.Windows.Forms.Panel();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.panelEndDate = new System.Windows.Forms.Panel();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.buttonGo = new System.Windows.Forms.Button();
            this.comboBoxDateRange = new System.Windows.Forms.ComboBox();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.tableLayoutPanelDateRanges.SuspendLayout();
            this.panelStartDate.SuspendLayout();
            this.panelEndDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDateRanges
            // 
            this.tableLayoutPanelDateRanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDateRanges.ColumnCount = 4;
            this.tableLayoutPanelDateRanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanelDateRanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelDateRanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanelDateRanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanelDateRanges.Controls.Add(this.labelEndDateDesc, 2, 0);
            this.tableLayoutPanelDateRanges.Controls.Add(this.labelTo, 1, 1);
            this.tableLayoutPanelDateRanges.Controls.Add(this.labelStartDateDesc, 0, 0);
            this.tableLayoutPanelDateRanges.Controls.Add(this.panelStartDate, 0, 1);
            this.tableLayoutPanelDateRanges.Controls.Add(this.panelEndDate, 2, 1);
            this.tableLayoutPanelDateRanges.Controls.Add(this.buttonGo, 3, 1);
            this.tableLayoutPanelDateRanges.Location = new System.Drawing.Point(137, 0);
            this.tableLayoutPanelDateRanges.Name = "tableLayoutPanelDateRanges";
            this.tableLayoutPanelDateRanges.RowCount = 2;
            this.tableLayoutPanelDateRanges.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanelDateRanges.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanelDateRanges.Size = new System.Drawing.Size(512, 41);
            this.tableLayoutPanelDateRanges.TabIndex = 6;
            // 
            // labelEndDateDesc
            // 
            this.labelEndDateDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelEndDateDesc.Location = new System.Drawing.Point(251, 0);
            this.labelEndDateDesc.Name = "labelEndDateDesc";
            this.labelEndDateDesc.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.labelEndDateDesc.Size = new System.Drawing.Size(214, 13);
            this.labelEndDateDesc.TabIndex = 13;
            this.labelEndDateDesc.Text = "End Date:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTo.Location = new System.Drawing.Point(223, 13);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(22, 28);
            this.labelTo.TabIndex = 16;
            this.labelTo.Text = "to";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartDateDesc
            // 
            this.labelStartDateDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStartDateDesc.Location = new System.Drawing.Point(3, 0);
            this.labelStartDateDesc.Name = "labelStartDateDesc";
            this.labelStartDateDesc.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.labelStartDateDesc.Size = new System.Drawing.Size(214, 13);
            this.labelStartDateDesc.TabIndex = 12;
            this.labelStartDateDesc.Text = "Start Date:";
            // 
            // panelStartDate
            // 
            this.panelStartDate.Controls.Add(this.labelStartDate);
            this.panelStartDate.Controls.Add(this.dateTimePickerStartDate);
            this.panelStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStartDate.Location = new System.Drawing.Point(0, 13);
            this.panelStartDate.Margin = new System.Windows.Forms.Padding(0);
            this.panelStartDate.Name = "panelStartDate";
            this.panelStartDate.Size = new System.Drawing.Size(220, 28);
            this.panelStartDate.TabIndex = 17;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate.BackColor = System.Drawing.SystemColors.Window;
            this.labelStartDate.Location = new System.Drawing.Point(5, 7);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(176, 15);
            this.labelStartDate.TabIndex = 1;
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerStartDate.CustomFormat = "";
            this.dateTimePickerStartDate.Enabled = false;
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(3, 5);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(212, 20);
            this.dateTimePickerStartDate.TabIndex = 0;
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
            // 
            // panelEndDate
            // 
            this.panelEndDate.Controls.Add(this.labelEndDate);
            this.panelEndDate.Controls.Add(this.dateTimePickerEndDate);
            this.panelEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEndDate.Location = new System.Drawing.Point(248, 13);
            this.panelEndDate.Margin = new System.Windows.Forms.Padding(0);
            this.panelEndDate.Name = "panelEndDate";
            this.panelEndDate.Size = new System.Drawing.Size(220, 28);
            this.panelEndDate.TabIndex = 18;
            // 
            // labelEndDate
            // 
            this.labelEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndDate.BackColor = System.Drawing.SystemColors.Window;
            this.labelEndDate.Location = new System.Drawing.Point(5, 7);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(174, 15);
            this.labelEndDate.TabIndex = 3;
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEndDate.CustomFormat = "";
            this.dateTimePickerEndDate.Enabled = false;
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(3, 5);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(211, 20);
            this.dateTimePickerEndDate.TabIndex = 2;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(471, 16);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(36, 22);
            this.buttonGo.TabIndex = 19;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // comboBoxDateRange
            // 
            this.comboBoxDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDateRange.FormattingEnabled = true;
            this.comboBoxDateRange.Location = new System.Drawing.Point(4, 18);
            this.comboBoxDateRange.Name = "comboBoxDateRange";
            this.comboBoxDateRange.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDateRange.TabIndex = 8;
            this.comboBoxDateRange.SelectedIndexChanged += new System.EventHandler(this.comboBoxDateRange_SelectedIndexChanged);
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Location = new System.Drawing.Point(2, 2);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(68, 13);
            this.labelDateRange.TabIndex = 7;
            this.labelDateRange.Text = "Date Range:";
            // 
            // DateRangeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelDateRanges);
            this.Controls.Add(this.comboBoxDateRange);
            this.Controls.Add(this.labelDateRange);
            this.Name = "DateRangeSelector";
            this.Size = new System.Drawing.Size(650, 41);
            this.tableLayoutPanelDateRanges.ResumeLayout(false);
            this.tableLayoutPanelDateRanges.PerformLayout();
            this.panelStartDate.ResumeLayout(false);
            this.panelEndDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDateRanges;
        private System.Windows.Forms.Label labelEndDateDesc;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelStartDateDesc;
        private System.Windows.Forms.Panel panelStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Panel panelEndDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ComboBox comboBoxDateRange;
        private System.Windows.Forms.Label labelDateRange;
    }
}
