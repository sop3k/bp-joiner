using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace baseprotect
{
    enum SortOrder
    {
        SortAsc,
        SortDesc
    };

    class ExcelCleaner : IDisposable
    {
        Excel.Application excelApp;

        public ExcelCleaner()
        {
            excelApp = new Excel.Application();
            excelApp.Visible = true;
        }

        public ExcelCleaner(bool visible)
        {
            excelApp = new Excel.Application();
            excelApp.Visible = visible;
        }

        public string CleanExcelFile(string input, string worksheetName)
        {
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range allCells = null;
            Excel.Range toDelCells = null;

            try
            {
                workbook = OpenExcelWorkbook(input);
                worksheet = SelectWorksheet(workbook, worksheetName);

                if (worksheet == null)
                    worksheet = SelectWorksheet(workbook, 1);
                worksheet.Activate();

                UnFreezePanes(worksheet);
                allCells = GetUsedRange(worksheet);

                SortRange(allCells, SortOrder.SortDesc);
                object[,] values = GetRangeData(allCells);

                List<int> toDel = new List<int>();
                for (int row = 1; row <= values.GetLength(0); row++)
                {
                    int[] nulls = new int[values.GetLength(1) + 1];

                    for (int col = 1; col <= values.GetLength(1); col++)
                    {
                        if (values[row, col] == null)
                            nulls[col] = 1;
                    }

                    if (nulls.Sum() > (nulls.Length * 0.7) && nulls.Sum() < (nulls.Length - 1))
                    {
                        toDel.Add(row);
                    }
                }
                
                try
                {
                    toDelCells = GetRows(worksheet, toDel.ToArray());
                    DeleteRange(toDelCells);
                }
                catch(Exception e)    
                {
                    toDelCells.Value2 = "";
                }

                string path = new TempFile(".xls").Path;
                SaveWorkbookAs(workbook, path);
                return path;
            }
            finally
            {
                CloseRange(toDelCells);
                CloseRange(allCells);
                CloseWorksheet(worksheet);
                CloseWorkbook(workbook);
            }

        }

        public List<object[]> GetNonEmptyRows(object[,] values, double threshold)
        {
            List<object[]> notEmpty = new List<object[]>();
            for (int row = 1; row <= values.GetLength(0); row++)
            {
                int[] nulls = new int[values.GetLength(1) + 1];

                for (int col = 1; col <= values.GetLength(1); col++)
                {
                    if (values[row, col] == null)
                        nulls[col] = 1;
                }

                if (nulls.Sum() > (nulls.Length * threshold) && nulls.Sum() <= (nulls.Length - 1))
                    continue;

                notEmpty.Add((object[])Utils.GetOneDimension(values, row));
            }
            return notEmpty;
        }

        public void CloseRange(Excel.Range range)
        {
            if (range != null)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(range);
        }

        public void CloseWorkbook(Excel.Workbook workbook)
        {
            if (workbook != null)
            {
                workbook.Close(false, Type.Missing, Type.Missing);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbook);
            }
        }

        public void CloseWorksheet(Excel.Worksheet worksheet)
        {
            if (worksheet != null)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(worksheet);
        }

        public void CloseSheets(Excel.Sheets sheets)
        {
            if (sheets != null)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(sheets);
        }

        public void CloseWorkbooks(Excel.Workbooks workbooks)
        {
            if (workbooks != null)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbooks);
        }

        public string FindWorksheet(string filename, string[] patterns)
        {
            Excel.Workbook workbook = OpenExcelWorkbook(filename);
            Excel.Sheets sheets = workbook.Worksheets;

            foreach (string pattern in patterns)
            {
                Excel.Worksheet worksheet = null;
                for (int i = 1; i <= sheets.Count; i++)
                {
                    worksheet = SelectWorksheet(workbook, i);
                    if (worksheet != null)
                    {
                        string worksheetName = worksheet.Name;
                        if (Regex.IsMatch(worksheetName, pattern))
                        {
                            CloseSheets(sheets);
                            CloseWorksheet(worksheet);
                            CloseWorkbook(workbook);

                            return worksheetName;
                        }
                    }
                    CloseWorksheet(worksheet);
                }
            }

            if(sheets.Count >= 1)
            {
                Excel.Worksheet worksheet = SelectWorksheet(workbook, 1);
                string wName = worksheet.Name;

                CloseSheets(sheets);
                CloseWorksheet(worksheet);
                CloseWorkbook(workbook);

                return wName;
            }
            
            CloseSheets(sheets);
            CloseWorkbook(workbook);
            return "";
        }

        public Excel.Workbook OpenExcelWorkbook(string filename)
        {
            Excel.Workbook workbook = null;
            Excel.Workbooks workbooks = excelApp.Workbooks;

            System.Globalization.CultureInfo oldCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                workbook = workbooks.Open(filename, Type.Missing, false, Type.Missing,
                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                             Type.Missing, Type.Missing, Type.Missing,
                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                if (System.IO.Path.GetExtension(filename).ToLower() == ".csv")
                {
                    string connection = string.Format("TEXT;{0}", filename);

                    Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;
                    Excel.QueryTables tables = sheet.QueryTables;
                    Excel.Range destination = sheet.get_Range("A1", Type.Missing);
                    Excel.QueryTable table = tables.Add(connection, destination, Type.Missing);

                    try
                    {
                        table.TextFileCommaDelimiter = false;
                        table.Name = System.IO.Path.GetFileName(filename);
                        table.FieldNames = true;
                        table.RowNumbers = false;
                        table.FillAdjacentFormulas = false;
                        table.PreserveFormatting = true;
                        table.RefreshOnFileOpen = true;
                        table.RefreshStyle = Excel.XlCellInsertionMode.xlOverwriteCells;
                        table.TextFilePlatform = -535;
                        table.SavePassword = false;
                        table.SaveData = true;
                        table.AdjustColumnWidth = true;
                        table.RefreshPeriod = 0;
                        table.TextFilePromptOnRefresh = false;
                        table.TextFileStartRow = 1;
                        table.TextFileParseType = Excel.XlTextParsingType.xlDelimited;
                        table.TextFileTextQualifier = Excel.XlTextQualifier.xlTextQualifierSingleQuote;
                        table.TextFileConsecutiveDelimiter = false;
                        table.TextFileTabDelimiter = false;
                        table.TextFileSemicolonDelimiter = true;
                        table.TextFileCommaDelimiter = false;
                        table.TextFileSpaceDelimiter = false;
                        table.TextFileColumnDataTypes = new object[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                        table.TextFileTrailingMinusNumbers = true;
                        table.Refresh(true);

                        workbook.RefreshAll();
                    }
                    finally
                    {
                        CloseRange(destination);
                        CloseWorksheet(sheet);
                    }
                }

                return workbook;
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCulture;
                CloseWorkbooks(workbooks);
            }
        }

        public Excel.Worksheet SelectWorksheet(Excel.Workbook workbook, string pattern)
        {
            Excel.Worksheet worksheet = null;
            Excel.Sheets worksheets = workbook.Worksheets;
            try
            {
                for (int i = 1; i <= worksheets.Count; i++)
                {
                    worksheet = SelectWorksheet(workbook, i);
                    string worksheetName = worksheet.Name;
                    if (Regex.IsMatch(worksheetName, pattern))
                        return worksheet;
                }
                return null;
            }
            finally
            {
                CloseSheets(worksheets);
            }
        }

       public  Excel.Worksheet SelectWorksheet(Excel.Workbook workbook, int index)
        {
            Excel.Sheets worksheets = workbook.Worksheets;

            try
            {
                if (index > 0 && index <= worksheets.Count)
                    return (Excel.Worksheet)worksheets.get_Item(index);
                return null;
            }
            finally
            {
                CloseSheets(worksheets);
            }
        }

        public Excel.Range GetRow(Excel.Worksheet worksheet, int? index)
        {
            if (index.HasValue && index.Value > 0)
            {
                string range = String.Format("A{0}", index);
                return (Excel.Range)worksheet.get_Range(range, Type.Missing).EntireRow;
            }
            return null;
        }

        public Excel.Range GetRows(Excel.Worksheet worksheet, int[] indexes)
        {
            string[] rows = new string[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
            {
                rows[i] = string.Format("A{0}", indexes[i]);
            }

            Excel.Range range = null;
            Excel.Range entireRowRange = null;
            try
            {
                if (indexes.Length > 0)
                {
                    range = (Excel.Range)worksheet.get_Range(string.Join(";", rows), Type.Missing);
                    entireRowRange = (Excel.Range)range.EntireRow;
                }
                return entireRowRange;
            }
            finally
            {
                CloseRange(range);
            }
        }

        public Excel.Range GetRange(Excel.Worksheet worksheet, string leftTop, string bottomRight)
        {
            string range = String.Format("{0}:{1}", leftTop, bottomRight);
            return (Excel.Range)worksheet.get_Range(range, Type.Missing);
        }

        public object[,] GetRangeData(Excel.Range range)
        {
            return (object[,])range.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
        }

        public Excel.Range GetUsedRange(Excel.Worksheet worksheet)
        {
            return (Excel.Range)worksheet.UsedRange;
        }

        public void DeleteRange(Excel.Range range)
        {
            if (range != null)
                range.Delete(Excel.XlDirection.xlUp);
        }

        public Excel.Range SortRange(Excel.Range range, SortOrder order)
        {
            Microsoft.Office.Interop.Excel.XlSortOrder ord = Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending;
            if (order == SortOrder.SortDesc)
                ord = Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending;

            range.Sort(range.Columns[1, Type.Missing], ord, Type.Missing, Type.Missing, ord, Type.Missing, ord,
                       Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, Type.Missing, Type.Missing,
                       Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
                       Microsoft.Office.Interop.Excel.XlSortMethod.xlStroke,
                       Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
                       Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
                       Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);

            return range;
        }

        public void SaveWorkbookAs(Excel.Workbook workbook, string filename)
        {
            try{
                workbook.SaveAs( filename, Excel.XlFileFormat.xlWorkbookNormal,
                         Type.Missing, Type.Missing, false, Type.Missing,
                         Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, false,
                         Type.Missing, Type.Missing, Type.Missing );
                return;
            }catch ( Exception ){}

            workbook.SaveAs( filename, Excel.XlFileFormat.xlExcel9795,
                         Type.Missing, Type.Missing, false, Type.Missing,
                         Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, false,
                         Type.Missing, Type.Missing, Type.Missing );
        }

        public void UnFreezePanes(Excel.Worksheet worksheet)
        {
            Excel.Range range = null;
            try
            {
                range = GetUsedRange(worksheet);
                range.Select();
                excelApp.ActiveWindow.FreezePanes = false;
            }
            finally
            {
                CloseRange(range);
            }
        }

        public void Close()
        {
            performGC();
            if (excelApp != null)
            {
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
            }
            performGC();
        }

        private void performGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void Dispose()
        {
            Close();
        }
    }

}
