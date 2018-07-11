namespace Library.WinForms
{
    partial class StringListMaker
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
            this.splitContainerListMaker = new System.Windows.Forms.SplitContainer();
            this.listBoxEntries = new System.Windows.Forms.ListBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxEntries = new System.Windows.Forms.TextBox();
            this.imageButtonAddEntry = new Library.WinForms.ImageButton();
            this.imageButtonDeleteEntry = new Library.WinForms.ImageButton();
            this.splitContainerListMaker.Panel1.SuspendLayout();
            this.splitContainerListMaker.Panel2.SuspendLayout();
            this.splitContainerListMaker.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerListMaker
            // 
            this.splitContainerListMaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListMaker.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListMaker.IsSplitterFixed = true;
            this.splitContainerListMaker.Location = new System.Drawing.Point(0, 0);
            this.splitContainerListMaker.Name = "splitContainerListMaker";
            this.splitContainerListMaker.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerListMaker.Panel1
            // 
            this.splitContainerListMaker.Panel1.Controls.Add(this.listBoxEntries);
            this.splitContainerListMaker.Panel1.Controls.Add(this.labelDescription);
            // 
            // splitContainerListMaker.Panel2
            // 
            this.splitContainerListMaker.Panel2.Controls.Add(this.imageButtonAddEntry);
            this.splitContainerListMaker.Panel2.Controls.Add(this.imageButtonDeleteEntry);
            this.splitContainerListMaker.Panel2.Controls.Add(this.textBoxEntries);
            this.splitContainerListMaker.Size = new System.Drawing.Size(210, 150);
            this.splitContainerListMaker.SplitterDistance = 109;
            this.splitContainerListMaker.SplitterWidth = 2;
            this.splitContainerListMaker.TabIndex = 0;
            // 
            // listBoxEntries
            // 
            this.listBoxEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEntries.FormattingEnabled = true;
            this.listBoxEntries.IntegralHeight = false;
            this.listBoxEntries.Location = new System.Drawing.Point(0, 23);
            this.listBoxEntries.Name = "listBoxEntries";
            this.listBoxEntries.Size = new System.Drawing.Size(210, 86);
            this.listBoxEntries.TabIndex = 1;
            this.listBoxEntries.SelectedIndexChanged += new System.EventHandler(this.listBoxEntries_SelectedIndexChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDescription.Location = new System.Drawing.Point(0, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(210, 23);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Add description here...";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEntries
            // 
            this.textBoxEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEntries.Location = new System.Drawing.Point(1, 9);
            this.textBoxEntries.Name = "textBoxEntries";
            this.textBoxEntries.Size = new System.Drawing.Size(133, 20);
            this.textBoxEntries.TabIndex = 0;
            this.textBoxEntries.TextChanged += new System.EventHandler(this.textBoxEntries_TextChanged);
            this.textBoxEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEntries_KeyDown);
            // 
            // imageButtonAddEntry
            // 
            this.imageButtonAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonAddEntry.ButtonImage = global::Library.WinForms.Properties.Resources.add;
            this.imageButtonAddEntry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonAddEntry.DisabledImage = global::Library.WinForms.Properties.Resources.add_disabled;
            this.imageButtonAddEntry.Enabled = false;
            this.imageButtonAddEntry.Location = new System.Drawing.Point(139, 4);
            this.imageButtonAddEntry.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonAddEntry.Name = "imageButtonAddEntry";
            this.imageButtonAddEntry.Size = new System.Drawing.Size(34, 34);
            this.imageButtonAddEntry.TabIndex = 2;
            this.imageButtonAddEntry.TooltipText = "Add Entry";
            this.imageButtonAddEntry.Click += new System.EventHandler(this.imageButtonAddEntry_Click);
            // 
            // imageButtonDeleteEntry
            // 
            this.imageButtonDeleteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonDeleteEntry.ButtonImage = global::Library.WinForms.Properties.Resources.delete;
            this.imageButtonDeleteEntry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonDeleteEntry.DisabledImage = global::Library.WinForms.Properties.Resources.delete_disabled;
            this.imageButtonDeleteEntry.Enabled = false;
            this.imageButtonDeleteEntry.Location = new System.Drawing.Point(175, 4);
            this.imageButtonDeleteEntry.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonDeleteEntry.Name = "imageButtonDeleteEntry";
            this.imageButtonDeleteEntry.Size = new System.Drawing.Size(34, 34);
            this.imageButtonDeleteEntry.TabIndex = 1;
            this.imageButtonDeleteEntry.TooltipText = "Delete Entry";
            this.imageButtonDeleteEntry.Click += new System.EventHandler(this.imageButtonDeleteEntry_Click);
            // 
            // StringListMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerListMaker);
            this.Name = "StringListMaker";
            this.Size = new System.Drawing.Size(210, 150);
            this.splitContainerListMaker.Panel1.ResumeLayout(false);
            this.splitContainerListMaker.Panel2.ResumeLayout(false);
            this.splitContainerListMaker.Panel2.PerformLayout();
            this.splitContainerListMaker.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerListMaker;
        private ImageButton imageButtonAddEntry;
        private ImageButton imageButtonDeleteEntry;
        private System.Windows.Forms.TextBox textBoxEntries;
        private System.Windows.Forms.ListBox listBoxEntries;
        private System.Windows.Forms.Label labelDescription;
    }
}
