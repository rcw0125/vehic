using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VehIC_WF
{
    public class ExcelFile
    {
        private HSSFWorkbook hssfworkbook = null;
        private  ISheet sheet1 = null;
        private string exlTitle = "";

        public ExcelFile(string exlTitle)
        {
            this.exlTitle = exlTitle;

            this.hssfworkbook = new HSSFWorkbook();

            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "邢钢";
            hssfworkbook.DocumentSummaryInformation = dsi;

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = exlTitle;
            hssfworkbook.SummaryInformation = si;

            this.sheet1 = hssfworkbook.GetSheet("Sheet1");
        }

        public void SetCellValue(int row, int col, string val)
        {
            if (sheet1 == null)
            {
                if (hssfworkbook != null)
                    sheet1 = hssfworkbook.CreateSheet();
            }
            if (sheet1 != null)
            {
                IRow r = sheet1.GetRow(row);
                if (r == null)
                    r = sheet1.CreateRow(row);
                ICell cell = r.GetCell(col);
                if (cell == null)
                    cell = r.CreateCell(col);
                cell.SetCellValue(val);
            }
        }

        public void Save()
        {
            if (hssfworkbook != null)
            {
                FileStream xlsfile = new FileStream(exlTitle + ".xls", FileMode.Create);
                hssfworkbook.Write(xlsfile);
                xlsfile.Close();
            }
        }
    }
}
