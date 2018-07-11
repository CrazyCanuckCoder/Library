namespace Library.WinForms
{
    partial class BaseDataEntryForm : IBaseDataEntryForm
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
            this.panelInputPanelHolder = new System.Windows.Forms.Panel();
            this.imageButtonCancel = new ImageButton();
            this.imageButtonAction = new ImageButton();
            this.SuspendLayout();
            // 
            // panelInputPanelHolder
            // 
            this.panelInputPanelHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInputPanelHolder.Location = new System.Drawing.Point(20, 22);
            this.panelInputPanelHolder.Name = "panelInputPanelHolder";
            this.panelInputPanelHolder.Size = new System.Drawing.Size(296, 227);
            this.panelInputPanelHolder.TabIndex = 6;
            this.panelInputPanelHolder.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelInputPanelHolder_ControlAdded);
            // 
            // imageButtonCancel
            // 
            this.imageButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonCancel.ButtonImage = global::Library.WinForms.Properties.Resources.cancel;
            this.imageButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.imageButtonCancel.DisabledImage = global::Library.WinForms.Properties.Resources.cancel_disabled;
            this.imageButtonCancel.Location = new System.Drawing.Point(282, 275);
            this.imageButtonCancel.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonCancel.Name = "imageButtonCancel";
            this.imageButtonCancel.Size = new System.Drawing.Size(34, 34);
            this.imageButtonCancel.TabIndex = 5;
            this.imageButtonCancel.TooltipText = "Cancel";
            this.imageButtonCancel.Click += new System.EventHandler(this.imageButtonCancel_Click);
            // 
            // imageButtonAction
            // 
            this.imageButtonAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonAction.ButtonImage = global::Library.WinForms.Properties.Resources.add;
            this.imageButtonAction.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonAction.DisabledImage = global::Library.WinForms.Properties.Resources.add_disabled;
            this.imageButtonAction.Location = new System.Drawing.Point(242, 275);
            this.imageButtonAction.MinimumSize = new System.Drawing.Size(34, 34);
            this.imageButtonAction.Name = "imageButtonAction";
            this.imageButtonAction.Size = new System.Drawing.Size(34, 34);
            this.imageButtonAction.TabIndex = 4;
            this.imageButtonAction.TooltipText = "Add";
            this.imageButtonAction.Click += new System.EventHandler(this.imageButtonAction_Click);
            // 
            // BaseDataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 326);
            this.Controls.Add(this.panelInputPanelHolder);
            this.Controls.Add(this.imageButtonCancel);
            this.Controls.Add(this.imageButtonAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseDataEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelInputPanelHolder;
        public ImageButton imageButtonAction;
        public ImageButton imageButtonCancel;

    }
}