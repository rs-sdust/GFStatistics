// ***********************************************************************
// Assembly         : ForestModel
// Author           : YXQ
// Created          : 06-13-2016
//
// Modified By : YXQ
// Modified On : 06-17-2016     修改分类影像处理函数按不同像元值类型处理，添加森林面积和碳密度影像的分块处理
// Modified By : YXQ
// Modified On : 06-17-2016     添加数组求和及指定像元值个数统计
// Modified By : YXQ
// Modified On : 06-20-2016     代码优化，完善内存释放。
// ***********************************************************************
// <copyright file="ForestCarbon.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SpatialAnalyst;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

/// <summary>
/// The Math namespace.
/// </summary>
namespace GFS.CarbonBLL
{
    /// <summary>
    /// 植被碳储量计算类
    /// 调用时请按生物量->碳密度->植被面积->碳储量的顺序计算
    /// </summary>
    public class VegetationCarbon
    {
        /// <summary>
        /// 土地覆盖分类数据
        /// </summary>
        private string landCover = string.Empty;
        /// <summary>
        /// 该类植被在分类影像的像元值
        /// </summary>
        private int classID = 0;
        /// <summary>
        /// 指数数据
        /// </summary>
        Dictionary<string, string> index = new Dictionary<string, string>();
        /// <summary>
        /// 反演模型
        /// </summary>
        private string expression = string.Empty;
        /// <summary>
        /// 碳转换系数
        /// </summary>
        private double coefficient = 0.5;

        /// <summary>
        /// 输出生物量
        /// </summary>
        private string Biomass = string.Empty;

        /// <summary>
        /// 输出碳密度
        /// </summary>
        private string carbonDensity = string.Empty;
        /// <summary>
        /// 输出碳储量
        /// </summary>
        private string carbonStorage = string.Empty;

        /// <summary>
        /// 生物量变量
        /// </summary>
        private IGeoDataset rasterBiomass = null;
        
        /// <summary>
        /// 植被面积变量
        /// </summary>
        private double forestArea = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="VegetationCarbon"/> class.
        /// </summary>
        /// <param name="landCover">输入土地覆盖数据.</param>
        /// <param name="classID">输入该类植被的分类像元值.</param>
        /// <param name="index">输入指数数据列表.</param>
        /// <param name="expression">输入生物量反演模型.</param>
        /// <param name="coefficient">输入碳转换系数.</param>
        /// <param name="Biomass">输出生物量文件名.</param>
        /// <param name="carbonDensity">输出碳密度文件名.</param>
        /// <param name="carbonStorage">输出碳储量文件名.</param>
        public VegetationCarbon(string landCover,int classID, Dictionary<string, string> index, string expression, double coefficient, string Biomass, string carbonDensity, string carbonStorage)
        {
            this.landCover = landCover;
            this.classID = classID;
            this.index = index;
            this.expression = expression;
            this.coefficient = coefficient;
            this.Biomass = Biomass;
            this.carbonDensity = carbonDensity;
            this.carbonStorage = carbonStorage;
        }

