namespace Library
{
    public delegate void ControlSelectedEventHandler(object sender, ControlSelectedEventArgs e);

    public delegate void ButtonSelectedEventHandler(object sender, ButtonSelectedEventArgs e);

    public delegate void FileChosenEventHandler(object sender, FileChosenEventArgs e);

    public delegate void MillerItemActionEventHandler(object sender, MillerItemEventArgs e);

    public delegate void MillerItemMovedEventHandler(object sender, MillerItemMovedEventArgs e);

    public delegate void DateRangeChangedEventHandler(object sender, DateRangeChangedEventArgs e);

}