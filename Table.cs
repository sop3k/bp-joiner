using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace baseprotect
{
    public class Table
    {
        List<Row> rows;

        public Table()
        {
            rows = new List<Row>();
        }

        public Table(string filename, string table)
        {
            ExcelCleaner cleaner = new ExcelCleaner();
            string name = cleaner.FindWorksheet(filename,
                new string[] { "TOI", "Sniper", "Tabelle*" });
            ExcelReader reader = new ExcelReader();
            reader.Open(filename);
        }

        public Table Join(Table table, string[] joinCriteria)
        {
            Table result = new Table();

            for (int lRow = 0; lRow < this.Count; lRow++)
            {
                ValueHolder[] lRowJoinValues = this[lRow][joinCriteria];
                for (int rRow = 0; rRow < table.Count; rRow++)
                {
                    ValueHolder[] rRowJoinValues = table[rRow][joinCriteria];
                    if (ArraysContainEquals(rRowJoinValues, lRowJoinValues))
                    {
                        Row row = new Row(this[lRow], table[rRow]);
                        result.AddRow(row);
                    }
                }
            }

            return result;
        }

        public Row this[int index]
        {
            get
            {
                return rows[index];
            }
        }

        public void AddRow(Row row)
        {
            rows.Add(row);
        }

        public void DeleteRow(int index)
        {
            rows.RemoveAt(index);
        }

        private bool ArraysContainEquals(ValueHolder[] leftRow, ValueHolder[] rightRow)
        {
            if (leftRow.Length != rightRow.Length)
                return false;

            for (int i = 0; i < leftRow.Length; i++)
            {
                if (!leftRow[i].Equals(rightRow[i]))
                    return false;
            }
            return true;
        }

        public static Table JoinTables(Table[] tables, string[] joinColumns)
        {
            if (tables.Length >= 2)
            {
                int index = 1;
                Table partialyJoined = tables[0].Join(tables[1], joinColumns);
                while (++index < tables.Length)
                {
                    partialyJoined.Join(tables[index], joinColumns);
                }
                return partialyJoined;
            }
            else if (tables.Length == 1)
            {
                return tables[0];
            }
            return null;
        }

        public Table RemoveDuplicates(string[] columns)
        {
            Table result = new Table();
            foreach (Row row in rows)
            {
                if (!result.ContainsRow(row, columns))
                    result.AddRow(row);
            }
            return result;
        }

        public void RemoveColumn(string column)
        {
            rows.ForEach((row) => { row.RemoveValue(column); });
        }

        public bool ContainsRow(Row row, string[] columns)
        {
            ValueHolder[] values = row[columns];
            foreach (Row r in rows)
            {
                if (ArraysContainEquals(values, r[columns]))
                    return true;
            }
            return false;
        }

        public int Count
        {
            get { return rows.Count; }
        }

        public IEnumerable<Row> Rows
        {
            get
            {
                return rows;
            }
        }
    }
}
