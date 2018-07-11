using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class DataGridSettings
    {
        public bool IncludeColumnHeaders    { get; set; }
        public bool ExportAllColumns        { get; set; }
        public List<string> ColumnsToExport { get; set; }

        public DataGridSettings(bool IncludeHeaders, bool SaveAllColumns, List<string> ColumnsToSave)
        {
            this.IncludeColumnHeaders = IncludeHeaders;
            this.ExportAllColumns     = SaveAllColumns;
            this.ColumnsToExport      = ColumnsToSave;
        }
    }
}
