// ***********************************************************************
// Assembly         : SDJT.Common
// Author           : Ricker Yan
// Created          : 03-30-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-19-2016
// ***********************************************************************
// <copyright file="EngineAPI.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Class EngineAPI.</summary>
// ***********************************************************************
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
//using ESRI.ArcGIS.Geoprocessor;
//using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.SystemUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;

/// <summary>
/// The Common namespace.
/// </summary>
namespace GFS.Common
{
    /// <summary>
    /// Class EngineAPI.
    /// </summary>
    public class EngineAPI
    {

        /// <summary>
        /// Gets the layers.
        /// </summary>
        /// <param name="pMap">The  map.</param>
        /// <param name="sUID">The  uid.</param>
        /// <param name="sLayerName">Name of the  layer.</param>
        /// <returns>System.Collections.Generic.List&lt;ILayer&gt;.</returns>
        public static System.Collections.Generic.List<ILayer> GetLayers(IMap pMap, string sUID, string sLayerName = null)
        {
            System.Collections.Generic.List<ILayer> list = new System.Collections.Generic.List<ILayer>();
            IEnumLayer enumLayer = pMap.get_Layers(new UIDClass
            {
                Value = sUID
            }, true);
            try
            {
                enumLayer.Reset();
                ILayer layer;
                while ((layer = enumLayer.Next()) != null)
                {
                    if (string.IsNullOrEmpty(sLayerName) || !(sLayerName != layer.Name))
                    {
                        list.Add(layer);
                    }
                }
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(enumLayer);
            }
            return list;
        }

