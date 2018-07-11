#region

using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public class CheckboxInput : CheckBox, IDataEntryControl
    {
        #region IDataEntryControl Members

        public string Descriptor
        {
            get { return Text; }

            set
            {
                if (value != null)
                {
                    Text = value;
                }
            }
        }

        public bool IsMandatory
        {
            get { return false; }

            set
            {
                //  Ignore value, checkboxes are never mandatory.
            }
        }

        public bool HasValue
        {
            get { return true; }
        }

        public bool HasRequiredInput()
        {
            return true;
        }

        public void SetDataBinding(BindingSource DataBinder, string SourceName)
        {
            DataBindings.Add("Checked", DataBinder, SourceName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion
    }
}