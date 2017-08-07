// ***********************************************************************
// Assembly         : SDJT.SystemUI
// Author           : yxq
// Created          : 04-01-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmSelectFeatures.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Form : Custom Open File Dialog</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SDJT.Common;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using SDJT.Sys;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using System.Collections;
using SDJT.Const;

/// <summary>
/// The CommandUI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmSelectFeatures.
    /// </summary>
    public partial class frmSelectFeatures : frmBase
    {
        /// <summary>
        /// The workspace list
        /// </summary>
        private List<WorkspaceInfo> m_pWorkspaceList = new List<WorkspaceInfo>();

        /// <summary>
        /// The start point
        /// </summary>
        private System.Drawing.Point m_pStartPoint = System.Drawing.Point.Empty;

        /// <summary>
        /// The Rectangle
        /// </summary>
        private Rectangle m_pRect = Rectangle.Empty;

        /// <summary>
        /// The PressedShiftKey
        /// </summary>
        private bool m_bPressedShiftKey = false;

        /// <summary>
        /// The PressedCtrlKey
        /// </summary>
        private bool m_bPressedCtrlKey = false;

        /// <summary>
        /// The MSG_ERROR01
        /// </summary>
        private static string MSG_ERROR01 = "存在已损坏图层！读取失败！";

        /// <summary>
        /// The MSG_ERROR02
        /// </summary>
        private static string MSG_ERROR02 = "图层{0}已损坏！读取失败！";

        /// <summary>
        /// The MSG_CONST01
        /// </summary>
        private static string MSG_CONST01 = "添加SDE连接";

        /// <summary>
        /// Gets the panel bottom.
        /// </summary>
        /// <value>The panel bottom.</value>
        public PanelControl PanelBottom
        {
            get
            {
                return this.panelBottom; 
            }
        }

        /// <summary>
        /// Gets the selected features.
        /// </summary>
        /// <value>The selected features.</value>
        public List<IFeatureClass> SelectedFeatures
        {
            get
            {
                List<IFeatureClass> list = new List<IFeatureClass>();
                list.AddRange(this.FeaturesDict.Values);
                return list;
            }
        }

        /// <summary>
        /// Gets the features dictionary.
        /// </summary>
        /// <value>The features dictionary.</value>
        public SortedDictionary<string, IFeatureClass> FeaturesDict
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the raster list.
        /// </summary>
        /// <value>The raster list.</value>
        public List<IRasterDataset> RasterList
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the raster dictionary.
        /// </summary>
        /// <value>The raster dictionary.</value>
        public Dictionary<string, IRasterDataset> RasterDict
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has tables.
        /// </summary>
        /// <value><c>true</c> if this instance has tables; otherwise, <c>false</c>.</value>
        public bool HasTables
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is multi select.
        /// </summary>
        /// <value><c>true</c> if this instance is multi select; otherwise, <c>false</c>.</value>
        public bool IsMultiSelect
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the geometry.
        /// </summary>
        /// <value>The type of the geometry.</value>
        public esriGeometryType GeometryType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        public DataType DataType
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmSelectFeatures" /> class.
        /// </summary>
        public frmSelectFeatures()
        {
            InitializeComponent();
            this.IsMultiSelect = true;
            this.GeometryType = esriGeometryType.esriGeometryAny;
            this.DataType = (DataType)47;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }

        /// <summary>
        /// Handles the Load event of the frmSelectFeatures control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void frmSelectFeatures_Load(object sender, EventArgs e)
        {
            this.FeaturesDict = new SortedDictionary<string, IFeatureClass>();
            this.RasterList = new List<IRasterDataset>();
            this.RasterDict = new Dictionary<string, IRasterDataset>();
            this.imageListFile.ImageList = base.DataImageList;
            this.imageComboBoxPath.Properties.SmallImages = base.DataImageList;
            this.imageListFile.SelectionMode = (this.IsMultiSelect ? SelectionMode.MultiExtended : SelectionMode.One);
            string pathFromRegistry = CommonAPI.GetPathFromRegistry(CommonAPI.KEY_FEATURE_PATH);
            ControlAPI.InitPathComboBox(pathFromRegistry, this.imageComboBoxPath, this.DataType);
        }

        /// <summary>
        /// Handles the DrawItem event of the imageComboBoxPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ListBoxDrawItemEventArgs" /> instance containing the event data.</param>
        private void imageComboBoxPath_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            ControlAPI.DrawPathItem(e, base.DataImageList);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the imageComboBoxPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void imageComboBoxPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnBack.Enabled = false;
            ImageComboBoxItem imageComboBoxItem = this.imageComboBoxPath.SelectedItem as ImageComboBoxItem;
            if (imageComboBoxItem != null)
            {
                if (imageComboBoxItem.ImageIndex != 2 && imageComboBoxItem.ImageIndex != 33)
                {
                    this.btnBack.Enabled = true;
                }
                string sPath = imageComboBoxItem.Value.ToString();
                IconType imageIndex = (IconType)imageComboBoxItem.ImageIndex;
                if (imageIndex <= IconType.Cad)
                {
                    switch (imageIndex)
                    {
                        case IconType.Disk:
                        case IconType.Folder:
                            ControlAPI.OpenFolder(sPath, this.imageListFile, this.DataType, this.m_pWorkspaceList, this.GeometryType);
                            break;
                        case IconType.ShpPoint:
                        case IconType.ShpLine:
                        case IconType.ShpPolygon:
                            break;
                        case IconType.PGDB:
                            ControlAPI.OpenGeodatabase(sPath, this.imageListFile, DataType.mdb, this.m_pWorkspaceList, this.GeometryType, this.HasTables, false);
                            break;
                        case IconType.PGDBDataset:
                            this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.mdb, this.GeometryType);
                            break;
                        default:
                            if (imageIndex != IconType.Coverage)
                            {
                                if (imageIndex == IconType.Cad)
                                {
                                    this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.cad, this.GeometryType);
                                }
                            }
                            else
                            {
                                this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.coverage, this.GeometryType);
                            }
                            break;
                    }
                }
                else if (imageIndex != IconType.SdeConnections)
                {
                    switch (imageIndex)
                    {
                        case IconType.FGDB:
                            ControlAPI.OpenGeodatabase(sPath, this.imageListFile, DataType.gdb, this.m_pWorkspaceList, this.GeometryType, this.HasTables, false);
                            break;
                        case IconType.FGDBDataset:
                            this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.gdb, this.GeometryType);
                            break;
                        default:
                            switch (imageIndex)
                            {
                                case IconType.SDE:
                                    ControlAPI.OpenGeodatabase(sPath, this.imageListFile, DataType.sde, this.m_pWorkspaceList, this.GeometryType, this.HasTables, false);
                                    break;
                                case IconType.SDEDataset:
                                    this.OpenGeodatabaseDataset(sPath, imageComboBoxItem.Description, DataType.sde, this.GeometryType);
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    this.GetSDEConnInfo();
                }
                this.ClearImageListSelectedItems();
            }
        }
        /// <summary>
        /// Opens the geodatabase dataset.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        /// <param name="type">The type.</param>
        /// <param name="geometryType">Type of the geometry.</param>
        private void OpenGeodatabaseDataset(string sPath, string sName, DataType type, esriGeometryType geometryType)
        {
            string sFilePath = sPath.Substring(0, sPath.Length - sName.Length - 1);
            IWorkspace workspace = ControlAPI.GetWorkspace(sFilePath, type, this.m_pWorkspaceList);
            if (workspace != null)
            {
                this.imageListFile.BeginUpdate();
                try
                {
                    this.imageListFile.Items.Clear();
                    if (workspace != null)
                    {
                        IEnumDatasetName enumDatasetName = workspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
                        try
                        {
                            enumDatasetName.Reset();
                            IDatasetName datasetName;
                            while ((datasetName = enumDatasetName.Next()) != null)
                            {
                                if (datasetName.Name == sName)
                                {
                                    break;
                                }
                            }
                            ControlAPI.AddFeatureClassToListBox(datasetName.SubsetNames, this.imageListFile, type, geometryType);
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(enumDatasetName);
                        }
                    }
                }
                finally
                {
                    this.imageListFile.EndUpdate();
                }
            }
        }

        /// <summary>
        /// Gets the sde connection information.
        /// </summary>
        private void GetSDEConnInfo()
        {
            this.imageListFile.BeginUpdate();
            this.imageListFile.Items.Clear();
            ControlAPI.AddItemToListBox(IconType.AddSdeConn, frmSelectFeatures.MSG_CONST01, this.imageListFile);
            DirectoryInfo directoryInfo = new DirectoryInfo(ConstDef.PATH_CONFIG);
            FileInfo[] files = directoryInfo.GetFiles("*.sde", SearchOption.AllDirectories);
            FileInfo[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                FileInfo fileInfo = array[i];
                ControlAPI.AddItemToListBox(IconType.SdeConnection, fileInfo.Name, this.imageListFile);
            }
            this.imageListFile.EndUpdate();
        }

        /// <summary>
        /// Clears the image list selected items.
        /// </summary>
        private void ClearImageListSelectedItems()
        {
            for (int i = 0; i < this.imageListFile.Items.Count; i++)
            {
                this.imageListFile.SetSelected(i, false);
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void imageListFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int num = this.imageListFile.IndexFromPoint(e.Location);
                if (num >= 0)
                {
                    string selectedPath = ControlAPI.GetSelectedPath(this.imageComboBoxPath);
                    if (selectedPath != null)
                    {
                        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            string itemText = this.imageListFile.GetItemText(num);
                            string text = selectedPath + itemText;
                            switch (this.imageListFile.GetItemImageIndex(num))
                            {
                                case 3:
                                    ControlAPI.InsertItemToComboBox(IconType.Folder, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 4:
                                case 5:
                                case 6:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.shp);
                                    break;
                                case 7:
                                    ControlAPI.InsertItemToComboBox(IconType.PGDB, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 8:
                                    ControlAPI.InsertItemToComboBox(IconType.PGDBDataset, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.mdb);
                                    break;
                                case 17:
                                    ControlAPI.InsertItemToComboBox(IconType.Coverage, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 18:
                                case 19:
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.coverage);
                                    break;
                                case 24:
                                    ControlAPI.InsertItemToComboBox(IconType.Cad, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 25:
                                case 26:
                                case 27:
                                case 28:
                                case 29:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.cad);
                                    break;
                                case 31:
                                    this.OpenRasterDataset(selectedPath, itemText);
                                    break;
                                case 34:
                                    //this.AddSDEConn(selectedPath);
                                    break;
                                case 35:
                                    //this.OpenSDEConn(itemText, text);
                                    break;
                                case 36:
                                    {
                                        string coverageDir = ControlAPI.GetCoverageDir();
                                        if (EngineAPI.E00ToCoverage(text, coverageDir))
                                        {
                                            string sName = System.IO.Path.GetFileNameWithoutExtension(text).ToLower();
                                            this.GetDatasetFeatures(coverageDir, sName, DataType.coverage);
                                            if (this.FeaturesDict != null && this.FeaturesDict.Count > 0)
                                            {
                                                //base.DialogResult = DialogResult.OK;
                                                //CommandAPI.AddRasterLayersToMap(this.RasterDict);
                                                CommandAPI.AddFeatureLayersToMap(this.SelectedFeatures);
                                            }
                                        }
                                        break;
                                    }
                                case 37:
                                    ControlAPI.InsertItemToComboBox(IconType.FGDB, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 38:
                                    ControlAPI.InsertItemToComboBox(IconType.FGDBDataset, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 39:
                                case 40:
                                case 41:
                                case 42:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.gdb);
                                    break;
                                case 44:
                                    ControlAPI.InsertItemToComboBox(IconType.SDEDataset, text, itemText, this.imageComboBoxPath);
                                    break;
                                case 45:
                                case 46:
                                case 47:
                                case 48:
                                    this.OpenFeatureClass(selectedPath, itemText, DataType.sde);
                                    break;
                            }
                        }
                        finally
                        {
                            System.Windows.Forms.Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void imageListFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                this.m_bPressedShiftKey = true;
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                this.m_bPressedCtrlKey = true;
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void imageListFile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                this.m_bPressedShiftKey = false;
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                this.m_bPressedCtrlKey = false;
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void imageListFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.IsMultiSelect)
            {
                if (!this.m_bPressedCtrlKey && !this.m_bPressedShiftKey)
                {
                    this.ClearImageListSelectedItems();
                }
                this.m_pStartPoint = e.Location;
                this.m_pRect = Rectangle.Empty;
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void imageListFile_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMultiSelect && !this.m_pStartPoint.IsEmpty)
            {
                this.m_pRect = this.GetRect(e);
                this.SelectImageListBoxItems();
                this.imageListFile.Refresh();
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void imageListFile_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsMultiSelect && !this.m_pStartPoint.IsEmpty)
            {
                this.m_pStartPoint = System.Drawing.Point.Empty;
                this.m_pRect = Rectangle.Empty;
                this.imageListFile.Refresh();
            }
        }

        /// <summary>
        /// Handles the Paint event of the imageListFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        private void imageListFile_Paint(object sender, PaintEventArgs e)
        {
            if (this.IsMultiSelect && !this.m_pRect.IsEmpty)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), this.m_pRect);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.imageComboBoxPath.SelectedIndex >= 1)
            {
                this.imageComboBoxPath.SelectedIndex = this.imageComboBoxPath.SelectedIndex - 1;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string selectedPath = ControlAPI.GetSelectedPath(this.imageComboBoxPath);
            if (selectedPath != null)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                    List<ImageListBoxItem> list = new List<ImageListBoxItem>();
                    int num = 0;
                    foreach (ImageListBoxItem imageListBoxItem in ((IEnumerable)this.imageListFile.SelectedItems))
                    {
                        string text = imageListBoxItem.Value.ToString();
                        IconType imageIndex = (IconType)imageListBoxItem.ImageIndex;
                        IconType imageIndex2 = (IconType)imageListBoxItem.ImageIndex;
                        if (imageIndex2 <= IconType.Coverage)
                        {
                            if (imageIndex2 == IconType.Folder)
                            {
                                ControlAPI.InsertItemToComboBox(IconType.Folder, selectedPath + text, text, this.imageComboBoxPath);
                                return;
                            }
                            switch (imageIndex2)
                            {
                                case IconType.PGDB:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.PGDB, selectedPath + text, text, this.imageComboBoxPath);
                                        return;
                                    }
                                    num++;
                                    break;
                                case IconType.PGDBDataset:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.PGDBDataset, selectedPath + text, text, this.imageComboBoxPath);
                                        return;
                                    }
                                    break;
                                default:
                                    if (imageIndex2 == IconType.Coverage)
                                    {
                                        if (!this.IsMultiSelect)
                                        {
                                            ControlAPI.InsertItemToComboBox(IconType.Coverage, selectedPath + text, text, this.imageComboBoxPath);
                                            return;
                                        }
                                    }
                                    break;
                            }
                        }
                        else if (imageIndex2 != IconType.Cad)
                        {
                            switch (imageIndex2)
                            {
                                case IconType.AddSdeConn:
                                    //this.AddSDEConn(selectedPath);
                                    return;
                                case IconType.SdeConnection:
                                    //this.OpenSDEConn(text, selectedPath + text);
                                    return;
                                case IconType.E00:
                                    break;
                                case IconType.FGDB:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.FGDB, selectedPath + text, text, this.imageComboBoxPath);
                                        return;
                                    }
                                    num++;
                                    break;
                                case IconType.FGDBDataset:
                                    if (!this.IsMultiSelect)
                                    {
                                        ControlAPI.InsertItemToComboBox(IconType.FGDBDataset, selectedPath + text, text, this.imageComboBoxPath);
                                        return;
                                    }
                                    break;
                                default:
                                    if (imageIndex2 == IconType.SDEDataset)
                                    {
                                        if (!this.IsMultiSelect)
                                        {
                                            ControlAPI.InsertItemToComboBox(IconType.SDEDataset, selectedPath + text, text, this.imageComboBoxPath);
                                            return;
                                        }
                                    }
                                    break;
                            }
                        }
                        else if (!this.IsMultiSelect)
                        {
                            ControlAPI.InsertItemToComboBox(IconType.Cad, selectedPath + text, text, this.imageComboBoxPath);
                            return;
                        }
                        list.Add(imageListBoxItem);
                    }
                    if (list.Count != 0 && num <= 1)
                    {
                        this.FeaturesDict.Clear();
                        this.RasterList.Clear();
                        this.RasterDict.Clear();
                        string text2 = selectedPath.TrimEnd(new char[]
                        {
                            '\\'
                        });
                        string text3 = "";
                        foreach (ImageListBoxItem imageListBoxItem in list)
                        {
                            string text = imageListBoxItem.Value.ToString();
                            switch (imageListBoxItem.ImageIndex)
                            {
                                case 4:
                                case 5:
                                case 6:
                                    if (!this.GetFeatures(selectedPath, text, DataType.shp))
                                    {
                                        return;
                                    }
                                    break;
                                case 7:
                                    if (!this.GetWorkspaceFeatures(text2, text, DataType.mdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 8:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.mdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    if (!this.GetFeatures(selectedPath, text, DataType.mdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 17:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.coverage))
                                    {
                                        return;
                                    }
                                    break;
                                case 18:
                                case 19:
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                    if (!this.GetFeatures(selectedPath, text, DataType.coverage))
                                    {
                                        return;
                                    }
                                    break;
                                case 24:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.cad))
                                    {
                                        return;
                                    }
                                    break;
                                case 25:
                                case 26:
                                case 27:
                                case 28:
                                case 29:
                                    if (!this.GetFeatures(selectedPath, text, DataType.cad))
                                    {
                                        return;
                                    }
                                    break;
                                case 31:
                                    this.GetRasterDataset(selectedPath, text);
                                    break;
                                case 36:
                                    {
                                        if (text3 == "")
                                        {
                                            text3 = ControlAPI.GetCoverageDir();
                                        }
                                        string text4 = text2 + "\\" + text;
                                        if (EngineAPI.E00ToCoverage(text4, text3))
                                        {
                                            string sName = System.IO.Path.GetFileNameWithoutExtension(text4).ToLower();
                                            this.GetDatasetFeatures(text3, sName, DataType.coverage);
                                        }
                                        break;
                                    }
                                case 37:
                                    if (!this.GetWorkspaceFeatures(text2, text, DataType.gdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 38:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.gdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 39:
                                case 40:
                                case 41:
                                case 42:
                                    if (!this.GetFeatures(selectedPath, text, DataType.gdb))
                                    {
                                        return;
                                    }
                                    break;
                                case 44:
                                    if (!this.GetDatasetFeatures(selectedPath, text, DataType.sde))
                                    {
                                        return;
                                    }
                                    break;
                                case 45:
                                case 46:
                                case 47:
                                case 48:
                                    if (!this.GetFeatures(selectedPath, text, DataType.sde))
                                    {
                                        return;
                                    }
                                    break;
                            }
                        }
                        base.DialogResult = DialogResult.OK;
                    }
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = Cursors.Default;
                }
            }
        }
        //--------------------------------------------
        /// <summary>
        /// Gets the rect.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetRect(MouseEventArgs e)
        {
            int num = Math.Min(this.m_pStartPoint.X, e.X);
            int num2 = Math.Min(this.m_pStartPoint.Y, e.Y);
            int num3 = Math.Max(this.m_pStartPoint.X, e.X);
            int num4 = Math.Max(this.m_pStartPoint.Y, e.Y);
            Rectangle result = new Rectangle(num, num2, num3 - num, num4 - num2);
            return result;
        }

        /// <summary>
        /// Selects the image ListBox items.
        /// </summary>
        private void SelectImageListBoxItems()
        {
            if (!this.m_pRect.IsEmpty)
            {
                for (int i = 0; i < this.imageListFile.Items.Count; i++)
                {
                    Rectangle itemRectangle = this.imageListFile.GetItemRectangle(i);
                    bool value = false;
                    if (itemRectangle.IntersectsWith(this.m_pRect))
                    {
                        value = true;
                    }
                    this.imageListFile.SetSelected(i, value);
                }
            }
        }
        /// <summary>
        /// Opens the feature class.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        /// <param name="type">The type.</param>
        private void OpenFeatureClass(string sPath, string sName, DataType type)
        {
            this.RasterList.Clear();
            this.RasterDict.Clear();
            this.FeaturesDict.Clear();
            this.GetFeatures(sPath, sName, type);
            if (this.FeaturesDict.Count == 1)
            {
                //base.DialogResult = DialogResult.OK;
                //CommandAPI.AddRasterLayersToMap(this.RasterDict);
                CommandAPI.AddFeatureLayersToMap(this.SelectedFeatures);
            }
        }

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool GetFeatures(string sPath, string sName, DataType type)
        {
            string sPrefix = "";
            string text = "";
            string text2 = sPath.TrimEnd(new char[]
            {
                '\\'
            });
            if (type <= DataType.sde)
            {
                switch (type)
                {
                    case DataType.mdb:
                        {
                            int num = text2.LastIndexOf(".mdb", StringComparison.CurrentCultureIgnoreCase);
                            text2 = text2.Substring(0, num + 4);
                            break;
                        }
                    case (DataType)3:
                        break;
                    case DataType.gdb:
                        {
                            int num = text2.LastIndexOf(".gdb", StringComparison.CurrentCultureIgnoreCase);
                            text2 = text2.Substring(0, num + 4);
                            break;
                        }
                    default:
                        if (type == DataType.sde)
                        {
                            int num = text2.LastIndexOf(".sde", StringComparison.CurrentCultureIgnoreCase);
                            text2 = text2.Substring(0, num + 4);
                        }
                        break;
                }
            }
            else if (type == DataType.cad || type == DataType.coverage)
            {
                int num = text2.LastIndexOf('\\');
                text = text2.Substring(num + 1);
                int num2 = text.LastIndexOf('.');
                if (num2 >= 0)
                {
                    sPrefix = text.Substring(0, num2) + "_";
                }
                else
                {
                    sPrefix = text + "_";
                }
                text2 = text2.Substring(0, num);
            }
            IFeatureWorkspace featureWorkspace = ControlAPI.GetWorkspace(text2, type, this.m_pWorkspaceList) as IFeatureWorkspace;
            bool result;
            if (featureWorkspace == null)
            {
                result = true;
            }
            else
            {
                IFeatureClass featureClass = null;
                try
                {
                    if (type <= DataType.sde)
                    {
                        switch (type)
                        {
                            case DataType.shp:
                            case DataType.mdb:
                            case DataType.gdb:
                                break;
                            case (DataType)3:
                                goto IL_202;
                            default:
                                if (type != DataType.sde)
                                {
                                    goto IL_202;
                                }
                                break;
                        }
                        featureClass = featureWorkspace.OpenFeatureClass(sName);
                    }
                    else if (type == DataType.cad || type == DataType.coverage)
                    {
                        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(text);
                        IEnumDataset subsets = featureDataset.Subsets;
                        try
                        {
                            subsets.Reset();
                            IDataset dataset;
                            while ((dataset = subsets.Next()) != null)
                            {
                                if (dataset.Name == sName)
                                {
                                    featureClass = (dataset as IFeatureClass);
                                    break;
                                }
                            }
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(subsets);
                            Marshal.ReleaseComObject(featureDataset);
                        }
                    }
                    IL_202:;
                }
                catch
                {
                    XtraMessageBox.Show(string.Format(frmSelectFeatures.MSG_ERROR02, sName), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = false;
                    return result;
                }
                if (featureClass != null)
                {
                    string covOrCadFCName = ControlAPI.GetCovOrCadFCName(sPrefix, sName);
                    if (covOrCadFCName == "" || this.FeaturesDict.ContainsKey(covOrCadFCName))
                    {
                        Marshal.ReleaseComObject(featureClass);
                        result = true;
                        return result;
                    }
                    this.FeaturesDict.Add(covOrCadFCName, featureClass);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Opens the raster dataset.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        private void OpenRasterDataset(string sPath, string sName)
        {
            this.RasterList.Clear();
            this.RasterDict.Clear();
            this.FeaturesDict.Clear();
            this.GetRasterDataset(sPath, sName);
            if (this.RasterList.Count == 1)
            {
                //base.DialogResult = DialogResult.OK;
                CommandAPI.AddRasterLayersToMap(this.RasterDict);
                //CommandAPI.AddFeatureLayersToMap(this.SelectedFeatures);
            }
        }

        /// <summary>
        /// Gets the raster dataset.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        private void GetRasterDataset(string sPath, string sName)
        {
            IRasterWorkspace2 rasterWorkspace = ControlAPI.GetWorkspace(sPath, DataType.raster, this.m_pWorkspaceList) as IRasterWorkspace2;
            if (rasterWorkspace != null)
            {
                IEnumDatasetName enumDatasetName = (rasterWorkspace as IWorkspace).get_DatasetNames(esriDatasetType.esriDTRasterDataset);
                try
                {
                    enumDatasetName.Reset();
                    IDatasetName datasetName;
                    while ((datasetName = enumDatasetName.Next()) != null)
                    {
                        if (string.Equals(datasetName.Name, sName, StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }
                    }
                    if (datasetName != null)
                    {
                        IRasterDataset rasterDataset = (datasetName as IName).Open() as IRasterDataset;
                        this.RasterList.Add(rasterDataset);
                        string key = System.IO.Path.Combine(sPath, sName);
                        if (this.RasterDict.ContainsKey(key))
                        {
                            this.RasterDict[key] = rasterDataset;
                        }
                        else
                        {
                            this.RasterDict.Add(key, rasterDataset);
                        }
                    }
                }
                finally
                {
                    Marshal.ReleaseComObject(enumDatasetName);
                }
            }
        }

        /// <summary>
        /// Gets the dataset features.
        /// </summary>
        /// <param name="sPath">The s path.</param>
        /// <param name="sName">Name of the s.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool GetDatasetFeatures(string sPath, string sName, DataType type)
        {
            string sPrefix = "";
            string sFilePath;
            if (type <= DataType.sde)
            {
                switch (type)
                {
                    case DataType.mdb:
                    case DataType.gdb:
                        break;
                    case (DataType)3:
                        goto IL_80;
                    default:
                        if (type != DataType.sde)
                        {
                            goto IL_80;
                        }
                        break;
                }
                sFilePath = sPath.TrimEnd(new char[]
                {
                    '\\'
                });
                goto IL_88;
            }
            if (type == DataType.cad || type == DataType.coverage)
            {
                sPrefix = sName + "_";
                sFilePath = sPath.TrimEnd(new char[]
                {
                    '\\'
                });
                goto IL_88;
            }
            IL_80:
            bool result = true;
            return result;
            IL_88:
            IWorkspace workspace = ControlAPI.GetWorkspace(sFilePath, type, this.m_pWorkspaceList);
            if (workspace == null)
            {
                result = true;
            }
            else
            {
                try
                {
                    IFeatureDataset featureDataset = (workspace as IFeatureWorkspace).OpenFeatureDataset(sName);
                    IEnumDataset subsets = featureDataset.Subsets;
                    try
                    {
                        subsets.Reset();
                        IDataset dataset;
                        while ((dataset = subsets.Next()) != null)
                        {
                            IFeatureClass featureClass = dataset as IFeatureClass;
                            if (featureClass != null)
                            {
                                string covOrCadFCName = ControlAPI.GetCovOrCadFCName(sPrefix, dataset.Name);
                                if (covOrCadFCName == "" || this.FeaturesDict.ContainsKey(covOrCadFCName))
                                {
                                    Marshal.ReleaseComObject(featureClass);
                                }
                                else
                                {
                                    this.FeaturesDict.Add(covOrCadFCName, featureClass);
                                }
                            }
                        }
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(subsets);
                        Marshal.ReleaseComObject(featureDataset);
                    }
                    result = true;
                }
                catch
                {
                    XtraMessageBox.Show(frmSelectFeatures.MSG_ERROR01, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = false;
                }
            }
            return result;
        }
        /// <summary>
        /// Gets the workspace features.
        /// </summary>
        /// <param name="sFilePath">The s file path.</param>
        /// <param name="sName">Name of the s.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool GetWorkspaceFeatures(string sFilePath, string sName, DataType type)
        {
            string sFilePath2 = sFilePath + "\\" + sName;
            IWorkspace workspace = ControlAPI.GetWorkspace(sFilePath2, type, this.m_pWorkspaceList);
            bool result;
            if (workspace == null)
            {
                result = true;
            }
            else
            {
                try
                {
                    IEnumDataset enumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                    try
                    {
                        IDataset dataset;
                        while ((dataset = enumDataset.Next()) != null)
                        {
                            if (this.FeaturesDict.ContainsKey(dataset.Name))
                            {
                                Marshal.ReleaseComObject(dataset);
                            }
                            else
                            {
                                this.FeaturesDict.Add(dataset.Name, dataset as IFeatureClass);
                            }
                        }
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(enumDataset);
                    }
                    enumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                    try
                    {
                        IDataset dataset;
                        while ((dataset = enumDataset.Next()) != null)
                        {
                            IEnumDataset subsets = (dataset as IFeatureDataset).Subsets;
                            try
                            {
                                IDataset dataset2;
                                while ((dataset2 = subsets.Next()) != null)
                                {
                                    if (this.FeaturesDict.ContainsKey(dataset2.Name))
                                    {
                                        Marshal.ReleaseComObject(dataset2);
                                    }
                                    else
                                    {
                                        this.FeaturesDict.Add(dataset2.Name, dataset2 as IFeatureClass);
                                    }
                                }
                            }
                            finally
                            {
                                Marshal.ReleaseComObject(subsets);
                            }
                        }
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(enumDataset);
                    }
                    result = true;
                }
                catch
                {
                    XtraMessageBox.Show(frmSelectFeatures.MSG_ERROR01, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            base.Close();
        }

    }
}