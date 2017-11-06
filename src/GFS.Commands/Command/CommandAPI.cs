// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-01-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CommandAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Class CommandAPI.</summary>
// ***********************************************************************
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
//using SDJT.Const;
//using SDJT.Sys;
using GFS.Commands.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GFS.BLL;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CommandAPI.
    /// </summary>
    public class CommandAPI
    {
        /// <summary>
        /// Adds the feature layers to map.
        /// </summary>
        /// <param name="featureClassList">The feature class list.</param>
        public static void AddFeatureLayersToMap(List<IFeatureClass> featureClassList)
        {
            if ((featureClassList != null) && (featureClassList.Count != 0))
            {
                AddLayers(featureClassList, GFS.BLL.EnviVars.instance.MapControl.Map);
                //SaveRecentFilesInfo();
            }
        }

        /// <summary>
        /// Adds the item to ListBox.
        /// </summary>
        /// <param name="file">The file.</param>
        //private static void AddItemToListBox(RecentFile file)
        //{
        //    foreach (ImageListBoxItem item in EnviVars.instance.RecentFilesCtrl.Items)
        //    {
        //        RecentFile file2 = item.Value as RecentFile;
        //        if ((file2 != null) && (file2.FullPath == file.FullPath))
        //        {
        //            EnviVars.instance.RecentFilesCtrl.Items.Remove(item);
        //            break;
        //        }
        //    }
        //    if (EnviVars.instance.RecentFilesCtrl.ItemCount == 10)
        //    {
        //        EnviVars.instance.RecentFilesCtrl.Items.RemoveAt(9);
        //    }
        //    ImageListBoxItem item2 = new ImageListBoxItem
        //    {
        //        ImageIndex = file.Type,
        //        Value = file
        //    };
        //    EnviVars.instance.RecentFilesCtrl.Items.Insert(0, item2);
        //}

        /// <summary>
        /// Adds the layers.
        /// </summary>
        /// <param name="featureClassList">The feature class list.</param>
        /// <param name="map">The map.</param>
        public static void AddLayers(List<IFeatureClass> featureClassList, IMap map)
        {
            IMap o = new MapClass();
            try
            {
                foreach (IFeatureClass class2 in featureClassList)
                {
                    IFeatureLayer layer = new FeatureLayerClass
                    {
                        Name = class2.AliasName,
                        FeatureClass = class2
                    };
                    o.AddLayer(layer);
                    //AddRecentFile(layer);
                }
                IEnumLayer layers = o.get_Layers(null, true);
                try
                {
                    map.AddLayers(layers, true);
                }
                finally
                {
                    if (layers != null)
                    Marshal.ReleaseComObject(layers);
                }
            }
            finally
            {
                if (o != null)
                Marshal.ReleaseComObject(o);
            }
        }

        /// <summary>
        /// Adds the raster layers to map.
        /// </summary>
        /// <param name="rasterDict">The raster dictionary.</param>
        public static void AddRasterLayersToMap(Dictionary<string, IRasterDataset> rasterDict)
        {
            if ((rasterDict != null) && (rasterDict.Count != 0))
            {
                List<string> rasterFiles = new List<string>();
                Dictionary<string, IRasterLayer> dictionary = new Dictionary<string, IRasterLayer>();
                foreach (KeyValuePair<string, IRasterDataset> pair in rasterDict)
                {
                    IRasterLayer layer = new RasterLayerClass
                    {
                        Name = Path.GetFileNameWithoutExtension(pair.Key)
                    };
                    layer.CreateFromDataset(pair.Value);
                    dictionary.Add(pair.Key, layer);
                    IRasterPyramid3 pyramid = pair.Value as IRasterPyramid3;
                    if (!((pyramid == null) || pyramid.Present))
                    {
                        rasterFiles.Add(pair.Key);
                    }
                }
                if (rasterFiles.Count > 0)
                {
                    //new frmCreatePyramid(rasterFiles) { Owner = GFS.BLL.EnviVars.instance.MainForm }.ShowDialog();
                    //using(GPExecutor gp = new GPExecutor())
                    {
                        EnviVars.instance.GpExecutor.CreatePyramid(rasterFiles);
                    }
                    //EnviVars.instance.GpExecutor.CreatePyramid(rasterFiles);
                }
                foreach (KeyValuePair<string, IRasterLayer> pair2 in dictionary)
                {
                    //EnviVars.instance.MapControl.AddLayer(pair2.Value, 0);
                    //AddRecentFile(pair2.Key, FileType.Raster);
                }
                //SaveRecentFilesInfo();
            }
        }

        /// <summary>
        /// Adds the recent file.
        /// </summary>
        /// <param name="featureLayer">The feature layer.</param>
        //private static void AddRecentFile(IFeatureLayer featureLayer)
        //{
        //    FileType shp = FileType.Shp;
        //    string str = "";
        //    switch (featureLayer.DataSourceType)
        //    {
        //        case "Shapefile Feature Class":
        //            shp = FileType.Shp;
        //            str = ".shp";
        //            break;

        //        case "Personal Geodatabase Feature Class":
        //            shp = FileType.MDB;
        //            break;

        //        case "CAD Point Feature Class":
        //        case "CAD Polyline Feature Class":
        //        case "CAD Polygon Feature Class":
        //            shp = FileType.CAD;
        //            break;

        //        case "File Geodatabase Feature Class":
        //            shp = FileType.GDB;
        //            break;

        //        default:
        //            return;
        //    }
        //    IDatasetName dataSourceName = (featureLayer as IDataLayer).DataSourceName as IDatasetName;
        //    RecentFile file = new RecentFile
        //    {
        //        Type = (int)shp,
        //        Name = dataSourceName.Name + str
        //    };
        //    if (shp == FileType.CAD)
        //    {
        //        string name = (dataSourceName as IFeatureClassName).FeatureDatasetName.Name;
        //        file.Path = Path.Combine(dataSourceName.WorkspaceName.PathName, name);
        //        file.FullPath = Path.Combine(file.Path, file.Name);
        //    }
        //    else
        //    {
        //        file.Path = dataSourceName.WorkspaceName.PathName;
        //        IDatasetName featureDatasetName = (dataSourceName as IFeatureClassName).FeatureDatasetName;
        //        if (featureDatasetName != null)
        //        {
        //            string str3 = featureDatasetName.Name;
        //            file.FullPath = Path.Combine(file.Path, str3, file.Name);
        //        }
        //        else
        //        {
        //            file.FullPath = Path.Combine(file.Path, file.Name);
        //        }
        //    }
        //    AddItemToListBox(file);
        //}

        /// <summary>
        /// Adds the recent file.
        /// </summary>
        /// <param name="sFilePath">The s file path.</param>
        /// <param name="type">The type.</param>
        //public static void AddRecentFile(string sFilePath, FileType type)
        //{
        //    RecentFile file = new RecentFile
        //    {
        //        Name = Path.GetFileName(sFilePath),
        //        Path = Path.GetDirectoryName(sFilePath),
        //        FullPath = sFilePath,
        //        Type = (int)type
        //    };
        //    AddItemToListBox(file);
        //}

        /// <summary>
        /// Gets the current layer.
        /// </summary>
        /// <param name="hookHelper">The hook helper.</param>
        /// <returns>ILayer.</returns>
        public static ILayer GetCurrentLayer(IHookHelper hookHelper)
        {
            ILayer customProperty = null;
            IMapControl4 hook = null;
            IPageLayoutControl3 control2 = null;
            if (hookHelper.Hook is IMapControl4)
            {
                hook = (IMapControl4)hookHelper.Hook;
                return (hook.CustomProperty as ILayer);
            }
            if (hookHelper.Hook is IPageLayoutControl3)
            {
                control2 = (IPageLayoutControl3)hookHelper.Hook;
                return (control2.CustomProperty as ILayer);
            }
            if (hookHelper.Hook is IToolbarControl)
            {
                IToolbarControl control3 = (IToolbarControl)hookHelper.Hook;
                object buddy = control3.Buddy;
                if (buddy is IMapControl4)
                {
                    hook = (IMapControl4)buddy;
                    return (hook.CustomProperty as ILayer);
                }
                if (buddy is IPageLayoutControl3)
                {
                    control2 = (IPageLayoutControl3)buddy;
                    customProperty = control2.CustomProperty as ILayer;
                }
            }
            return customProperty;
        }

        /// <summary>
        /// Saves the recent files information.
        /// </summary>
        //public static void SaveRecentFilesInfo()
        //{
        //    RecentFiles xmlClass = new RecentFiles
        //    {
        //        RecentList = new List<RecentFile>()
        //    };
        //    foreach (ImageListBoxItem item in EnviVars.instance.RecentFilesCtrl.Items)
        //    {
        //        RecentFile file = item.Value as RecentFile;
        //        if (file != null)
        //        {
        //            xmlClass.RecentList.Add(file);
        //        }
        //    }
        //    new XmlSerialization().Serialize(xmlClass, ConstDef.FILE_RENCENTFILES);
        //}
    }
}
