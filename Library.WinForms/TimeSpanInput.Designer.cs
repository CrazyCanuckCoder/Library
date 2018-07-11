namespace Library.WinForms
{
    partial class TimeSpanInput
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
            this.components = new System.ComponentModel.Container();
            this.errorInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDays = new System.Windows.Forms.Label();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.panTimeSpanInput = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            this.panTimeSpanInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorInput
            // 
            this.errorInput.ContainerControl = this;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(3, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(31, 13);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "Days";
            // 
            // numDays
            // 
            this.numDays.Location = new System.Drawing.Point(6, 16);
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(83, 20);
            this.numDays.TabIndex = 1;
            this.numDays.ValueChanged += new System.EventHandler(this.numDays_ValueChanged);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(111, 0);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 2;
            this.lblHours.Text = "Hours";
            // 
            // numHours
            // 
            this.numHours.Location = new System.Drawing.Point(114, 16);
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(83, 20);
            this.numHours.TabIndex = 3;
            this.numHours.ValueChanged += new System.EventHandler(this.numHours_ValueChanged);
            // 
            // panTimeSpanInput
            // 
            this.panTimeSpanInput.Controls.Add(this.lblDays);
            this.panTimeSpanInput.Controls.Add(this.lblHours);
            this.panTimeSpanInput.Controls.Add(this.numDays);
            this.panTimeSpanInput.Controls.Add(this.numHours);
            this.panTimeSpanInput.Location = new System.Drawing.Point(3, 3);
            this.panTimeSpanInput.Name = "panTimeSpanInput";
            this.panTimeSpanInput.Size = new System.Drawing.Size(210, 42);
            this.panTimeSpanInput.TabIndex = 8;
            // 
            // TimeSpanInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panTimeSpanInput);
            this.Name = "TimeSpanInput";
            this.Size = new System.Drawing.Size(266, 50);
            ((System.ComponentModel.ISupportInitialize)(this.errorInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.panTimeSpanInput.ResumeLayout(false);
            this.panTimeSpanInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorInput;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Panel panTimeSpanInput;
    }
}
