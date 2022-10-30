using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public partial class TouchErrorProvider : Component, IExtenderProvider
    {
        public TouchErrorProvider()
        {
            InitializeComponent();
        }

        public TouchErrorProvider(IContainer Container)
        {
            Container.Add(this);

            InitializeComponent();
        }

        private class ErrorInfo
        {
            public string ErrorText                 { get; set; }
            public Control IconControl              { get; set; }
            public PictureBox IconBox               { get; set; }
            public ErrorIconAlignment IconAlignment { get; set; }

            public ErrorInfo(string NewErrorText, Control NewIconControl)
            {
                ErrorText     = NewErrorText;
                IconControl   = NewIconControl;
                IconAlignment = ErrorIconAlignment.MiddleRight;
            }
        }

        private const int ICON_X_BUFFER = 0;

        /// <summary>
        /// Contains the information about each error.
        /// 
        ///   Key: The control with the error.
        /// Value: An ErrorInfo object containing references to the error text, 
        ///        the control associated with the error icon (in case it is 
        ///        different than the control with the error) and the picture
        ///        box control that displays the error icon.
        /// </summary>
        /// 
        private Dictionary<Control, ErrorInfo> _dictionary = new Dictionary<Control, ErrorInfo>();

        /// <summary>
        /// The control used for displaying the tool tips on the error controls.
        /// </summary>
        /// 
        private ToolTip _toolTipProvider = null;

        /// <summary>
        /// Gets the current tool tip control.
        /// </summary>
        /// 
        public ToolTip ToolTipProvider
        {
            get
            {
                if (_toolTipProvider == null)
                {
                    _toolTipProvider = toolTip;
                }

                return _toolTipProvider;
            }

            private set
            {
                if (value != null)
                {
                    toolTip = value;
                }
            }
        }

        /// <summary>
        /// The image to display to indicate an error.
        /// </summary>
        /// 
        public Image Icon
        {
            get
            {
                return pictureBoxIcon.Image;
            }

            set
            {
                pictureBoxIcon.Image = value;
            }
        }

        /// <summary>
        /// Returns true if there is at least one error control recorded.
        /// </summary>
        /// 
        public bool HasErrors
        {
            get
            {
                return _dictionary.Keys.Count > 0;
            }
        }

        /// <summary>
        /// Returns true if the parameter is a windows form control.
        /// </summary>
        /// 
        /// <param name="extendee">
        /// The object to check.
        /// </param>
        /// 
        /// <returns>
        /// True if the extendee object is a control.
        /// </returns>
        /// 
        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        /// <summary>
        /// Sets the tool tip control used for setting the error controls's text.
        /// </summary>
        /// 
        /// <remarks>
        /// Use this if you want to use a tooltip control with different values
        /// than the default ones for the tooltip.
        /// </remarks>
        /// 
        /// <param name="NewProvider">
        /// The tool tip control to use.
        /// </param>
        /// 
        public void SetToolTipProvider(ToolTip NewProvider)
        {
            if (NewProvider != null)
            {
                ToolTipProvider = NewProvider;
            }
            else
            {
                throw new ArgumentNullException("NewProvider");
            }
        }

        /// <summary>
        /// Sets an error condition for a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control that contains an error.
        /// </param>
        /// 
        /// <param name="ErrorText">
        /// The text explaining the error for the control.
        /// </param>
        /// 
        public void SetError(Control ErrorControl, string ErrorText)
        {
            SetError(ErrorControl, ErrorControl, ErrorText, ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Sets an error condition for a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control that contains an error.
        /// </param>
        /// 
        /// <param name="IconControl">
        /// A separate control than the error control that will have the error
        /// icon associated with it.
        /// </param>
        /// 
        /// <remarks>
        /// Use the IconControl parameter when the icon cannot be shown near the
        /// actual error control.  By default, the IconControl is set to the
        /// ErrorControl reference.
        /// </remarks>
        /// 
        /// <param name="ErrorText">
        /// The text explaining the error for the control.
        /// </param>
        /// 
        public void SetError(Control ErrorControl, Control IconControl, string ErrorText)
        {
            SetError(ErrorControl, IconControl, ErrorText, ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Sets an error condition for a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control that contains an error.
        /// </param>
        /// 
        /// <param name="ErrorText">
        /// The text explaining the error for the control.
        /// </param>
        /// 
        /// <param name="IconAlignment">
        /// The alignment type for the error icon.
        /// </param>
        /// 
        public void SetError(Control ErrorControl, string ErrorText, ErrorIconAlignment IconAlignment)
        {
            SetError(ErrorControl, ErrorControl, ErrorText, IconAlignment);
        }

        /// <summary>
        /// Sets an error condition for a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control that contains an error.
        /// </param>
        /// 
        /// <param name="IconControl">
        /// A separate control than the error control that will have the error
        /// icon associated with it.
        /// </param>
        /// 
        /// <remarks>
        /// Use the IconControl parameter when the icon cannot be shown near the
        /// actual error control.  By default, the IconControl is set to the
        /// ErrorControl reference.
        /// </remarks>
        /// 
        /// <param name="ErrorText">
        /// The text explaining the error for the control.
        /// </param>
        /// 
        /// <param name="IconAlignment">
        /// The alignment type for the error icon.
        /// </param>
        /// 
        public void SetError(Control ErrorControl, Control IconControl, string ErrorText, ErrorIconAlignment IconAlignment)
        {
            if (ErrorControl != null)
            {
                if (IconControl != null)
                {
                    if (!string.IsNullOrEmpty(ErrorText))
                    {
                        if (!_dictionary.ContainsKey(ErrorControl))
                        {
                            ErrorInfo errorInfo = new ErrorInfo(ErrorText, IconControl);
                            errorInfo.IconAlignment = IconAlignment;

                            //  Add the icon image to the current form and dictionary.

                            PictureBox newIcon = pictureBoxIcon.Clone();
                            newIcon.Parent = IconControl.Parent;
                            SetIconLocation(IconControl, newIcon, errorInfo.IconAlignment);
                            newIcon.TabIndex = 0;
                            IconControl.Parent.Controls.Add(newIcon);
                            errorInfo.IconBox = newIcon;

                            //  Add the error text to the error control's tooltip text.

                            ToolTipProvider.SetToolTip(ErrorControl, ErrorText);

                            //  Create the error instance.

                            _dictionary.Add(ErrorControl, errorInfo);
                        }
                        else
                        {
                            throw new ArgumentException("Error exists for control already.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No error text specified.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("IconControl");
                }
            }
            else
            {
                throw new ArgumentNullException("ErrorControl");
            }
        }

        /// <summary>
        /// Retrieves the error text for the specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control that has error text.
        /// </param>
        /// 
        /// <returns>
        /// A string containing the error text for the specified control.
        /// </returns>
        /// 
        public string GetError(Control ErrorControl)
        {
            string error = "";

            if (ErrorControl != null)
            {
                if (_dictionary.ContainsKey(ErrorControl))
                {
                    error = _dictionary[ErrorControl].ErrorText;
                }
            }
            else
            {
                error = "Invalid argument, ErrorControl is null.";
            }

            return error;
        }

        /// <summary>
        /// Clears all error text, icons and controls as if there are no
        /// errors to report.
        /// </summary>
        /// 
        public void Clear()
        {
            foreach (KeyValuePair<Control, ErrorInfo> kvp in _dictionary)
            {
                kvp.Key.Parent.Controls.Remove(kvp.Value.IconBox);
            }

            ToolTipProvider.RemoveAll();
            _dictionary = new Dictionary<Control, ErrorInfo>();
        }

        /// <summary>
        /// Sets the control that will have the error icon associated with it.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The original control with the error.
        /// </param>
        /// 
        /// <param name="IconControl">
        /// The control what will have the error icon associated with it.
        /// </param>
        /// 
        public void SetIconControl(Control ErrorControl, Control IconControl)
        {
            if (ErrorControl != null)
            {
                if (IconControl != null)
                {
                    if (_dictionary.ContainsKey(ErrorControl))
                    {
                        _dictionary[ErrorControl].IconControl = IconControl;
                    }
                    else
                    {
                        throw new ArgumentException("Specified control does not have an error instance.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("IconControl");
                }
            }
            else
            {
                throw new ArgumentNullException("ErrorControl");
            }
        }

        /// <summary>
        /// Gets the control that will have the error icon associated with it.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The original control with the error.
        /// </param>
        /// 
        /// <returns>
        /// The control that has the error icon associated with it.
        /// </returns>
        /// 
        public Control GetIconControl(Control ErrorControl)
        {
            Control iconControl = null;

            if (ErrorControl != null)
            {
                if (_dictionary.ContainsKey(ErrorControl))
                {
                    iconControl = _dictionary[ErrorControl].IconControl;
                }
                else
                {
                    throw new ArgumentException("Specified control does not have an error instance.");
                }
            }
            else
            {
                throw new ArgumentNullException("ErrorControl");
            }

            return iconControl;
        }

        /// <summary>
        /// Clears an error instance for a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// 
        /// The control with the error instance.
        /// </param>
        /// 
        public void ClearError(Control ErrorControl)
        {
            if (ErrorControl != null)
            {
                if (_dictionary.ContainsKey(ErrorControl))
                {
                    _dictionary[ErrorControl].IconControl.Parent.Controls.Remove(_dictionary[ErrorControl].IconBox);
                    _toolTipProvider.SetToolTip(ErrorControl, "");
                    _dictionary.Remove(ErrorControl);
                }
                else
                {
                    throw new ArgumentException("Specified control does not have an error instance.");
                }
            }
            else
            {
                throw new ArgumentNullException("ErrorControl");
            }
        }

        /// <summary>
        /// Sets the alignment for the error icon of a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control containing an error.
        /// </param>
        /// 
        /// <param name="NewErrorLocation">
        /// The new alignment for the icon box.
        /// </param>
        /// 
        public void SetIconAlignment(Control ErrorControl, ErrorIconAlignment NewErrorLocation)
        {
            if (ErrorControl != null)
            {
                if (_dictionary.ContainsKey(ErrorControl))
                {
                    ErrorInfo errorInfo = _dictionary[ErrorControl];
                    errorInfo.IconAlignment = NewErrorLocation;
                    SetIconLocation(errorInfo.IconControl, errorInfo.IconBox, errorInfo.IconAlignment);
                }
                else
                {
                    throw new ArgumentException("Specified control does not have an error instance.");
                }
            }
            else
            {
                throw new ArgumentNullException("ErrorControl");
            }
        }

        /// <summary>
        /// Retrieves the icon alignment for a specified control.
        /// </summary>
        /// 
        /// <param name="ErrorControl">
        /// The control containing an error.
        /// </param>
        /// 
        /// <returns>
        /// The ErrorIconAlignment for the specified control.
        /// </returns>
        /// 
        public ErrorIconAlignment GetIconAlignment(Control ErrorControl)
        {
            ErrorIconAlignment alignment = ErrorIconAlignment.MiddleRight;

            if (ErrorControl != null)
            {
                if (_dictionary.ContainsKey(ErrorControl))
                {
                    alignment = _dictionary[ErrorControl].IconAlignment;
                }
                else
                {
                    throw new Exception("Specified control does not have an error instance.");
                }
            }
            else
            {
                throw new ArgumentNullException("ErrorControl");
            }

            return alignment;
        }





        /// <summary>
        /// Moves a specified picture box displaying an error icon relative to
        /// the location of an icon control.
        /// </summary>
        /// 
        /// <param name="IconControl">
        /// The control where the picture box will be displayed next to.
        /// </param>
        /// 
        /// <param name="IconBox">
        /// The picture box displaying the error icon.
        /// </param>
        /// 
        /// <param name="IconAlignment">
        /// The alignment type for the error icon.
        /// </param>
        /// 
        private void SetIconLocation(Control IconControl, PictureBox IconBox, ErrorIconAlignment IconAlignment)
        {
            int xLocation = 0;
            int yLocation = 0;

            switch (IconAlignment)
            {
                case ErrorIconAlignment.BottomLeft:
                    xLocation = IconControl.Location.X - IconBox.Width      - ICON_X_BUFFER;
                    yLocation = IconControl.Location.Y + IconControl.Height - IconBox.Height;
                    break;

                case ErrorIconAlignment.BottomRight:
                    xLocation = IconControl.Location.X + IconControl.Width  + ICON_X_BUFFER;
                    yLocation = IconControl.Location.Y + IconControl.Height - IconBox.Height;
                    break;

                case ErrorIconAlignment.MiddleLeft:
                    xLocation = IconControl.Location.X - IconBox.Width            - ICON_X_BUFFER;
                    yLocation = IconControl.Location.Y + (IconControl.Height / 2) - (IconBox.Height / 2);
                    break;

                case ErrorIconAlignment.MiddleRight:
                    xLocation = IconControl.Location.X + IconControl.Width        + ICON_X_BUFFER;
                    yLocation = IconControl.Location.Y + (IconControl.Height / 2) - (IconBox.Height / 2);
                    break;

                case ErrorIconAlignment.TopLeft:
                    xLocation = IconControl.Location.X - IconBox.Width - ICON_X_BUFFER;
                    yLocation = IconControl.Location.Y;
                    break;

                case ErrorIconAlignment.TopRight:
                    xLocation = IconControl.Location.X + IconControl.Width + ICON_X_BUFFER;
                    yLocation = IconControl.Location.Y;
                    break;
            }

            IconBox.Location = new Point(xLocation, yLocation);
        }
    }
}
