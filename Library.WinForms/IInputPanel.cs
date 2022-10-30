namespace Library.WinForms
{
    public interface IInputPanel
    {
        string ActionError { get; }
        EntryType DataEntryType { get; set; }
        string EntryError { get; }
        IBaseDataClass SourceInfo { get; set; }

        bool DeleteData();
        bool SaveData();
        bool VerifyInput();
    }
}