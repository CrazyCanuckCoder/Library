#region

using System;
using System.Windows.Forms;

#endregion

namespace Library
{
    public class ControlSelectedEventArgs : EventArgs
    {
        public Control ControlSelected { get; set; }

        public ControlSelectedEventArgs(Control SelectedControl)
        {
            ControlSelected = SelectedControl;
        }
    }

    public class ButtonSelectedEventArgs : EventArgs
    {
        public RadioButton ButtonSelected { get; set; }

        public ButtonSelectedEventArgs(RadioButton SelectedButton)
        {
            ButtonSelected = SelectedButton;
        }
    }

    public class FileChosenEventArgs : EventArgs
    {
        public string FilePath { get; set; }
        public FileSelectMode OriginalMode { get; set; }

        public FileChosenEventArgs(string FilePath, FileSelectMode ModeChosen)
        {
            this.FilePath = FilePath;
            OriginalMode = ModeChosen;
        }
    }

    public class MillerItemEventArgs : EventArgs
    {
        public IMillerItem MillerItem { get; set; }

        public MillerItemEventArgs(IMillerItem NewMillerItem)
        {
            MillerItem = NewMillerItem;
        }
    }

    public class MillerItemMovedEventArgs : EventArgs
    {
        public Control MovedItem    { get; set; }
        public Control ReplacedItem { get; set; }

        public MillerItemMovedEventArgs(Control NewMovedItem, Control NewReplacedItem)
        {
            MovedItem    = NewMovedItem;
            ReplacedItem = NewReplacedItem;
        }
    }

    public class DateRangeChangedEventArgs : EventArgs
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateRangeChangedEventArgs(DateTime NewStartDate, DateTime NewEndDate)
        {
            StartDate = NewStartDate;
            EndDate   = NewEndDate;
        }
    }

}