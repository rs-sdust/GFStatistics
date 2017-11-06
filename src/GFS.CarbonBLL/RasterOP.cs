// ***********************************************************************
// Assembly         : ForestModel
// Author           : YXQ
// Created          : 06-13-2016
//
// Modified By : YXQ
// Modified On : 06-17-2016     添加影像分块读取函数，添加返回object的影像读取函数
// Modified By : YXQ
//
// ***********************************************************************
// <copyright file="RasterOP.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
//using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;

/// <summary>
/// The ForestModel namespace.
/// </summary>
namespace GFS.CarbonBLL
{
    /// <summary>
    /// Class 栅格基础操作.
    /// </summary>
    public class RasterOP
    {
        /// <summary>
        /// Gets the class value from raster.
        /// </summary>
        /// <param name="inFile">The in file.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <exception cref="System.Exception">文件类型不正确，请选择分类结果文件！</exception>
        public static List<string> GetClassFromRaster(string inFile)
        {
            IRasterLayer pRasterLayer = null;
            IUniqueValues pUniqueValues = null;
            IRasterCalcUniqueValues pCalcUniqueValues = null;
            List<string> classNames = null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(inFile);
                if (!(1 == pRasterLayer.BandCount))
                {
                    throw new Exception("文件类型不正确，请选择分类结果文件！");
                }
                pUniqueValues = new UniqueValuesClass();
                pCalcUniqueValues = new RasterCalcUniqueValuesClass();
                pCalcUniqueValues.AddFromRaster(pRasterLayer.Raster, 0, pUniqueValues);
                classNames = new List<string>();
                for (int i = 0; i < pUniqueValues.Count; i++)
                {
                    classNames.Add(pUniqueValues.get_UniqueValue(i).ToString());
                }
                return classNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pCalcUniqueValues != null)
                    Marshal.ReleaseComObject(pCalcUniqueValues);
                if (pUniqueValues != null)
                    Marshal.ReleaseComObject(pUniqueValues);
                if (pRasterLayer != null)
                    Marshal.ReleaseComObject(pRasterLayer);
            }
        }
        /// <summary>
        /// 打开栅格数据.
        /// </summary>
        /// <param name="filePath">文件路径.</param>
        /// <returns>IRasterDataset.</returns>
        public static IRasterDataset OpenFileRasterDataset(string filePath)
        {
            try
            {
                //新建工作空间工厂
                IWorkspaceFactory WorkspaceFactory = new RasterWorkspaceFactoryClass();
                //新建工作空间
                IWorkspace Workspace = WorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(filePath), 0);
                //新建栅格工作空间
                IRasterWorkspace rasterWorkspace = (IRasterWorkspace)Workspace;
                // IGeoDataset rasterSet = (IGeoDataset)rasterWorkspace.OpenRasterDataset(System.IO.Path.GetFileName(fullpath)); 
                //读取栅格数据
                IRasterDataset rasterSet = (IRasterDataset)rasterWorkspace.OpenRasterDataset(System.IO.Path.GetFileName(filePath));
                //返回IRasterDataset
                return rasterSet;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取栅格数据集失败!\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 读取指定块处的像元值到数组.
        /// </summary>
        /// <param name="pRasterDS">The p raster ds.</param>
        /// <param name="pBlockSize0">左上角点.</param>
        /// <param name="pBlockSize1">块大小.</param>
        /// <returns>System.Single[].</returns>
        public static float[,] ReadFloat(IRasterDataset2 pRasterDS, IPnt pBlockSize0, IPnt pBlockSize1)
        {
            try
            {
                //IRaster pRaster = thisRasterLayer.Raster;
                IRaster pRaster = pRasterDS.CreateFullRaster();
                IRaster2 pRaster2 = (IRaster2)pRaster;
                IRasterProps pRSp = (IRasterProps)pRaster;

                IPixelBlock pixelBlock = pRaster2.CreateCursorEx(pBlockSize1).PixelBlock;

                pRaster.Read(pBlockSize0, pixelBlock);
                IPixelBlock3 block2 = (IPixelBlock3)pixelBlock;
                return (float[,])block2.get_PixelData(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取影像失败!\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 一次读取整幅影像像元值
        /// </summary>
        /// <param name="pRasterDS">The p raster ds.</param>
        /// <returns>System.Object.</returns>
        public static object ReadPixelValue(IRasterDataset2 pRasterDS)
        {
            try
            {
                //IRaster pRaster = thisRasterLayer.Raster;
                IRaster pRaster = pRasterDS.CreateFullRaster();
                IRaster2 pRaster2 = (IRaster2)pRaster;
                IRasterProps pRSp = (IRasterProps)pRaster;
                IPnt pBlockSize = new PntClass();
                pBlockSize.SetCoords((float)pRSp.Width, (float)pRSp.Height);
                IPixelBlock pixelBlock = pRaster2.CreateCursorEx(pBlockSize).PixelBlock;
                pBlockSize.SetCoords(0.0, 0.0);
                pRaster.Read(pBlockSize, pixelBlock);
                IPixelBlock3 block2 = (IPixelBlock3)pixelBlock;

                return block2.get_PixelData(0); ;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取分类影像失败!\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 一次读取整幅影像像元值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pRasterDS">The p raster ds.</param>
        /// <returns>T[].</returns>
        public static T[,] ReadPixelValue<T>(IRasterDataset2 pRasterDS)
        {
            try
            {
                //IRaster pRaster = thisRasterLayer.Raster;
                IRaster pRaster = pRasterDS.CreateFullRaster();
                IRaster2 pRaster2 = (IRaster2)pRaster;
                IRasterProps pRSp = (IRasterProps)pRaster;
                IPnt pBlockSize = new PntClass();
                pBlockSize.SetCoords((float)pRSp.Width, (float)pRSp.Height);
                IPixelBlock pixelBlock = pRaster2.CreateCursorEx(pBlockSize).PixelBlock;
                pBlockSize.SetCoords(0.0, 0.0);
                pRaster.Read(pBlockSize, pixelBlock);
                IPixelBlock3 block2 = (IPixelBlock3)pixelBlock;

                return (T[,])block2.get_PixelData(0); ;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取分类影像失败!\n" + ex.Message);
                return null;
            }
        }

        /// <summary>  
        /// 获取目录下所有tif文件名列表（包括子文件夹）  
        /// </summary>
        /// <param name="fPath">文件目录</param>
        /// <param name="files">获取的文件列表</param>
        public static List<string> GetAllBands(string fPath)
        {
            //获取当前目录下的所有文件
            List<string> fileList = new List<string>();
            string[] fNames = Directory.GetFiles(fPath, "*.tif");
            foreach (string file in fNames)
            {
                fileList.Add(file.ToString());
            }
            return fileList;
            ////获取当前目录下的所有目录
            //DirectoryInfo firstFolder = new DirectoryInfo(fPath);
            //List<string> folders = new List<string>();
            //foreach (DirectoryInfo NextFolder in firstFolder.GetDirectories())
            //{
            //    //递归获取逐级子目录下的所有文件
            //    GetAllFiles(NextFolder.FullName, files);
            //}
        }


    }
}
