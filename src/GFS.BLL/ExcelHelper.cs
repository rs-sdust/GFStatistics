using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Windows.Forms;

namespace GFS.BLL
{
    /// <summary>
    /// Excel的辅助类
    /// </summary>
    public class ExcelHelper
    {
        public ExcelHelper()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //private DataSet ds = new DataSet();
        public DataTable ExcelToDataTable(string path)
        {
            try
            {
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    /* Initialize Workbook */
                    IWorkbook workbook = null;
                    string ExtensionName = Path.GetExtension(path).ToLower();
                    if (ExtensionName == ".xlsx")
                        workbook = new XSSFWorkbook(fs);
                    else if (ExtensionName == ".xls")
                        workbook = new HSSFWorkbook(fs);
                    /* Convert To DataTable */
                    ISheet sheet = workbook.GetSheetAt(0);
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                    IRow row;
                    /* Columns Name Written */
                    if (rows.MoveNext())
                    {
                        int Columns = 0;
                        row = (IRow)rows.Current;
                        for (; Columns < row.LastCellNum; Columns++)
                        {
                            ICell cell = row.GetCell(Columns);
                            string temp = (cell == null) ? null : cell.ToString();//读取列名temp
                            
                            //找出该列非空的单元格datacell
                            System.Collections.IEnumerator judge = sheet.GetRowEnumerator();
                            judge.MoveNext();
                            ICell datacell;
                            IRow datarow;
                            bool isnull = true;
                            while (judge.MoveNext())
                            {
                                datarow = (IRow)judge.Current;//需找到有数据的单元格
                                datacell = datarow.GetCell(Columns);
                                if (datacell != null)
                                {
                                    //判断单元格数据的格式，作为该列的数据格式
                                    if (datacell.CellType == CellType.String)
                                    {
                                        DataColumn dc = new DataColumn(temp, System.Type.GetType("System.String"));
                                        dt.Columns.Add(dc);
                                    }
                                    else if (datacell.CellType == CellType.Numeric)
                                    {
                                        DataColumn dc = new DataColumn(temp, System.Type.GetType("System.Double"));
                                        dt.Columns.Add(dc);
                                    }
                                    else 
                                    {
                                        MessageBox.Show("数据文件格式异常");
                                    }
                                    isnull = false;
                                    break;
                                }
                            }
                            if (isnull)//整列都没有数据
                            {
                                DataColumn dc = new DataColumn(temp);
                                dt.Columns.Add(dc);
                            }
                        }
                    }
                    /* Rows Value Written */
                    while (rows.MoveNext())
                    {
                        row = (IRow)rows.Current;
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < row.LastCellNum; i++)
                        {
                            ICell cell = row.GetCell(i);
                            if ( cell.CellType == CellType.String )
                                dr[i] = (cell == null) ? "" : cell.ToString();
                            else if (cell.CellType == CellType.Numeric)
                                dr[i] = (cell == null) ? 0 : Convert.ToDouble(cell.ToString());
                        }
                        dt.Rows.Add(dr);
                    }
                    //ds.Reset();///If you don't add this command, each event will add a new table
                    //ds.Tables.Add(dt);///You can choose to return a DataSet
                }
                return dt;
            }
            catch
            {
                /**********************************
                 * 1.This file has been opened.
                 * 2.Incompatible format.
                **********************************/
                return null;
            }
        }

        public bool DataTableToExcel(string path, string SheetName, DataTable dt, bool ColumnWritten)
        {
            if (dt != null)
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        /* Initialize Workbook */
                        IWorkbook workbook = null;
                        string ExtensionName = Path.GetExtension(path).ToLower();
                        if (ExtensionName == ".xlsx")
                            workbook = new XSSFWorkbook();
                        else if (ExtensionName == ".xls")
                            workbook = new HSSFWorkbook();
                        /* Convert To Excel */
                        ISheet sheet = workbook.CreateSheet(SheetName);
                        /* Columns Name Written */
                        int count;
                        if (ColumnWritten)
                        {
                            IRow row = sheet.CreateRow(0);
                            for (int i = 0; i < dt.Columns.Count; ++i)
                                row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                            count = 1;
                        }
                        else
                            count = 0;
                        /* Excel Cell Value Written */
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            IRow row = sheet.CreateRow(count);
                            for (int j = 0; j < dt.Columns.Count; ++j)
                            {
                                ICell cell = row.CreateCell(j);
                                //判断单元格是否为空
                                string isempty = Convert.ToString(dt.Rows[i][j]);
                                if (isempty != null && !isempty.Equals(""))
                                {
                                    //判断单元格格式
                                    Type type = dt.Columns[j].DataType;
                                    if (type == typeof(string))
                                    {
                                        cell.SetCellType(CellType.String);
                                        cell.SetCellValue(Convert.ToString(dt.Rows[i][j]));
                                    }
                                    else if (type == typeof(double))
                                    {
                                        cell.SetCellType(CellType.Numeric);
                                        cell.SetCellValue(Convert.ToDouble(dt.Rows[i][j]));
                                    }
                                }
                                else 
                                {
                                    //判断单元格格式
                                    Type type = dt.Columns[j].DataType;
                                    if (type == typeof(string))
                                    {
                                        cell.SetCellType(CellType.String);
                                    }
                                    else if (type == typeof(double))
                                    {
                                        cell.SetCellType(CellType.Numeric);
                                    }
                                }
                            }
                            ++count;
                        }
                        workbook.Write(fs);
                    }
                    return true;
                }
                catch
                {
                    /**********************************
                        * 1.This file has been opened.
                        * 2.Data is empty.
                    **********************************/
                    return false;
                }
            }
            else
                return false;
        }
    
    
    }
}
