namespace Library.WinForms
{
    partial class SelectableDataEntryForm
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
            this.imageButtonDelete = new Library.WinForms.ImageButton();
            this.imageButtonEdit = new Library.WinForms.ImageButton();
            this.comboBoxItems = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.imageButtonAddItem = new Library.WinForms.ImageButton();
            this.SuspendLayout();
            // 
            // panelInputPanelHolder
            // 
            this.panelInputPanelHolder.Location = new System.Drawing.Point(20, 86);
            this.panelInputPanelHolder.Size = new System.Drawing.Size(342, 227);
            // 
            // imageButtonAction
            // 
            this.imageButtonAction.Location = new System.Drawing.Point(288, 339);
            // 
            // imageButtonCancel
            // 
            this.imageButtonCancel.Location = new System.Drawing.Point(328, 339);
            // 
            // imageButtonDelete
            // 
            this.imageButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonDelete.ButtonImage = global::Library.WinForms.Properties.Resources.delete;
            this.imageButtonDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonDelete.DisabledImage = global::Library.WinForms.Properties.Resources.delete_disabled;
            this.imageButtonDelete.Location = new System.Drawing.Point(287, 21);
            this.imageButtonDelete.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonDelete.Name = "imageButtonDelete";
            this.imageButtonDelete.Size = new System.Drawing.Size(34, 34);
            this.imageButtonDelete.TabIndex = 18;
            this.imageButtonDelete.TooltipText = "Delete";
            // 
            // imageButtonEdit
            // 
            this.imageButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonEdit.ButtonImage = global::Library.WinForms.Properties.Resources.application_form_edit;
            this.imageButtonEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonEdit.DisabledImage = global::Library.WinForms.Properties.Resources.application_form_edit_disabled;
            this.imageButtonEdit.Location = new System.Drawing.Point(247, 21);
            this.imageButtonEdit.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonEdit.Name = "imageButtonEdit";
            this.imageButtonEdit.Size = new System.Drawing.Size(34, 34);
            this.imageButtonEdit.TabIndex = 17;
            this.imageButtonEdit.TooltipText = "Edit";
            // 
            // comboBoxItems
            // 
            this.comboBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItems.FormattingEnabled = true;
            this.comboBoxItems.Location = new System.Drawing.Point(85, 27);
            this.comboBoxItems.Name = "comboBoxItems";
            this.comboBoxItems.Size = new System.Drawing.Size(146, 21);
            this.comboBoxItems.TabIndex = 16;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(16, 31);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(65, 13);
            this.labelDescription.TabIndex = 15;
            // 
            // imageButtonAddItem
            // 
            this.imageButtonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonAddItem.ButtonImage = global::Library.WinForms.Properties.Resources.add;
            this.imageButtonAddItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonAddItem.DisabledImage = global::Library.WinForms.Properties.Resources.add_disabled;
            this.imageButtonAddItem.Location = new System.Drawing.Point(328, 21);
            this.imageButtonAddItem.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonAddItem.Name = "imageButtonAddItem";
            this.imageButtonAddItem.Size = new System.Drawing.Size(34, 34);
            this.imageButtonAddItem.TabIndex = 19;
            this.imageButtonAddItem.TooltipText = "Add New";
            // 
            // SelectableDataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(382, 390);
            this.Controls.Add(this.imageButtonAddItem);
            this.Controls.Add(this.imageButtonDelete);
            this.Controls.Add(this.imageButtonEdit);
            this.Controls.Add(this.comboBoxItems);
            this.Controls.Add(this.labelDescription);
            this.Name = "SelectableDataEntryForm";
            this.Controls.SetChildIndex(this.imageButtonAction, 0);
            this.Controls.SetChildIndex(this.imageButtonCancel, 0);
            this.Controls.SetChildIndex(this.panelInputPanelHolder, 0);
            this.Controls.SetChildIndex(this.labelDescription, 0);
            this.Controls.SetChildIndex(this.comboBoxItems, 0);
            this.Controls.SetChildIndex(this.imageButtonEdit, 0);
            this.Controls.SetChildIndex(this.imageButtonDelete, 0);
            this.Controls.SetChildIndex(this.imageButtonAddItem, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public ImageButton imageButtonDelete;
        public ImageButton imageButtonEdit;
        public System.Windows.Forms.ComboBox comboBoxItems;
        public System.Windows.Forms.Label labelDescription;
        public ImageButton imageButtonAddItem;

    }
}