        /// <summary>
        /// Opens the workspace.
        /// </summary>
        /// <param name="sFilePath">The s file path.</param>
        /// <param name="type">The type.</param>
        /// <returns>IWorkspace.</returns>
        public static IWorkspace OpenWorkspace(string sFilePath, DataType type)
        {
            IWorkspace result;
            try
            {
                sFilePath = sFilePath.TrimEnd(new char[]
                {
            '\\'
                });
                IWorkspaceFactory workspaceFactory = null;
                if (type <= DataType.sde)
                {
                    switch (type)
                    {
                        case DataType.shp:
                            workspaceFactory = new ShapefileWorkspaceFactoryClass();
                            break;
                        case DataType.mdb:
                            workspaceFactory = new AccessWorkspaceFactoryClass();
                            break;
                        case (DataType)3:
                            break;
                        case DataType.gdb:
                            workspaceFactory = new FileGDBWorkspaceFactoryClass();
                            break;
                        default:
                            if (type == DataType.sde)
                            {
                                workspaceFactory = new SdeWorkspaceFactoryClass();
                            }
                            break;
                    }
                }
                else if (type != DataType.cad)
                {
                    if (type != DataType.raster)
                    {
                        if (type == DataType.coverage)
                        {
                            workspaceFactory = new ArcInfoWorkspaceFactoryClass();
                        }
                    }
                    else
                    {
                        workspaceFactory = new RasterWorkspaceFactoryClass();
                    }
                }
                else
                {
                    workspaceFactory = new CadWorkspaceFactoryClass();
                }
                result = workspaceFactory.OpenFromFile(sFilePath, 0);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// E00s to coverage.
        /// </summary>
        /// <param name="sE00FilePath">The s e00 file path.</param>
        /// <param name="sOutputPath">The s output path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool E00ToCoverage(string sE00FilePath, string sOutputPath)
        {
            string text = Application.StartupPath + "\\eoo2Cov\\IMPORT71.EXE";
            bool result;
            if (!System.IO.File.Exists(text))
            {
                result = false;
            }
            else
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(sE00FilePath);
                string str = sOutputPath + "\\" + fileNameWithoutExtension;
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = text;
                    process.StartInfo.Arguments = sE00FilePath + " " + str + " /T";
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Determines whether [is equal spatial reference] [the specified p SRF1].
        /// </summary>
        /// <param name="pSrf1">The p SRF1.</param>
        /// <param name="pSrf2">The p SRF2.</param>
        /// <returns><c>true</c> if [is equal spatial reference] [the specified p SRF1]; otherwise, <c>false</c>.</returns>
        public static bool IsEqualSpatialReference(ISpatialReference pSrf1, ISpatialReference pSrf2)
        {
            bool result = false;
            if ((pSrf1 as ICompareCoordinateSystems).IsEqualNoVCS(pSrf2))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Converts the unit.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <param name="inUnits">The in units.</param>
        /// <param name="outUnits">The out units.</param>
        /// <returns>System.Double.</returns>
        public static double ConvertUnit(double dValue, esriUnits inUnits, esriUnits outUnits)
        {
            IUnitConverter unitConverter = new UnitConverterClass();
            return unitConverter.ConvertUnits(dValue, inUnits, outUnits);
        }

        /// <summary>
        /// Flashes the geometry.
        /// </summary>
        /// <param name="pMapControl">The p map control.</param>
        /// <param name="pFeature">The p feature.</param>
        public static void FlashGeometry(IMapControl4 pMapControl, IFeature pFeature)
        {
            pMapControl.Extent = pFeature.Extent;
            IGeometry pGeometry = pFeature.ShapeCopy as IGeometry;
            pMapControl.FlashShape(pGeometry, 2, 300);
            //IColor rgbColor = EngineAPI.GetRgbColor(0, 255, 0);
            //ISymbol symbol = null;
            //switch (pGeometry.GeometryType)
            //{
            //    case esriGeometryType.esriGeometryPoint:
            //    case esriGeometryType.esriGeometryMultipoint:
            //        symbol = (new SimpleMarkerSymbolClass
            //        {
            //            Color = rgbColor,
            //            Size = 8.0
            //        } as ISymbol);
            //        break;
            //    case esriGeometryType.esriGeometryPolyline:
            //        symbol = (new CartographicLineSymbolClass
            //        {
            //            Width = 2.0,
            //            Color = rgbColor,
            //            Cap = esriLineCapStyle.esriLCSRound
            //        } as ISymbol);
            //        break;
            //    case esriGeometryType.esriGeometryPolygon:
            //        symbol = (new SimpleFillSymbolClass
            //        {
            //            Style = esriSimpleFillStyle.esriSFSSolid,
            //            Color = rgbColor
            //        } as ISymbol);
            //        break;
            //}
            //if (symbol != null)
            //{
            //    symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            //    pMapControl.FlashShape(pGeometry, 2, 300, symbol);
            //}
        }

        /// <summary>
        /// Gets the color of the RGB.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns>IRgbColor.</returns>
        public static IRgbColor GetRgbColor(int red, int green, int blue)
        {
            return new RgbColorClass
            {
                Blue = blue,
                Red = red,
                Green = green
            };
        }

        /// <summary>
        /// Opens the raster file.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        /// <returns>IRasterDataset.</returns>
        public static IRasterDataset OpenRasterFile(string sPath, string sName)
        {
            IRasterDataset result;
            if (!System.IO.Directory.Exists(sPath))
            {
                result = null;
            }
            else
            {
                IWorkspace workspace = EngineAPI.OpenWorkspace(sPath, DataType.raster);
                if (workspace == null)
                {
                    result = null;
                }
                else
                {
                    IEnumDatasetName enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTRasterDataset);
                    try
                    {
                        enumDatasetName.Reset();
                        IDatasetName datasetName;
                        while ((datasetName = enumDatasetName.Next()) != null)
                        {
                            if (string.Equals(datasetName.Name, sName, System.StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }
                        }
                        if (datasetName == null)
                        {
                            result = null;
                        }
                        else
                        {
                            IRasterDataset rasterDataset = (datasetName as IName).Open() as IRasterDataset;
                            result = rasterDataset;
                        }
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(enumDatasetName);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workspace);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Opens the GDB feature class.
        /// </summary>
        /// <param name="sFilePath">The s file path.</param>
        /// <param name="type">The type.</param>
        /// <param name="sFcName">Name of the s fc.</param>
        /// <returns>IFeatureClass.</returns>
        public static IFeatureClass OpenGDBFeatureClass(string sFilePath, DataType type, string sFcName)
        {
            IFeatureClass result;
            if (type == DataType.mdb && !System.IO.File.Exists(sFilePath))
            {
                result = null;
            }
            else if (type == DataType.gdb && !System.IO.Directory.Exists(sFilePath))
            {
                result = null;
            }
            else
            {
                IWorkspace workspace = EngineAPI.OpenWorkspace(sFilePath, type);
                if (workspace == null)
                {
                    result = null;
                }
                else
                {
                    try
                    {
                        result = (workspace as IFeatureWorkspace).OpenFeatureClass(sFcName);
                    }
                    catch
                    {
                        result = null;
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workspace);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Opens the cad feature class.
        /// </summary>
        /// <param name="sCadFilePath">The s cad file path.</param>
        /// <param name="sFcName">Name of the s fc.</param>
        /// <returns>IFeatureClass.</returns>
        public static IFeatureClass OpenCADFeatureClass(string sCadFilePath, string sFcName)
        {
            IFeatureClass result;
            if (!System.IO.File.Exists(sCadFilePath))
            {
                result = null;
            }
            else
            {
                IWorkspace workspace = EngineAPI.OpenWorkspace(System.IO.Path.GetDirectoryName(sCadFilePath), DataType.cad);
                if (workspace == null)
                {
                    result = null;
                }
                else
                {
                    string fileName = System.IO.Path.GetFileName(sCadFilePath);
                    IEnumDatasetName enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
                    try
                    {
                        enumDatasetName.Reset();
                        IDatasetName datasetName = null;
                        IDatasetName datasetName2;
                        while ((datasetName2 = enumDatasetName.Next()) != null)
                        {
                            if (string.Equals(datasetName2.Name, fileName, System.StringComparison.OrdinalIgnoreCase))
                            {
                                IEnumDatasetName subsetNames = datasetName2.SubsetNames;
                                try
                                {
                                    subsetNames.Reset();
                                    while ((datasetName = subsetNames.Next()) != null)
                                    {
                                        if (string.Equals(datasetName.Name, sFcName, System.StringComparison.OrdinalIgnoreCase))
                                        {
                                            break;
                                        }
                                    }
                                }
                                finally
                                {
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(subsetNames);
                                }
                                break;
                            }
                        }
                        if (datasetName == null)
                        {
                            result = null;
                        }
                        else
                        {
                            IFeatureClass featureClass = (datasetName as IName).Open() as IFeatureClass;
                            result = featureClass;
                        }
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(enumDatasetName);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workspace);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// create vector file by geometry
        /// </summary>
        /// <param name="sFilePath">vector file path</param>
        /// <param name="geometry">based geometry</param>
        /// <returns></returns>
        public static bool CreateShpFile(string sFilePath, List<ROIGeometry> geometryList)
        {
            string directoryName = System.IO.Path.GetDirectoryName(sFilePath);
            IFeatureWorkspace featureWorkspace = EngineAPI.OpenWorkspace(directoryName, DataType.shp) as IFeatureWorkspace;
            bool result;
            if (featureWorkspace == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(sFilePath);
                    result = EngineAPI.CreateGeometryLayer(fileNameWithoutExtension, geometryList, featureWorkspace, "");
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(featureWorkspace);
                }
            }
            return result;
        }
        /// <summary>
        /// Create geometry layer
        /// </summary>
        /// <param name="sName">filename without extension</param>
        /// <param name="geometry">based geometry</param>
        /// <param name="featureWorkspace">featureWorkspace</param>
        /// <param name="sAlias"></param>
        /// <returns></returns>
        public static bool CreateGeometryLayer(string sName, List<ROIGeometry> geometryList, IFeatureWorkspace featureWorkspace, string sAlias = "")
        {
            bool result;
            try
            {
                IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
                IFields requiredFields = objectClassDescription.RequiredFields;
                string shapeFieldName = (objectClassDescription as IFeatureClassDescription).ShapeFieldName;
                int index = requiredFields.FindField(shapeFieldName);
                IGeometryDef geometryDef = requiredFields.get_Field(index).GeometryDef;
                IGeometryDefEdit geometryDefEdit = geometryDef as IGeometryDefEdit;
                geometryDefEdit.GeometryType_2 = geometryList[0].geometry.GeometryType;
                geometryDefEdit.SpatialReference_2 = geometryList[0].geometry.SpatialReference;
                IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(sName, requiredFields, new UIDClass
                {
                    Value = "esriGeoDatabase.Feature"
                }, null, esriFeatureType.esriFTSimple, shapeFieldName, "");

                try
                {
                    foreach (ROIGeometry roi in geometryList)
                    {
                        IFeature feature = featureClass.CreateFeature();
                        feature.Shape = roi.geometry;
                        feature.Store();
                    }

                    if (!string.IsNullOrEmpty(sAlias))
                    {
                        EngineAPI.AlterDatasetAlias(featureClass, sAlias);
                    }
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(featureClass);
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// alter alias of dataset
        /// </summary>
        /// <param name="objectClass">esri object</param>
        /// <param name="sAlias">alias</param>
        public static void AlterDatasetAlias(IObjectClass objectClass, string sAlias)
        {
            try
            {
                (objectClass as IClassSchemaEdit).AlterAliasName(sAlias);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 打开栅格文件
        /// </summary>
        public static IRasterDataset OpenRasterFile(string inFile)
        {
            FileInfo fInfo = new FileInfo(inFile);
            return EngineAPI.OpenRasterFile(fInfo.DirectoryName, fInfo.Name);

        }

        public static IRasterDataset OpenRasterDataset(string inFile, int bandIndex)
        {
            IWorkspaceFactory pWorkspaceFactory = null; 
            IRasterWorkspace rasterWorkspace=null;
            IRasterDataset rasterDataset = null;
            int Index = inFile.LastIndexOf("\\");
            string filePath = inFile.Substring(0, Index);
            string fileName = inFile.Substring(Index + 1);

            try
            {
                pWorkspaceFactory = new RasterWorkspaceFactory();
                rasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(filePath, 0);
                rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                if (bandIndex > 0)
                {
                    IRasterBandCollection pRasterBandCollection = rasterDataset as IRasterBandCollection;
                    IRasterBand pBand = pRasterBandCollection.Item(bandIndex - 1);
                    rasterDataset = pBand as IRasterDataset;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Failed in Opening RasterDataset. " + ex.InnerException.ToString());
                //Log.WriteLog(typeof(RasterMapAlgebraOp), ex);
                throw ex;
            }
            finally
            {
                if(pWorkspaceFactory!=null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pWorkspaceFactory);
                if (rasterWorkspace != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rasterWorkspace);
            }
            return rasterDataset;
        }
        /// <summary>
        /// 打开矢量文件
        /// </summary>
        /// <param name="shpFile">文件名</param>
        /// <returns></returns>
        public static IFeatureClass OpenFeatureClass(string shpFile)
        {
            IFeatureClass result;
            FileInfo fInfo = new FileInfo(shpFile);
            if (!System.IO.Directory.Exists(fInfo.DirectoryName))
            {
                result = null;
            }
            else
            {
                IWorkspace workspace = EngineAPI.OpenWorkspace(fInfo.DirectoryName, DataType.shp);
                if (workspace == null)
                {
                    result = null;
                }
                else
                {
                    IEnumDatasetName enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTFeatureClass);
                    try
                    {
                        enumDatasetName.Reset();
                        IDatasetName datasetName;
                        while ((datasetName = enumDatasetName.Next()) != null)
                        {
                            if (fInfo.Name.StartsWith(datasetName.Name))
                            {
                                break;
                            }
                        }
                        if (datasetName == null)
                        {
                            result = null;
                        }
                        else
                        {
                            IFeatureClass pFeatureClass = (datasetName as IName).Open() as IFeatureClass;
                            result = pFeatureClass;
                        }
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(enumDatasetName);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workspace);
                    }
                }
            }
            return result;
        }

        //
        //Get spatialReference from string 
        //
        public static ISpatialReference GetSpatialRefFromPrjStr(string strPrj)
        {
            ISpatialReference result = null;
            if (strPrj != "none")
            {
                ISpatialReferenceFactory4 spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                ISpatialReferenceInfo spatialReferenceInfo;
                int num;
                spatialReferenceFactory.CreateESRISpatialReferenceInfo(strPrj, out spatialReferenceInfo, out num);
                result = (spatialReferenceInfo as ISpatialReference);
            }
            return result;
        }

    }
}
