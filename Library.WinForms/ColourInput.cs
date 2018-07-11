#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class ColourInput : LabelledInput, IDataEntryControl
    {
        public ColourInput()
        {
            InitializeComponent();
        }


        [Description("Returns true if the user has chosen a colour.")]
        public bool HasValue
        {
            get { return colorComboBoxInput.SelectedItem != null; }
        }

        [Description("Returns true if the user has chosen a colour when it is mandatory to do so.")]
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

        [Description("The colour entered by the user.")]
        public Color Value
        {
            get { return colorComboBoxInput.Color; }

            set { colorComboBoxInput.Color = value; }
        }

        public void SetDataBinding(BindingSource DataBinder, string SourceName)
        {
            colorComboBoxInput.DataBindings.Add("Color", DataBinder, SourceName, false,
                                                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void colorComboBoxInput_Leave(object sender, EventArgs e)
        {
            HasRequiredInput();
        }

        private void ColourInput_EnabledChanged(object sender, EventArgs e)
        {
            colorComboBoxInput.Enabled = Enabled;
        }
    }
}