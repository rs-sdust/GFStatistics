using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GFS.BLL;


namespace GFS.CarbonBLL
{
    public class SoilCarbon
    {
         /// <summary>
        /// 土壤分类文件
        /// </summary>
        private string soilFile = string.Empty;
        /// <summary>
        /// 读取的土壤属性表
        /// </summary>
        private DataTable soilTable = null;
        /// <summary>
        /// 土壤类型字段名
        /// </summary>
        private string soilType = string.Empty;
        /// <summary>
        /// 土壤面积字段名
        /// </summary>
        private string soilArea = string.Empty;
        /// <summary>
        /// 土壤面积统计表
        /// </summary>
        private DataTable AreaTable = null;
        /// <summary>
        /// 土壤厚度字段名
        /// </summary>
        private string soilDepth = string.Empty;
        /// <summary>
        /// 土壤厚度统计表
        /// </summary>
        private DataTable depthTable = null;
        /// <summary>
        /// 土壤容重字段名
        /// </summary>
        private string SoilDensity = string.Empty;
        /// <summary>
        /// 土壤容重统计表
        /// </summary>
        private DataTable densityTable = null;
        /// <summary>
        /// 土壤有机物含量
        /// </summary>
        private string soilOrganics = string.Empty;
        /// <summary>
        /// 土壤有机物含量统计表
        /// </summary>
        private DataTable organicsTable = null;
        /// <summary>
        /// 土壤砾石含量
        /// </summary>
        private string soilGravel = string.Empty;
        /// <summary>
        /// 土壤砾石含量统计表
        /// </summary>
        private DataTable gravelTable = null;
        /// <summary>
        /// 土壤碳储量文件
        /// </summary>
        private string soilCarbon = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoilCarbon"/> class.
        /// </summary>
        /// <param name="soilFile">The soil file.</param>
        /// <param name="soilType">Type of the soil.</param>
        /// <param name="soilDepth">The soil depth.</param>
        /// <param name="SoilDensity">The soil density.</param>
        /// <param name="soilOrganics">The soil organics.</param>
        /// <param name="soilGravel">The soil gravel.</param>
        /// <param name="soilCarbon">The soil carbon.</param>
        public SoilCarbon(string soilFile,string soilType,string soilArea,string soilDepth,
            string SoilDensity,string soilOrganics,string soilGravel,string soilCarbon)
        {
            ReadAttribute(soilFile);
            this.soilType = soilType;
            this.soilArea = soilArea;
            this.soilDepth = soilDepth;
            this.SoilDensity = SoilDensity;
            this.soilOrganics = soilOrganics;
            this.soilGravel = soilGravel;
            this.soilCarbon = soilCarbon;
            //getStatistics();
            //Cal_Storage();
        }
        /// <summary>
        /// 获取统计信息
        /// </summary>
        private void getStatistics()
        {
            Summarize sumarize=null;
            if (soilTable != null)
            {
                sumarize = new Summarize(soilTable);
                //统计各土壤类型的面积
                AreaTable=sumarize.Sum(soilTable.Columns.IndexOf(soilArea),soilTable.Columns.IndexOf(soilType));
                //统计各土壤类型的土层厚度均值
                depthTable = sumarize.Avg(soilTable.Columns.IndexOf(soilDepth), soilTable.Columns.IndexOf(soilType));
                //统计各土壤类型的土壤容重均值
                densityTable = sumarize.Avg(soilTable.Columns.IndexOf(SoilDensity), soilTable.Columns.IndexOf(soilType));
                //统计各土壤类型的土壤有机质均值
                organicsTable = sumarize.Avg(soilTable.Columns.IndexOf(soilOrganics), soilTable.Columns.IndexOf(soilType));
                //统计各土壤类型的土层砾石含量均值
                gravelTable = sumarize.Avg(soilTable.Columns.IndexOf(soilGravel), soilTable.Columns.IndexOf(soilType));
            }
        }
        /// <summary>
        /// 计算和写出碳储量.
        /// </summary>
        public Boolean Cal_Storage()
        {
            try
            {
                getStatistics();
                List<double> result = new List<double>();
                double storage = 0.0;
                int typeCount = 0;
                if (AreaTable.Rows.Count > typeCount)
                    typeCount = AreaTable.Rows.Count;
                if (depthTable.Rows.Count > typeCount)
                    typeCount = depthTable.Rows.Count;
                if (densityTable.Rows.Count > typeCount)
                    typeCount = densityTable.Rows.Count;
                if (organicsTable.Rows.Count > typeCount)
                    typeCount = organicsTable.Rows.Count;
                if (gravelTable.Rows.Count > typeCount)
                    typeCount = gravelTable.Rows.Count;

                for (int i = 0; i < typeCount; i++)
                {
                    double storageI = double.Parse(depthTable.Rows[i][1].ToString()) *
                        double.Parse(densityTable.Rows[i][1].ToString()) *
                        double.Parse(gravelTable.Rows[i][1].ToString()) *
                        (1 - double.Parse(organicsTable.Rows[i][1].ToString())) / 100 *
                        double.Parse(AreaTable.Rows[i][1].ToString());
                    result.Add(storageI);
                }

                if (result.Count > 0)
                {
                    foreach (double value in result)
                    {
                        storage += value;
                    }
                }
                //TxtOP.WriteTxt(soilCarbon, storage);
                DataTable dt = new DataTable();
                dt.Columns.Add("土壤碳储量");
                DataRow newRow = dt.NewRow();
                newRow[0] = storage;
                dt.Rows.Add(newRow);
                GFS.BLL.ExcelHelper exclHelper = new GFS.BLL.ExcelHelper();
                exclHelper.DataTableToExcel(soilCarbon, "Sheet", dt, true);
                exclHelper.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("计算土壤碳储量失败！\r\n" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 读取shp属性表到datatable.
        /// </summary>
        /// <param name="shpFile">shp文件名.</param>
        private void ReadAttribute(string shpFile)
        {
            IFeatureClass pFeatureClass = null;
            ITable pTable = null;
            ICursor cursor = null;
            IRow row = null;
            DataColumn dataColumn = null;

            try
            {
                pFeatureClass = ShpFileOP.OpenFeatureClass(shpFile);
                if (pFeatureClass == null)
                    return;
                pTable = pFeatureClass as ITable;
                cursor = pTable.Search(null, true);
                row = cursor.NextRow();
                if (row == null)
                {
                    return;
                }
                else
                {
                    soilTable = new DataTable("soil");
                    for (int i = 0; i < row.Fields.FieldCount; i++)
                    {
                        IField field = row.Fields.get_Field(i);
                        if (!field.Name.StartsWith("SHAPE", StringComparison.OrdinalIgnoreCase))
                        {

                            if (row.Fields.get_Field(i).Type.GetHashCode() < 4)
                                dataColumn = new DataColumn(row.Fields.get_Field(i).AliasName, typeof(double));
                            else
                                dataColumn = new DataColumn(row.Fields.get_Field(i).AliasName, typeof(string));
                            soilTable.Columns.Add(dataColumn);
                        }
                    }
                    while (row != null)
                    {
                        DataRow dataRow = soilTable.NewRow();
                        for (int j = 0; j < soilTable.Columns.Count; j++)
                        {
                            string columnName = soilTable.Columns[j].ColumnName;
                            int index = row.Fields.FindFieldByAliasName(columnName);
                            dataRow[j] = row.get_Value(index);
                        }
                        soilTable.Rows.Add(dataRow);
                        row = cursor.NextRow();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取属性表失败！/r" + ex.Message);
            }
            finally
            {
                dataColumn = null;
                row = null;
                if (cursor != null)
                    Marshal.ReleaseComObject(cursor);
                if (pTable != null)
                    Marshal.ReleaseComObject(pTable);
                if (pFeatureClass != null)
                    Marshal.ReleaseComObject(pFeatureClass);
            }
        }
    }
}
