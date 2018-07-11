#region

using System.Collections.Generic;

#endregion

namespace Library.WinForms
{
    /// <summary>
    /// Use this class when you want the user to select from a list of items in
    /// a combo box to edit or delete an item.
    /// </summary>
    /// 
    /// <remarks>
    /// To use this class, follow these steps:
    /// 
    /// 1. Set up the combo box with the available items for the user
    ///     - the items must be from a class derived from BaseDataClass
    ///     - each item of the combo box must be the entire class
    ///     - set up the ValueMember property as the identity field
    ///     - set up the DisplayMember property as the field describing the item
    /// 2. Set up the click methods for the selection buttons
    ///     - for the AddItem button, call the AddItem method
    ///     - for the Accept (edit) button, call the EditItem method
    ///     - for the Delete button, call the DeleteItem method
    ///     - ensure you specify your datatype for each of the methods
    ///     - this methods will set up the form for the corresponding action (add, edit or delete)
    ///     
    /// See the remarks for the BaseDataEntryForm for more instructions.
    /// </remarks>
    /// 
    public partial class SelectableDataEntryForm : BaseDataEntryForm
    {
        public SelectableDataEntryForm()
        {
            InitializeComponent();
            SetOffsetSizes();
        }

        /// <summary>
        /// Sets the data source and display values of the combo box used on this 
        /// form to select which item to edit.
        /// </summary>
        /// 
        /// <remarks>
        /// This method should be called in the constructor of the derived form.
        /// </remarks>
        /// 
        /// <typeparam name="T">
        /// The type of objects to edit.  The objects must derive from BaseDataClass.
        /// </typeparam>
        /// 
        /// <param name="AllItems">
        /// A list of items to use as the data source for the combo box.
        /// </param>
        /// 
        /// <param name="DisplayMember">
        /// The name of the property of an item to use for the display member
        /// of the combo box.
        /// </param>
        /// 
        /// <param name="ValueMember">
        /// The name of the property of an item to use for the value member of
        /// the combo box.
        /// </param>
        /// 
        protected virtual void SetupComboBox<T>(List<T> AllItems, string DisplayMember, string ValueMember)
            where T : BaseDataClass
        {
            comboBoxItems.DataSource = AllItems;
            comboBoxItems.DisplayMember = DisplayMember;
            comboBoxItems.ValueMember = ValueMember;
        }

        /// <summary>
        /// Creates a new item and sets up the form accordingly.
        /// </summary>
        /// 
        protected virtual void AddItem<T>() where T : BaseDataClass, new()
        {
            SetFormForAction<T>(EntryType.Add);
        }

        /// <summary>
        /// Adds the selected item to the editing controls.
        /// </summary>
        /// 
        protected virtual void EditItem<T>() where T : BaseDataClass, new()
        {
            SetFormForAction<T>(EntryType.Edit);
        }

        /// <summary>
        /// Removes the selected item from the list of available items.
        /// </summary>
        /// 
        protected virtual void DeleteItem<T>() where T : BaseDataClass, new()
        {
            SetFormForAction<T>(EntryType.Delete);
        }

        /// <summary>
        /// Based on the specified action, sets the data entry panel to either
        /// add, edit or delete an item.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of item to manipulate.  Must derive from BaseDataClass.
        /// </typeparam>
        /// 
        /// <param name="ActionType">
        /// Indicates whether to add an item, edit an item or delete an item.
        /// </param>
        /// 
        private void SetFormForAction<T>(EntryType ActionType) where T : BaseDataClass, new()
        {
            DataEntryType = ActionType;
            T actionItem = (ActionType == EntryType.Add) ? new T() : (T) comboBoxItems.SelectedItem;
            EntryPanel.SourceInfo = actionItem;

            EnableEditingControls();
            DisableSelectionControls();
        }

        /// <summary>
        /// Enables the controls that the user will specify whether to confirm
        /// the current action or cancel it.
        /// </summary>
        /// 
        private void EnableEditingControls()
        {
            imageButtonAction.Enabled = true;
            imageButtonCancel.Enabled = true;
        }

        /// <summary>
        /// Disables the controls used to select the status to manage after
        /// the user has specified which action to perform.
        /// </summary>
        /// 
        private void DisableSelectionControls()
        {
            comboBoxItems.Enabled = false;
            imageButtonAddItem.Enabled = false;
            imageButtonEdit.Enabled = false;
            imageButtonDelete.Enabled = false;
        }
    }
}