        /// <summary>
        /// 计算生物量
        /// </summary>
        public Boolean Cal_Biomass()
        {
            //获取公式中栅格符号
            string[] ss = expression.Split(new char[2] { '[', ']' });
            List<string> rasSymbols = new List<string>();
            for (int i = 1; i < ss.Length; i = i + 2)
            {
                if (rasSymbols.Contains(ss[i]) == false)
                {
                    rasSymbols.Add(ss[i]);
                }
            }
    
            //栅格代数
            IMapAlgebraOp mapAlgebraOp = null; 
            IRasterDataset rasterDataset = null;
            ISaveAs2 saveAs=null;

            try
            {
                //判断数量是否一致
                if (rasSymbols.Count > index.Count)
                {
                    XtraMessageBox.Show("运算表达式有错误！");
                    return false;
                }

                //读取和绑定栅格
                mapAlgebraOp = new RasterMapAlgebraOpClass();
                foreach (string key in rasSymbols)
                {
                    rasterDataset = RasterOP.OpenFileRasterDataset(index[key]);
                    mapAlgebraOp.BindRaster((IGeoDataset)rasterDataset, key);
                }

                //执行
                rasterBiomass = mapAlgebraOp.Execute(expression);

                //删除原有输出文件
                if (File.Exists(Biomass))
                {
                    File.Delete(Biomass); 
                }

                //保存文件
                saveAs = (ISaveAs2)rasterBiomass;
                //saveAs.SaveAs(outFile, workspace, "TIFF");
                IDataset o =saveAs.SaveAs(Biomass, null, "TIFF");
                if(o!=null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
                return true;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("计算森林生物量失败！\r\n" + ex.Message);
                return false;
            }
            finally
            {
                //释放
                if (rasterDataset != null)
                    Marshal.ReleaseComObject(rasterDataset);   
                //if (saveAs != null)
                //    Marshal.ReleaseComObject(saveAs);
                if (mapAlgebraOp != null)
                    Marshal.ReleaseComObject(mapAlgebraOp);                
            }


        }

        /// <summary>
        /// 计算碳密度
        /// </summary>
        public Boolean Cal_carbonDensity()
        {
            string exp = coefficient + " * [Biomass]";
            //栅格代数
            IMapAlgebraOp mapAlgebraOp = null;
            IGeoDataset rasout = null;
            ISaveAs2 saveAs = null;

            try
            {
                //绑定符号
                mapAlgebraOp = new RasterMapAlgebraOpClass();
                mapAlgebraOp.BindRaster(rasterBiomass, "Biomass");
                //执行
                rasout = mapAlgebraOp.Execute(exp);
                //rasterDensity = (IRasterDataset)rasout;
                //删除原有输出文件
                if (File.Exists(carbonDensity))
                {
                    File.Delete(carbonDensity);
                }

                //保存文件
                saveAs = (ISaveAs2)rasout;
                //saveAs.SaveAs(outFile, workspace, "TIFF");
                IDataset o = saveAs.SaveAs(carbonDensity, null, "TIFF");
                if(o!=null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("计算碳密度失败！\r\n" + ex.Message);
                return false;
            }
            finally
            {
                //释放
                //rasterBiomass = null;
                if (rasterBiomass != null)
                    Marshal.ReleaseComObject(rasterBiomass);
                if (saveAs != null)
                    Marshal.ReleaseComObject(saveAs);
                if (rasout != null)
                    Marshal.ReleaseComObject(rasout);
                if (mapAlgebraOp != null)
                    Marshal.ReleaseComObject(mapAlgebraOp); 
            }

        }

        /// <summary>
        /// 计算植被面积---逐像元读取(暂时弃用)
        /// </summary>
        /// <returns>System.Double.</returns>
        public Boolean Cal_forestCover()
        {        
            int forestCount = 0;
            IRasterLayer rasLyr = new RasterLayerClass();
            try
            {
                rasLyr.CreateFromFilePath(landCover);
                IRaster2 raster = rasLyr.Raster as IRaster2;
                //获取像元大小
                IRasterProps rasterProps = (IRasterProps)raster;
                double cellSize = rasterProps.MeanCellSize().X;
                //控制并行度
                //ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount*2 };
                
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); 
                
                //并行循环
                Parallel.For(0, rasLyr.ColumnCount, col =>
                {
                    Parallel.For(0, rasLyr.RowCount, row =>
                    {
                        object o = raster.GetPixelValue(0, col, row);
                        if (o != null)
                        {
                            if (int.Parse(o.ToString()) == 4)
                            {
                                forestCount++;
                                //Console.WriteLine(forestCount);
                            }
                        }
                    });
                });

                ////普通循环计算林地像元个数
                //for (int i = 0; i < rasLyr.ColumnCount; i++)
                //    for (int j = 0; j < rasLyr.RowCount; j++)
                //    {
                //        object o = raster.GetPixelValue(0, i, j);
                //        if (o != null)
                //        {
                //            if (int.Parse(o.ToString()) == 4)
                //            {
                //                forestCount++;
                //            }
                //        }
                //    }

                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                Console.WriteLine("林地像元计算用时：" + timeSpan.TotalSeconds + "s 循环大小：" + rasLyr.ColumnCount + "," + rasLyr.RowCount);
                //计算林地像元面积
                forestArea = forestCount * cellSize * cellSize / 100;
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("计算森林面积失败！\r\n" + ex.Message);
                return false;
            }
            finally
            {
                if (rasLyr != null)
                    Marshal.ReleaseComObject(rasLyr);
            }
        }

        /// <summary>
        /// 计算植被面积---按数据类型一次全部读取
        /// </summary>
        /// <returns>System.Double.</returns>
        public Boolean Cal_forestCoverBlock()
        {
            IRasterLayer rasLyr = null;
            IRasterProps rasterProps = null;
            IRasterDataset rasterdat = null;
            object o = null;
            Byte[,] dataByte = null;
            Int16[,] dataInt16 = null;
            double cellSize = 0;
            int forestCount = 0;

            try
            {
                rasLyr = new RasterLayerClass();
                rasLyr.CreateFromFilePath(landCover);
                IRaster2 raster = rasLyr.Raster as IRaster2;
                //获取像元大小
                rasterProps = (IRasterProps)raster;
                cellSize = rasterProps.MeanCellSize().X;
                rasterdat = raster.RasterDataset;

                //读取像元值
                o = RasterOP.ReadPixelValue(rasterdat as IRasterDataset2);
                if (o == null)
                    return false;
                Type type = o.GetType();

                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();

                switch (type.FullName)
                {
                    case "System.Byte[,]":

                        dataByte = (Byte[,])o;
                        forestCount = ArrayStatis(dataByte, classID);
                        break;
                    case "System.Int16[]":

                        dataInt16 = (Int16[,])o;
                        forestCount = ArrayStatis(dataInt16, classID);
                        break;
                    default :

                        o = null;
                        break;
                        
                }

                //stopwatch.Stop();
                //TimeSpan timeSpan = stopwatch.Elapsed;
                //Console.WriteLine("林地像元计算用时：" + timeSpan.TotalSeconds + "s 循环大小：" + rasLyr.ColumnCount + "," + rasLyr.RowCount);
                //计算林地像元面积
                forestArea = forestCount * cellSize * cellSize / 100;
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("计算森林面积失败！\r\n" + ex.Message);
                return false;
            }
            finally
            {
                dataByte = null;
                dataInt16 = null;
                o = null;
                if (rasterdat != null)
                    Marshal.ReleaseComObject(rasterdat);
                if (rasterProps != null)
                    Marshal.ReleaseComObject(rasterProps);
                if (rasLyr != null)
                    Marshal.ReleaseComObject(rasLyr);
            }
        }

        /// <summary>
        /// 计算碳储量---逐个像元读取(暂时弃用)
        /// </summary>
        public Boolean Cal_carbonStorage()
        {
            double sumDensity = 0;
            double value = 0;
            IRasterLayer rasLyr = new RasterLayerClass();
            //int debugx = 0;
            //int debugY = 0;
            try
            {
                rasLyr.CreateFromFilePath(carbonDensity);
                IRaster2 raster = rasLyr.Raster as IRaster2;

                //普通循环计算碳密度像元和
                //for (int i = 0; i < rasLyr.ColumnCount; i++)
                //{
                //    for (int j = 0; j < rasLyr.RowCount; j++)
                //    {
                //        if (double.TryParse(raster.GetPixelValue(0, i, j).ToString(), out value))
                //            sumDensity += value;
                //    }
                //}

                //控制并行度
                ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount*2 };
                
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
 
                //并行循环
                Parallel.For(0, rasLyr.ColumnCount,col =>
                   {
                       Parallel.For(0, rasLyr.RowCount, row =>
                       {
                           object o = raster.GetPixelValue(0, col, row);
                           if (o != null)
                           {
                               if (double.TryParse(o.ToString(), out value))
                               {
                                   sumDensity += value;
                                   //Console.WriteLine(sumDensity);
                               }
                           }
                       });

                       //for (int row = 0; row < rasLyr.RowCount; row++)
                       //{
                       //    object o = raster.GetPixelValue(0, col, row);
                       //    if (o != null)
                       //    {
                       //        if (double.TryParse(o.ToString(), out value))
                       //            sumDensity += value;
                       //    }
                       //}
                   });

                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                Console.WriteLine("碳密度加和计算用时：" + timeSpan.TotalSeconds + "s 循环大小：" + rasLyr.ColumnCount + "," + rasLyr.RowCount);

                //计算碳储量
                double Storage = sumDensity * forestArea;

                //写出结果到文本
                //TxtOP.WriteTxt(carbonStorage, Storage);

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("计算森林碳储量失败！\r\n" + ex.Message);
                return false;
            }
            finally
            { 
                if(rasLyr!=null)
                    Marshal.ReleaseComObject(rasLyr);
            }
        }

