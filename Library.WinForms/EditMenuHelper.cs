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
            _formRef = MainForm;

            _editMenu          = EditMenu;
            _cutMenuItem       = CutMenuItem;
            _copyMenuItem      = CopyMenuItem;
            _pasteMenuItem     = PasteMenuItem;
            _selectAllMenuItem = SelectAllMenuItem;

            InitiateMenuEvents();
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
            _editMenu.DropDownOpening += (sender, e) => CheckEditMenuStatus();

            _cutMenuItem.Click       += (sender, e) => _textBox.Cut();
            _copyMenuItem.Click      += (sender, e) => _textBox.Copy();
            _pasteMenuItem.Click     += (sender, e) => _textBox.Paste();
            _selectAllMenuItem.Click += (sender, e) => _textBox.SelectAll();
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
                activeControl = GetActualActiveControl((CurrentControl as ContainerControl).ActiveControl);
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
            Control activeControl = GetActualActiveControl(_formRef.ActiveControl);
            _textBox         = activeControl as TextBoxBase;

            bool isTextBox      = _textBox != null;
            bool textIsSelected = isTextBox && _textBox.SelectionLength > 0;

            _cutMenuItem      .Enabled = textIsSelected;
            _copyMenuItem     .Enabled = textIsSelected;
            _pasteMenuItem    .Enabled = isTextBox && Clipboard.ContainsText();
            _selectAllMenuItem.Enabled = isTextBox;
        }
    }
}
