namespace Library.WinForms
{
    public interface IBaseDataClass
    {
        string ErrorMessage { get; }
        bool Save();
        bool Delete();
    }
}
