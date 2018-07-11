#region

using System;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class ComboBoxInput : LabelledInput, IDataEntryControl
    {
        public ComboBoxInput()
        {
            InitializeComponent();
        }

        #region IDataEntryControl Members

        public bool HasValue
        {
            get { return comboBoxEntry.SelectedItem != null; }
        }

        public bool HasRequiredInput()
        {
            bool hasInput = true;

            if (IsMandatory)
            {
                hasInput = HasValue;
            }

            pictureBoxErrorIndicator.Visible = !hasInput;

            return hasInput;
        }

        public void SetDataBinding(BindingSource DataBinder, string SourceName)
        {
            comboBoxEntry.DataBindings.Add("SelectedValue", DataBinder, SourceName, false,
                                           DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion

        public void SetupComboBox(object DataSource, string DisplayMember, string ValueMember)
        {
            comboBoxEntry.DataSource = DataSource;
            comboBoxEntry.DisplayMember = DisplayMember;
            comboBoxEntry.ValueMember = ValueMember;
        }

        private void ComboBoxInput_EnabledChanged(object sender, EventArgs e)
        {
            comboBoxEntry.Enabled = Enabled;
        }
    }
}