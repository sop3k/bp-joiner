using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace baseprotect
{

    class ExcelReader : IDisposable
    {
        const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;CharSet=utf8""";

        OleDbConnection connection;
        string filename;

        public ExcelReader()
        {
        }

        public ExcelReader(string filename)
            : this()
        {
            Open(filename);
        }

        public DbConnection Open(string file)
        {
            filename = file;
            connection = new OleDbConnection();
            connection.ConnectionString = string.Format(connectionString, filename);
            return OpenConnection();
        }

        public DbConnection OpenConnection()
        {
            connection.Open();
            return connection;
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public string[] ReadWorksheetColumns(string name)
        {
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT TOP 1 * FROM [{0}$];", name);

            using (OleDbDataReader dr = cmd.ExecuteReader())
            {
                if (!dr.HasRows)
                    return null;

                dr.Read();
                string[] columns = new string[dr.FieldCount];

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    columns[i] = dr.GetName(i);
                }

                return columns;
            }
        }

        public string ChangeEmptyCollumnName(string column, Dictionary<int, string> filler)
        {
            string pattern = @"^[Ff](?<Index>\d+)";
            Match match = Regex.Match(column, pattern);
            
            if(match.Success)
            {
                int index = int.Parse(match.Groups["Index"].ToString());
                if(filler.ContainsKey(index))
                    return filler[index];
                return column;
            }

            return column;
        }

        private bool allEmpty(OleDbDataReader dr)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                object v = dr[i];

                if (v == null || v.GetType() == typeof(System.DBNull))
                    continue;
                else
                    return false;
            }
            return true;
        }

        public Table ReadWorksheet(string name, ProviderFormatInfo pfi)
        {
            return ReadWorksheet(name, null, pfi);
        }

        public Table ReadWorksheet(string Name, string selector, ProviderFormatInfo pfi)
        {
            string[] columns = ReadWorksheetColumns(Name);
            
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM [{0}$];", Name);
            
            Exception lastException = null;

            string name = Name;
            if (!String.IsNullOrEmpty(selector))
                name = selector;

            while(true)
            {
                try
                {
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if ( !dr.HasRows )
                            return null;

                        Table table = new Table();

                        while ( dr.Read() )
                        {
                            if (allEmpty(dr))
                                continue;

                            Row row = new Row();

                            foreach (string column in columns )
                            {
                                String columnName = pfi.TranslateColumn(row, Regex.Replace(column, @"^\W+|\W+$", ""));

                                if (String.IsNullOrEmpty(columnName))
                                    continue;

                                object value = dr[column];
                                
                                if (typeof(System.DBNull) == value.GetType()
                                    || String.IsNullOrEmpty(value.ToString().Trim('0')))
                                    value = null;

                                /*Handle Date and Time in one column*/
                                if (columnName == "TIME")
                                {
                                    if (row["DATE"].IsNull() && value != null && !value.Equals("")){
                                        row.Add("DATE", GuessHolder(pfi, "DATE", value));
                                    }

                                    if (value == null || value.Equals(""))
                                        value = row["DATE"].GetValue<DateTime>();
                                }

                                if (value == null || value.Equals(""))
                                    if (!row[columnName].IsNull())
                                        continue;

                                row.Add(columnName, GuessHolder(pfi, columnName, value));
                            }
                            table.AddRow( row );
                        }

                        lastException = null;
                        return table;
                    }
                }
                catch ( Exception e )
                {
                    lastException = e;
                    continue;
                }
            }

            if ( lastException != null )
                throw new Exception(lastException.Message, lastException);

            return null;
        }

        public ValueHolder GuessHolder(ProviderFormatInfo tr, string column, object value)
        {
            if (DateColumns != null && DateColumns.Contains(column))
                return new DateHolder(value);

            switch (column)
            {
                case "IP":
                    return new IPHolder(value);

                case "DATE":
                    return new DateHolder(value);

                case "TIME":
                    return new TimeHolder(value);

                default:
                    return new ValueHolder(value);
            }
        }

        public string FileName()
        {
            return filename;
        }

        public string[] DateColumns
        {
            get;
            set;
        }

        public void Dispose()
        {
            if(connection.State == System.Data.ConnectionState.Open)
                CloseConnection();
        }
    }
}
