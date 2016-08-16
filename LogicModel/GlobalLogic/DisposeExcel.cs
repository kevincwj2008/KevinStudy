using org.in2bits.MyXls;
using System.Data;
using System.IO;
using System.Web;

namespace XFCompany.CIPnetWeb.LogicModel
{
    public class DisposeExcel
    {
        public DisposeExcel()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 从DataTable导出Excel
        /// <summary>
        /// 从DataTable导出Excel
        /// </summary>
        /// <param name="dt">要导出的数据源(Datatable)</param>
        /// <param name="fileName">导出后存储的文件名，注意：不是路径，也不需要包括后缀名！</param>
        /// <param name="filePath">将文件导出到哪个相对目录，注意：相对路径即可，不需要填写最后的文件名，例如：~/upload/</param>
        /// <param name="sheetName">在Excel中的状态栏显示的名字</param>
        public static string DataTableToExcel(DataTable Dt, string fileName, string filePath, string sheetName)
        {
            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//状态栏标题名称
            Cells Cells = sheet.Cells;
            int RowIndex = 1;
            int ColIndex = 0;
            foreach (DataColumn Col in Dt.Columns)
            {
                ColIndex++;
                //sheet.Cells.AddValueCell(1,colIndex,col.ColumnName);//添加XLS标题行
                Cells.Add(1, ColIndex, Col.ColumnName);
            }

            foreach (DataRow row in Dt.Rows)
            {
                RowIndex++;
                ColIndex = 0;
                foreach (DataColumn Col in Dt.Columns)
                {
                    ColIndex++;
                    //sheet.Cells.AddValueCell(rowIndex, colIndex, row[col.ColumnName].ToString());//将数据添加到xls表格里
                    //Cell cell= cells.AddValueCell(rowIndex, colIndex, Convert.ToDouble(row[col.ColumnName].ToString()));//转换为数字型
                    Cell Cell = Cells.Add(RowIndex, ColIndex, row[Col.ColumnName].ToString());
                    //如果你数据库里的数据都是数字的话 最好转换一下，不然导入到Excel里是以字符串形式显示。
                    //cell.Font.FontFamily = FontFamilies.Roman; //字体
                    //cell.Font.Bold = true; //字体为粗体 
                    Cell.Font.Weight = FontWeight.Bold;
                }
            }
            xls.FileName = fileName;//文件名
            filePath = HttpContext.Current.Server.MapPath(filePath);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            xls.Save(filePath, true);//保存位置
            return filePath + "\\" + xls.FileName;
        }
        #endregion
    }


}