        /// <summary>
        /// 计算碳储量---分块读取
        /// 效率可提高百倍以上
        /// </summary>
        public Boolean Cal_carbonStorageBlock()
        {
            IRasterLayer rasLyr = null;
            IRasterDataset rasterdat=null;
            IPnt pBlockSize0 = null;
            IPnt pBlockSize1 = null;
            double sumDensity = 0;
            float[,] data = null;

            try
            {
                rasLyr = new RasterLayerClass();
                pBlockSize0 = new PntClass();
                pBlockSize1 = new PntClass();
                rasLyr.CreateFromFilePath(carbonDensity);
                IRaster2 raster = rasLyr.Raster as IRaster2;
                rasterdat = raster.RasterDataset;

                int blockSize=512;
                pBlockSize1.SetCoords(blockSize, blockSize);
                //影像x方向分块数
                int colBlock = rasLyr.ColumnCount / blockSize;
                //影像y方向分块数
                int rowBlock = rasLyr.RowCount / blockSize;
                //影像分块后x方向剩余像元数
                int colMod = rasLyr.ColumnCount % blockSize;
                //影像分块后y方向剩余像元数
                int rowMod = rasLyr.RowCount % blockSize;

                //分块读取像元并处理
                for (int col = 0; col < colBlock; col++)
                {
                    for (int row = 0; row < rowBlock; row++)
                    {
                        pBlockSize0.SetCoords(blockSize*col,blockSize*row);
                        data = RasterOP.ReadFloat(rasterdat as IRasterDataset2, pBlockSize0, pBlockSize1);
                        if (data == null)
                            return false;
                        sumDensity += ArraySum(data);
                    }
                }

                //读取剩余列像元并处理
                if (colMod > 0)
                {
                    pBlockSize0.SetCoords(blockSize * colBlock, 0);
                    pBlockSize1.SetCoords(colMod, rasLyr.RowCount);
                    data = RasterOP.ReadFloat(rasterdat as IRasterDataset2, pBlockSize0, pBlockSize1);
                    if (data == null)
                        return false;
                    sumDensity += ArraySum(data);
                }
                //读取剩余行像元并处理
                if (rowMod > 0)
                {
                    pBlockSize0.SetCoords(0, blockSize * rowBlock);
                    pBlockSize1.SetCoords(colBlock, rowMod);
                    data = RasterOP.ReadFloat(rasterdat as IRasterDataset2, pBlockSize0, pBlockSize1);
                    if (data == null)
                        return false;
                    sumDensity += ArraySum(data);
                }

                //计算碳储量
                double Storage = sumDensity * forestArea;

                //写出结果到xls
                //TxtOP.WriteTxt(carbonStorage, Storage);
                DataTable dt = new DataTable();
                dt.Columns.Add("碳储量-"+ classID);
                DataRow newRow = dt.NewRow();
                newRow[0] = Storage;
                dt.Rows.Add(newRow);
                GFS.BLL.ExcelHelper exclHelper = new GFS.BLL.ExcelHelper();
                exclHelper.DataTableToExcel(carbonStorage, "Sheet", dt, true);
                exclHelper.Dispose();
                data = null;
                if (rasterdat != null)
                {
                    Marshal.ReleaseComObject(rasterdat);
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("计算森林碳储量失败！\r\n" + ex.Message);
                return false;
            }
            finally
            {
                data = null;
                if(rasLyr!=null)
                    Marshal.ReleaseComObject(rasLyr);
                if (rasterdat != null)
                    Marshal.ReleaseComObject(rasterdat);
                if(pBlockSize0!=null)
                    Marshal.ReleaseComObject(pBlockSize0);
                if(pBlockSize1!=null)
                    Marshal.ReleaseComObject(pBlockSize1);
            }
        }

        /// <summary>
        /// 统计数组中指定像元值的个数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="threshold">The threshold.</param>
        /// <returns>System.Int32.</returns>
        private int ArrayStatis<T>(T[,] data, int threshold)
        {
            int forestCount = 0;
            T value;
            //并行循环
            Parallel.For(0, data.GetLength(0), col =>
            {
                Parallel.For(0, data.GetLength(1), row =>
                {
                    value = data[col, row];
                    if (value != null && int.Parse(value.ToString()) == threshold)
                        forestCount++;

                });

            });
            return forestCount;
        }

        /// <summary>
        /// 统计数组中所有像元的和.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>System.Double.</returns>
        private double ArraySum<T>(T[,] data)
        {
            double sumDensity = 0;
            double valuenum=0;
            T value;
            //并行循环
            Parallel.For(0, data.GetLength(0), col =>
            {
                Parallel.For(0, data.GetLength(1), row =>
                {
                    value = data[col, row];
                    if (value != null && double.TryParse(value.ToString(), out valuenum))
                        sumDensity += valuenum;

                });

            });
            return sumDensity;
        }

    }
}
