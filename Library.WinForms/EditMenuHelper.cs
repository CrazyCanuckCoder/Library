using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    /// <summary>
    /// Provides the basic functionality for the standard Edit menu.
    /// </summary>
    /// 
    public class EditMenuHelper
    {
        public EditMenuHelper(Form MainForm, 
                              ToolStripMenuItem EditMenu, 
                              ToolStripMenuItem CutMenuItem, 
                              ToolStripMenuItem CopyMenuItem, 
                              ToolStripMenuItem PasteMenuItem, 
                              ToolStripMenuItem SelectAllMenuItem)
        {
            this._formRef = MainForm;

            this._editMenu          = EditMenu;
            this._cutMenuItem       = CutMenuItem;
            this._copyMenuItem      = CopyMenuItem;
            this._pasteMenuItem     = PasteMenuItem;
            this._selectAllMenuItem = SelectAllMenuItem;

            this.InitiateMenuEvents();
        }


        // The references to the controls used by this class.

        private Form _formRef = null;

        private ToolStripMenuItem _editMenu          = null;
        private ToolStripMenuItem _cutMenuItem       = null;
        private ToolStripMenuItem _copyMenuItem      = null;
        private ToolStripMenuItem _pasteMenuItem     = null;
        private ToolStripMenuItem _selectAllMenuItem = null;

        private TextBoxBase _textBox = null;



        /// <summary>
        /// Sets the events for the menu items.
        /// </summary>
        /// 
        private void InitiateMenuEvents()
        {
            this._editMenu.DropDownOpening += (sender, e) => this.CheckEditMenuStatus();

            this._cutMenuItem.Click       += (sender, e) => this._textBox.Cut();
            this._copyMenuItem.Click      += (sender, e) => this._textBox.Copy();
            this._pasteMenuItem.Click     += (sender, e) => this._textBox.Paste();
            this._selectAllMenuItem.Click += (sender, e) => this._textBox.SelectAll();
        }

        /// <summary>
        /// Navigates the tree of controls to find the last active control.
        /// </summary>
        /// 
        /// <param name="CurrentControl">
        /// A reference to the starting control to search the tree.
        /// </param>
        /// 
        /// <returns>
        /// A Control containing a reference to the found control.
        /// </returns>
        /// 
        private Control GetActualActiveControl(Control CurrentControl)
        {
            Control activeControl = CurrentControl;

            if (CurrentControl is ContainerControl)
            {
                activeControl = this.GetActualActiveControl((CurrentControl as ContainerControl).ActiveControl);
            }

            return activeControl;
        }

        /// <summary>
        /// Called from the menu opening event, updates the status of the menu items based on the type of 
        /// active control and whether or not the menu items should be enabled.
        /// </summary>
        /// 
        private void CheckEditMenuStatus()
        {
            Control activeControl = this.GetActualActiveControl(this._formRef.ActiveControl);
            this._textBox         = activeControl as TextBoxBase;

            bool isTextBox      = this._textBox != null;
            bool textIsSelected = isTextBox && this._textBox.SelectionLength > 0;

            this._cutMenuItem      .Enabled = textIsSelected;
            this._copyMenuItem     .Enabled = textIsSelected;
            this._pasteMenuItem    .Enabled = isTextBox && Clipboard.ContainsText();
            this._selectAllMenuItem.Enabled = isTextBox;
        }
    }
}
