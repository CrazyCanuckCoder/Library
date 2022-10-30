using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Library
{
    public static class Export
    {
        /// <summary>
        /// Writes the data of a DataTable to a comma separated values text file.
        /// </summary>
        /// 
        /// <param name="FilePath">
        /// The full path and name of the file to write.
        /// </param>
        /// 
        /// <param name="SourceTable">
        /// A DataTable containing the data to export.
        /// </param>
        /// 
        /// <exception cref="Exception" />
        /// 
        public static void DataTableToCSV(string FilePath, DataTable SourceTable)
        {
            DataTableToCSV(FilePath, SourceTable, true, null);
        }


        /// <summary>
        /// Writes the data of a DataTable to a comma separated values text file.
        /// </summary>
        /// 
        /// <param name="FilePath">
        /// The full path and name of the file to write.
        /// </param>
        /// 
        /// <param name="SourceTable">
        /// A DataTable containing the data to export.
        /// </param>
        /// 
        /// <param name="WriteColumnHeaders">
        /// True to write the name of the columns to the file; false otherwise.
        /// </param>
        /// 
        /// <exception cref="Exception" />
        /// 
        public static void DataTableToCSV(string FilePath, DataTable SourceTable, bool WriteColumnHeaders)
        {
            DataTableToCSV(FilePath, SourceTable, WriteColumnHeaders, null);
        }



        /// <summary>
        /// Writes the data of a DataTable to a comma separated values text file.
        /// </summary>
        /// 
        /// <param name="FilePath">
        /// The full path and name of the file to write.
        /// </param>
        /// 
        /// <param name="SourceTable">
        /// A DataTable containing the data to export.
        /// </param>
        /// 
        /// <param name="WriteColumnHeaders">
        /// True to write the name of the columns to the file; false otherwise.
        /// </param>
        /// 
        /// <param name="ColumnsToInclude">
        /// A list of the names of the columns to include in the output.  Use
        /// null to indicate all columns should be added.
        /// </param>
        /// 
        /// <exception cref="Exception" />
        /// 
        public static void DataTableToCSV(string FilePath, DataTable SourceTable, bool WriteColumnHeaders, List<string> ColumnsToInclude)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                if (SourceTable != null && SourceTable.Rows.Count > 0)
                {
                    //  Delete file if it exists or create it when it doesn't exist.

                    using (var writer = new StreamWriter(FilePath, false))
                    {
                        DataTableToCSV(writer, SourceTable, WriteColumnHeaders, ColumnsToInclude);
                    }
                }
                else
                {
                    throw new Exception("No data to export.");
                }
            }
            else
            {
                throw new Exception("Invalid file name or path.");
            }
        }


        /// <summary>
        /// Writes the data of a DataTable to a comma separated values text file.
        /// </summary>
        /// 
        /// <param name="CSVWriter">
        /// The stream to write the CSV file to.  The calling method is responsible for creating, opening and 
        /// ensuring the stream is closed when this method completes.
        /// </param>
        /// 
        /// <param name="SourceTable">
        /// A DataTable containing the data to export.
        /// </param>
        /// 
        /// <param name="WriteColumnHeaders">
        /// True to write the name of the columns to the file; false otherwise.
        /// </param>
        /// 
        /// <param name="ColumnsToInclude">
        /// A list of the names of the columns to include in the output.  Use
        /// null to indicate all columns should be added.
        /// </param>
        /// 
        /// <exception cref="Exception" />
        /// 
        public static void DataTableToCSV(StreamWriter CSVWriter, DataTable SourceTable, bool WriteColumnHeaders, List<string> ColumnsToInclude)
        {
            if (SourceTable != null && SourceTable.Rows.Count > 0)
            {
                var lineBuilder = new StringBuilder();

                if (WriteColumnHeaders)
                {
                    //  Write the columns as a header line.

                    if (ColumnsToInclude == null)
                    {
                        foreach (DataColumn currColumn in SourceTable.Columns)
                        {
                            lineBuilder.Append(currColumn.ColumnName.Replace(" ", "-") + ",");
                        }
                    }
                    else
                    {
                        foreach (string columnName in ColumnsToInclude)
                        {
                            lineBuilder.Append(columnName.Replace(" ", "-") + ",");
                        }
                    }

                    CSVWriter.WriteLine(lineBuilder.ToString());
                }

                //  Write each row to the file.

                foreach (DataRow currRow in SourceTable.Rows)
                {
                    lineBuilder = new StringBuilder();

                    if (ColumnsToInclude == null)
                    {
                        foreach (DataColumn currColumn in SourceTable.Columns)
                        {
                            lineBuilder.Append(GetColumnValue(currRow, currColumn.ColumnName));
                        }
                    }
                    else
                    {
                        foreach (string columnName in ColumnsToInclude)
                        {
                            lineBuilder.Append(GetColumnValue(currRow, columnName));
                        }
                    }

                    CSVWriter.WriteLine(lineBuilder.ToString());
                }
            }
            else
            {
                throw new Exception("No data to export.");
            }
        }

        /// <summary>
        /// Gets the value for a specified column and adds a delimiter.
        /// </summary>
        /// 
        /// <param name="CurrentRow">
        /// The DataRow containing the specified column.
        /// </param>
        /// 
        /// <param name="ColumnName">
        /// The name of the column to get the value from.
        /// </param>
        /// 
        /// <returns>
        /// A string containing the column value and a delimiter or just a delimiter
        /// if the column has no value.
        /// </returns>
        /// 
        private static string GetColumnValue(DataRow CurrentRow, string ColumnName)
        {
            string colValue = ",";

            if (CurrentRow[ColumnName] != null && CurrentRow[ColumnName] != DBNull.Value)
            {
                bool addQuotes = CurrentRow[ColumnName] is string;
                colValue = (addQuotes ? "\"" : "") + CurrentRow[ColumnName].ToString() +
                           (addQuotes ? "\"" : "") + ",";
            }

            return colValue;
        }

    }
}