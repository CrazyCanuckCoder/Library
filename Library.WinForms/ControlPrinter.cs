﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    /// <summary>
    /// Prints any control by generating an image of its contents and sending the image to the printer.
    /// </summary>
    /// 
    public class ControlPrinter : IControlPrinter
    {
        public ControlPrinter()
        {
        }

        /// <summary>
        /// The bitmap image of the chart used in printing.
        /// </summary>
        /// 
        private Bitmap _printImage;

        /// <summary>
        /// Contains the error text if the printing failed.
        /// </summary>
        /// 
        public string ErrorMessage { get; private set; }


        /// <summary>
        /// Prompts the user to select a printer and then prints the specified control to the selected printer.
        /// </summary>
        /// 
        /// <param name="ControlToPrint">
        /// The Control object containing the image or data to print.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the print was successful and false if not.
        /// </returns>
        /// 
        public bool Print(Control ControlToPrint)
        {
            this.ErrorMessage = "";

            if (ControlToPrint != null)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.AllowPrintToFile = false;
                printDialog.UseEXDialog = true;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Print(ControlToPrint, printDialog.PrinterSettings);
                }
            }
            else
            {
                this.ErrorMessage = "Nothing to print!";
            }

            return this.ErrorMessage.IsEmpty();
        }

        /// <summary>
        /// Prints the specified control to the selected printer.
        /// </summary>
        /// 
        /// <param name="ControlToPrint">
        /// The Control object containing the image or data to print.
        /// </param>
        /// 
        /// <param name="NewSettings">
        /// The settings of the printer to send the image to.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the print was successful and false if not.
        /// </returns>
        /// 
        public bool Print(Control ControlToPrint, PrinterSettings NewSettings)
        {
            this.ErrorMessage = "";

            if (ControlToPrint != null)
            {
                if (NewSettings != null)
                {
                    try
                    {
                        PrintDocument printDoc = new PrintDocument();
                        printDoc.PrintPage += PrintDoc_PrintPage;
                        printDoc.EndPrint += PrintDoc_EndPrint;
                        printDoc.PrinterSettings = NewSettings;

                        this._printImage = this.GeneratePrintImage(ControlToPrint, NewSettings.DefaultPageSettings);

                        if (this._printImage != null)
                        {
                            printDoc.Print();
                        }
                        else
                        {
                            this.ErrorMessage = "Document generation failed, unable to print.";
                        }
                    }
                    catch (InvalidPrinterException)
                    {
                        this.ErrorMessage = "Invalid printer specified.";
                    }
                    catch (Exception ex)
                    {
                        this.ErrorMessage = "Unable to print document.  " + ex.Message;
                    }
                }
                else
                {
                    this.ErrorMessage = "No printer specified.  Please specify a printer to use.";
                }
            }
            else
            {
                this.ErrorMessage = "Nothing to print!";
            }

            return this.ErrorMessage.IsEmpty();
        }

        /// <summary>
        /// Adjusts the control that the user selected for printing to fit the current page size then creates
        /// an image for use in the printing routines.
        /// </summary>
        /// 
        /// <param name="ControlToImage">
        /// The control to make an image of for the purpose of printing it.
        /// </param>
        /// 
        /// <param name="PrintPageSettings">
        /// An object containing the information about the paper size and margins.
        /// </param>
        /// 
        /// <returns>
        /// An image file containing a snapshot of the control for use in printing.
        /// </returns>
        /// 
        public Bitmap GeneratePrintImage(Control ControlToImage, PageSettings PrintPageSettings)
        {
            Bitmap memoryImage = null;

            if (ControlToImage != null)
            {
                if (PrintPageSettings != null)
                {
                    ControlPrinterForm imageMaker = new ControlPrinterForm(ControlToImage);
                    imageMaker.Show();

                    try
                    {
                        //  Adjust the form to fit the control fully on the printer page.

                        float marginDiff = Math.Max(PrintPageSettings.HardMarginX, PrintPageSettings.HardMarginY) * ControlPrinterForm.PRINTER_MARGIN_FACTOR;

                        if (PrintPageSettings.Landscape)
                        {
                            imageMaker.Size = new Size((int)(PrintPageSettings.PrintableArea.Height - marginDiff),
                                                       (int)(PrintPageSettings.PrintableArea.Width  - marginDiff));
                        }
                        else
                        {
                            imageMaker.Size = new Size((int)(PrintPageSettings.PrintableArea.Width  - marginDiff),
                                                       (int)(PrintPageSettings.PrintableArea.Height - marginDiff));
                        }

                        //  Create an image of the control.

                        memoryImage = new Bitmap(imageMaker.Width, imageMaker.Height);
                        imageMaker.DrawToBitmap(memoryImage, new Rectangle(0, 0, imageMaker.Width, imageMaker.Height));
                    }
                    finally
                    {
                        imageMaker.Close();
                    }
                }
                else
                {
                    this.ErrorMessage = "No printer specified.  Please specify a printer to use.";
                }
            }
            else
            {
                this.ErrorMessage = "Nothing to print!";
            }

            return memoryImage;
        }





        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //  Center the image on the printer page.

            if (e.PageSettings.Landscape)
            {
                e.Graphics.DrawImage(this._printImage, Math.Abs(e.PageSettings.PrintableArea.Width  - this._printImage.Height) / ControlPrinterForm.PRINTER_MARGIN_FACTOR,
                                                       Math.Abs(e.PageSettings.PrintableArea.Height - this._printImage.Width)  / ControlPrinterForm.PRINTER_MARGIN_FACTOR);
            }
            else
            {
                e.Graphics.DrawImage(this._printImage, Math.Abs(e.PageSettings.PrintableArea.Width  - this._printImage.Width)  / ControlPrinterForm.PRINTER_MARGIN_FACTOR,
                                                       Math.Abs(e.PageSettings.PrintableArea.Height - this._printImage.Height) / ControlPrinterForm.PRINTER_MARGIN_FACTOR);
            }
        }



        private void PrintDoc_EndPrint(object sender, PrintEventArgs e)
        {
            this._printImage = null;
        }
    }
}
