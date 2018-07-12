using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class BulkCopy
    {
        public BulkCopy(string NewConnectionString)
        {
            this.ConnectionString = NewConnectionString;
        }

        /// <summary>
        /// The connection string to use when connecting to the SQL Server.
        /// </summary>
        /// 
        public string ConnectionString { get; private set; }




        /// <summary>
        /// Inserts the elements of a List into a table in a database.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the list elements.
        /// </typeparam>
        /// 
        /// <remarks>
        /// The elements of the list must have properties with names corresponding to columns in the database
        /// table and each property's data type must be compatible with the associated table column.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"></exception>
        /// 
        /// <param name="DataList">
        /// Contains elements to be inserted into a database table.
        /// </param>
        /// 
        /// <param name="SqlTableName">
        /// The name of the table in the database.
        /// </param>
        /// 
        public void InsertData<T>(List<T> DataList, string SqlTableName)
        {
            if (!string.IsNullOrEmpty(SqlTableName))
            {
                if (DataList != null && DataList.Count > 0)
                {
                    this.InsertData(SqlTableName, DataList.ConvertToDataTable());
                }
                else
                {
                    throw new ArgumentException("List is null or has no data.");
                }
            }
            else
            {
                throw new ArgumentException("Name of SQL table is empty or null.");
            }
        }

        /// <summary>
        /// Inserts the rows of an in-memory DataTable into a table in a database.
        /// </summary>
        /// 
        /// <remarks>
        /// The in-memory DataTable must contain columns that correspond to the database's table's columns
        /// including matching the column's name and data type.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"></exception>
        /// 
        /// <param name="SqlTableName">
        /// The name of the table in the database.
        /// </param>
        /// 
        /// <param name="DataToInsert">
        /// The information to insert into the database's table.
        /// </param>
        /// 
        public void InsertData(string SqlTableName, DataTable DataToInsert)
        {
            if (!string.IsNullOrEmpty(SqlTableName))
            {
                if (DataToInsert != null && DataToInsert.Rows.Count > 0)
                {
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(this.ConnectionString))
                    {
                        bulkcopy.BulkCopyTimeout      = (int) TimeSpan.FromMinutes(10).TotalSeconds;
                        bulkcopy.DestinationTableName = SqlTableName;
                        bulkcopy.WriteToServer(DataToInsert);
                    }
                }
                else
                {
                    throw new ArgumentException("DataTable is null or has no data.");
                }
            }
            else
            {
                throw new ArgumentException("Name of SQL table is empty or null.");
            }
        }
    }
}
