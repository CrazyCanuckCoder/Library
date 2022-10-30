using System.Collections.Generic;

namespace Library
{
    public class DataGridSettings
    {
        public bool IncludeColumnHeaders    { get; set; }
        public bool ExportAllColumns        { get; set; }
        public List<string> ColumnsToExport { get; set; }

        public DataGridSettings(bool IncludeHeaders, bool SaveAllColumns, List<string> ColumnsToSave)
        {
            IncludeColumnHeaders = IncludeHeaders;
            ExportAllColumns     = SaveAllColumns;
            ColumnsToExport      = ColumnsToSave;
        }
    }
}
