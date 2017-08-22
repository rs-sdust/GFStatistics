// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-10-2017
// ***********************************************************************
// <copyright file="CmdIdentifyTool .cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>ITool for identify clicked obj</summary>
// ***********************************************************************
using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
//using HTES.TAS.Const;
using GFS.BLL;
using GFS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GFS.Commands
{
    [ClassInterface(ClassInterfaceType.None), Guid("94106573-0228-40bb-8060-9fcb0ebe6c78"), ProgId("HTES.TAS.Tools.Identify.IdentifyTool")]
    public sealed class CmdIdentifyTool : BaseTool
    {
        private IHookHelper m_hookHelper;

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdIdentifyTool.ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdIdentifyTool.ArcGISCategoryUnregistration(registerType);
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(cLSID);
        }

        public CmdIdentifyTool()
        {
            this.m_category = "barItem";
            this.m_caption = "识别";
            this.m_message = "识别";
            this.m_toolTip = "识别";
            this.m_name = "CmdIdentifyTool";
            try
            {
                ITool tool = new ControlsMapIdentifyToolClass();
                this.m_cursor = new System.Windows.Forms.Cursor((IntPtr)tool.Cursor);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        public override void OnCreate(object hook)
        {
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
        }

        public override void OnClick()
        {
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                List<ILayer> layers = EngineAPI.GetLayers(this.m_hookHelper.FocusMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
                if (layers.Count == 0)
                {
                    IdentifyManager.instance.FrmIdentify.Close();
                    IdentifyManager.instance.FrmIdentify = null;
                    EnviVars.instance.MapControl.CurrentTool = null;
                    EnviVars.instance.MapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
                }
                else
                {
                    foreach (ILayer current in layers)
                    {
                        IIdentify identify = current as IIdentify;
                        IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                        IArray array = identify.Identify(point);
                        if (array != null && array.Count != 0)
                        {
                            IdentifyManager.instance.FrmIdentify.treeList1.ClearNodes();
                            IIdentifyObj identifyObj = array.get_Element(0) as IIdentifyObj;
                            identifyObj.Flash(this.m_hookHelper.ActiveView.ScreenDisplay);
                            TreeListNode treeListNode = IdentifyManager.instance.FrmIdentify.treeList1.AppendNode(new object[]
							{
								identifyObj.Layer.Name
							}, 0, identifyObj);
                            DataColumn column = new DataColumn("字段", typeof(string));
                            DataColumn column2 = new DataColumn("值", typeof(string));
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add(column);
                            dataTable.Columns.Add(column2);
                            if (current is IFeatureLayer)
                            {
                                IFeature feature = (identifyObj as IRowIdentifyObject).Row as IFeature;
                                TreeListNode treeListNode2 = IdentifyManager.instance.FrmIdentify.treeList1.AppendNode(new object[]
								{
									feature.OID.ToString()
								}, treeListNode);
                                int num = feature.Fields.FindField((current as IFeatureLayer).FeatureClass.ShapeFieldName);
                                for (int i = 0; i < feature.Fields.FieldCount; i++)
                                {
                                    if (num != i)
                                    {
                                        DataRow dataRow = dataTable.NewRow();
                                        dataRow["字段"] = feature.Fields.get_Field(i).AliasName;
                                        dataRow["值"] = feature.get_Value(i).ToString();
                                        dataTable.Rows.Add(dataRow);
                                    }
                                }
                                treeListNode2.Tag = dataTable;
                            }
                            else if (current is IRasterLayer)
                            {
                                IRasterLayer rasterLayer = current as IRasterLayer;
                                IRaster2 raster = rasterLayer.Raster as IRaster2;
                                int num2 = raster.ToPixelRow(point.Y);
                                int num3 = raster.ToPixelColumn(point.X);
                                double num4 = CommonAPI.ConvertToDouble(raster.GetPixelValue(0, num3, num2));
                                this.AddRow(dataTable, "像素值", num4);
                                this.AddRow(dataTable, "行号", num2);
                                this.AddRow(dataTable, "列号", num3);
                                IRasterIdentifyObj rasterIdentifyObj = array.get_Element(0) as IRasterIdentifyObj;
                                if (rasterLayer.BandCount != 1)
                                {
                                    Regex regex = new Regex("\\d{2,3}");
                                    MatchCollection matchCollection = regex.Matches(rasterIdentifyObj.MapTip);
                                    if (matchCollection.Count == 3)
                                    {
                                        this.AddRow(dataTable, "R", matchCollection[0].Value);
                                        this.AddRow(dataTable, "G", matchCollection[1].Value);
                                        this.AddRow(dataTable, "B", matchCollection[2].Value);
                                    }
                                }
                                IdentifyManager.instance.FrmIdentify.treeList1.AppendNode(new object[]
								{
									rasterIdentifyObj.Name
								}, treeListNode, dataTable);
                            }
                            IdentifyManager.instance.FrmIdentify.UpdateStatusText(string.Format("X:{0:0.000 },Y:{1:0.000}", point.X, point.Y));
                            IdentifyManager.instance.FrmIdentify.treeList1.ExpandAll();
                            if (treeListNode.Nodes.Count > 0)
                            {
                                IdentifyManager.instance.FrmIdentify.treeList1.FocusedNode = treeListNode.Nodes[0];
                            }
                            IdentifyManager.instance.FrmIdentify.Show();
                            break;
                        }
                        IdentifyManager.instance.FrmIdentify.Close();
                        IdentifyManager.instance.FrmIdentify = null;
                    }
                }
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
        }

        private void AddRow(DataTable dt, string fieldName, object value)
        {
            DataRow dataRow = dt.NewRow();
            dataRow["字段"] = fieldName;
            dataRow["值"] = value;
            dt.Rows.Add(dataRow);
        }
    }
}
