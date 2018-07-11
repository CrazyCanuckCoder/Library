#region

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class LabelledInput : UserControl, ILabelledInput
    {
        public LabelledInput()
        {
            InitializeComponent();
        }

        private bool _isMandatory = false;
        private bool _showIndicator = true;

        [Description("The text to describe the input.")]
        public string Descriptor
        {
            get { return labelDescription.Text; }

            set
            {
                if (value != null)
                {
                    labelDescription.Text = value.Trim();
                    toolTipBase.SetToolTip(pictureBoxErrorIndicator, labelDescription.Text + " is required.");
                }
            }
        }

        [Description("True if this field must have some input.")]
        public bool IsMandatory
        {
            get { return _isMandatory; }

            set
            {
                _isMandatory = value;
                labelIndicator.Visible = (_isMandatory && _showIndicator);
            }
        }

        [Description("Set this to true to show an asterisk by the description when a field is mandatory.")]
        public bool ShowIndicator
        {
            get { return _showIndicator; }

            set
            {
                _showIndicator = value;
                labelIndicator.Visible = (_isMandatory && _showIndicator);
            }
        }

        [Description("Sets the width of the panel containing the description text.")]
        public int DescriptionPanelWidth
        {
            get { return splitContainerMain.SplitterDistance; }

            set
            {
                if (value >= splitContainerMain.Panel1MinSize)
                {
                    splitContainerMain.SplitterDistance = value;
                }
            }
        }
    }
}