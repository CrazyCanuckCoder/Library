namespace Library.WinForms
{
    partial class IPAddressInput
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
            this.labelDot1 = new System.Windows.Forms.Label();
            this.labelDot2 = new System.Windows.Forms.Label();
            this.labelDot3 = new System.Windows.Forms.Label();
            this.textBoxQuadrant1 = new System.Windows.Forms.TextBox();
            this.textBoxQuadrant2 = new System.Windows.Forms.TextBox();
            this.textBoxQuadrant4 = new System.Windows.Forms.TextBox();
            this.textBoxQuadrant3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelDot1
            // 
            this.labelDot1.BackColor = System.Drawing.SystemColors.Window;
            this.labelDot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDot1.Location = new System.Drawing.Point(40, 0);
            this.labelDot1.Margin = new System.Windows.Forms.Padding(0);
            this.labelDot1.Name = "labelDot1";
            this.labelDot1.Size = new System.Drawing.Size(10, 15);
            this.labelDot1.TabIndex = 4;
            this.labelDot1.Text = ".";
            // 
            // labelDot2
            // 
            this.labelDot2.BackColor = System.Drawing.SystemColors.Window;
            this.labelDot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDot2.Location = new System.Drawing.Point(90, 0);
            this.labelDot2.Margin = new System.Windows.Forms.Padding(0);
            this.labelDot2.Name = "labelDot2";
            this.labelDot2.Size = new System.Drawing.Size(10, 15);
            this.labelDot2.TabIndex = 5;
            this.labelDot2.Text = ".";
            // 
            // labelDot3
            // 
            this.labelDot3.BackColor = System.Drawing.SystemColors.Window;
            this.labelDot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDot3.Location = new System.Drawing.Point(140, 0);
            this.labelDot3.Margin = new System.Windows.Forms.Padding(0);
            this.labelDot3.Name = "labelDot3";
            this.labelDot3.Size = new System.Drawing.Size(10, 15);
            this.labelDot3.TabIndex = 6;
            this.labelDot3.Text = ".";
            // 
            // textBoxQuadrant1
            // 
            this.textBoxQuadrant1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQuadrant1.Location = new System.Drawing.Point(0, 0);
            this.textBoxQuadrant1.Name = "textBoxQuadrant1";
            this.textBoxQuadrant1.Size = new System.Drawing.Size(40, 15);
            this.textBoxQuadrant1.TabIndex = 0;
            this.textBoxQuadrant1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuadrant1.Enter += new System.EventHandler(this.QuadrantEnter);
            this.textBoxQuadrant1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuadrantKeyPress);
            // 
            // textBoxQuadrant2
            // 
            this.textBoxQuadrant2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQuadrant2.Location = new System.Drawing.Point(50, 0);
            this.textBoxQuadrant2.Name = "textBoxQuadrant2";
            this.textBoxQuadrant2.Size = new System.Drawing.Size(40, 15);
            this.textBoxQuadrant2.TabIndex = 1;
            this.textBoxQuadrant2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuadrant2.Enter += new System.EventHandler(this.QuadrantEnter);
            this.textBoxQuadrant2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuadrantKeyPress);
            // 
            // textBoxQuadrant4
            // 
            this.textBoxQuadrant4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQuadrant4.Location = new System.Drawing.Point(150, 0);
            this.textBoxQuadrant4.Name = "textBoxQuadrant4";
            this.textBoxQuadrant4.Size = new System.Drawing.Size(40, 15);
            this.textBoxQuadrant4.TabIndex = 3;
            this.textBoxQuadrant4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuadrant4.Enter += new System.EventHandler(this.QuadrantEnter);
            this.textBoxQuadrant4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuadrantKeyPress);
            // 
            // textBoxQuadrant3
            // 
            this.textBoxQuadrant3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQuadrant3.Location = new System.Drawing.Point(100, 0);
            this.textBoxQuadrant3.Name = "textBoxQuadrant3";
            this.textBoxQuadrant3.Size = new System.Drawing.Size(40, 15);
            this.textBoxQuadrant3.TabIndex = 2;
            this.textBoxQuadrant3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuadrant3.Enter += new System.EventHandler(this.QuadrantEnter);
            this.textBoxQuadrant3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuadrantKeyPress);
            // 
            // IPAddressInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxQuadrant4);
            this.Controls.Add(this.textBoxQuadrant3);
            this.Controls.Add(this.textBoxQuadrant2);
            this.Controls.Add(this.textBoxQuadrant1);
            this.Controls.Add(this.labelDot3);
            this.Controls.Add(this.labelDot2);
            this.Controls.Add(this.labelDot1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "IPAddressInput";
            this.Size = new System.Drawing.Size(190, 15);
            this.Resize += new System.EventHandler(this.IPAddressInput_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDot1;
        private System.Windows.Forms.Label labelDot2;
        private System.Windows.Forms.Label labelDot3;
        private System.Windows.Forms.TextBox textBoxQuadrant1;
        private System.Windows.Forms.TextBox textBoxQuadrant2;
        private System.Windows.Forms.TextBox textBoxQuadrant4;
        private System.Windows.Forms.TextBox textBoxQuadrant3;

    }
}
