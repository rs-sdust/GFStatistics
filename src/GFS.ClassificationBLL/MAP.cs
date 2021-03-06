﻿// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-18-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
// ***********************************************************************
// <copyright file="MAP.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>access to map</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using GFS.Commands.UI;
using GFS.BLL;
using DevExpress.XtraEditors;
using GFS.Common;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace GFS.ClassificationBLL
{
    public class MAP
    {
        /// <summary>
        /// 加载栅格文件到主地图控件
        /// </summary>
        /// <param name="rasterPath">The raster path.</param>
        public static void AddRasterFileToMap(string rasterPath)
        {
            try
            {
                IRasterLayer rasterLayer = new RasterLayerClass();
                string directoryName = System.IO.Path.GetDirectoryName(rasterPath);
                string fileName = System.IO.Path.GetFileName(rasterPath);
                IRasterWorkspace rasterWorkspace = EngineAPI.OpenWorkspace(directoryName, DataType.raster) as IRasterWorkspace;
                IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                rasterLayer.CreateFromDataset(rasterDataset);
                IRasterPyramid3 rasterPyramid = rasterDataset as IRasterPyramid3;
                if (rasterPyramid != null && !rasterPyramid.Present)
                {
                    //new frmCreatePyramid(new List<string>
                    //{
                    //    rasterLayer.FilePath
                    //})
                    //{
                    //    Owner = EnviVars.instance.MainForm
                    //}.ShowDialog();
                    //using (GPExecutor gp = new GPExecutor())
                    {
                        EnviVars.instance.GpExecutor.CreatePyramid(new List<string>
                    {
                        rasterLayer.FilePath
                    });
                    }
                }
                EnviVars.instance.MapControl.AddLayer(rasterLayer, 0);
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show("加载数据失败！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(MAP), ex);
                throw ex;
            }
        }

        /// <summary>
        /// 加载矢量文件到主地图控件
        /// </summary>
        /// <param name="rasterPath">The raster path.</param>
        public static void AddShpFileToMap(string filePath)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(filePath);
                string path = filePath.Substring(0, filePath.Length - fileinfo.Name.Length);
                string filename = fileinfo.Name;
                EnviVars.instance.MapControl.AddShapeFile(path,filename);
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(MAP), ex);
                throw ex;
            }
        }

        /// <summary>
        /// Gets raster band count.
        /// </summary>
        /// <param name="rasterFile">The raster file.</param>
        /// <returns>System.Int32.</returns>
        public static int GetBandCount(string rasterFile)
        {
            IRasterLayer pRasterLayer = null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(rasterFile);
                return pRasterLayer.BandCount;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取栅格波段失败！请检查文件是否损坏：" + rasterFile, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(MapAPI), ex);
                return -1;
            }
            finally
            {
                if (pRasterLayer != null)
                    Marshal.ReleaseComObject(pRasterLayer);
            }
        }
    }
}
