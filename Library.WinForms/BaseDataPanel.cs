#region

using System.Collections.Generic;
using System.Windows.Forms;
using Library;

#endregion

namespace Library.WinForms
{
    /// <summary>
    /// Add controls to this panel to be used in the manipulation of data based
    /// objects.  This control works closely with the BaseDataEntryForm to
    /// provide basic data manipulation functionality.
    /// </summary>
    /// 
    /// <remarks>
    /// To use this panel, add input controls from this library.  Input controls
    /// like TextInput and ComboBoxInput implement the IDataEntryControl interface
    /// that this panel uses to check if the control has data, set its data 
    /// bindings and to tell the control to indicate properly how to handle the
    /// current data entry type.  If you don't use the input controls of this 
    /// library, ensure the controls implement the IDateEntryControl interface for
    /// this panel to work correctly.
    /// 
    /// In the derived version of this class you must implement the 
    /// SetupDataBindings method for each of the controls in this class.
    /// </remarks>
    /// 
    public partial class BaseDataPanel : UserControl, IInputPanel
    {
        public BaseDataPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The field used by the DataEntryType property.
        /// </summary>
        /// 
        private EntryType _dataEntryType = EntryType.Add;

        /// <summary>
        /// The field used by the SourceInfo property.
        /// </summary>
        /// 
        private IBaseDataClass _sourceInfo = null;

        /// <summary>
        /// The intermediary object to bind object properties to controls.
        /// </summary>
        /// 
        protected BindingSource _bindingSource = new BindingSource();

        /// <summary>
        /// Contains a list of the input controls in this panel.
        /// </summary>
        /// 
        /// <remarks>
        /// This list is used by the VerifyInput method to check every control.
        /// Each control must be added to the list in code.  It is recommended
        /// that the controls are added by the SetupDataBindings method after
        /// it has setup the BindingSource property.
        /// </remarks>
        /// 
        protected List<IDataEntryControl> _inputControls = new List<IDataEntryControl>();

        /// <summary>
        /// Contains any text for the user when input controls are missing entries.
        /// </summary>
        /// 
        /// <remarks>
        /// Set by the VerifyInput method when looking at mandatory input controls.
        /// </remarks>
        /// 
        public string EntryError { get; protected set; }

        /// <summary>
        /// Contains any text for the user when the action did not complete successfully.
        /// </summary>
        /// 
        /// <remarks>
        /// This property must be set by either the SaveData or the DeleteData method.
        /// </remarks>
        /// 
        public string ActionError { get; protected set; }

        /// <summary>
        /// Indicates whether the user wants to perform an addition, modification or
        /// a deletion.
        /// </summary>
        /// 
        /// <remarks>
        /// Will change the input controls of this panel to be enabled when editing
        /// and to be disabled if deleting or waiting for the entry type to be 
        /// determined.
        /// </remarks>
        /// 
        public EntryType DataEntryType
        {
            get { return _dataEntryType; }

            set
            {
                _dataEntryType = value;
                SetInputControls();
            }
        }

        /// <summary>
        /// The underlying data used by the input controls.
        /// </summary>
        /// 
        /// <remarks>
        /// This is the information used to bind to the input controls.  When
        /// this property is set, it will update the binding source property.
        /// </remarks>
        /// 
        public IBaseDataClass SourceInfo
        {
            get { return _sourceInfo; }

            set
            {
                _sourceInfo = value;
                _bindingSource.DataSource = _sourceInfo;
            }
        }

        /// <summary>
        /// Checks each input control that is flagged mandatory for data.  Any
        /// input control without data has its description added to the EntryError
        /// property.
        /// </summary>
        /// 
        /// <remarks>
        /// Once VerifyInput has returned false, it is up to you to display the
        /// message stored in the EntryError property to the user.
        /// </remarks>
        /// 
        /// <returns>
        /// True if every mandatory field indicates it has data.
        /// </returns>
        /// 
        public virtual bool VerifyInput()
        {
            EntryError = "";

            foreach (IDataEntryControl dataControl in _inputControls)
            {
                if (!dataControl.HasRequiredInput())
                {
                    EntryError += dataControl.Descriptor + " is required.\r\n";
                }
            }

            return EntryError == "";
        }

