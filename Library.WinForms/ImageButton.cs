#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class ImageButton : UserControl, IButtonControl
    {
        /// <summary>
        /// A control that simulates button click animation for an image based
        /// button.  The size of the button at runtime is based on the size of
        /// the image plus a small amount of offset.
        /// </summary>
        /// 
        /// <remarks>
        /// Ensure you use an image file with the dimensions of the size that
        /// you want for the button.  The size of the button is automatically
        /// determined after an image is assigned to the ButtonImage property.
        /// </remarks>
        /// 
        public ImageButton()
        {
            InitializeComponent();
            _originalLocation = pictureBoxImage.Location;
            _offsetLocation = new Point(_originalLocation.X + WidthOffset, _originalLocation.Y + HeightOffset);
        }

        //  Constants used by this class.

        private const int HeightOffset = 2;
        private const int WidthOffset = 2;

        //  Stores the original location of the PictureBox control that displays
        //     the image as well as the offset location used when the user 
        //     presses the left mouse button.

        private readonly Point _offsetLocation;
        private readonly Point _originalLocation;

        //  Fields used for the public properties.

        private string _tooltipText = "";
        private Image _buttonImage = null;
        private DialogResult _dialogResult = DialogResult.None;
        private bool _isDefault = false;

        [Description("The image to display on the button.")]
        public Image ButtonImage
        {
            get { return _buttonImage; }

            set
            {
                _buttonImage = value;
                pictureBoxImage.Image = value;
                DetermineNewSize();
            }
        }

        [Description("The image displayed for the button when it is disabled.")]
        public Image DisabledImage { get; set; }

        [Description("The text displayed when the user hovers the mouse over the button.")]
        public string TooltipText
        {
            get { return _tooltipText; }

            set
            {
                if (value != null)
                {
                    _tooltipText = value;
                    toolTip.SetToolTip(pictureBoxImage, value);
                }
            }
        }

        /// <summary>
        /// Sets the size of the control to the size of the image plus the
        /// offset amount.
        /// </summary>
        /// 
        /// <remarks>
        /// Sets the MinimumSize property to prevent the programmer from inadvertently
        /// sizing the control smaller than the image.
        /// </remarks>
        /// 
        private void DetermineNewSize()
        {
            if (pictureBoxImage.Image != null)
            {
                Height = pictureBoxImage.Image.Height + HeightOffset;
                Width  = pictureBoxImage.Image.Width  + WidthOffset;
                MinimumSize = new Size(Width, Height);
            }
            else
            {
                MinimumSize = new Size();
            }
            Refresh();
        }

        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBoxImage.Location = _offsetLocation;
            }
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBoxImage.Location = _originalLocation;

                //  Check that the mouse cursor is still over the image before 
                //    firing the click event.

                if (pictureBoxImage.ClientRectangle.Contains(pictureBoxImage.PointToClient(Control.MousePosition)))
                {
                    OnClick(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Sets the image displayed based on the status of the Enabled property.
        /// </summary>
        /// 
        private void ImageButton_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
            {
                pictureBoxImage.Image = ButtonImage;
            }
            else
            {
                if (DisabledImage != null)
                {
                    pictureBoxImage.Image = DisabledImage;
                }
            }
            Refresh();
        }

        #region IButtonControl Members

        public DialogResult DialogResult
        {
            get { return _dialogResult; }

            set { _dialogResult = value; }
        }

        public void NotifyDefault(bool value)
        {
            _isDefault = value;
        }

        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }

        #endregion
    }
}