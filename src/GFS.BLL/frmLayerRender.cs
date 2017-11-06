// ***********************************************************************
// Assembly         : SDJT.System
// Author           : Ricker Yan
// Created          : 04-19-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-21-2016
// ***********************************************************************
// <copyright file="frmLayerRender.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>图层渲染UI</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
//using SDJT.Sys;
//using SDJT.Carto;
using DevExpress.Utils;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
//using SDJT.Const;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.esriSystem;
using GFS.Carto;
//using SDJT.Log;

/// <summary>
/// The Sys namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class frmLayerRender.
    /// </summary>
    public partial class frmLayerRender : DevExpress.XtraEditors.XtraForm
    {

        //private Logger m_logger = new Logger();

        /// <summary>
        /// The layer
        /// </summary>
        private ILayer layer = null;

        /// <summary>
        /// The layer type
        /// </summary>
        private LayerType layerType;

        /// <summary>
        /// The simple renderer symbol
        /// </summary>
        private ISymbol simpleRendererSymbol = null;

        /// <summary>
        /// The unique value record class list
        /// </summary>
        private List<UniqueValueRecordClass> uniqueValueRecordClassList = null;

        /// <summary>
        /// The classify record class list
        /// </summary>
        private List<ClassifyRecordClass> classifyRecordClassList = null;

        /// <summary>
        /// The random color ramp image list
        /// </summary>
        private ImageList RandomColorRampImageList = null;

        /// <summary>
        /// The current enum colors
        /// </summary>
        private IEnumColors CurrentEnumColors = null;

        /// <summary>
        /// The current symbology style class
        /// </summary>
        private esriSymbologyStyleClass CurrentSymbologyStyleClass;

        /// <summary>
        /// The p style gallery
        /// </summary>
        private IStyleGallery pStyleGallery = null;

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "渲染方式";

        /// <summary>
        /// The ms G02
        /// </summary>
        private static string MSG02 = "矢量图层";

        /// <summary>
        /// The ms G03
        /// </summary>
        private static string MSG03 = "简单渲染";

        /// <summary>
        /// The ms G04
        /// </summary>
        private static string MSG04 = "唯一值渲染";

        /// <summary>
        /// The ms G05
        /// </summary>
        private static string MSG05 = "栅格图层";

        /// <summary>
        /// The ms G06
        /// </summary>
        private static string MSG06 = "分类渲染";

        /// <summary>
        /// The ms G07
        /// </summary>
        private static string MSG07 = "拉伸渲染";

        /// <summary>
        /// The ms G08
        /// </summary>
        private static string MSG08 = "计算统计和直方图......";

        /// <summary>
        /// The ms G09
        /// </summary>
        private static string MSG09 = "符号";

        /// <summary>
        /// The ms G10
        /// </summary>
        private static string MSG10 = "值";

        /// <summary>
        /// The ms G11
        /// </summary>
        private static string MSG11 = "标注";

        /// <summary>
        /// The ms G12
        /// </summary>
        private static string MSG12 = "请先选择配色方案！";

        /// <summary>
        /// The ms G13
        /// </summary>
        private static string MSG13 = "请先选择字段！";
        /// <summary>
        /// Initializes a new instance of the <see cref="frmLayerRender"/> class.
        /// </summary>
        /// <param name="layer">The layer.</param>
        public frmLayerRender(ILayer layer)
        {
            this.InitializeComponent();
            this.layer = layer;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel1);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel2);
        }

        /// <summary>
        /// Handles the Load event of the FormLayerProperty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormLayerProperty_Load(object sender, EventArgs e)
        {
            if (this.layer is IGeoFeatureLayer)
            {
                this.layerType = LayerType.FeatureLayer;
            }
            else
            {
                if (!(this.layer is IRasterLayer))
                {
                    base.Close();
                    return;
                }
                this.layerType = LayerType.RasterLayer;
            }
            this.xtraTabControl.ShowTabHeader = DefaultBoolean.False;
            this.btnRasterUniqueRemoveValues.Enabled = false;
            this.btnRasterUniqueRemoveAllValues.Enabled = false;
            this.btnUniqueRemoveValues.Enabled = false;
            this.btnUniqueRemoveAllValues.Enabled = false;
            this.InitTreeList();
            this.InitColorScheme();
            this.InitRendererInfo();
        }

        /// <summary>
        /// Initializes the tree list.
        /// </summary>
        private void InitTreeList()
        {
            this.treeListRenderer.OptionsBehavior.Editable = false;
            this.treeListRenderer.OptionsSelection.InvertSelection = true;
            this.treeListRenderer.Columns.Add();
            this.treeListRenderer.Columns[0].Caption = frmLayerRender.MSG01;
            this.treeListRenderer.Columns[0].Visible = true;
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    {
                        TreeListNode parentNode = this.treeListRenderer.AppendNode(new object[]
                        {
                    frmLayerRender.MSG02
                        }, null);
                        this.treeListRenderer.AppendNode(new object[]
                        {
                    frmLayerRender.MSG03
                        }, parentNode);
                        this.treeListRenderer.AppendNode(new object[]
                        {
                    frmLayerRender.MSG04
                        }, parentNode);
                        break;
                    }
                case LayerType.RasterLayer:
                    {
                        TreeListNode parentNode = this.treeListRenderer.AppendNode(new object[]
                        {
                    frmLayerRender.MSG05
                        }, null);
                        IRasterLayer rasterLayer = this.layer as IRasterLayer;
                        IRasterRenderer renderer = rasterLayer.Renderer;
                        IAttributeTable attributeTable = rasterLayer as IAttributeTable;
                        if (attributeTable.AttributeTable != null)
                        {
                            this.treeListRenderer.AppendNode(new object[]
                            {
                        frmLayerRender.MSG04
                            }, parentNode);
                        }
                        this.treeListRenderer.AppendNode(new object[]
                        {
                    frmLayerRender.MSG06
                        }, parentNode);
                        this.treeListRenderer.AppendNode(new object[]
                        {
                    frmLayerRender.MSG07
                        }, parentNode);
                        break;
                    }
            }
            this.treeListRenderer.ExpandAll();
            this.FocusRendererType();
        }

        /// <summary>
        /// Focuses the type of the renderer.
        /// </summary>
        private void FocusRendererType()
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    {
                        IGeoFeatureLayer geoFeatureLayer = this.layer as IGeoFeatureLayer;
                        IFeatureRenderer renderer = geoFeatureLayer.Renderer;
                        if (renderer is ISimpleRenderer)
                        {
                            TreeListNode rendererTypeNode = this.GetRendererTypeNode(frmLayerRender.MSG03);
                            if (rendererTypeNode != null)
                            {
                                this.treeListRenderer.SetFocusedNode(rendererTypeNode);
                            }
                        }
                        else if (renderer is IUniqueValueRenderer)
                        {
                            TreeListNode rendererTypeNode = this.GetRendererTypeNode(frmLayerRender.MSG04);
                            if (rendererTypeNode != null)
                            {
                                this.treeListRenderer.SetFocusedNode(rendererTypeNode);
                            }
                        }
                        break;
                    }
                case LayerType.RasterLayer:
                    {
                        IRasterLayer rasterLayer = this.layer as IRasterLayer;
                        IRasterRenderer renderer2 = rasterLayer.Renderer;
                        if (renderer2 is IRasterUniqueValueRenderer)
                        {
                            TreeListNode rendererTypeNode = this.GetRendererTypeNode(frmLayerRender.MSG04);
                            if (rendererTypeNode != null)
                            {
                                this.treeListRenderer.SetFocusedNode(rendererTypeNode);
                            }
                        }
                        else if (renderer2 is IRasterClassifyColorRampRenderer)
                        {
                            TreeListNode rendererTypeNode = this.GetRendererTypeNode(frmLayerRender.MSG06);
                            if (rendererTypeNode != null)
                            {
                                this.treeListRenderer.SetFocusedNode(rendererTypeNode);
                            }
                        }
                        else if (renderer2 is IRasterStretchColorRampRenderer)
                        {
                            TreeListNode rendererTypeNode = this.GetRendererTypeNode(frmLayerRender.MSG07);
                            if (rendererTypeNode != null)
                            {
                                this.treeListRenderer.SetFocusedNode(rendererTypeNode);
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Gets the renderer type node.
        /// </summary>
        /// <param name="rendererType">Type of the renderer.</param>
        /// <returns>TreeListNode.</returns>
        private TreeListNode GetRendererTypeNode(string rendererType)
        {
            TreeListNode treeListNode = this.treeListRenderer.Nodes[0];
            TreeListNode result;
            for (int i = 0; i < treeListNode.Nodes.Count; i++)
            {
                TreeListNode treeListNode2 = treeListNode.Nodes[i];
                string displayText = treeListNode2.GetDisplayText(frmLayerRender.MSG01);
                if (displayText == rendererType)
                {
                    this.treeListRenderer.SetFocusedNode(treeListNode2);
                    result = treeListNode2;
                    return result;
                }
            }
            result = null;
            return result;
        }

        /// <summary>
        /// Handles the FocusedNodeChanged event of the treeListRenderer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedNodeChangedEventArgs"/> instance containing the event data.</param>
        private void treeListRenderer_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            string displayText = e.Node.GetDisplayText(frmLayerRender.MSG01);
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    if (displayText == frmLayerRender.MSG03)
                    {
                        this.xtraTabControl.SelectedTabPage = this.pageVectorSimple;
                    }
                    else if (displayText == frmLayerRender.MSG04)
                    {
                        this.xtraTabControl.SelectedTabPage = this.pageVectorUniqueValue;
                    }
                    break;
                case LayerType.RasterLayer:
                    if (displayText == frmLayerRender.MSG04)
                    {
                        this.xtraTabControl.SelectedTabPage = this.pageRasterUniqueValue;
                    }
                    else if (displayText == frmLayerRender.MSG06)
                    {
                        this.xtraTabControl.SelectedTabPage = this.pageRasterClassify;
                    }
                    else if (displayText == frmLayerRender.MSG07)
                    {
                        this.xtraTabControl.SelectedTabPage = this.pageRasterStretch;
                    }
                    break;
            }
        }

        /// <summary>
        /// Initializes the renderer information.
        /// </summary>
        private void InitRendererInfo()
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    {
                        IGeoFeatureLayer geoFeatureLayer = this.layer as IGeoFeatureLayer;
                        IFeatureRenderer renderer = geoFeatureLayer.Renderer;
                        switch (geoFeatureLayer.FeatureClass.ShapeType)
                        {
                            case esriGeometryType.esriGeometryPoint:
                                this.CurrentSymbologyStyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                                goto IL_73;
                            case esriGeometryType.esriGeometryPolyline:
                                this.CurrentSymbologyStyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                                goto IL_73;
                        }
                        this.CurrentSymbologyStyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                        IL_73:
                        this.cmbUniqueValueField.Properties.Items.Clear();
                        ITable table = geoFeatureLayer as ITable;
                        IFields fields = table.Fields;
                        for (int i = 0; i < fields.FieldCount; i++)
                        {
                            IField field = fields.get_Field(i);
                            if (field.Type != esriFieldType.esriFieldTypeOID && field.Type != esriFieldType.esriFieldTypeGeometry)
                            {
                                this.cmbUniqueValueField.Properties.Items.Add(field.Name);
                            }
                        }
                        if (renderer is IUniqueValueRenderer)
                        {
                            if (this.simpleRendererSymbol == null)
                            {
                                IRgbColor rgbColor = new RgbColorClass();
                                Random random = new Random();
                                rgbColor.Red = random.Next(0, 255);
                                rgbColor.Green = random.Next(0, 255);
                                rgbColor.Blue = random.Next(0, 255);
                                switch (this.CurrentSymbologyStyleClass)
                                {
                                    case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                                        this.simpleRendererSymbol = (new SimpleFillSymbolClass
                                        {
                                            Style = esriSimpleFillStyle.esriSFSSolid,
                                            Color = rgbColor
                                        } as ISymbol);
                                        break;
                                    case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                                        this.simpleRendererSymbol = (new SimpleLineSymbolClass
                                        {
                                            Style = esriSimpleLineStyle.esriSLSSolid,
                                            Color = rgbColor
                                        } as ISymbol);
                                        break;
                                    case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                                        this.simpleRendererSymbol = (new SimpleMarkerSymbolClass
                                        {
                                            Style = esriSimpleMarkerStyle.esriSMSCircle,
                                            Color = rgbColor,
                                            Size = 4.0
                                        } as ISymbol);
                                        break;
                                }
                                Bitmap image = CommonAPI.PreviewItem(this.simpleRendererSymbol, this.labelSimplePreview.Width, this.labelSimplePreview.Height);
                                this.labelSimplePreview.Appearance.Image = image;
                            }
                            IUniqueValueRenderer uniqueValueRenderer = renderer as IUniqueValueRenderer;
                            string text = uniqueValueRenderer.get_Field(0);
                            this.cmbUniqueValueField.Text = text;
                            string colorScheme = uniqueValueRenderer.ColorScheme;
                            this.SelectColorScheme(this.cmbUniqueValueColorRamp, colorScheme);
                            this.uniqueValueRecordClassList = this.InitUniqueValueRendererData(uniqueValueRenderer);
                            this.InitGridControl(this.gridControlUniqueValue, this.gridViewUniqueValue, this.repositoryItemPictureEditUniqueValue, this.uniqueValueRecordClassList);
                        }
                        else
                        {
                            ISimpleRenderer simpleRenderer = renderer as ISimpleRenderer;
                            this.simpleRendererSymbol = simpleRenderer.Symbol;
                            if (this.simpleRendererSymbol != null)
                            {
                                Bitmap image = CommonAPI.PreviewItem(this.simpleRendererSymbol, this.labelSimplePreview.Width, this.labelSimplePreview.Height);
                                this.labelSimplePreview.Appearance.Image = image;
                                this.txtSimpleDescription.Text = simpleRenderer.Label;
                            }
                            this.cmbUniqueValueField.SelectedIndex = 0;
                            this.SelectColorScheme(this.cmbUniqueValueColorRamp, "");
                            this.uniqueValueRecordClassList = new List<UniqueValueRecordClass>();
                            this.InitGridControl(this.gridControlUniqueValue, this.gridViewUniqueValue, this.repositoryItemPictureEditUniqueValue, this.uniqueValueRecordClassList);
                        }
                        break;
                    }
                case LayerType.RasterLayer:
                    {
                        this.CurrentSymbologyStyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                        IRasterLayer rasterLayer = this.layer as IRasterLayer;
                        IRasterRenderer renderer2 = rasterLayer.Renderer;
                        IAttributeTable attributeTable = rasterLayer as IAttributeTable;
                        if (attributeTable != null && attributeTable.AttributeTable != null)
                        {
                            ITable attributeTable2 = attributeTable.AttributeTable;
                            IFields fields2 = attributeTable2.Fields;
                            for (int i = 0; i < fields2.FieldCount; i++)
                            {
                                IField field2 = fields2.get_Field(i);
                                if (field2.Type != esriFieldType.esriFieldTypeOID && field2.Type != esriFieldType.esriFieldTypeGeometry)
                                {
                                    if (!(field2.Name.ToUpper() == "COUNT"))
                                    {
                                        this.cmbRasterUniqueValueField.Properties.Items.Add(field2.Name);
                                        this.cmbRasterClassifyField.Properties.Items.Add(field2.Name);
                                    }
                                }
                            }
                        }
                        if (renderer2 is IRasterUniqueValueRenderer)
                        {
                            IRasterUniqueValueRenderer rasterUniqueValueRenderer = renderer2 as IRasterUniqueValueRenderer;
                            string text = rasterUniqueValueRenderer.Field;
                            this.cmbRasterUniqueValueField.Text = text;
                            string colorScheme = rasterUniqueValueRenderer.ColorScheme;
                            this.SelectColorScheme(this.cmbRasterUniqueValueColorRamp, colorScheme);
                            this.uniqueValueRecordClassList = this.InitRasterUniqueValueRendererData(rasterUniqueValueRenderer);
                            this.InitGridControl(this.gridControlRasterUniqueValue, this.gridViewRasterUniqueValue, this.repositoryItemPictureEditRasterUniqueValue, this.uniqueValueRecordClassList);
                            this.cmbRasterClassifyField.SelectedIndex = 0;
                            this.InitClassifyClass();
                            this.cmbRasterClassifyClass.Text = "5";
                            this.SelectColorScheme(this.cmbRasterClassifyColorRamp, "");
                            this.classifyRecordClassList = new List<ClassifyRecordClass>();
                            this.InitGridControl(this.gridControlRasterClassify, this.gridViewRasterClassify, this.repositoryItemPictureEditRasterClassify, this.classifyRecordClassList);
                        }
                        else if (renderer2 is IRasterClassifyColorRampRenderer)
                        {
                            this.cmbRasterUniqueValueField.SelectedIndex = 0;
                            this.SelectColorScheme(this.cmbRasterUniqueValueColorRamp, "");
                            this.uniqueValueRecordClassList = new List<UniqueValueRecordClass>();
                            this.InitGridControl(this.gridControlRasterUniqueValue, this.gridViewRasterUniqueValue, this.repositoryItemPictureEditRasterUniqueValue, this.uniqueValueRecordClassList);
                            IRasterClassifyColorRampRenderer rasterClassifyColorRampRenderer = renderer2 as IRasterClassifyColorRampRenderer;
                            string text = rasterClassifyColorRampRenderer.ClassField;
                            this.cmbRasterClassifyField.Text = text;
                            this.InitClassifyClass();
                            this.cmbRasterClassifyClass.Text = rasterClassifyColorRampRenderer.ClassCount.ToString();
                            IRasterClassifyUIProperties rasterClassifyUIProperties = renderer2 as IRasterClassifyUIProperties;
                            string colorScheme = rasterClassifyUIProperties.ColorRamp;
                            this.SelectColorScheme(this.cmbRasterClassifyColorRamp, colorScheme);
                            this.classifyRecordClassList = this.InitRasterClassifyRendererData(rasterClassifyColorRampRenderer);
                            this.InitGridControl(this.gridControlRasterClassify, this.gridViewRasterClassify, this.repositoryItemPictureEditRasterClassify, this.classifyRecordClassList);
                        }
                        else if (renderer2 is IRasterStretchColorRampRenderer)
                        {
                            IRasterStretchColorRampRenderer rasterStretchColorRampRenderer = renderer2 as IRasterStretchColorRampRenderer;
                            this.SelectColorScheme(this.cmbRasterStretchColorRamp, rasterStretchColorRampRenderer.ColorRamp.Name);
                            IRasterStretchAdvancedLabels rasterStretchAdvancedLabels = renderer2 as IRasterStretchAdvancedLabels;
                            this.txtRasterStretchIntervals.Text = "1";
                            IRasterStretch2 rasterStretch = (IRasterStretch2)renderer2;
                            this.chkRasterStretchInvert.Checked = rasterStretch.Invert;
                            this.chkRasterStretchBackground.Checked = rasterStretch.Background;
                            this.txtRasterStretchBackground.Text = rasterStretch.BackgroundValue.ToString();
                            this.txtRasterStretchBackground.Enabled = this.chkRasterStretchBackground.Checked;
                            this.colorRasterStretchBackground.Color = ColorTranslator.FromOle(rasterStretch.BackgroundColor.RGB);
                            this.classifyRecordClassList = this.InitRasterStretchRendererData(rasterStretchColorRampRenderer, rasterStretchColorRampRenderer.ColorRamp);
                            this.InitGridControl(this.gridControlRasterStretch, this.gridViewRasterStretch, this.repositoryItemPictureEditRasterStretch, this.classifyRecordClassList);
                            this.InitClassifyClass();
                            this.cmbRasterClassifyClass.Text = "5";
                            IRasterClassifyColorRampRenderer rasterClassifyColorRampRenderer = new RasterClassifyColorRampRendererClass();
                            IRasterRenderer rasterRenderer = rasterClassifyColorRampRenderer as IRasterRenderer;
                            IRaster raster = rasterLayer.Raster;
                            IRasterBandCollection rasterBandCollection = raster as IRasterBandCollection;
                            IRasterBand rasterBand = rasterBandCollection.Item(0);
                            if (rasterBand.Histogram == null)
                            {
                                WaitDialogForm waitDialogForm = new WaitDialogForm(frmLayerRender.MSG08, "提示信息");
                                try
                                {
                                    waitDialogForm.Owner = this;
                                    waitDialogForm.TopMost = false;
                                    rasterBand.ComputeStatsAndHist();
                                }
                                finally
                                {
                                    waitDialogForm.Close();
                                }
                            }
                            rasterRenderer.Raster = raster;
                            rasterClassifyColorRampRenderer.ClassCount = 5;
                            rasterRenderer.Update();
                            this.SelectColorScheme(this.cmbRasterClassifyColorRamp, rasterStretchColorRampRenderer.ColorRamp.Name);
                            this.classifyRecordClassList = this.InitRasterClassifyRendererData(rasterClassifyColorRampRenderer);
                            this.InitGridControl(this.gridControlRasterClassify, this.gridViewRasterClassify, this.repositoryItemPictureEditRasterClassify, this.classifyRecordClassList);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Initializes the classify class.
        /// </summary>
        private void InitClassifyClass()
        {
            this.cmbRasterClassifyClass.Properties.Items.Clear();
            for (int i = 1; i <= 32; i++)
            {
                this.cmbRasterClassifyClass.Properties.Items.Add(i.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSimpleChange control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSimpleChange_Click(object sender, EventArgs e)
        {
            this.ChangeSymbol(ref this.simpleRendererSymbol, this.labelSimplePreview, this.CurrentSymbologyStyleClass);
        }

        /// <summary>
        /// Selects the color scheme.
        /// </summary>
        /// <param name="cmbColorRamp">The CMB color ramp.</param>
        /// <param name="colorScheme">The color scheme.</param>
        private void SelectColorScheme(ImageComboBoxEdit cmbColorRamp, string colorScheme)
        {
            for (int i = 0; i < cmbColorRamp.Properties.Items.Count; i++)
            {
                string b = cmbColorRamp.Properties.Items[i].Value.ToString();
                if (colorScheme == b)
                {
                    cmbColorRamp.SelectedIndex = i;
                    return;
                }
            }
            cmbColorRamp.SelectedIndex = 0;
        }

        /// <summary>
        /// Initializes the grid control.
        /// </summary>
        /// <param name="gridControl">The grid control.</param>
        /// <param name="gridView">The grid view.</param>
        /// <param name="repositoryItemPictureEdit">The repository item picture edit.</param>
        /// <param name="uniqueValueRecordClassList">The unique value record class list.</param>
        private void InitGridControl(GridControl gridControl, GridView gridView, RepositoryItemPictureEdit repositoryItemPictureEdit, List<UniqueValueRecordClass> uniqueValueRecordClassList)
        {
            gridControl.DataSource = uniqueValueRecordClassList;
            gridView.PopulateColumns();
            gridView.Columns[0].ColumnEdit = repositoryItemPictureEdit;
            gridView.Columns[0].Caption = frmLayerRender.MSG09;
            gridView.Columns[0].Width = 10;
            gridView.Columns[1].Caption = frmLayerRender.MSG10;
            gridView.Columns[1].Width = 45;
            gridView.Columns[1].OptionsColumn.AllowEdit = false;
            gridView.Columns[2].ColumnEdit = (RepositoryItemTextEdit)this.gridControlUniqueValue.RepositoryItems["repositoryItemTextEdit"];
            gridView.Columns[2].Caption = frmLayerRender.MSG11;
            gridView.Columns[2].Width = 45;
            gridView.Columns[3].Visible = false;
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.OptionsCustomization.AllowColumnResizing = false;
            gridView.OptionsCustomization.AllowSort = false;
            gridView.OptionsCustomization.AllowFilter = false;
        }

        /// <summary>
        /// Initializes the grid control.
        /// </summary>
        /// <param name="gridControl">The grid control.</param>
        /// <param name="gridView">The grid view.</param>
        /// <param name="repositoryItemPictureEdit">The repository item picture edit.</param>
        /// <param name="classifyRecordClassList">The classify record class list.</param>
        private void InitGridControl(GridControl gridControl, GridView gridView, RepositoryItemPictureEdit repositoryItemPictureEdit, List<ClassifyRecordClass> classifyRecordClassList)
        {
            gridControl.DataSource = classifyRecordClassList;
            gridView.PopulateColumns();
            gridView.Columns[0].ColumnEdit = repositoryItemPictureEdit;
            gridView.Columns[0].Caption = frmLayerRender.MSG09;
            gridView.Columns[0].Width = 10;
            gridView.Columns[1].Caption = frmLayerRender.MSG10;
            gridView.Columns[1].Width = 45;
            gridView.Columns[2].ColumnEdit = (RepositoryItemTextEdit)this.gridControlUniqueValue.RepositoryItems["repositoryItemTextEdit"];
            gridView.Columns[2].Caption = frmLayerRender.MSG11;
            gridView.Columns[2].Width = 45;
            gridView.Columns[3].Visible = false;
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.OptionsCustomization.AllowColumnResizing = false;
            gridView.OptionsCustomization.AllowSort = false;
            gridView.OptionsCustomization.AllowFilter = false;
        }

        /// <summary>
        /// Initializes the unique value renderer data.
        /// </summary>
        /// <param name="uniqueValueRenderer">The unique value renderer.</param>
        /// <returns>List&lt;UniqueValueRecordClass&gt;.</returns>
        private List<UniqueValueRecordClass> InitUniqueValueRendererData(IUniqueValueRenderer uniqueValueRenderer)
        {
            List<UniqueValueRecordClass> list = new List<UniqueValueRecordClass>();
            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                string value = uniqueValueRenderer.get_Value(i);
                ISymbol symbol = uniqueValueRenderer.get_Symbol(value);
                string label = uniqueValueRenderer.get_Label(value);
                UniqueValueRecordClass item = new UniqueValueRecordClass(symbol, value, label);
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Initializes the raster unique value renderer data.
        /// </summary>
        /// <param name="rasterUniqueValueRenderer">The raster unique value renderer.</param>
        /// <returns>List&lt;UniqueValueRecordClass&gt;.</returns>
        private List<UniqueValueRecordClass> InitRasterUniqueValueRendererData(IRasterUniqueValueRenderer rasterUniqueValueRenderer)
        {
            List<UniqueValueRecordClass> list = new List<UniqueValueRecordClass>();
            int num = rasterUniqueValueRenderer.get_ClassCount(0);
            for (int i = 0; i < num; i++)
            {
                string value = rasterUniqueValueRenderer.get_Value(0, i, 0).ToString();
                ISymbol symbol = rasterUniqueValueRenderer.get_Symbol(0, i);
                string label = rasterUniqueValueRenderer.get_Label(0, i);
                UniqueValueRecordClass item = new UniqueValueRecordClass(symbol, value, label);
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Initializes the raster classify renderer data.
        /// </summary>
        /// <param name="rasterClassifyColorRampRenderer">The raster classify color ramp renderer.</param>
        /// <returns>List&lt;ClassifyRecordClass&gt;.</returns>
        private List<ClassifyRecordClass> InitRasterClassifyRendererData(IRasterClassifyColorRampRenderer rasterClassifyColorRampRenderer)
        {
            List<ClassifyRecordClass> list = new List<ClassifyRecordClass>();
            for (int i = 0; i < rasterClassifyColorRampRenderer.ClassCount; i++)
            {
                ISymbol symbol = rasterClassifyColorRampRenderer.get_Symbol(i);
                string label = rasterClassifyColorRampRenderer.get_Label(i);
                double breakValue = rasterClassifyColorRampRenderer.get_Break(i);
                ClassifyRecordClass item = new ClassifyRecordClass(symbol, breakValue, label);
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Initializes the raster stretch renderer data.
        /// </summary>
        /// <param name="rasterClassifyColorRampRenderer">The raster classify color ramp renderer.</param>
        /// <param name="pColorRamp">The p color ramp.</param>
        /// <returns>List&lt;ClassifyRecordClass&gt;.</returns>
        private List<ClassifyRecordClass> InitRasterStretchRendererData(IRasterStretchColorRampRenderer rasterClassifyColorRampRenderer, IColorRamp pColorRamp)
        {
            IRasterStretchAdvancedLabels rasterStretchAdvancedLabels = rasterClassifyColorRampRenderer as IRasterStretchAdvancedLabels;
            List<ClassifyRecordClass> list = new List<ClassifyRecordClass>();
            int numLabels = rasterStretchAdvancedLabels.NumLabels;
            IAlgorithmicColorRamp algorithmicColorRamp = new AlgorithmicColorRampClass();
            algorithmicColorRamp.Size = numLabels;
            algorithmicColorRamp.FromColor = pColorRamp.get_Color(pColorRamp.Size - 1);
            algorithmicColorRamp.ToColor = pColorRamp.get_Color(0);
            algorithmicColorRamp.Name = pColorRamp.Name;
            bool flag;
            algorithmicColorRamp.CreateRamp(out flag);
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Width = 1.0;
            simpleLineSymbol.Color = SymbleAPI.CreateRGBColor(110, 110, 110);
            for (int i = 0; i < numLabels; i++)
            {
                int num = (int)rasterStretchAdvancedLabels.get_LabelValue(i);
                IColor color = algorithmicColorRamp.get_Color(i);
                ClassifyRecordClass item = new ClassifyRecordClass(new SimpleFillSymbolClass
                {
                    Color = color,
                    Outline = simpleLineSymbol
                } as ISymbol, (double)num, num.ToString());
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Handles the DoubleClick event of the repositoryItemPictureEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void repositoryItemPictureEdit_DoubleClick(object sender, EventArgs e)
        {
            string name = this.xtraTabControl.SelectedTabPage.Name;
            if (name != null)
            {
                if (!(name == "pageVectorUniqueValue"))
                {
                    if (!(name == "pageRasterUniqueValue"))
                    {
                        if (!(name == "pageRasterClassify"))
                        {
                            if (name == "pageRasterStretch")
                            {
                                ISymbol symbol = this.classifyRecordClassList[this.gridViewRasterStretch.FocusedRowHandle].Symbol;
                                this.ChangeSymbol(ref symbol, esriSymbologyStyleClass.esriStyleClassFillSymbols);
                                this.classifyRecordClassList[this.gridViewRasterStretch.FocusedRowHandle].Symbol = symbol;
                                this.gridViewRasterStretch.UpdateGroupSummary();
                            }
                        }
                        else
                        {
                            ISymbol symbol = this.classifyRecordClassList[this.gridViewRasterClassify.FocusedRowHandle].Symbol;
                            this.ChangeSymbol(ref symbol, esriSymbologyStyleClass.esriStyleClassFillSymbols);
                            this.classifyRecordClassList[this.gridViewRasterClassify.FocusedRowHandle].Symbol = symbol;
                            this.gridViewRasterClassify.UpdateGroupSummary();
                        }
                    }
                    else
                    {
                        ISymbol symbol = this.uniqueValueRecordClassList[this.gridViewRasterUniqueValue.FocusedRowHandle].Symbol;
                        this.ChangeSymbol(ref symbol, esriSymbologyStyleClass.esriStyleClassFillSymbols);
                        this.uniqueValueRecordClassList[this.gridViewRasterUniqueValue.FocusedRowHandle].Symbol = symbol;
                        this.gridViewRasterUniqueValue.UpdateGroupSummary();
                    }
                }
                else
                {
                    ISymbol symbol = this.uniqueValueRecordClassList[this.gridViewUniqueValue.FocusedRowHandle].Symbol;
                    esriSymbologyStyleClass symbologyStyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    if (symbol is ILineSymbol)
                    {
                        symbologyStyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    }
                    else if (symbol is IFillSymbol)
                    {
                        symbologyStyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    }
                    this.ChangeSymbol(ref symbol, symbologyStyleClass);
                    this.uniqueValueRecordClassList[this.gridViewUniqueValue.FocusedRowHandle].Symbol = symbol;
                    this.gridViewUniqueValue.UpdateGroupSummary();
                }
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="SymbologyStyleClass">The symbology style class.</param>
        private void ChangeSymbol(ref ISymbol Symbol, esriSymbologyStyleClass SymbologyStyleClass)
        {
            frmSymbolSelector frmSymbolSelect = new frmSymbolSelector();
            IStyleGalleryItem item = frmSymbolSelect.GetItem(SymbologyStyleClass, Symbol);
            if (item != null)
            {
                Symbol = (ISymbol)item.Item;
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="label">The label.</param>
        /// <param name="SymbologyStyleClass">The symbology style class.</param>
        private void ChangeSymbol(ref ISymbol Symbol, LabelControl label, esriSymbologyStyleClass SymbologyStyleClass)
        {
            this.ChangeSymbol(ref Symbol, SymbologyStyleClass);
            label.Appearance.Image = CommonAPI.PreviewItem(Symbol, label.Width, label.Height);
        }

        /// <summary>
        /// Handles the Click event of the btnAddAllValues control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddAllValues_Click(object sender, EventArgs e)
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    if (this.cmbUniqueValueColorRamp.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show(frmLayerRender.MSG12, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (this.uniqueValueRecordClassList == null)
                        {
                            this.uniqueValueRecordClassList = new List<UniqueValueRecordClass>();
                            this.InitGridControl(this.gridControlUniqueValue, this.gridViewUniqueValue, this.repositoryItemPictureEditUniqueValue, this.uniqueValueRecordClassList);
                        }
                        this.uniqueValueRecordClassList.Clear();
                        IQueryFilter queryFilter = new QueryFilterClass();
                        string text = this.cmbUniqueValueField.EditValue.ToString();
                        queryFilter.AddField(text);
                        IGeoFeatureLayer geoFeatureLayer = this.layer as IGeoFeatureLayer;
                        ITable table = geoFeatureLayer as ITable;
                        ICursor cursor = table.Search(queryFilter, true);
                        IRow row = cursor.NextRow();
                        int index = table.FindField(text);
                        IList<string> list = new List<string>();
                        while (row != null)
                        {
                            string text2 = row.get_Value(index).ToString();
                            if (text2 == "")
                            {
                                text2 = "<Null>";
                            }
                            if (list.Contains(text2))
                            {
                                row = cursor.NextRow();
                            }
                            else
                            {
                                list.Add(text2);
                                UniqueValueRecordClass uniqueValueRecordClass = new UniqueValueRecordClass();
                                uniqueValueRecordClass.Value = text2;
                                uniqueValueRecordClass.Label = text2;
                                this.uniqueValueRecordClassList.Add(uniqueValueRecordClass);
                                row = cursor.NextRow();
                            }
                        }
                        if (this.gridViewUniqueValue.SelectedRowsCount == 0)
                        {
                            this.gridViewUniqueValue.FocusedRowHandle = 0;
                        }
                        this.cmbColorRamp_SelectedIndexChanged(null, null);
                        this.btnUniqueRemoveValues.Enabled = true;
                        this.btnUniqueRemoveAllValues.Enabled = true;
                    }
                    break;
                case LayerType.RasterLayer:
                    if (this.cmbRasterUniqueValueColorRamp.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show(frmLayerRender.MSG12, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (this.cmbRasterUniqueValueField.EditValue == null || this.cmbRasterUniqueValueField.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show(frmLayerRender.MSG13, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (this.uniqueValueRecordClassList == null)
                        {
                            this.uniqueValueRecordClassList = new List<UniqueValueRecordClass>();
                        }
                        this.uniqueValueRecordClassList.Clear();
                        IQueryFilter queryFilter = new QueryFilterClass();
                        string text = this.cmbRasterUniqueValueField.EditValue.ToString();
                        queryFilter.AddField(text);
                        IRasterLayer rasterLayer = this.layer as IRasterLayer;
                        IRasterRenderer renderer = rasterLayer.Renderer;
                        IAttributeTable attributeTable = rasterLayer as IAttributeTable;
                        ITable table = attributeTable.AttributeTable;
                        ICursor cursor = table.Search(queryFilter, true);
                        IRow row = cursor.NextRow();
                        int index = table.FindField(text);
                        IList<string> list = new List<string>();
                        while (row != null)
                        {
                            string text2 = row.get_Value(index).ToString();
                            if (text2 == "")
                            {
                                text2 = "<Null>";
                            }
                            if (list.Contains(text2))
                            {
                                row = cursor.NextRow();
                            }
                            else
                            {
                                list.Add(text2);
                                UniqueValueRecordClass uniqueValueRecordClass = new UniqueValueRecordClass();
                                uniqueValueRecordClass.Value = text2;
                                uniqueValueRecordClass.Label = text2;
                                this.uniqueValueRecordClassList.Add(uniqueValueRecordClass);
                                row = cursor.NextRow();
                            }
                        }
                        if(cursor!=null)
                        Marshal.ReleaseComObject(cursor);
                        if (this.gridViewRasterUniqueValue.SelectedRowsCount == 0)
                        {
                            this.gridViewRasterUniqueValue.FocusedRowHandle = 0;
                        }
                        this.cmbColorRamp_SelectedIndexChanged(null, null);
                        this.InitGridControl(this.gridControlRasterUniqueValue, this.gridViewRasterUniqueValue, this.repositoryItemPictureEditRasterUniqueValue, this.uniqueValueRecordClassList);
                        this.btnRasterUniqueRemoveValues.Enabled = true;
                        this.btnRasterUniqueRemoveAllValues.Enabled = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAddValues control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddValues_Click(object sender, EventArgs e)
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    if (this.cmbUniqueValueColorRamp.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show(frmLayerRender.MSG12, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        //frmUniqueValueAddValue frmUniqueValueAddValue = new frmUniqueValueAddValue(PSCarto.CartoAPI.ValueType.String);
                        //DialogResult dialogResult = frmUniqueValueAddValue.ShowDialog();
                        //if (dialogResult != DialogResult.Cancel)
                        //{
                        //    this.btnUniqueRemoveValues.Enabled = true;
                        //    this.btnUniqueRemoveAllValues.Enabled = true;
                        //    string value = frmUniqueValueAddValue.Value;
                        //    frmUniqueValueAddValue.Dispose();
                        //    for (int i = 0; i < this.gridViewUniqueValue.RowCount; i++)
                        //    {
                        //        if (this.gridViewUniqueValue.GetRowCellDisplayText(i, "Value") == value)
                        //        {
                        //            return;
                        //        }
                        //    }
                        //    string label = value;
                        //    ISymbol symbol = null;
                        //    this.InitializeRandomColorSymbol(ref symbol, RandomColorStatus.ColorRamp, this.CurrentSymbologyStyleClass);
                        //    UniqueValueRecordClass item = new UniqueValueRecordClass(symbol, value, label);
                        //    this.uniqueValueRecordClassList.Add(item);
                        //    this.gridViewUniqueValue.FocusedRowHandle = this.uniqueValueRecordClassList.Count - 1;
                        //    this.gridViewUniqueValue.UpdateGroupSummary();
                        //}
                    }
                    break;
                case LayerType.RasterLayer:
                    if (this.cmbRasterUniqueValueColorRamp.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show(frmLayerRender.MSG12, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (this.cmbRasterUniqueValueField.EditValue == null || this.cmbRasterUniqueValueField.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show(frmLayerRender.MSG13, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        //frmUniqueValueAddValue frmUniqueValueAddValue = new frmUniqueValueAddValue(PSCarto.CartoAPI.ValueType.Int);
                        //DialogResult dialogResult = frmUniqueValueAddValue.ShowDialog();
                        //if (dialogResult != DialogResult.Cancel)
                        //{
                        //    this.btnRasterUniqueRemoveValues.Enabled = true;
                        //    this.btnRasterUniqueRemoveAllValues.Enabled = true;
                        //    string value = frmUniqueValueAddValue.Value;
                        //    frmUniqueValueAddValue.Dispose();
                        //    for (int i = 0; i < this.gridViewUniqueValue.RowCount; i++)
                        //    {
                        //        if (this.gridViewUniqueValue.GetRowCellDisplayText(i, "Value") == value)
                        //        {
                        //            return;
                        //        }
                        //    }
                        //    string label = value;
                        //    ISymbol symbol = null;
                        //    this.InitializeRandomColorSymbol(ref symbol, RandomColorStatus.ColorRamp, this.CurrentSymbologyStyleClass);
                        //    UniqueValueRecordClass item = new UniqueValueRecordClass(symbol, value, label);
                        //    this.uniqueValueRecordClassList.Add(item);
                        //    this.gridViewRasterUniqueValue.FocusedRowHandle = this.uniqueValueRecordClassList.Count - 1;
                        //    this.gridViewRasterUniqueValue.UpdateGroupSummary();
                        //}
                    }
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveValues control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveValues_Click(object sender, EventArgs e)
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    this.uniqueValueRecordClassList.RemoveAt(this.gridViewUniqueValue.FocusedRowHandle);
                    this.gridViewUniqueValue.UpdateGroupSummary();
                    if (this.gridViewUniqueValue.RowCount < 1)
                    {
                        this.btnUniqueRemoveValues.Enabled = false;
                        this.btnUniqueRemoveAllValues.Enabled = false;
                    }
                    if (this.gridViewUniqueValue.FocusedRowHandle == this.gridViewUniqueValue.RowCount)
                    {
                        this.gridViewUniqueValue.FocusedRowHandle = this.uniqueValueRecordClassList.Count - 1;
                    }
                    break;
                case LayerType.RasterLayer:
                    this.uniqueValueRecordClassList.RemoveAt(this.gridViewRasterUniqueValue.FocusedRowHandle);
                    this.gridViewRasterUniqueValue.UpdateGroupSummary();
                    if (this.gridViewRasterUniqueValue.RowCount < 1)
                    {
                        this.btnRasterUniqueRemoveValues.Enabled = false;
                        this.btnRasterUniqueRemoveAllValues.Enabled = false;
                    }
                    if (this.gridViewRasterUniqueValue.FocusedRowHandle == this.gridViewRasterUniqueValue.RowCount)
                    {
                        this.gridViewRasterUniqueValue.FocusedRowHandle = this.uniqueValueRecordClassList.Count - 1;
                    }
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAllValues control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveAllValues_Click(object sender, EventArgs e)
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    this.uniqueValueRecordClassList.Clear();
                    this.gridViewUniqueValue.RefreshData();
                    this.btnUniqueRemoveValues.Enabled = false;
                    this.btnUniqueRemoveAllValues.Enabled = false;
                    break;
                case LayerType.RasterLayer:
                    this.uniqueValueRecordClassList.Clear();
                    this.gridViewUniqueValue.RefreshData();
                    this.btnRasterUniqueRemoveValues.Enabled = false;
                    this.btnRasterUniqueRemoveAllValues.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Initializes the color scheme.
        /// </summary>
        private void InitColorScheme()
        {
            switch (this.layerType)
            {
                case LayerType.FeatureLayer:
                    this.InitializeColorScheme(ref this.RandomColorRampImageList, ColorRampsPriority.RandomColorRamps, this.cmbUniqueValueColorRamp);
                    break;
                case LayerType.RasterLayer:
                    this.InitializeColorScheme(ref this.RandomColorRampImageList, ColorRampsPriority.RandomColorRamps, this.cmbRasterUniqueValueColorRamp);
                    this.RandomColorRampImageList = null;
                    this.InitializeColorScheme(ref this.RandomColorRampImageList, ColorRampsPriority.GradualColorRamps, this.cmbRasterClassifyColorRamp);
                    this.RandomColorRampImageList = null;
                    this.InitializeColorScheme(ref this.RandomColorRampImageList, ColorRampsPriority.GradualColorRamps, this.cmbRasterStretchColorRamp);
                    break;
            }
        }

        /// <summary>
        /// Initializes the color scheme.
        /// </summary>
        /// <param name="myImageList">My image list.</param>
        /// <param name="myColorRampsPriority">My color ramps priority.</param>
        /// <param name="myImageComboBoxEdit">My image ComboBox edit.</param>
        private void InitializeColorScheme(ref ImageList myImageList, ColorRampsPriority myColorRampsPriority, ImageComboBoxEdit myImageComboBoxEdit)
        {
            if (myImageList == null)
            {
                myImageList = new ImageList();
                myImageList.ColorDepth = ColorDepth.Depth32Bit;
                myImageList.ImageSize = new Size(myImageComboBoxEdit.Size.Width - myImageComboBoxEdit.Size.Height, myImageComboBoxEdit.Size.Height);
                if (myColorRampsPriority == ColorRampsPriority.RandomColorRamps)
                {
                    myImageList.Images.Add("Pastels", GFS.Carto.Resources.Pastels);
                    myImageList.Images.Add("Muted Pastels", GFS.Carto.Resources.Muted_Pastels);
                    myImageList.Images.Add("Enamel",GFS.Carto.Resources.Enamel);
                    myImageList.Images.Add("Dark Glazes", GFS.Carto.Resources.Dark_Glazes);
                    myImageList.Images.Add("Cool Tones", GFS.Carto.Resources.Cool_Tones);
                    myImageList.Images.Add("Warm Tones", GFS.Carto.Resources.Warm_Tones);
                    myImageList.Images.Add("Pastels Blue to Red", GFS.Carto.Resources.Pastels_Blue_to_Red);
                    myImageList.Images.Add("Verdant Tones", GFS.Carto.Resources.Verdant_Tones);
                    myImageList.Images.Add("Terra Tones", GFS.Carto.Resources.Terra_Tones);
                    myImageList.Images.Add("Basic Random", GFS.Carto.Resources.Basic_Random);
                    myImageList.Images.Add("Pastel Terra Tones", GFS.Carto.Resources.Pastel_Terra_Tones);
                    myImageList.Images.Add("Reds", GFS.Carto.Resources.Reds);
                    myImageList.Images.Add("Oranges", GFS.Carto.Resources.Oranges);
                    myImageList.Images.Add("Yellows", GFS.Carto.Resources.Yellows);
                    myImageList.Images.Add("Yellow Greens", GFS.Carto.Resources.Yellow_Greens);
                    myImageList.Images.Add("Greens", GFS.Carto.Resources.Greens);
                    myImageList.Images.Add("Green Blues", GFS.Carto.Resources.Green_Blues);
                    myImageList.Images.Add("Cyans", GFS.Carto.Resources.Cyans);
                    myImageList.Images.Add("Blues", GFS.Carto.Resources.Blues);
                    myImageList.Images.Add("Purple Blues", GFS.Carto.Resources.Purple_Blues);
                    myImageList.Images.Add("Purples", GFS.Carto.Resources.Purples);
                    myImageList.Images.Add("Purple Reds", GFS.Carto.Resources.Purple_Reds);
                    myImageList.Images.Add("Magentas", GFS.Carto.Resources.Magentas);
                    myImageList.Images.Add("Warm Grey", GFS.Carto.Resources.Warm_Grey);
                    myImageList.Images.Add("Cool Grey", GFS.Carto.Resources.Cool_Grey);
                    myImageList.Images.Add("Black and White", GFS.Carto.Resources.Black_and_White);
                    myImageList.Images.Add("Yellow to Dark Red", GFS.Carto.Resources.Yellow_to_Dark_Red);
                    myImageList.Images.Add("Blue Light to Dark", GFS.Carto.Resources.Blue_Light_to_Dark);
                    myImageList.Images.Add("Purple-Blue Light to Dark", GFS.Carto.Resources.Purple_Blue_Light_to_Dark);
                    myImageList.Images.Add("Blue-Green Light to Dark", GFS.Carto.Resources.Blue_Green_Light_to_Dark);
                    myImageList.Images.Add("Green Light to Dark", GFS.Carto.Resources.Green_Light_to_Dark);
                    myImageList.Images.Add("Purple-Red Light to Dark", GFS.Carto.Resources.Purple_Red_Light_to_Dark);
                    myImageList.Images.Add("Red Light to Dark", GFS.Carto.Resources.Red_Light_to_Dark);
                    myImageList.Images.Add("Yellow-Green Light to Dark", GFS.Carto.Resources.Yellow_Green_Light_to_Dark);
                    myImageList.Images.Add("Gray Light to Dark", GFS.Carto.Resources.Gray_Light_to_Dark);
                    myImageList.Images.Add("Brown Light to Dark", GFS.Carto.Resources.Brown_Light_to_Dark);
                    myImageList.Images.Add("Orange Light to Dark", GFS.Carto.Resources.Orange_Light_to_Dark);
                    myImageList.Images.Add("Blue Bright", GFS.Carto.Resources.Blue_Bright);
                    myImageList.Images.Add("Purple-Blue Bright", GFS.Carto.Resources.Purple_Blue_Bright);
                    myImageList.Images.Add("Blue-Green Bright", GFS.Carto.Resources.Blue_Green_Bright);
                    myImageList.Images.Add("Green Bright", GFS.Carto.Resources.Green_Bright);
                    myImageList.Images.Add("Purple Bright", GFS.Carto.Resources.Purple_Bright);
                    myImageList.Images.Add("Purple-Red Bright", GFS.Carto.Resources.Purple_Red_Bright);
                    myImageList.Images.Add("Red Bright", GFS.Carto.Resources.Red_Bright);
                    myImageList.Images.Add("Yellow-Green Bright", GFS.Carto.Resources.Yellow_Green_Bright);
                    myImageList.Images.Add("Orange Bright", GFS.Carto.Resources.Orange_Bright);
                    myImageList.Images.Add("White to Black", GFS.Carto.Resources.White_to_Black);
                    myImageList.Images.Add("Black to White", GFS.Carto.Resources.Black_to_White);
                    myImageList.Images.Add("Spectrum-Full Bright", GFS.Carto.Resources.Spectrum_Full_Bright);
                    myImageList.Images.Add("Spectrum-Full Light", GFS.Carto.Resources.Spectrum_Full_Light);
                    myImageList.Images.Add("Spectrum-Full Dark", GFS.Carto.Resources.Spectrum_Full_Dark);
                    myImageList.Images.Add("Red to Green", GFS.Carto.Resources.Red_to_Green);
                    myImageList.Images.Add("Cyan to Purple", GFS.Carto.Resources.Cyan_to_Purple);
                    myImageList.Images.Add("Yellow to Red", GFS.Carto.Resources.Yellow_to_Red);
                    myImageList.Images.Add("Partial Spectrum", GFS.Carto.Resources.Partial_Spectrum);
                    myImageList.Images.Add("Cyan-Light to Blue-Dark", GFS.Carto.Resources.Cyan_Light_to_Blue_Dark);
                    myImageList.Images.Add("Green to Blue", GFS.Carto.Resources.Green_to_Blue);
                    myImageList.Images.Add("Yellow to Green to Dark Blue", GFS.Carto.Resources.Yellow_to_Green_to_Dark_Blue);
                    myImageList.Images.Add("Precipitation", GFS.Carto.Resources.Precipitation);
                    myImageList.Images.Add("Temperature", GFS.Carto.Resources.Temperature);
                    myImageList.Images.Add("Elevation #1", GFS.Carto.Resources.Elevation__1);
                    myImageList.Images.Add("Elevation #2", GFS.Carto.Resources.Elevation__2);
                    myImageList.Images.Add("Brown to Blue Green Diverging, Bright", GFS.Carto.Resources.Brown_to_Blue_Green_Diverging__Bright);
                    myImageList.Images.Add("Brown to Blue Green Diverging, Dark", GFS.Carto.Resources.Brown_to_Blue_Green_Diverging__Dark);
                    myImageList.Images.Add("Red to Blue Diverging, Dark", GFS.Carto.Resources.Red_to_Blue_Diverging__Dark);
                    myImageList.Images.Add("Red to Blue Diverging, Bright", GFS.Carto.Resources.Red_to_Blue_Diverging__Bright);
                    myImageList.Images.Add("Purple to Green Diverging, Dark", GFS.Carto.Resources.Purple_to_Green_Diverging__Dark);
                    myImageList.Images.Add("Purple to Green Diverging, Bright", GFS.Carto.Resources.Purple_to_Green_Diverging__Bright);
                    myImageList.Images.Add("Partial Spectrum 1 Diverging", GFS.Carto.Resources.Partial_Spectrum_1_Diverging);
                    myImageList.Images.Add("Partial Spectrum 2 Diverging", GFS.Carto.Resources.Partial_Spectrum_2_Diverging);
                    myImageList.Images.Add("Pink to YellowGreen Diverging, Dark", GFS.Carto.Resources.Pink_to_YellowGreen_Diverging__Dark);
                    myImageList.Images.Add("Pink to YellowGreen Diverging, Bright", GFS.Carto.Resources.Pink_to_YellowGreen_Diverging__Bright);
                    myImageList.Images.Add("Red to Green Diverging, Dark", GFS.Carto.Resources.Red_to_Green_Diverging__Dark);
                    myImageList.Images.Add("Red to Green Diverging, Bright", GFS.Carto.Resources.Red_to_Green_Diverging__Bright);
                    myImageList.Images.Add("Distance", GFS.Carto.Resources.Distance);
                    myImageList.Images.Add("Surface", GFS.Carto.Resources.Surface);
                    myImageList.Images.Add("Slope", GFS.Carto.Resources.Slope);
                    myImageList.Images.Add("Aspect", GFS.Carto.Resources.Aspect);
                    myImageList.Images.Add("Cold to Hot Diverging", GFS.Carto.Resources.Cold_to_Hot_Diverging);
                }
                else
                {
                    myImageList.Images.Add("Yellow to Dark Red", GFS.Carto.Resources.Yellow_to_Dark_Red);
                    myImageList.Images.Add("Blue Light to Dark", GFS.Carto.Resources.Blue_Light_to_Dark);
                    myImageList.Images.Add("Purple-Blue Light to Dark", GFS.Carto.Resources.Purple_Blue_Light_to_Dark);
                    myImageList.Images.Add("Blue-Green Light to Dark", GFS.Carto.Resources.Blue_Green_Light_to_Dark);
                    myImageList.Images.Add("Green Light to Dark", GFS.Carto.Resources.Green_Light_to_Dark);
                    myImageList.Images.Add("Purple-Red Light to Dark", GFS.Carto.Resources.Purple_Red_Light_to_Dark);
                    myImageList.Images.Add("Red Light to Dark", GFS.Carto.Resources.Red_Light_to_Dark);
                    myImageList.Images.Add("Yellow-Green Light to Dark", GFS.Carto.Resources.Yellow_Green_Light_to_Dark);
                    myImageList.Images.Add("Gray Light to Dark", GFS.Carto.Resources.Gray_Light_to_Dark);
                    myImageList.Images.Add("Brown Light to Dark", GFS.Carto.Resources.Brown_Light_to_Dark);
                    myImageList.Images.Add("Orange Light to Dark", GFS.Carto.Resources.Orange_Light_to_Dark);
                    myImageList.Images.Add("Blue Bright", GFS.Carto.Resources.Blue_Bright);
                    myImageList.Images.Add("Purple-Blue Bright", GFS.Carto.Resources.Purple_Blue_Bright);
                    myImageList.Images.Add("Blue-Green Bright", GFS.Carto.Resources.Blue_Green_Bright);
                    myImageList.Images.Add("Green Bright", GFS.Carto.Resources.Green_Bright);
                    myImageList.Images.Add("Purple Bright", GFS.Carto.Resources.Purple_Bright);
                    myImageList.Images.Add("Purple-Red Bright", GFS.Carto.Resources.Purple_Red_Bright);
                    myImageList.Images.Add("Red Bright", GFS.Carto.Resources.Red_Bright);
                    myImageList.Images.Add("Yellow-Green Bright", GFS.Carto.Resources.Yellow_Green_Bright);
                    myImageList.Images.Add("Orange Bright", GFS.Carto.Resources.Orange_Bright);
                    myImageList.Images.Add("White to Black", GFS.Carto.Resources.White_to_Black);
                    myImageList.Images.Add("Black to White", GFS.Carto.Resources.Black_to_White);
                    myImageList.Images.Add("Spectrum-Full Bright", GFS.Carto.Resources.Spectrum_Full_Bright);
                    myImageList.Images.Add("Spectrum-Full Light", GFS.Carto.Resources.Spectrum_Full_Light);
                    myImageList.Images.Add("Spectrum-Full Dark", GFS.Carto.Resources.Spectrum_Full_Dark);
                    myImageList.Images.Add("Red to Green", GFS.Carto.Resources.Red_to_Green);
                    myImageList.Images.Add("Cyan to Purple", GFS.Carto.Resources.Cyan_to_Purple);
                    myImageList.Images.Add("Yellow to Red", GFS.Carto.Resources.Yellow_to_Red);
                    myImageList.Images.Add("Partial Spectrum", GFS.Carto.Resources.Partial_Spectrum);
                    myImageList.Images.Add("Cyan-Light to Blue-Dark", GFS.Carto.Resources.Cyan_Light_to_Blue_Dark);
                    myImageList.Images.Add("Green to Blue", GFS.Carto.Resources.Green_to_Blue);
                    myImageList.Images.Add("Yellow to Green to Dark Blue", GFS.Carto.Resources.Yellow_to_Green_to_Dark_Blue);
                    myImageList.Images.Add("Precipitation", GFS.Carto.Resources.Precipitation);
                    myImageList.Images.Add("Temperature", GFS.Carto.Resources.Temperature);
                    myImageList.Images.Add("Elevation #1", GFS.Carto.Resources.Elevation__1);
                    myImageList.Images.Add("Elevation #2", GFS.Carto.Resources.Elevation__2);
                    myImageList.Images.Add("Brown to Blue Green Diverging, Bright", GFS.Carto.Resources.Brown_to_Blue_Green_Diverging__Bright);
                    myImageList.Images.Add("Brown to Blue Green Diverging, Dark", GFS.Carto.Resources.Brown_to_Blue_Green_Diverging__Dark);
                    myImageList.Images.Add("Red to Blue Diverging, Dark", GFS.Carto.Resources.Red_to_Blue_Diverging__Dark);
                    myImageList.Images.Add("Red to Blue Diverging, Bright", GFS.Carto.Resources.Red_to_Blue_Diverging__Bright);
                    myImageList.Images.Add("Purple to Green Diverging, Dark", GFS.Carto.Resources.Purple_to_Green_Diverging__Dark);
                    myImageList.Images.Add("Purple to Green Diverging, Bright", GFS.Carto.Resources.Purple_to_Green_Diverging__Bright);
                    myImageList.Images.Add("Partial Spectrum 1 Diverging", GFS.Carto.Resources.Partial_Spectrum_1_Diverging);
                    myImageList.Images.Add("Partial Spectrum 2 Diverging", GFS.Carto.Resources.Partial_Spectrum_2_Diverging);
                    myImageList.Images.Add("Pink to YellowGreen Diverging, Dark", GFS.Carto.Resources.Pink_to_YellowGreen_Diverging__Dark);
                    myImageList.Images.Add("Pink to YellowGreen Diverging, Bright", GFS.Carto.Resources.Pink_to_YellowGreen_Diverging__Bright);
                    myImageList.Images.Add("Red to Green Diverging, Dark", GFS.Carto.Resources.Red_to_Green_Diverging__Dark);
                    myImageList.Images.Add("Red to Green Diverging, Bright", GFS.Carto.Resources.Red_to_Green_Diverging__Bright);
                    myImageList.Images.Add("Distance", GFS.Carto.Resources.Distance);
                    myImageList.Images.Add("Surface", GFS.Carto.Resources.Surface);
                    myImageList.Images.Add("Slope", GFS.Carto.Resources.Slope);
                    myImageList.Images.Add("Aspect", GFS.Carto.Resources.Aspect);
                    myImageList.Images.Add("Cold to Hot Diverging", GFS.Carto.Resources.Cold_to_Hot_Diverging);
                    myImageList.Images.Add("Pastels", GFS.Carto.Resources.Pastels);
                    myImageList.Images.Add("Muted Pastels", GFS.Carto.Resources.Muted_Pastels);
                    myImageList.Images.Add("Enamel", GFS.Carto.Resources.Enamel);
                    myImageList.Images.Add("Dark Glazes", GFS.Carto.Resources.Dark_Glazes);
                    myImageList.Images.Add("Cool Tones", GFS.Carto.Resources.Cool_Tones);
                    myImageList.Images.Add("Warm Tones", GFS.Carto.Resources.Warm_Tones);
                    myImageList.Images.Add("Pastels Blue to Red", GFS.Carto.Resources.Pastels_Blue_to_Red);
                    myImageList.Images.Add("Verdant Toner", GFS.Carto.Resources.Verdant_Tones);
                    myImageList.Images.Add("Terra Tones", GFS.Carto.Resources.Terra_Tones);
                    myImageList.Images.Add("Basic Random", GFS.Carto.Resources.Basic_Random);
                    myImageList.Images.Add("Pastel Terra Tones", GFS.Carto.Resources.Pastel_Terra_Tones);
                    myImageList.Images.Add("Reds", GFS.Carto.Resources.Reds);
                    myImageList.Images.Add("Oranges", GFS.Carto.Resources.Oranges);
                    myImageList.Images.Add("Yellows", GFS.Carto.Resources.Yellows);
                    myImageList.Images.Add("Yellow Greens", GFS.Carto.Resources.Yellow_Greens);
                    myImageList.Images.Add("Greens", GFS.Carto.Resources.Greens);
                    myImageList.Images.Add("Green Blues", GFS.Carto.Resources.Green_Blues);
                    myImageList.Images.Add("Cyans", GFS.Carto.Resources.Cyans);
                    myImageList.Images.Add("Blues", GFS.Carto.Resources.Blues);
                    myImageList.Images.Add("Purple Blues", GFS.Carto.Resources.Purple_Blues);
                    myImageList.Images.Add("Purples", GFS.Carto.Resources.Purples);
                    myImageList.Images.Add("Purple Reds", GFS.Carto.Resources.Purple_Reds);
                    myImageList.Images.Add("Magentas", GFS.Carto.Resources.Magentas);
                    myImageList.Images.Add("Warm Grey", GFS.Carto.Resources.Warm_Grey);
                    myImageList.Images.Add("Cool Grey", GFS.Carto.Resources.Cool_Grey);
                    myImageList.Images.Add("Black and White", GFS.Carto.Resources.Black_and_White);
                }
            }
            myImageComboBoxEdit.Properties.SmallImages = myImageList;
            foreach (string current in myImageList.Images.Keys)
            {
                ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
                imageComboBoxItem.Value = current;
                imageComboBoxItem.ImageIndex = myImageList.Images.IndexOfKey(current);
                myImageComboBoxEdit.Properties.Items.Add(imageComboBoxItem);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLayerPropertiesOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLayerPropertiesOK_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.xtraTabControl.SelectedTabPage.Name;
                if (name != null)
                {
                    if (!(name == "pageVectorSimple"))
                    {
                        if (!(name == "pageVectorUniqueValue"))
                        {
                            if (!(name == "pageRasterUniqueValue"))
                            {
                                if (!(name == "pageRasterClassify"))
                                {
                                    if (name == "pageRasterStretch")
                                    {
                                        IRasterLayer rasterLayer = this.layer as IRasterLayer;
                                        IRasterStretchColorRampRenderer rasterStretchColorRampRenderer = rasterLayer.Renderer as IRasterStretchColorRampRenderer;
                                        string labelHigh = rasterStretchColorRampRenderer.LabelHigh;
                                        string labelLow = rasterStretchColorRampRenderer.LabelLow;
                                        int num = Convert.ToInt32(this.txtRasterStretchIntervals.Text) + 1;
                                        IColorRamp colorRamp = this.CreateEnumColorsFromColorRamps(this.cmbRasterStretchColorRamp, num);
                                        IRasterStretchAdvancedLabels rasterStretchAdvancedLabels = rasterStretchColorRampRenderer as IRasterStretchAdvancedLabels;
                                        rasterStretchAdvancedLabels.NumLabels = num;
                                        ILegendInfo legendInfo = rasterStretchColorRampRenderer as ILegendInfo;
                                        ILegendGroup legendGroup = legendInfo.get_LegendGroup(0);
                                        int i = num - 1;
                                        for (int j = 0; j < legendGroup.ClassCount; j++)
                                        {
                                            ILegendClass legendClass = legendGroup.get_Class(j);
                                            legendClass.Symbol = new ColorRampSymbolClass();
                                            ISymbol symbol = legendClass.Symbol;
                                            IColorRampSymbol colorRampSymbol = symbol as IColorRampSymbol;
                                            colorRampSymbol.ColorRamp = colorRamp;
                                            colorRampSymbol.ColorRampInLegendGroup = colorRamp;
                                            colorRampSymbol.LegendClassIndex = j;
                                            legendClass.Symbol = (colorRampSymbol as ISymbol);
                                            legendClass.Label = rasterStretchAdvancedLabels.get_LabelValue(j).ToString();
                                        }
                                        rasterStretchColorRampRenderer.ColorRamp = colorRamp;
                                        (rasterStretchColorRampRenderer as IRasterRenderer).Update();
                                        (rasterStretchColorRampRenderer as IRasterRenderer).Update();
                                        IRasterRenderer rasterRenderer = rasterStretchColorRampRenderer as IRasterRenderer;
                                        rasterRenderer.Update();
                                        IRasterStretch2 rasterStretch = (IRasterStretch2)rasterRenderer;
                                        rasterStretch.Background = this.chkRasterStretchBackground.Checked;
                                        if (this.chkRasterStretchBackground.Checked)
                                        {
                                            rasterStretch.BackgroundValue = Convert.ToInt32(this.txtRasterStretchBackground.Text);
                                            Color color = this.colorRasterStretchBackground.Color;
                                            rasterStretch.BackgroundColor = new RgbColorClass
                                            {
                                                RGB = (int)color.B * 65536 + (int)color.G * 256 + (int)color.R
                                            };
                                        }
                                        rasterLayer.Renderer = rasterRenderer;
                                    }
                                }
                                else
                                {
                                    IRasterLayer rasterLayer = this.layer as IRasterLayer;
                                    IRasterRenderer renderer = rasterLayer.Renderer;
                                    IRasterClassifyColorRampRenderer rasterClassifyColorRampRenderer;
                                    if (renderer is IRasterClassifyColorRampRenderer)
                                    {
                                        rasterClassifyColorRampRenderer = (renderer as IRasterClassifyColorRampRenderer);
                                    }
                                    else
                                    {
                                        rasterClassifyColorRampRenderer = new RasterClassifyColorRampRendererClass();
                                    }
                                    rasterClassifyColorRampRenderer.ClassCount = Convert.ToInt32(this.cmbRasterClassifyClass.Text);
                                    for (int i = 0; i < this.classifyRecordClassList.Count; i++)
                                    {
                                        ClassifyRecordClass classifyRecordClass = this.classifyRecordClassList[i];
                                        rasterClassifyColorRampRenderer.set_Break(i, classifyRecordClass.BreakValue);
                                        rasterClassifyColorRampRenderer.set_Label(i, classifyRecordClass.Label);
                                        rasterClassifyColorRampRenderer.set_Symbol(i, classifyRecordClass.Symbol);
                                    }
                                    string text = this.cmbRasterClassifyField.Text;
                                    if (text != "")
                                    {
                                        rasterClassifyColorRampRenderer.ClassField = this.cmbRasterClassifyField.Text;
                                    }
                                    IRasterClassifyUIProperties rasterClassifyUIProperties = rasterClassifyColorRampRenderer as IRasterClassifyUIProperties;
                                    if (this.cmbRasterClassifyColorRamp.SelectedIndex == -1)
                                    {
                                        rasterClassifyUIProperties.ColorRamp = "";
                                    }
                                    else
                                    {
                                        rasterClassifyUIProperties.ColorRamp = this.cmbRasterClassifyColorRamp.Properties.Items[this.cmbRasterClassifyColorRamp.SelectedIndex].Value.ToString();
                                    }
                                    rasterLayer.Renderer = (rasterClassifyColorRampRenderer as IRasterRenderer);
                                }
                            }
                            else
                            {
                                IRasterLayer rasterLayer = this.layer as IRasterLayer;
                                IRasterRenderer renderer = rasterLayer.Renderer;
                                IRasterUniqueValueRenderer rasterUniqueValueRenderer;
                                if (renderer is IRasterUniqueValueRenderer)
                                {
                                    rasterUniqueValueRenderer = (renderer as IRasterUniqueValueRenderer);
                                }
                                else
                                {
                                    rasterUniqueValueRenderer = new RasterUniqueValueRendererClass();
                                }
                                for (int i = 0; i < rasterUniqueValueRenderer.HeadingCount; i++)
                                {
                                    int num2 = rasterUniqueValueRenderer.get_ClassCount(i);
                                    for (int j = 0; j < num2; j++)
                                    {
                                        rasterUniqueValueRenderer.RemoveValues(i, j);
                                    }
                                }
                                rasterUniqueValueRenderer.HeadingCount = 1;
                                rasterUniqueValueRenderer.set_ClassCount(0, this.uniqueValueRecordClassList.Count);
                                for (int i = 0; i < this.uniqueValueRecordClassList.Count; i++)
                                {
                                    UniqueValueRecordClass uniqueValueRecordClass = this.uniqueValueRecordClassList[i];
                                    rasterUniqueValueRenderer.AddValue(0, i, uniqueValueRecordClass.Value);
                                    rasterUniqueValueRenderer.set_Label(0, i, uniqueValueRecordClass.Label);
                                    rasterUniqueValueRenderer.set_Symbol(0, i, uniqueValueRecordClass.Symbol);
                                }
                                rasterUniqueValueRenderer.Field = this.cmbRasterUniqueValueField.Text;
                                if (this.cmbRasterUniqueValueColorRamp.SelectedIndex == -1)
                                {
                                    rasterUniqueValueRenderer.ColorScheme = "";
                                }
                                else
                                {
                                    rasterUniqueValueRenderer.ColorScheme = this.cmbRasterUniqueValueColorRamp.Properties.Items[this.cmbRasterUniqueValueColorRamp.SelectedIndex].Value.ToString();
                                }
                                rasterLayer.Renderer = (rasterUniqueValueRenderer as IRasterRenderer);
                            }
                        }
                        else
                        {
                            IGeoFeatureLayer geoFeatureLayer = this.layer as IGeoFeatureLayer;
                            IFeatureRenderer renderer2 = geoFeatureLayer.Renderer;
                            IUniqueValueRenderer uniqueValueRenderer;
                            if (renderer2 is IUniqueValueRenderer)
                            {
                                uniqueValueRenderer = (renderer2 as IUniqueValueRenderer);
                            }
                            else
                            {
                                uniqueValueRenderer = new UniqueValueRendererClass();
                            }
                            uniqueValueRenderer.RemoveAllValues();
                            for (int i = 0; i < this.uniqueValueRecordClassList.Count; i++)
                            {
                                UniqueValueRecordClass uniqueValueRecordClass = this.uniqueValueRecordClassList[i];
                                uniqueValueRenderer.AddValue(uniqueValueRecordClass.Value, "", uniqueValueRecordClass.Symbol);
                                uniqueValueRenderer.set_Label(uniqueValueRecordClass.Value, uniqueValueRecordClass.Label);
                            }
                            uniqueValueRenderer.FieldCount = 1;
                            uniqueValueRenderer.set_Field(0, this.cmbUniqueValueField.Text);
                            uniqueValueRenderer.ColorScheme = this.cmbUniqueValueColorRamp.Properties.Items[this.cmbUniqueValueColorRamp.SelectedIndex].Value.ToString();
                            geoFeatureLayer.Renderer = (uniqueValueRenderer as IFeatureRenderer);
                        }
                    }
                    else
                    {
                        IGeoFeatureLayer geoFeatureLayer = this.layer as IGeoFeatureLayer;
                        IFeatureRenderer renderer2 = geoFeatureLayer.Renderer;
                        ISimpleRenderer simpleRenderer;
                        if (renderer2 is ISimpleRenderer)
                        {
                            simpleRenderer = (renderer2 as ISimpleRenderer);
                        }
                        else
                        {
                            simpleRenderer = new SimpleRendererClass();
                        }
                        simpleRenderer.Symbol = this.simpleRendererSymbol;
                        simpleRenderer.Label = this.txtSimpleDescription.Text;
                        geoFeatureLayer.Renderer = (simpleRenderer as IFeatureRenderer);
                    }
                }
                //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                base.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                GFS.BLL.Log.WriteLog(typeof(frmLayerRender),ex);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbColorRamp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbColorRamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = this.xtraTabControl.SelectedTabPage.Name;
            if (name != null)
            {
                if (!(name == "pageVectorUniqueValue"))
                {
                    if (!(name == "pageRasterUniqueValue"))
                    {
                        if (name == "pageRasterClassify")
                        {
                            if (this.classifyRecordClassList != null && this.classifyRecordClassList.Count != 0)
                            {
                                ImageComboBoxEdit mImageComboBoxEdit = this.cmbRasterClassifyColorRamp;
                                int count = this.classifyRecordClassList.Count;
                                this.CreateEnumColorsFromColorRamps(mImageComboBoxEdit, count);
                                this.CurrentEnumColors.Reset();
                                for (int i = 0; i < this.classifyRecordClassList.Count; i++)
                                {
                                    IColor color = this.CurrentEnumColors.Next();
                                    IFillSymbol fillSymbol;
                                    if (this.classifyRecordClassList[i].Symbol == null)
                                    {
                                        fillSymbol = new SimpleFillSymbolClass();
                                    }
                                    else
                                    {
                                        fillSymbol = (this.classifyRecordClassList[i].Symbol as IFillSymbol);
                                    }
                                    fillSymbol.Color = color;
                                    this.classifyRecordClassList[i].Symbol = (fillSymbol as ISymbol);
                                }
                                this.gridViewRasterClassify.UpdateSummary();
                            }
                        }
                    }
                    else if (this.uniqueValueRecordClassList != null && this.uniqueValueRecordClassList.Count != 0)
                    {
                        ImageComboBoxEdit mImageComboBoxEdit = this.cmbRasterUniqueValueColorRamp;
                        int count = this.uniqueValueRecordClassList.Count;
                        this.CreateEnumColorsFromColorRamps(mImageComboBoxEdit, count);
                        this.CurrentEnumColors.Reset();
                        for (int i = 0; i < this.uniqueValueRecordClassList.Count; i++)
                        {
                            IColor color = this.CurrentEnumColors.Next();
                            IFillSymbol fillSymbol;
                            if (this.uniqueValueRecordClassList[i].Symbol == null)
                            {
                                fillSymbol = new SimpleFillSymbolClass();
                            }
                            else
                            {
                                fillSymbol = (this.uniqueValueRecordClassList[i].Symbol as IFillSymbol);
                            }
                            fillSymbol.Color = color;
                            this.uniqueValueRecordClassList[i].Symbol = (fillSymbol as ISymbol);
                        }
                        this.InitGridControl(this.gridControlRasterUniqueValue, this.gridViewRasterUniqueValue, this.repositoryItemPictureEditRasterUniqueValue, this.uniqueValueRecordClassList);
                        this.gridViewRasterUniqueValue.UpdateGroupSummary();
                    }
                }
                else if (this.uniqueValueRecordClassList != null && this.uniqueValueRecordClassList.Count != 0)
                {
                    ImageComboBoxEdit mImageComboBoxEdit = this.cmbUniqueValueColorRamp;
                    int count = this.uniqueValueRecordClassList.Count;
                    this.CreateEnumColorsFromColorRamps(mImageComboBoxEdit, count);
                    this.CurrentEnumColors.Reset();
                    for (int i = 0; i < this.uniqueValueRecordClassList.Count; i++)
                    {
                        IColor color = this.CurrentEnumColors.Next();
                        switch (this.CurrentSymbologyStyleClass)
                        {
                            case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                                {
                                    IFillSymbol fillSymbol;
                                    if (this.uniqueValueRecordClassList[i].Symbol == null)
                                    {
                                        fillSymbol = new SimpleFillSymbolClass();
                                    }
                                    else
                                    {
                                        fillSymbol = (this.uniqueValueRecordClassList[i].Symbol as IFillSymbol);
                                    }
                                    fillSymbol.Color = color;
                                    this.uniqueValueRecordClassList[i].Symbol = (fillSymbol as ISymbol);
                                    break;
                                }
                            case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                                {
                                    ILineSymbol lineSymbol;
                                    if (this.uniqueValueRecordClassList[i].Symbol == null)
                                    {
                                        lineSymbol = new SimpleLineSymbolClass();
                                    }
                                    else
                                    {
                                        lineSymbol = (this.uniqueValueRecordClassList[i].Symbol as ILineSymbol);
                                    }
                                    lineSymbol.Color = color;
                                    this.uniqueValueRecordClassList[i].Symbol = (lineSymbol as ISymbol);
                                    break;
                                }
                            case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                                {
                                    IMarkerSymbol markerSymbol;
                                    if (this.uniqueValueRecordClassList[i].Symbol == null)
                                    {
                                        markerSymbol = new SimpleMarkerSymbolClass();
                                        markerSymbol.Size = 4.0;
                                    }
                                    else
                                    {
                                        markerSymbol = (this.uniqueValueRecordClassList[i].Symbol as IMarkerSymbol);
                                    }
                                    markerSymbol.Color = color;
                                    this.uniqueValueRecordClassList[i].Symbol = (markerSymbol as ISymbol);
                                    break;
                                }
                        }
                    }
                    this.gridViewUniqueValue.UpdateGroupSummary();
                }
            }
        }

        /// <summary>
        /// Creates the enum colors from color ramps.
        /// </summary>
        /// <param name="mImageComboBoxEdit">The m image ComboBox edit.</param>
        /// <param name="ColorSize">Size of the color.</param>
        /// <returns>IColorRamp.</returns>
        private IColorRamp CreateEnumColorsFromColorRamps(ImageComboBoxEdit mImageComboBoxEdit, int ColorSize)
        {
            ImageComboBoxItem myImageComboBoxItem = mImageComboBoxEdit.Properties.Items[mImageComboBoxEdit.SelectedIndex];
            IStyleGalleryItem styleGalleryItem = this.MatchScheme(myImageComboBoxItem);
            IColorRamp colorRamp = styleGalleryItem.Item as IColorRamp;
            if (ColorSize == 1)
            {
                ColorSize = 2;
            }
            colorRamp.Size = ColorSize;
            bool flag;
            colorRamp.CreateRamp(out flag);
            colorRamp.Name = styleGalleryItem.Name;
            this.CurrentEnumColors = colorRamp.Colors;
            int num = 0;
            while (this.CurrentEnumColors.Next() != null)
            {
                num++;
            }
            return colorRamp;
        }

        /// <summary>
        /// Matches the scheme.
        /// </summary>
        /// <param name="myImageComboBoxItem">My image ComboBox item.</param>
        /// <returns>IStyleGalleryItem.</returns>
        private IStyleGalleryItem MatchScheme(ImageComboBoxItem myImageComboBoxItem)
        {
            string b = myImageComboBoxItem.Value.ToString();
            IStyleGalleryStorage styleGalleryStorage = new ServerStyleGalleryClass();
            styleGalleryStorage.AddFile(GFS.BLL.ConstDef.FILE_STYLE);
            this.pStyleGallery = (styleGalleryStorage as IStyleGallery);
            IEnumStyleGalleryItem enumStyleGalleryItem = this.pStyleGallery.get_Items("Color Ramps", GFS.BLL.ConstDef.FILE_STYLE, "");
            enumStyleGalleryItem.Reset();
            IStyleGalleryItem styleGalleryItem;
            for (styleGalleryItem = enumStyleGalleryItem.Next(); styleGalleryItem != null; styleGalleryItem = enumStyleGalleryItem.Next())
            {
                if (styleGalleryItem.Name == b)
                {
                    break;
                }
            }
            if (enumStyleGalleryItem != null)
            Marshal.ReleaseComObject(enumStyleGalleryItem);
            return styleGalleryItem;
        }

        /// <summary>
        /// Initializes the random color symbol.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="CurrentRandomColorStatus">The current random color status.</param>
        /// <param name="SymbologyStyleClass">The symbology style class.</param>
        private void InitializeRandomColorSymbol(ref ISymbol Symbol, RandomColorStatus CurrentRandomColorStatus, esriSymbologyStyleClass SymbologyStyleClass)
        {
            if (Symbol == null)
            {
                if (this.CurrentEnumColors == null)
                {
                    this.cmbColorRamp_SelectedIndexChanged(null, null);
                }
                IColor color = null;
                switch (CurrentRandomColorStatus)
                {
                    case RandomColorStatus.HsvColor:
                        {
                            IHsvColor hsvColor = new HsvColorClass();
                            Random random = new Random();
                            hsvColor.Hue = random.Next(0, 360);
                            hsvColor.Saturation = 25;
                            hsvColor.Value = 100;
                            color = hsvColor;
                            break;
                        }
                    case RandomColorStatus.ColorRamp:
                        color = this.CurrentEnumColors.Next();
                        if (color == null)
                        {
                            this.CurrentEnumColors.Reset();
                            color = this.CurrentEnumColors.Next();
                        }
                        break;
                }
                switch (SymbologyStyleClass)
                {
                    case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                        Symbol = (new SimpleFillSymbolClass
                        {
                            Style = esriSimpleFillStyle.esriSFSSolid,
                            Color = color
                        } as ISymbol);
                        break;
                    case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                        Symbol = (new SimpleLineSymbolClass
                        {
                            Style = esriSimpleLineStyle.esriSLSSolid,
                            Color = color
                        } as ISymbol);
                        break;
                    case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                        Symbol = (new SimpleMarkerSymbolClass
                        {
                            Style = esriSimpleMarkerStyle.esriSMSCircle,
                            Color = color,
                            Size = 4.0,
                            Outline = true
                        } as ISymbol);
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbField control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.uniqueValueRecordClassList != null)
            {
                this.btnRemoveAllValues_Click(null, null);
                this.btnAddAllValues_Click(null, null);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbRasterClassifyClass control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbRasterClassifyClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.classifyRecordClassList != null)
            {
                string text = this.cmbRasterClassifyField.Text;
                int num = Convert.ToInt32(this.cmbRasterClassifyClass.Text);
                double[] array = new double[num + 1];
                IRasterLayer rasterLayer = this.layer as IRasterLayer;
                IRasterRenderer rasterRenderer = rasterLayer.Renderer;
                IRasterClassifyColorRampRenderer rasterClassifyColorRampRenderer = rasterRenderer as IRasterClassifyColorRampRenderer;
                if (rasterClassifyColorRampRenderer == null)
                {
                    rasterClassifyColorRampRenderer = new RasterClassifyColorRampRendererClass();
                    rasterRenderer = (rasterClassifyColorRampRenderer as IRasterRenderer);
                    IRaster raster = rasterLayer.Raster;
                    IRasterBandCollection rasterBandCollection = raster as IRasterBandCollection;
                    IRasterBand rasterBand = rasterBandCollection.Item(0);
                    if (rasterBand.Histogram == null)
                    {
                        rasterBand.ComputeStatsAndHist();
                    }
                    rasterRenderer.Raster = raster;
                    rasterClassifyColorRampRenderer.ClassCount = num;
                    rasterRenderer.Update();
                    for (int i = 0; i <= num; i++)
                    {
                        array[i] = rasterClassifyColorRampRenderer.get_Break(i);
                    }
                }
                else
                {
                    IAttributeTable attributeTable = this.layer as IAttributeTable;
                    ITable attributeTable2 = attributeTable.AttributeTable;
                    if (attributeTable2 != null)
                    {
                        array = this.GetClassBreaksResult(text, attributeTable2, num);
                    }
                    else
                    {
                        rasterClassifyColorRampRenderer.ClassCount = num;
                        for (int i = 0; i <= num; i++)
                        {
                            array[i] = rasterClassifyColorRampRenderer.get_Break(i);
                        }
                    }
                }
                this.CreateEnumColorsFromColorRamps(this.cmbRasterClassifyColorRamp, num);
                this.CurrentEnumColors.Reset();
                this.classifyRecordClassList.Clear();
                for (int i = 0; i < array.Length - 1; i++)
                {
                    double num2 = array[i];
                    double value = array[i + 1];
                    string label = Math.Round(num2, 4) + " - " + Math.Round(value, 4);
                    IColor color = this.CurrentEnumColors.Next();
                    ISymbol symbol = new SimpleFillSymbolClass
                    {
                        Color = color
                    } as ISymbol;
                    ClassifyRecordClass item = new ClassifyRecordClass(symbol, num2, label);
                    this.classifyRecordClassList.Add(item);
                }
                this.gridViewRasterClassify.UpdateSummary();
            }
        }

        /// <summary>
        /// Gets the class breaks result.
        /// </summary>
        /// <param name="Field">The field.</param>
        /// <param name="table">The table.</param>
        /// <param name="breakCount">The break count.</param>
        /// <returns>System.Double[].</returns>
        private double[] GetClassBreaksResult(string Field, ITable table, int breakCount)
        {
            object doubleArrayValues = null;
            object longArrayFrequencies = null;
            IBasicHistogram basicHistogram = new BasicTableHistogramClass
            {
                Field = Field,
                Table = table
            } as IBasicHistogram;
            basicHistogram.GetHistogram(out doubleArrayValues, out longArrayFrequencies);
            IClassifyGEN classifyGEN = new EqualIntervalClass();
            classifyGEN.Classify(doubleArrayValues, longArrayFrequencies, ref breakCount);
            object classBreaks = classifyGEN.ClassBreaks;
            return classBreaks as double[];
        }

        /// <summary>
        /// Handles the Click event of the btnRasterStretchGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRasterStretchGenerate_Click(object sender, EventArgs e)
        {
            if (this.classifyRecordClassList != null)
            {
                this.SetRasterStretchView(false);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkRasterStretchInvert control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkRasterStretchInvert_CheckedChanged(object sender, EventArgs e)
        {
            if (this.classifyRecordClassList != null)
            {
                this.SetRasterStretchView(this.chkRasterStretchInvert.Checked);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbRasterStretchColorRamp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbRasterStretchColorRamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.classifyRecordClassList != null)
            {
                this.SetRasterStretchView(false);
            }
        }

        /// <summary>
        /// Sets the raster stretch view.
        /// </summary>
        /// <param name="bInvert">if set to <c>true</c> [b invert].</param>
        private void SetRasterStretchView(bool bInvert)
        {
            if (this.txtRasterStretchIntervals.Text == "")
            {
                this.txtRasterStretchIntervals.Text = "1";
            }
            int num = Convert.ToInt32(this.txtRasterStretchIntervals.Text) + 1;
            IColorRamp colorRamp = this.CreateEnumColorsFromColorRamps(this.cmbRasterStretchColorRamp, num);
            IRasterLayer rasterLayer = this.layer as IRasterLayer;
            IRasterStretchColorRampRenderer rasterStretchColorRampRenderer = rasterLayer.Renderer as IRasterStretchColorRampRenderer;
            if (rasterStretchColorRampRenderer == null)
            {
                rasterStretchColorRampRenderer = new RasterStretchColorRampRendererClass();
                rasterLayer.Renderer = (rasterStretchColorRampRenderer as IRasterRenderer);
                rasterLayer.Renderer.Raster = rasterLayer.Raster;
                rasterStretchColorRampRenderer.BandIndex = 0;
            }
            IRasterStretchAdvancedLabels rasterStretchAdvancedLabels = rasterStretchColorRampRenderer as IRasterStretchAdvancedLabels;
            int numLabels = rasterStretchAdvancedLabels.NumLabels;
            string labelHigh = rasterStretchColorRampRenderer.LabelHigh;
            string labelLow = rasterStretchColorRampRenderer.LabelLow;
            IColor fromColor = colorRamp.get_Color(0);
            IColor toColor = colorRamp.get_Color(colorRamp.Size - 1);
            if (bInvert)
            {
                fromColor = colorRamp.get_Color(colorRamp.Size - 1);
                toColor = colorRamp.get_Color(0);
            }
            IAlgorithmicColorRamp algorithmicColorRamp = new AlgorithmicColorRampClass();
            algorithmicColorRamp.Size = colorRamp.Size;
            algorithmicColorRamp.FromColor = fromColor;
            algorithmicColorRamp.ToColor = toColor;
            algorithmicColorRamp.Name = colorRamp.Name;
            bool flag;
            algorithmicColorRamp.CreateRamp(out flag);
            this.classifyRecordClassList.Clear();
            rasterStretchAdvancedLabels.NumLabels = num;
            this.classifyRecordClassList = this.InitRasterStretchRendererData(rasterStretchColorRampRenderer, algorithmicColorRamp);
            this.InitGridControl(this.gridControlRasterStretch, this.gridViewRasterStretch, this.repositoryItemPictureEditRasterStretch, this.classifyRecordClassList);
            this.gridViewRasterStretch.UpdateSummary();
            rasterStretchAdvancedLabels.NumLabels = numLabels;
            rasterStretchColorRampRenderer.LabelHigh = labelHigh;
            rasterStretchColorRampRenderer.LabelLow = labelLow;
        }

        /// <summary>
        /// Handles the HelpButtonClicked event of the frmLayerRender control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void frmLayerRender_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            //HelpManager.ShowHelp(this);
        }
    }
}