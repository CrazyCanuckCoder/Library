namespace Library.WinForms
{
    partial class BaseSelectionForm : IBaseSelectionForm
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
            this.panelSelectionPanelHolder = new System.Windows.Forms.Panel();
            this.imageButtonCancel = new ImageButton();
            this.imageButtonSelect = new ImageButton();
            this.SuspendLayout();
            // 
            // panelSelectionPanelHolder
            // 
            this.panelSelectionPanelHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelectionPanelHolder.Location = new System.Drawing.Point(15, 15);
            this.panelSelectionPanelHolder.Name = "panelSelectionPanelHolder";
            this.panelSelectionPanelHolder.Size = new System.Drawing.Size(306, 237);
            this.panelSelectionPanelHolder.TabIndex = 9;
            this.panelSelectionPanelHolder.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelSelectionPanelHolder_ControlAdded);
            // 
            // imageButtonCancel
            // 
            this.imageButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonCancel.ButtonImage = global::Library.WinForms.Properties.Resources.cancel;
            this.imageButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.imageButtonCancel.DisabledImage = global::Library.WinForms.Properties.Resources.cancel_disabled;
            this.imageButtonCancel.Location = new System.Drawing.Point(287, 278);
            this.imageButtonCancel.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonCancel.Name = "imageButtonCancel";
            this.imageButtonCancel.Size = new System.Drawing.Size(34, 34);
            this.imageButtonCancel.TabIndex = 8;
            this.imageButtonCancel.TooltipText = "Cancel";
            this.imageButtonCancel.Click += new System.EventHandler(this.imageButtonCancel_Click);
            // 
            // imageButtonSelect
            // 
            this.imageButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonSelect.ButtonImage = global::Library.WinForms.Properties.Resources.accept;
            this.imageButtonSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonSelect.DisabledImage = global::Library.WinForms.Properties.Resources.accept_disabled;
            this.imageButtonSelect.Location = new System.Drawing.Point(247, 278);
            this.imageButtonSelect.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonSelect.Name = "imageButtonSelect";
            this.imageButtonSelect.Size = new System.Drawing.Size(34, 34);
            this.imageButtonSelect.TabIndex = 7;
            this.imageButtonSelect.TooltipText = "Select";
            this.imageButtonSelect.Click += new System.EventHandler(this.imageButtonSelect_Click);
            // 
            // BaseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 326);
            this.Controls.Add(this.panelSelectionPanelHolder);
            this.Controls.Add(this.imageButtonCancel);
            this.Controls.Add(this.imageButtonSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelSelectionPanelHolder;
        public ImageButton imageButtonCancel;
        public ImageButton imageButtonSelect;
    }
}