        /// <summary>
        /// Saves the entered data to the bound data's original source.
        /// </summary>
        /// 
        /// <remarks>
        /// Uses the default save method of the source data object from the
        /// SourceInfo property.  If more sophisticated actions need to be
        /// performed, this method can be overridden.
        /// </remarks>
        /// 
        /// <returns>
        /// True to indicate the save was successful and false otherwise.
        /// </returns>
        /// 
        public virtual bool SaveData()
        {
            bool dataSaved = SourceInfo.Save();

            if (!dataSaved)
            {
                ActionError = SourceInfo.ErrorMessage;
            }

            return dataSaved;
        }

        /// <summary>
        /// Deletes the current data from the bound data's original source.
        /// </summary>
        /// 
        /// <remarks>
        /// Uses the default delete method of the source data object from the
        /// SourceInfo property.  If more sophisticated actions need to be
        /// performed, this method can be overridden.
        /// </remarks>
        /// 
        /// <returns>
        /// True to indicate the delete was successful and false otherwise.
        /// </returns>
        /// 
        public virtual bool DeleteData()
        {
            bool dataDeleted = SourceInfo.Delete();

            if (!dataDeleted)
            {
                ActionError = SourceInfo.ErrorMessage;
            }

            return dataDeleted;
        }

        /// <summary>
        /// Adds the specified input control to the list of input controls and
        /// sets up the data binding for the control.
        /// </summary>
        /// 
        /// <remarks>
        /// Call this method for each input control in the data panel.  It is 
        /// recommended to call this method in SetupDataBindings after the 
        /// BindingSource property has been setup.
        /// </remarks>
        /// 
        /// <param name="InputControl">
        /// The control to register.
        /// </param>
        /// 
        /// <param name="SourceName">
        /// The name of the datasource property to bind to the input control.
        /// </param>
        /// 
        protected virtual void RegisterInputControl(IDataEntryControl InputControl, string SourceName)
        {
            InputControl.SetDataBinding(_bindingSource, SourceName);
            _inputControls.Add(InputControl);
        }

        /// <summary>
        /// Sets up the databinding controls and input controls.
        /// </summary>
        /// 
        /// <remarks>
        /// Since binding data is very situationally specific, no implementation
        /// of this method has been made.  The binding source property must be
        /// setup with the underlying data for this panel.  Each input control
        /// can be setup through the RegisterInputControl method.  It is 
        /// recommended you call this method in the subclass' constructor right
        /// after the InitializeComponent() call.
        /// 
        /// Example implementation:
        /// 
        /// protected override void SetupDataBindings()
        /// {
        ///     this.AddressInfo = new Address();
        /// 
        ///     List<Province> allProvinces = Province.GetAllProvinces();
        /// 
        ///     this.comboBoxInputProvince.SetupComboBox(allProvinces, "ProvName", "ProvName");
        /// 
        ///     this.RegisterInputControl(this.textInputName, "Name");
        ///     this.RegisterInputControl(this.textInputAddress1, "Line1");
        ///     this.RegisterInputControl(this.textInputAddress2, "Line2");
        ///     this.RegisterInputControl(this.textInputAddress3, "Line3");
        ///     this.RegisterInputControl(this.textInputCity, "City");
        ///     this.RegisterInputControl(this.comboBoxInputProvince, "Province");
        ///     this.RegisterInputControl(this.maskedTextInputPostalCode, "PostalCode");
        /// }
        /// </remarks>
        /// 
        protected virtual void SetupDataBindings()
        {
        }

        /// <summary>
        /// Called after the DataEntryType value has changed.  Will enable the
        /// input controls if the entry type is either Add or Edit.
        /// </summary>
        /// 
        /// <remarks>
        /// Override this method when you want to change the behaviour of the
        /// data entry types.
        /// </remarks>
        /// 
        protected virtual void SetInputControls()
        {
            bool isEditable = (DataEntryType != EntryType.Delete && DataEntryType != EntryType.None);
            foreach (IDataEntryControl dataControl in _inputControls)
            {
                var control = dataControl as Control;
                if (control != null)
                {
                    control.Enabled = isEditable;
                }
            }
        }
    }
}