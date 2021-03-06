﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    /// <summary>
    /// This form is used by the ControlPrinter class to generate a bitmap image for use in printing a control.
    /// </summary>
    /// 
    public partial class ControlPrinterForm : Form
    {
        private ControlPrinterForm()
        {
            InitializeComponent();
        }

        public ControlPrinterForm(Control NewControl) : this()
        {
            if (NewControl == null)
            {
                throw new ArgumentNullException("NewControl");
            }
            else
            {
                this._controlToPrint = NewControl;
                this.AddControlToForm();
            }
        }

        /// <summary>
        /// The factor used to adjust the control to fit the printer margin.
        /// </summary>
        /// 
        public static readonly int PRINTER_MARGIN_FACTOR = 4;

        /// <summary>
        /// A reference to the control to print.
        /// </summary>
        /// 
        private readonly Control _controlToPrint;



        /// <summary>
        /// Sets up the user specified control on the form so it can print successfully.
        /// </summary>
        /// 
        private void AddControlToForm()
        {
            //  Add the control to the form.

            this.borderPanelBase.Controls.Add(this._controlToPrint);

            //  Set the control up.

            this._controlToPrint.Anchor   = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this._controlToPrint.Font     = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this._controlToPrint.Location = new Point(3, 3);
            this._controlToPrint.Name     = "ControlToPrint";
            this._controlToPrint.Size     = new Size(this.Width - 6, this.Height - 6);
            this._controlToPrint.TabIndex = 0;
        }
    }
}
