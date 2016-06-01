using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using Excel = Microsoft.Office.Interop.Excel;

namespace baseprotect
{
    class InfoImporter
    {
        private ExcelCleaner excel;

        public InfoImporter()
        {
            excel = new ExcelCleaner(true);
        }

        public void Import(string filename)
        {
            DoImport(filename);       
        }

        private void DoImport(string filename)
        {
            Excel.Workbook workbook = excel.OpenExcelWorkbook(filename);
            Excel.Worksheet worksheet = excel.SelectWorksheet(workbook, 1);

            excel.UnFreezePanes(worksheet);

            Excel.Range range = excel.GetRows(worksheet, new int[] { 2, 3 });
            excel.DeleteRange(range);
            
            Excel.Range cell = excel.GetRow(worksheet, 1);
            cell.Value2 = String.Empty;

            TempFile file = new TempFile(".xls");
            excel.SaveWorkbookAs(workbook, file.Path);
            string worksheetName = worksheet.Name;
            
            excel.CloseRange(range);
            excel.CloseRange(cell);
            
            excel.CloseWorksheet(worksheet);
            excel.CloseWorkbook(workbook);
            
            excel.Close();

            ExcelReader reader = new ExcelReader(file.Path);
            reader.DateColumns = new string[] { "WARRANT_DATE", "PRODUCT_RELEASE_DATE"};

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.Zero))
            {
                SQLiteTableWriter<Info> writer = new SQLiteTableWriter<Info>(Config.DB);
                //writer.WriteTable(Config.DB.Info, infoTable, null);

                scope.Complete();
            }
        }
    }
}
