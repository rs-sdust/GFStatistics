using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using System.Data;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.esriSystem;
using GFS.BLL;

namespace GFS.ClassificationBLL
{
   
    public class StatisticsResult
    {
        /// <summary>
        /// 结果统计
        /// </summary>
        /// <param name="file">输入栅格</param>
        /// <param name="DTable">统计数据表</param>
        /// <returns>返回信息</returns>
        public bool Statistics(string file, out DataTable DTable)
        {
            DTable = null;
            long blockCount = 0;
            bool result;
            string sMsg;
            try
            {
                FileInfo fi = new FileInfo(file);
                string fileName = fi.Name;
                string filePath = fi.DirectoryName;
                //打开栅格数据
                IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
                IWorkspace workspace = workspaceFactory.OpenFromFile(filePath, 0); //filePath栅格数据存储路径
                if (workspace == null)
                {
                    MessageBox.Show("Could not open the workspace.");
                }
                IRasterWorkspace rastWork = (IRasterWorkspace)workspace;
                //IRasterDataset rasterDatst = rastWork.OpenRasterDataset(fileName);
                //IRasterBandCollection rasterbandCollection = (IRasterBandCollection)rasterDatst;
                string fName = fileName.Substring(0, fileName.LastIndexOf("."));
                if (File.Exists(@filePath +"\\"+ fName + ".hdr"))
                {
                    //创建栅格属性表
                    if (EnviVars.instance.GpExecutor.RasterTable(file, out sMsg))
                    {
                        IRasterDataset rasterDatst = rastWork.OpenRasterDataset(fileName);
                        IRasterBandCollection rasterbandCollection = (IRasterBandCollection)rasterDatst;
                        for (int i = 0; i < rasterbandCollection.Count; i++)
                        {
                            //像素
                            IRasterBand rasterBand = rasterbandCollection.Item(i);
                            IRawPixels rawPixels = (IRawPixels)rasterBand;
                            IRasterProps rasterProps = (IRasterProps)rawPixels;
                            //像元大小
                            double blockX = (double)rasterProps.MeanCellSize().X;
                            double blockY = (double)rasterProps.MeanCellSize().Y;
                            double blockArea = blockX * blockY;
                            //栅格属性表
                            ITable table = rasterBand.AttributeTable;
                            DataTable pTable = new DataTable();
                            for (int j = 0; j < table.Fields.FieldCount; j++)
                            {
                                pTable.Columns.Add(table.Fields.get_Field(j).Name);

                            }
                            pTable.Columns[0].ColumnName = "作物名称";
                            pTable.Columns[1].ColumnName = "像元值";
                            pTable.Columns[2].ColumnName = "像元个数(points)";
                            pTable.Columns.Add("所占比例");
                            pTable.Columns.Add("所占面积(㎡)");
                            ICursor pCursor = table.Search(null, false);
                            //行数
                            IRow pRrow = pCursor.NextRow();
                            string Value = RDSCHA((@filePath + "\\" + fName + ".hdr"), "points");
                            string[] strs = Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int y = 0;
                            while (pRrow != null)
                            {
                                DataRow pRow = pTable.NewRow();

                                for (int k = 1; k < pRrow.Fields.FieldCount; k++)
                                {
                                    pRow[k] = pRrow.get_Value(k).ToString();
                                }
                                blockCount += long.Parse(pRow[2].ToString());//像元个数统计
                                pRow[0] = strs[Convert.ToInt32(pRrow.get_Value(1))].Trim();
                                pRow[4] = double.Parse(pRow[2].ToString()) * blockArea;
                                pTable.Rows.Add(pRow);
                                pRrow = pCursor.NextRow();
                            }
                            DataRow row = pTable.NewRow();
                            for (int m = 0; m < pTable.Rows.Count; m++)
                            {
                                pTable.Rows[m]["所占比例"] = (double.Parse(pTable.Rows[m][2].ToString()) / blockCount).ToString("P3");
                                double s = double.Parse(pTable.Rows[m][2].ToString());
                            }
                            DTable = pTable;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(sMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    IRasterDataset rasterDatst = rastWork.OpenRasterDataset(fileName);
                    IRasterBandCollection rasterbandCollection = (IRasterBandCollection)rasterDatst;
                    for (int i = 0; i < rasterbandCollection.Count; i++)
                    {
                        //像素
                        IRasterBand rasterBand = rasterbandCollection.Item(i);
                        IRawPixels rawPixels = (IRawPixels)rasterBand;
                        IRasterProps rasterProps = (IRasterProps)rawPixels;
                        
                        double blockX = (double)rasterProps.MeanCellSize().X;
                        double blockY = (double)rasterProps.MeanCellSize().Y;
                        double blockArea = blockX * blockY;//像元大小
                        ITable table = rasterBand.AttributeTable;//栅格属性表
                        DataTable pTable = new DataTable();
                        for (int j = 1; j < table.Fields.FieldCount; j++)
                        {
                            pTable.Columns.Add(table.Fields.get_Field(j).Name);
                            string t = table.Fields.get_Field(j).Name;
                        }
                        pTable.Columns[1].ColumnName = "像元个数(points)";
                        pTable.Columns.Add("所占比例");
                        pTable.Columns.Add("所占面积(㎡)");
                        ICursor pCursor = table.Search(null, false);
                        IRow pRrow = pCursor.NextRow();

                        while (pRrow != null)
                        {

                            DataRow pRow = pTable.NewRow();

                            for (int k = 1; k < pRrow.Fields.FieldCount; k++)
                            {
                                object l = pRrow.get_Value(k).ToString();
                                pRow[k-1] = pRrow.get_Value(k).ToString();

                            }
                            blockCount += long.Parse(pRow[1].ToString());//像元个数统计
                            pRow[3] = double.Parse(pRow[1].ToString()) * blockArea;
                            pTable.Rows.Add(pRow);
                            pRrow = pCursor.NextRow();
                        }
                        DataRow row = pTable.NewRow();
                        for (int m = 0; m < pTable.Rows.Count; m++)
                        {
                            pTable.Rows[m]["所占比例"] = (double.Parse(pTable.Rows[m][1].ToString()) / blockCount).ToString("P3");
                            double s = double.Parse(pTable.Rows[m][1].ToString());
                        }
                        DTable = pTable;
                    } 
                }
            result = true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               result = false;
            }
            return result ;
        }
        /// <summary>
        /// 从文本中读取字符串
        /// </summary>
        /// <param name="file">文件名</param>
        /// <param name="Key">关键字</param>
        /// <returns></returns>
        private string RDSCHA(string file, string Key)
        {
            StreamReader sr = new StreamReader(file, Encoding.Default);
            try
            {
                String line;
                //List<string> mList = new List<string>();
                string sValue = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {   
                    if (line.Contains(Key))
                    { 
                        sValue += line;
                    }
                    else
                        continue;
                }
                int start = sValue.IndexOf("}");
                sValue = sValue.Substring(0, start);
                return sValue;
            }
            catch (Exception ex)
            {
                return string.Empty;
                throw ex;
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }
        }
       
    }
}
