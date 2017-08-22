using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
//using HTES.TAS.Const;
//using HTES.TAS.DB.Model;
//using HTES.TAS.Log;
using GFS.BLL;
using GFS.Common;
//using PS.Plot.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GFS.Commands.UI
{
    public class FrmROI : XtraForm
    {
        private IContainer components = null;

        private SplitContainerControl splitContainerControl1;

        private SimpleButton btnSaveROI;

        private SimpleButton btnLoadROI;

        private SimpleButton btnClearROI;

        private SimpleButton btnDeleteROI;

        private SimpleButton btnAddROI;

        private LabelControl lblGeometryType;

        private CheckButton chkBtnPolygon;

        private CheckButton chkBtnRectangle;

        private CheckButton chkBtnSquare;

        private CheckButton chkBtnEllipse;

        private CheckButton chkBtnCircle;

        private ColorEdit colorEditROI;

        private TextEdit txtROIName;

        private TextEdit txtROIID;

        private LabelControl lblROIColor;

        private LabelControl lblROIName;

        private LabelControl lblROINum;

        private CheckedTreeList treeListROILayer;

        private TreeListColumn treeListColumnROIList;

        private PopupMenu popupMenu1;

        private BarButtonItem barBtnItemDeleteNode;

        private BarManager barManager1;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        public static Dictionary<int, ROILayerClass> RoiLayerDic = new Dictionary<int, ROILayerClass>();

        private CmdToolDrawElement m_drawElementTool;

        private IColor m_Color = new RgbColorClass();

        private IMapControl2 m_pMapControl;

        //private Logger m_logger = new Logger();

        private static string MSG01 = "是否保存ROI文件？";

        private static string MSG02 = "保存ROI图层到XML文件";

        private static string MSG03 = "加载ROI";

        private static string MSG04 = "请在ROI图层列表中至少勾选一个节点！";

        private static string MSG05 = "请在左侧列表中选择一个节点，然后再进行相关的操作！";

        private static string MSG06 = "保存ROI";

        private static string MSG08 = "删除所有ROI";

        private static string MSG09 = "删除ROI";

        private static string MSG10 = "新增ROI";

        private static string MSG11 = "多边形";

        private static string MSG12 = "长方形";

        private static string MSG13 = "正方形";

        private static string MSG14 = "椭圆";

        private static string MSG15 = "圆";

        private static string MSG16 = "是否确认全部删除？";

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmROI));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListROILayer = new GFS.Commands.UI.CheckedTreeList();
            this.treeListColumnROIList = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnSaveROI = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadROI = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearROI = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteROI = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddROI = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGeometryType = new DevExpress.XtraEditors.LabelControl();
            this.chkBtnCircle = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnPolygon = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnEllipse = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnRectangle = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnSquare = new DevExpress.XtraEditors.CheckButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblROINum = new DevExpress.XtraEditors.LabelControl();
            this.lblROIName = new DevExpress.XtraEditors.LabelControl();
            this.lblROIColor = new DevExpress.XtraEditors.LabelControl();
            this.txtROIID = new DevExpress.XtraEditors.TextEdit();
            this.txtROIName = new DevExpress.XtraEditors.TextEdit();
            this.colorEditROI = new DevExpress.XtraEditors.ColorEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtnItemDeleteNode = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListROILayer)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtROIID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtROIName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditROI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListROILayer);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSaveROI);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnLoadROI);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClearROI);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnDeleteROI);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnAddROI);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainerControl1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(532, 437);
            this.splitContainerControl1.SplitterPosition = 213;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListROILayer
            // 
            this.treeListROILayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.treeListROILayer.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeListROILayer.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListROILayer.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeListROILayer.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListROILayer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnROIList});
            this.treeListROILayer.Location = new System.Drawing.Point(3, 41);
            this.treeListROILayer.Name = "treeListROILayer";
            this.treeListROILayer.OptionsBehavior.Editable = false;
            this.treeListROILayer.OptionsView.ShowCheckBoxes = true;
            this.treeListROILayer.OptionsView.ShowIndicator = false;
            this.treeListROILayer.Size = new System.Drawing.Size(210, 393);
            this.treeListROILayer.TabIndex = 12;
            this.treeListROILayer.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeListROILayer_AfterCheckNode);
            this.treeListROILayer.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
            this.treeListROILayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListROILayer_MouseUp);
            // 
            // treeListColumnROIList
            // 
            this.treeListColumnROIList.Caption = "ROI 图层列表";
            this.treeListColumnROIList.FieldName = "ROI 图层列表";
            this.treeListColumnROIList.MinWidth = 32;
            this.treeListColumnROIList.Name = "treeListColumnROIList";
            this.treeListColumnROIList.OptionsColumn.AllowEdit = false;
            this.treeListColumnROIList.OptionsColumn.AllowMove = false;
            this.treeListColumnROIList.Visible = true;
            this.treeListColumnROIList.VisibleIndex = 0;
            this.treeListColumnROIList.Width = 91;
            // 
            // btnSaveROI
            // 
            this.btnSaveROI.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveROI.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnSaveROI.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveROI.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnSaveROI.Appearance.Options.UseBackColor = true;
            this.btnSaveROI.Appearance.Options.UseBorderColor = true;
            this.btnSaveROI.Appearance.Options.UseForeColor = true;
            this.btnSaveROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveROI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSaveROI.Enabled = false;
            this.btnSaveROI.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveROI.Image")));
            this.btnSaveROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaveROI.Location = new System.Drawing.Point(42, 10);
            this.btnSaveROI.Name = "btnSaveROI";
            this.btnSaveROI.Size = new System.Drawing.Size(24, 24);
            this.btnSaveROI.TabIndex = 5;
            this.btnSaveROI.Click += new System.EventHandler(this.btnSaveROI_Click);
            // 
            // btnLoadROI
            // 
            this.btnLoadROI.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadROI.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnLoadROI.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnLoadROI.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnLoadROI.Appearance.Options.UseBackColor = true;
            this.btnLoadROI.Appearance.Options.UseBorderColor = true;
            this.btnLoadROI.Appearance.Options.UseForeColor = true;
            this.btnLoadROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoadROI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnLoadROI.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadROI.Image")));
            this.btnLoadROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLoadROI.Location = new System.Drawing.Point(8, 10);
            this.btnLoadROI.Name = "btnLoadROI";
            this.btnLoadROI.Size = new System.Drawing.Size(25, 25);
            this.btnLoadROI.TabIndex = 4;
            this.btnLoadROI.Click += new System.EventHandler(this.btnLoadROI_Click);
            // 
            // btnClearROI
            // 
            this.btnClearROI.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnClearROI.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnClearROI.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnClearROI.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnClearROI.Appearance.Options.UseBackColor = true;
            this.btnClearROI.Appearance.Options.UseBorderColor = true;
            this.btnClearROI.Appearance.Options.UseForeColor = true;
            this.btnClearROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearROI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnClearROI.Enabled = false;
            this.btnClearROI.Image = ((System.Drawing.Image)(resources.GetObject("btnClearROI.Image")));
            this.btnClearROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClearROI.Location = new System.Drawing.Point(145, 10);
            this.btnClearROI.Name = "btnClearROI";
            this.btnClearROI.Size = new System.Drawing.Size(25, 25);
            this.btnClearROI.TabIndex = 3;
            this.btnClearROI.Click += new System.EventHandler(this.btnClearROI_Click);
            // 
            // btnDeleteROI
            // 
            this.btnDeleteROI.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteROI.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnDeleteROI.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnDeleteROI.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnDeleteROI.Appearance.Options.UseBackColor = true;
            this.btnDeleteROI.Appearance.Options.UseBorderColor = true;
            this.btnDeleteROI.Appearance.Options.UseForeColor = true;
            this.btnDeleteROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteROI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDeleteROI.Enabled = false;
            this.btnDeleteROI.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteROI.Image")));
            this.btnDeleteROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDeleteROI.Location = new System.Drawing.Point(111, 10);
            this.btnDeleteROI.Name = "btnDeleteROI";
            this.btnDeleteROI.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteROI.TabIndex = 2;
            this.btnDeleteROI.Click += new System.EventHandler(this.btnDeleteROI_Click);
            // 
            // btnAddROI
            // 
            this.btnAddROI.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnAddROI.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnAddROI.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddROI.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddROI.Appearance.Options.UseBackColor = true;
            this.btnAddROI.Appearance.Options.UseBorderColor = true;
            this.btnAddROI.Appearance.Options.UseForeColor = true;
            this.btnAddROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddROI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnAddROI.Image = ((System.Drawing.Image)(resources.GetObject("btnAddROI.Image")));
            this.btnAddROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddROI.Location = new System.Drawing.Point(77, 10);
            this.btnAddROI.Name = "btnAddROI";
            this.btnAddROI.Size = new System.Drawing.Size(25, 25);
            this.btnAddROI.TabIndex = 1;
            this.btnAddROI.Click += new System.EventHandler(this.btnAddROI_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lblGeometryType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkBtnCircle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkBtnPolygon, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkBtnEllipse, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkBtnRectangle, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkBtnSquare, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 55);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 29);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // lblGeometryType
            // 
            this.lblGeometryType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeometryType.Location = new System.Drawing.Point(3, 7);
            this.lblGeometryType.Name = "lblGeometryType";
            this.lblGeometryType.Size = new System.Drawing.Size(48, 14);
            this.lblGeometryType.TabIndex = 11;
            this.lblGeometryType.Text = "几何形状";
            // 
            // chkBtnCircle
            // 
            this.chkBtnCircle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBtnCircle.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.chkBtnCircle.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.chkBtnCircle.Appearance.ForeColor = System.Drawing.Color.Coral;
            this.chkBtnCircle.Appearance.Options.UseBackColor = true;
            this.chkBtnCircle.Appearance.Options.UseBorderColor = true;
            this.chkBtnCircle.Appearance.Options.UseForeColor = true;
            this.chkBtnCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBtnCircle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkBtnCircle.Enabled = false;
            this.chkBtnCircle.Image = ((System.Drawing.Image)(resources.GetObject("chkBtnCircle.Image")));
            this.chkBtnCircle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkBtnCircle.Location = new System.Drawing.Point(57, 3);
            this.chkBtnCircle.Name = "chkBtnCircle";
            this.chkBtnCircle.Size = new System.Drawing.Size(24, 23);
            this.chkBtnCircle.TabIndex = 6;
            this.chkBtnCircle.Click += new System.EventHandler(this.chkBtnCircle_Click);
            // 
            // chkBtnPolygon
            // 
            this.chkBtnPolygon.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBtnPolygon.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.chkBtnPolygon.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.chkBtnPolygon.Appearance.ForeColor = System.Drawing.Color.Coral;
            this.chkBtnPolygon.Appearance.Options.UseBackColor = true;
            this.chkBtnPolygon.Appearance.Options.UseBorderColor = true;
            this.chkBtnPolygon.Appearance.Options.UseForeColor = true;
            this.chkBtnPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBtnPolygon.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkBtnPolygon.Enabled = false;
            this.chkBtnPolygon.Image = ((System.Drawing.Image)(resources.GetObject("chkBtnPolygon.Image")));
            this.chkBtnPolygon.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkBtnPolygon.Location = new System.Drawing.Point(177, 3);
            this.chkBtnPolygon.Name = "chkBtnPolygon";
            this.chkBtnPolygon.Size = new System.Drawing.Size(25, 23);
            this.chkBtnPolygon.TabIndex = 10;
            this.chkBtnPolygon.Click += new System.EventHandler(this.chkBtnPolygon_Click);
            // 
            // chkBtnEllipse
            // 
            this.chkBtnEllipse.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBtnEllipse.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.chkBtnEllipse.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.chkBtnEllipse.Appearance.ForeColor = System.Drawing.Color.Coral;
            this.chkBtnEllipse.Appearance.Options.UseBackColor = true;
            this.chkBtnEllipse.Appearance.Options.UseBorderColor = true;
            this.chkBtnEllipse.Appearance.Options.UseForeColor = true;
            this.chkBtnEllipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBtnEllipse.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkBtnEllipse.Enabled = false;
            this.chkBtnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("chkBtnEllipse.Image")));
            this.chkBtnEllipse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkBtnEllipse.Location = new System.Drawing.Point(87, 3);
            this.chkBtnEllipse.Name = "chkBtnEllipse";
            this.chkBtnEllipse.Size = new System.Drawing.Size(24, 23);
            this.chkBtnEllipse.TabIndex = 7;
            this.chkBtnEllipse.Click += new System.EventHandler(this.chkBtnEllipse_Click);
            // 
            // chkBtnRectangle
            // 
            this.chkBtnRectangle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBtnRectangle.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.chkBtnRectangle.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.chkBtnRectangle.Appearance.ForeColor = System.Drawing.Color.Coral;
            this.chkBtnRectangle.Appearance.Options.UseBackColor = true;
            this.chkBtnRectangle.Appearance.Options.UseBorderColor = true;
            this.chkBtnRectangle.Appearance.Options.UseForeColor = true;
            this.chkBtnRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBtnRectangle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkBtnRectangle.Enabled = false;
            this.chkBtnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("chkBtnRectangle.Image")));
            this.chkBtnRectangle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkBtnRectangle.Location = new System.Drawing.Point(147, 3);
            this.chkBtnRectangle.Name = "chkBtnRectangle";
            this.chkBtnRectangle.Size = new System.Drawing.Size(24, 23);
            this.chkBtnRectangle.TabIndex = 9;
            this.chkBtnRectangle.Click += new System.EventHandler(this.chkBtnRectangle_Click);
            // 
            // chkBtnSquare
            // 
            this.chkBtnSquare.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBtnSquare.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.chkBtnSquare.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.chkBtnSquare.Appearance.ForeColor = System.Drawing.Color.Coral;
            this.chkBtnSquare.Appearance.Options.UseBackColor = true;
            this.chkBtnSquare.Appearance.Options.UseBorderColor = true;
            this.chkBtnSquare.Appearance.Options.UseForeColor = true;
            this.chkBtnSquare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBtnSquare.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkBtnSquare.Enabled = false;
            this.chkBtnSquare.Image = ((System.Drawing.Image)(resources.GetObject("chkBtnSquare.Image")));
            this.chkBtnSquare.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkBtnSquare.Location = new System.Drawing.Point(117, 3);
            this.chkBtnSquare.Name = "chkBtnSquare";
            this.chkBtnSquare.Size = new System.Drawing.Size(24, 23);
            this.chkBtnSquare.TabIndex = 8;
            this.chkBtnSquare.Click += new System.EventHandler(this.chkBtnSquare_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblROINum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblROIName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblROIColor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtROIID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtROIName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorEditROI, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 90);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 100);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // lblROINum
            // 
            this.lblROINum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblROINum.Location = new System.Drawing.Point(3, 9);
            this.lblROINum.Name = "lblROINum";
            this.lblROINum.Size = new System.Drawing.Size(48, 14);
            this.lblROINum.TabIndex = 0;
            this.lblROINum.Text = "ROI 编号";
            // 
            // lblROIName
            // 
            this.lblROIName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblROIName.Location = new System.Drawing.Point(3, 42);
            this.lblROIName.Name = "lblROIName";
            this.lblROIName.Size = new System.Drawing.Size(48, 14);
            this.lblROIName.TabIndex = 1;
            this.lblROIName.Text = "ROI 名称";
            // 
            // lblROIColor
            // 
            this.lblROIColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblROIColor.Location = new System.Drawing.Point(3, 76);
            this.lblROIColor.Name = "lblROIColor";
            this.lblROIColor.Size = new System.Drawing.Size(48, 14);
            this.lblROIColor.TabIndex = 2;
            this.lblROIColor.Text = "ROI 颜色";
            // 
            // txtROIID
            // 
            this.txtROIID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtROIID.Enabled = false;
            this.txtROIID.Location = new System.Drawing.Point(57, 6);
            this.txtROIID.Name = "txtROIID";
            this.txtROIID.Size = new System.Drawing.Size(225, 20);
            this.txtROIID.TabIndex = 3;
            // 
            // txtROIName
            // 
            this.txtROIName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtROIName.Enabled = false;
            this.txtROIName.Location = new System.Drawing.Point(57, 39);
            this.txtROIName.Name = "txtROIName";
            this.txtROIName.Size = new System.Drawing.Size(225, 20);
            this.txtROIName.TabIndex = 4;
            this.txtROIName.EditValueChanged += new System.EventHandler(this.txtROIName_EditValueChanged);
            // 
            // colorEditROI
            // 
            this.colorEditROI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditROI.EditValue = System.Drawing.Color.Red;
            this.colorEditROI.Enabled = false;
            this.colorEditROI.Location = new System.Drawing.Point(57, 73);
            this.colorEditROI.Name = "colorEditROI";
            this.colorEditROI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEditROI.Size = new System.Drawing.Size(225, 20);
            this.colorEditROI.TabIndex = 5;
            this.colorEditROI.TextChanged += new System.EventHandler(this.colorEditROI_EditValueChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItemDeleteNode, DevExpress.XtraBars.BarItemPaintStyle.Caption)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barBtnItemDeleteNode
            // 
            this.barBtnItemDeleteNode.Caption = "删除节点";
            this.barBtnItemDeleteNode.Id = 0;
            this.barBtnItemDeleteNode.Name = "barBtnItemDeleteNode";
            this.barBtnItemDeleteNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemDeleteNode_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnItemDeleteNode});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(532, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 437);
            this.barDockControlBottom.Size = new System.Drawing.Size(532, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(532, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // FrmROI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(532, 437);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmROI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROI工具";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FrmROI_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmROI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListROILayer)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtROIID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtROIName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditROI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        public FrmROI()
        {
            this.InitializeComponent();
            this.btnSaveROI.ToolTip = FrmROI.MSG06;
            this.btnLoadROI.ToolTip = FrmROI.MSG03;
            this.btnClearROI.ToolTip = FrmROI.MSG08;
            this.btnDeleteROI.ToolTip = FrmROI.MSG09;
            this.btnAddROI.ToolTip = FrmROI.MSG10;
            this.chkBtnPolygon.ToolTip = FrmROI.MSG11;
            this.chkBtnRectangle.ToolTip = FrmROI.MSG12;
            this.chkBtnSquare.ToolTip = FrmROI.MSG13;
            this.chkBtnEllipse.ToolTip = FrmROI.MSG14;
            this.chkBtnCircle.ToolTip = FrmROI.MSG15;
            this.m_Color = this.ColorToIColor(this.colorEditROI.Color);
            this.m_drawElementTool = new CmdToolDrawElement(FrmROI.RoiLayerDic);
            this.m_drawElementTool.ROITreeList = this.treeListROILayer;
            this.m_pMapControl = EnviVars.instance.MapControl;
            this.InitROI(FrmROI.RoiLayerDic);
        }

        private void FrmROI_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            List<TreeListNode> allCheckedNodes = this.treeListROILayer.GetAllCheckedNodes();
            if (allCheckedNodes.Count != 0)
            {
                System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show(FrmROI.MSG01, "提示信息", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Asterisk);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Title = FrmROI.MSG02;
                    saveFileDialog.Filter = string.Format("XML {0} (*.xml)|*.xml", "文件");
                    if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;
                        this.SaveROIToXml(fileName);
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnLoadROI_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Title = FrmROI.MSG03;
                openFileDialog.Filter = string.Format("XML {0} (*.xml)|*.xml", "文件");
                if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    this.LoadROI(fileName);
                    string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG03);
                    //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, message, null);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG03);
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, message, ex);
                Log.WriteLog(typeof(FrmROI), message);
                Log.WriteLog(typeof(FrmROI), ex);

            }
        }

        private void btnSaveROI_Click(object sender, EventArgs e)
        {
            try
            {
                List<TreeListNode> allCheckedNodes = this.treeListROILayer.GetAllCheckedNodes();
                if (allCheckedNodes.Count == 0)
                {
                    XtraMessageBox.Show(FrmROI.MSG04, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
                else
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Title = FrmROI.MSG02;
                    saveFileDialog.Filter = string.Format("XML {0} (*.xml)|*.xml", "文件");
                    if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;
                        this.SaveROIToXml(fileName);
                        string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG06);
                        //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, message, null);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG06);
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, message, ex);
                Log.WriteLog(typeof(FrmROI), message);
                Log.WriteLog(typeof(FrmROI), ex);
            }
        }

        private void btnAddROI_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtROIName.EditValueChanged -= new EventHandler(this.txtROIName_EditValueChanged);
                this.treeListROILayer.FocusedNodeChanged -= new FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
                ROILayerClass rOILayerClass = new ROILayerClass();
                string roiNodeName = string.Empty;
                int num = 1;
                while (rOILayerClass != null)
                {
                    roiNodeName = "ROI #" + num;
                    rOILayerClass = FrmROI.RoiLayerDic.Values.FirstOrDefault((ROILayerClass p) => p.Name == roiNodeName);
                    num++;
                }
                TreeListNode treeListNode = this.treeListROILayer.AppendNode(new object[]
				{
					roiNodeName
				}, null, System.Windows.Forms.CheckState.Checked);
                this.treeListROILayer.SetFocusedNode(treeListNode);
                int num2 = (FrmROI.RoiLayerDic.Keys.Count == 0) ? 1 : (FrmROI.RoiLayerDic.Keys.Max() + 1);
                this.txtROIID.Text = num2.ToString();
                this.txtROIName.Text = roiNodeName;
                this.m_drawElementTool.ParentNodeID = num2;
                ROILayerClass rOILayerClass2 = new ROILayerClass();
                rOILayerClass2.ID = num2;
                rOILayerClass2.Name = roiNodeName;
                rOILayerClass2.Color = this.ColorToIColor(this.colorEditROI.Color);
                rOILayerClass2.ElementList = new List<ROIElementClass>();
                FrmROI.RoiLayerDic.Add(num2, rOILayerClass2);
                treeListNode.Tag = rOILayerClass2;
                this.m_drawElementTool.ROINode = treeListNode;
                this.SetControlsEnabled(true);
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG10);
                //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, message, null);
                this.txtROIName.EditValueChanged += new EventHandler(this.txtROIName_EditValueChanged);
                this.treeListROILayer.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
            }
            catch (Exception ex)
            {
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG10);
                Log.WriteLog(typeof(FrmROI), message);
                Log.WriteLog(typeof(FrmROI), ex);
            }
        }

        private void btnDeleteROI_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ExistFocusedNode())
                {
                    TreeListNode focusedNode = this.treeListROILayer.FocusedNode;
                    if (focusedNode == null)
                    {
                        return;
                    }
                    this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
                    TreeListNode treeListNode = (focusedNode.Level == 0) ? focusedNode : focusedNode.ParentNode;
                    if (treeListNode.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    {
                        return;
                    }
                    this.DeleteCheckedROINode(treeListNode);
                    if (this.treeListROILayer.Nodes.Count == 0)
                    {
                        this.SetControlsEnabled(false);
                    }
                }
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG09);
                //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, message, null);
            }
            catch (Exception ex)
            {
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG09);
                Log.WriteLog(typeof(FrmROI), message);
                Log.WriteLog(typeof(FrmROI), ex);
            }
        }

        private void btnClearROI_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show(FrmROI.MSG16, "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                this.ClearROIElements();
                this.SetControlsEnabled(false);
            }
        }

        private void treeListROILayer_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.txtROIName.EditValueChanged -= new EventHandler(this.txtROIName_EditValueChanged);
            this.colorEditROI.EditValueChanged -= new EventHandler(this.colorEditROI_EditValueChanged);
            if (this.treeListROILayer.FocusedNode != null)
            {
                TreeListNode treeListNode = (this.treeListROILayer.FocusedNode.Level == 0) ? this.treeListROILayer.FocusedNode : this.treeListROILayer.FocusedNode.ParentNode;
                ROILayerClass rOILayerClass = treeListNode.Tag as ROILayerClass;
                if (this.treeListROILayer.FocusedNode.Level == 1)
                {
                    IElement element = (this.treeListROILayer.FocusedNode.Tag as ROIElementClass).Element;
                    IPoint point = new PointClass();
                    point.X = (element.Geometry.Envelope.XMin + element.Geometry.Envelope.XMax) / 2.0;
                    point.Y = (element.Geometry.Envelope.YMin + element.Geometry.Envelope.YMax) / 2.0;
                    IGeometry geometry = point;
                    geometry.Project(this.m_pMapControl.ActiveView.FocusMap.SpatialReference);
                    IEnvelope extent = this.m_pMapControl.ActiveView.Extent;
                    extent.CenterAt(point);
                    this.m_pMapControl.ActiveView.Extent = extent;
                    (this.m_pMapControl.ActiveView.GraphicsContainer as IGraphicsContainerSelect).UnselectAllElements();
                    (this.m_pMapControl.ActiveView.GraphicsContainer as IGraphicsContainerSelect).SelectElement(element);
                    this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, this.m_pMapControl.ActiveView.Extent);
                    this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
                }
                this.m_drawElementTool.ParentNodeID = rOILayerClass.ID;
                this.txtROIID.Text = rOILayerClass.ID.ToString();
                this.txtROIName.Text = rOILayerClass.Name;
                this.colorEditROI.Color = ColorTranslator.FromOle(rOILayerClass.Color.RGB);
                this.m_drawElementTool.ROINode = treeListNode;
                this.txtROIName.EditValueChanged += new EventHandler(this.txtROIName_EditValueChanged);
                this.colorEditROI.EditValueChanged += new EventHandler(this.colorEditROI_EditValueChanged);
            }
        }

        private void treeListROILayer_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && System.Windows.Forms.Control.ModifierKeys == System.Windows.Forms.Keys.None && this.treeListROILayer.State == TreeListState.Regular)
            {
                TreeListHitInfo treeListHitInfo = this.treeListROILayer.CalcHitInfo(e.Location);
                if (treeListHitInfo.HitInfoType == HitInfoType.Cell)
                {
                    this.treeListROILayer.SetFocusedNode(treeListHitInfo.Node);
                    if (treeListHitInfo.Node != null)
                    {
                        this.popupMenu1.ShowPopup(System.Windows.Forms.Control.MousePosition);
                    }
                }
            }
        }

        private void barBtnItemDeleteNode_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
            TreeListNode focusedNode = this.treeListROILayer.FocusedNode;
            if (focusedNode.Level == 0)
            {
                ROILayerClass rOILayerClass = focusedNode.Tag as ROILayerClass;
                foreach (ROIElementClass rOIElementClass in rOILayerClass.ElementList)
                {
                    if (rOIElementClass.Checked)
                    {
                        rOIElementClass.Checked = false;
                        if (this.IsExistElement(rOIElementClass.Element))
                        {
                            this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(rOIElementClass.Element);
                        }
                    }
                }
                FrmROI.RoiLayerDic.Remove(rOILayerClass.ID);
                this.treeListROILayer.DeleteNode(focusedNode);
            }
            else
            {
                ROIElementClass rOIElementClass = focusedNode.Tag as ROIElementClass;
                if (rOIElementClass.Checked)
                {
                    rOIElementClass.Checked = false;
                    if (this.IsExistElement(rOIElementClass.Element))
                    {
                        this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(rOIElementClass.Element);
                    }
                }
                if (focusedNode.ParentNode.Nodes.Count == 1)
                {
                    if (this.treeListROILayer.Nodes.Count > 1)
                    {
                        this.treeListROILayer.MoveFirst();
                    }
                    FrmROI.RoiLayerDic.Remove((focusedNode.ParentNode.Tag as ROILayerClass).ID);
                    this.treeListROILayer.DeleteNode(focusedNode.ParentNode);
                }
                else
                {
                    TreeListNode parentNode = focusedNode.ParentNode;
                    this.treeListROILayer.DeleteNode(focusedNode);
                    this.UpdateNodeCheckState(parentNode);
                }
            }
            if (this.treeListROILayer.Nodes.Count == 0)
            {
                this.SetControlsEnabled(false);
            }
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
        }

        private void treeListROILayer_AfterCheckNode(object sender, NodeEventArgs e)
        {
            this.treeListROILayer.SetFocusedNode(e.Node);
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
            if (e.Node.CheckState == System.Windows.Forms.CheckState.Unchecked)
            {
                if (e.Node.Level == 0)
                {
                    this.DeleteElements((e.Node.Tag as ROILayerClass).ElementList);
                }
                else
                {
                    int num = Convert.ToInt32(e.Node.GetValue(0).ToString());
                    this.DeleteElements(new List<ROIElementClass>
					{
						e.Node.Tag as ROIElementClass
					});
                }
            }
            else if (e.Node.Level == 0)
            {
                foreach (TreeListNode treeListNode in e.Node.Nodes)
                {
                    ROIElementClass rOIElementClass = treeListNode.Tag as ROIElementClass;
                    if (!rOIElementClass.Checked)
                    {
                        this.AddElements(rOIElementClass);
                    }
                }
            }
            else
            {
                ROIElementClass rOIElementClass = e.Node.Tag as ROIElementClass;
                this.AddElements(rOIElementClass);
            }
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
        }

        private void chkBtnCircle_Click(object sender, EventArgs e)
        {
            if (!this.chkBtnCircle.Checked)
            {
                this.chkBtnCircle.Checked = true;
                if (this.treeListROILayer.FocusedNode != null)
                {
                    this.m_drawElementTool.DrawType = EnumDrawType.circle;
                    this.m_drawElementTool.OnCreate(EnviVars.instance.MapControl.Object);
                    EnviVars.instance.MapControl.CurrentTool = this.m_drawElementTool;
                }
            }
            else
            {
                this.chkBtnCircle.Checked = false;
            }
        }

        private void chkBtnEllipse_Click(object sender, EventArgs e)
        {
            if (!this.chkBtnEllipse.Checked)
            {
                this.chkBtnEllipse.Checked = true;
                if (this.treeListROILayer.FocusedNode != null)
                {
                    this.m_drawElementTool.DrawType = EnumDrawType.ellipse;
                    this.m_drawElementTool.OnCreate(EnviVars.instance.MapControl.Object);
                    EnviVars.instance.MapControl.CurrentTool = this.m_drawElementTool;
                }
            }
            else
            {
                this.chkBtnEllipse.Checked = false;
            }
        }

        private void chkBtnSquare_Click(object sender, EventArgs e)
        {
            if (!this.chkBtnSquare.Checked)
            {
                this.chkBtnSquare.Checked = true;
                if (this.treeListROILayer.FocusedNode != null)
                {
                    this.m_drawElementTool.DrawType = EnumDrawType.square;
                    this.m_drawElementTool.OnCreate(EnviVars.instance.MapControl.Object);
                    EnviVars.instance.MapControl.CurrentTool = this.m_drawElementTool;
                }
            }
            else
            {
                this.chkBtnSquare.Checked = false;
            }
        }

        private void chkBtnRectangle_Click(object sender, EventArgs e)
        {
            if (!this.chkBtnRectangle.Checked)
            {
                this.chkBtnRectangle.Checked = true;
                if (this.treeListROILayer.FocusedNode != null)
                {
                    this.m_drawElementTool.DrawType = EnumDrawType.rectangle;
                    this.m_drawElementTool.OnCreate(EnviVars.instance.MapControl.Object);
                    EnviVars.instance.MapControl.CurrentTool = this.m_drawElementTool;
                }
            }
            else
            {
                this.chkBtnRectangle.Checked = false;
            }
        }

        private void chkBtnPolygon_Click(object sender, EventArgs e)
        {
            if (!this.chkBtnPolygon.Checked && this.ExistFocusedNode())
            {
                this.chkBtnPolygon.Checked = true;
                if (this.treeListROILayer.FocusedNode != null)
                {
                    this.m_drawElementTool.DrawType = EnumDrawType.polygon;
                    this.m_drawElementTool.OnCreate(EnviVars.instance.MapControl.Object);
                    EnviVars.instance.MapControl.CurrentTool = this.m_drawElementTool;
                }
            }
            else
            {
                this.chkBtnPolygon.Checked = false;
            }
        }

        private void colorEditROI_EditValueChanged(object sender, EventArgs e)
        {
            ColorEdit colorEdit = sender as ColorEdit;
            IColor color = this.ColorToIColor(colorEdit.Color);
            this.m_Color = color;
            if (this.ExistFocusedNode())
            {
                int key = Convert.ToInt32(this.txtROIID.Text);
                FrmROI.RoiLayerDic[key].Color = color;
                this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
                foreach (ROIElementClass current in FrmROI.RoiLayerDic[key].ElementList)
                {
                    (current.Element as IFillShapeElement).Symbol = this.GetFillSymbol();
                }
                this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
            }
        }

        private void txtROIName_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ExistFocusedNode())
            {
                TreeListNode treeListNode = (this.treeListROILayer.FocusedNode.Level == 0) ? this.treeListROILayer.FocusedNode : this.treeListROILayer.FocusedNode.ParentNode;
                treeListNode.SetValue(0, this.txtROIName.EditValue);
                (treeListNode.Tag as ROILayerClass).Name = this.txtROIName.EditValue.ToString();
            }
        }

        private IColor ColorToIColor(Color color)
        {
            return new RgbColorClass
            {
                RGB = (int)color.B * 65536 + (int)color.G * 256 + (int)color.R
            };
        }

        private IFillSymbol GetFillSymbol()
        {
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            IColor color = new RgbColorClass();
            simpleLineSymbol.Color = this.m_Color;
            simpleLineSymbol.Width = 1.0;
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            return new SimpleFillSymbolClass
            {
                Outline = simpleLineSymbol,
                Color = this.m_Color
            };
        }

        public void InitROI(Dictionary<int, ROILayerClass> roiLayerDic)
        {
            if (roiLayerDic != null)
            {
                this.treeListROILayer.AfterCheckNode -= new NodeEventHandler(this.treeListROILayer_AfterCheckNode);
                this.treeListROILayer.FocusedNodeChanged -= new FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
                this.colorEditROI.EditValueChanged -= new EventHandler(this.colorEditROI_EditValueChanged);
                foreach (KeyValuePair<int, ROILayerClass> current in roiLayerDic)
                {
                    TreeListNode treeListNode = this.treeListROILayer.AppendNode(new object[]
					{
						current.Value.Name
					}, null);
                    treeListNode.Tag = current.Value;
                    List<ROIElementClass> list = new List<ROIElementClass>();
                    for (int i = 0; i < current.Value.ElementList.Count; i++)
                    {
                        ROIElementClass rOIElementClass = current.Value.ElementList[i];
                        if (this.IsExistElement(rOIElementClass.Element))
                        {
                            rOIElementClass.Checked = true;
                        }
                        else
                        {
                            rOIElementClass.Checked = false;
                            list.Add(rOIElementClass);
                        }
                        System.Windows.Forms.CheckState checkState = rOIElementClass.Checked ? System.Windows.Forms.CheckState.Checked : System.Windows.Forms.CheckState.Unchecked;
                        TreeListNode treeListNode2 = this.treeListROILayer.AppendNode(new object[]
						{
							i
						}, treeListNode, checkState);
                        treeListNode2.Tag = rOIElementClass;
                    }
                    if (list.Count == treeListNode.Nodes.Count)
                    {
                        treeListNode.CheckState = System.Windows.Forms.CheckState.Unchecked;
                    }
                    else if (list.Count > 0)
                    {
                        treeListNode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
                    }
                    else
                    {
                        treeListNode.CheckState = System.Windows.Forms.CheckState.Checked;
                    }
                }
                if (roiLayerDic.Count > 0)
                {
                    this.SetControlsEnabled(true);
                }
                this.SetROINodeInfo();
                this.treeListROILayer.ExpandAll();
                this.treeListROILayer.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
                this.treeListROILayer.AfterCheckNode += new NodeEventHandler(this.treeListROILayer_AfterCheckNode);
            }
        }

        private void LoadROI(string xmlPath)
        {
            this.treeListROILayer.AfterCheckNode -= new NodeEventHandler(this.treeListROILayer_AfterCheckNode);
            this.treeListROILayer.FocusedNodeChanged -= new FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
            this.colorEditROI.EditValueChanged -= new EventHandler(this.colorEditROI_EditValueChanged);
            if (!string.IsNullOrEmpty(xmlPath) && File.Exists(xmlPath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlPath);
                XmlNode xmlNode = xmlDocument.SelectSingleNode("RegionsOfInterest");
                if (xmlNode == null)
                {
                    return;
                }
                //加载ROI文件前清空当前图形
                this.ClearROIElements();

                for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                {
                    XmlNode xmlNode2 = xmlNode.ChildNodes[i];
                    string value = xmlNode2.Attributes[0].Value;
                    TreeListNode treeListNode = this.treeListROILayer.AppendNode(new object[]
					{
						value
					}, null, System.Windows.Forms.CheckState.Checked);
                    string value2 = xmlNode2.Attributes[1].Value;
                    string[] array = value2.Split(new char[]
					{
						','
					});
                    int red = CommonAPI.ConvertToInt(array[0]);
                    int green = CommonAPI.ConvertToInt(array[1]);
                    int blue = CommonAPI.ConvertToInt(array[2]);
                    IRgbColor color = new RgbColorClass
                    {
                        Red = red,
                        Green = green,
                        Blue = blue
                    };
                    ROILayerClass rOILayerClass = new ROILayerClass();
                    rOILayerClass.ID = ((FrmROI.RoiLayerDic.Keys.Count == 0) ? 1 : (FrmROI.RoiLayerDic.Keys.Max() + 1));
                    rOILayerClass.Name = value;
                    rOILayerClass.Color = color;
                    rOILayerClass.ElementList = new List<ROIElementClass>();
                    FrmROI.RoiLayerDic.Add(rOILayerClass.ID, rOILayerClass);
                    treeListNode.Tag = rOILayerClass;
                    this.m_Color = rOILayerClass.Color;
                    IFillSymbol fillSymbol = this.GetFillSymbol();
                    string innerText = xmlNode2.SelectSingleNode("GeometryDef/CoordSysStr").InnerText;
                    ISpatialReference spatialReference = this.GetSpatialRefFromPrjStr(innerText);
                    XmlNodeList xmlNodeList = xmlNode2.SelectNodes("GeometryDef/Polygon/Exterior/LinearRing/Coordinates");
                    for (int j = 0; j < xmlNodeList.Count; j++)
                    {
                        TreeListNode treeListNode2 = this.treeListROILayer.AppendNode(new object[]
						{
							j
						}, treeListNode, System.Windows.Forms.CheckState.Checked);
                        IPointCollection pointCollection = new PolygonClass();
                        string innerText2 = xmlNodeList[j].InnerText;
                        string[] array2 = innerText2.Split(new char[]
						{
							' '
						});
                        int num = array2.Length / 2;
                        for (int k = 0; k < num; k++)
                        {
                            IPoint point = new PointClass();
                            double x = CommonAPI.ConvertToDouble(array2[2 * k]);
                            double y = CommonAPI.ConvertToDouble(array2[2 * k + 1]);
                            point.PutCoords(x, y);
                            object value3 = Missing.Value;
                            object value4 = Missing.Value;
                            pointCollection.AddPoint(point, ref value3, ref value4);
                        }
                        IPolygon polygon = pointCollection as IPolygon;
                        polygon.FromPoint = pointCollection.get_Point(0);
                        polygon.ToPoint = pointCollection.get_Point(pointCollection.PointCount - 1);
                        if (spatialReference == null)
                        {
                            spatialReference = new UnknownCoordinateSystemClass();
                        }
                        polygon.SpatialReference = spatialReference;
                        if (this.m_pMapControl.SpatialReference.Name != spatialReference.Name)
                        {
                            polygon.Project(this.m_pMapControl.SpatialReference);
                        }
                        polygon.Close();
                        IElement element = new PolygonElementClass();
                        element.Geometry = polygon;
                        (element as IFillShapeElement).Symbol = fillSymbol;
                        this.m_pMapControl.ActiveView.GraphicsContainer.AddElement(element, 0);
                        ROIElementClass rOIElementClass = new ROIElementClass
                        {
                            Element = element,
                            Checked = true
                        };
                        rOILayerClass.ElementList.Add(rOIElementClass);
                        treeListNode2.Tag = rOIElementClass;
                    }
                }
                this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            this.treeListROILayer.ExpandAll();
            this.SetControlsEnabled(true);
            this.SetROINodeInfo();
            this.treeListROILayer.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeListROILayer_FocusedNodeChanged);
            this.treeListROILayer.AfterCheckNode += new NodeEventHandler(this.treeListROILayer_AfterCheckNode);
        }

        private void SetROINodeInfo()
        {
            if (this.treeListROILayer.FocusedNode != null)
            {
                TreeListNode treeListNode = (this.treeListROILayer.FocusedNode.Level == 0) ? this.treeListROILayer.FocusedNode : this.treeListROILayer.FocusedNode.ParentNode;
                ROILayerClass rOILayerClass = treeListNode.Tag as ROILayerClass;
                this.m_drawElementTool.ParentNodeID = rOILayerClass.ID;
                this.m_drawElementTool.ROINode = this.treeListROILayer.FocusedNode;
                this.txtROIID.Text = rOILayerClass.ID.ToString();
                this.txtROIName.Text = rOILayerClass.Name;
                this.colorEditROI.Color = ColorTranslator.FromOle(rOILayerClass.Color.RGB);
                this.colorEditROI.EditValueChanged += new EventHandler(this.colorEditROI_EditValueChanged);
            }
        }

        private void SaveROIToXml(string savePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode xmlNode = xmlDocument.CreateElement("RegionsOfInterest");
            xmlNode.Attributes.Append(this.CreateXmlAttribute(xmlDocument, "version", "1.0"));
            foreach (TreeListNode treeListNode in this.treeListROILayer.Nodes)
            {
                if (treeListNode.CheckState != System.Windows.Forms.CheckState.Unchecked)
                {
                    XmlNode xmlNode2 = xmlDocument.CreateElement("Region");
                    string displayText = treeListNode.GetDisplayText(0);
                    ROILayerClass rOILayerClass = treeListNode.Tag as ROILayerClass;
                    xmlNode2.Attributes.Append(this.CreateXmlAttribute(xmlDocument, "name", treeListNode.GetDisplayText(0)));
                    Color color = ColorTranslator.FromOle(rOILayerClass.Color.RGB);
                    xmlNode2.Attributes.Append(this.CreateXmlAttribute(xmlDocument, "color", string.Format("{0},{1},{2}", color.R, color.G, color.B)));
                    xmlNode2.Attributes.Append(this.CreateXmlAttribute(xmlDocument, "ID", rOILayerClass.ID.ToString()));
                    XmlNode xmlNode3 = xmlDocument.CreateElement("GeometryDef");
                    XmlNode xmlNode4 = xmlDocument.CreateElement("CoordSysStr");
                    xmlNode4.InnerText = this.GetSpatialReferenceStr();
                    xmlNode3.AppendChild(xmlNode4);
                    foreach (TreeListNode treeListNode2 in treeListNode.Nodes)
                    {
                        if (treeListNode2.CheckState == System.Windows.Forms.CheckState.Checked)
                        {
                            int index = Convert.ToInt32(treeListNode2.GetDisplayText(0));
                            IElement element = rOILayerClass.ElementList[index].Element;
                            XmlNode xmlNode5 = this.CreatePolygonNode(xmlDocument, element);
                            xmlNode5.Attributes.Append(this.CreateXmlAttribute(xmlDocument, "ID", treeListNode2.GetDisplayText(0)));
                            xmlNode3.AppendChild(xmlNode5);
                        }
                    }
                    xmlNode2.AppendChild(xmlNode3);
                    xmlNode.AppendChild(xmlNode2);
                }
            }
            xmlDocument.AppendChild(xmlNode);
            xmlDocument.InsertBefore(newChild, xmlDocument.DocumentElement);
            xmlDocument.Save(savePath);
        }

        private string GetSpatialReferenceStr()
        {
            string result = string.Empty;
            if (this.m_pMapControl.SpatialReference.Name == "Unknown")
            {
                result = "none";
            }
            else
            {
                IESRISpatialReferenceGEN iESRISpatialReferenceGEN = new GeographicCoordinateSystemClass();
                iESRISpatialReferenceGEN = (this.m_pMapControl.SpatialReference as IESRISpatialReferenceGEN);
                string empty = string.Empty;
                int num;
                iESRISpatialReferenceGEN.ExportToESRISpatialReference(out empty, out num);
                result = empty;
            }
            return result;
        }

        private XmlAttribute CreateXmlAttribute(XmlDocument xmlDoc, string attributeName, string value)
        {
            XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(attributeName);
            xmlAttribute.Value = value;
            return xmlAttribute;
        }

        private XmlNode CreatePolygonNode(XmlDocument xmlDoc, IElement pElement)
        {
            StringBuilder stringBuilder = new StringBuilder();
            IPointCollection pointCollection = pElement.Geometry as IPointCollection;
            ICurve curve = pElement.Geometry as ICurve;
            IPoint point = new PointClass();
            if (pElement is ICircleElement || pElement is IEllipseElement)
            {
                for (double num = 0.01; num < 1.0; num += 0.01)
                {
                    curve.QueryPoint(esriSegmentExtension.esriExtendAtFrom, num, true, point);
                    stringBuilder.Append(string.Format("{0} {1} ", point.X, point.Y));
                }
            }
            else
            {
                for (int i = 0; i < pointCollection.PointCount; i++)
                {
                    point = pointCollection.get_Point(i);
                    stringBuilder.Append(string.Format("{0} {1} ", point.X, point.Y));
                }
            }
            XmlNode xmlNode = xmlDoc.CreateElement("Polygon");
            XmlNode xmlNode2 = xmlDoc.CreateElement("Exterior");
            XmlNode xmlNode3 = xmlDoc.CreateElement("LinearRing");
            XmlNode xmlNode4 = xmlDoc.CreateElement("Coordinates");
            xmlNode4.InnerText = stringBuilder.ToString();
            xmlNode3.AppendChild(xmlNode4);
            xmlNode2.AppendChild(xmlNode3);
            xmlNode.AppendChild(xmlNode2);
            return xmlNode;
        }

        private ISpatialReference GetSpatialRefFromPrjStr(string strPrj)
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

        private void SetControlsEnabled(bool bEnabled)
        {
            if (this.btnSaveROI.Enabled != bEnabled)
            {
                this.btnSaveROI.Enabled = bEnabled;
                this.btnDeleteROI.Enabled = bEnabled;
                this.btnClearROI.Enabled = bEnabled;
                this.chkBtnCircle.Enabled = bEnabled;
                this.chkBtnEllipse.Enabled = bEnabled;
                this.chkBtnSquare.Enabled = bEnabled;
                this.chkBtnRectangle.Enabled = bEnabled;
                this.chkBtnPolygon.Enabled = bEnabled;
                this.txtROIName.Enabled = bEnabled;
                this.colorEditROI.Enabled = bEnabled;
            }
            if (!bEnabled)
            {
                EnviVars.instance.MapControl.CurrentTool = EnviVars.instance.SelectElementTool;
            }
        }

        private void DeleteElements(List<ROIElementClass> elementList)
        {
            foreach (ROIElementClass current in elementList)
            {
                if (current.Checked)
                {
                    current.Checked = false;
                    if (this.IsExistElement(current.Element))
                    {
                        this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(current.Element);
                    }
                }
            }
        }

        private void AddElements(ROIElementClass roiElement)
        {
            if (!roiElement.Checked)
            {
                roiElement.Checked = true;
                this.m_pMapControl.ActiveView.GraphicsContainer.AddElement(roiElement.Element, 0);
            }
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
        }

        public void UnDisplayROIElements()
        {
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
            foreach (KeyValuePair<int, ROILayerClass> current in FrmROI.RoiLayerDic)
            {
                foreach (ROIElementClass current2 in current.Value.ElementList)
                {
                    if (current2.Checked)
                    {
                        current2.Checked = false;
                        if (this.IsExistElement(current2.Element))
                        {
                            this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(current2.Element);
                        }
                    }
                }
            }
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
            base.Dispose();
        }

        private void ClearROIElements()
        {
            try
            {
                this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
                foreach (KeyValuePair<int, ROILayerClass> current in FrmROI.RoiLayerDic)
                {
                    foreach (ROIElementClass current2 in current.Value.ElementList)
                    {
                        if (current2.Checked)
                        {
                            current2.Checked = false;
                            if (this.IsExistElement(current2.Element))
                            {
                                this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(current2.Element);
                            }
                        }
                    }
                }
                this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
                FrmROI.RoiLayerDic.Clear();
                this.treeListROILayer.Nodes.Clear();
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG08);
                //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, message, null);
            }
            catch (Exception ex)
            {
                string message = string.Format("{0}_{1}", this.Text, FrmROI.MSG08);
                Log.WriteLog(typeof(FrmROI), message);
                Log.WriteLog(typeof(FrmROI), ex);
            }
        }

        private bool IsExistElement(IElement element)
        {
            bool result = false;
            IGraphicsContainer graphicsContainer = this.m_pMapControl.ActiveView.GraphicsContainer;
            graphicsContainer.Reset();
            IElement element2;
            while ((element2 = this.m_pMapControl.ActiveView.GraphicsContainer.Next()) != null)
            {
                if (element2 == element)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void UpdateNodeCheckState(TreeListNode parentNode)
        {
            int num = 0;
            foreach (TreeListNode treeListNode in parentNode.Nodes)
            {
                if (treeListNode.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    num++;
                }
            }
            if (num == parentNode.Nodes.Count)
            {
                this.treeListROILayer.SetNodeCheckState(parentNode, System.Windows.Forms.CheckState.Checked, true);
            }
            else if (num == 0)
            {
                this.treeListROILayer.SetNodeCheckState(parentNode, System.Windows.Forms.CheckState.Unchecked, true);
            }
            else
            {
                this.treeListROILayer.SetNodeCheckState(parentNode, System.Windows.Forms.CheckState.Indeterminate);
            }
        }

        private bool ExistFocusedNode()
        {
            bool result = false;
            int key = Convert.ToInt32(this.txtROIID.Text);
            if (!FrmROI.RoiLayerDic.ContainsKey(key))
            {
                XtraMessageBox.Show(FrmROI.MSG05, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
            else
            {
                result = true;
            }
            return result;
        }

        private void DeleteCheckedROINode(TreeListNode roiLayerNode)
        {
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
            ROILayerClass rOILayerClass = roiLayerNode.Tag as ROILayerClass;
            List<TreeListNode> list = new List<TreeListNode>();
            foreach (TreeListNode treeListNode in roiLayerNode.Nodes)
            {
                if ((treeListNode.Tag as ROIElementClass).Checked)
                {
                    list.Add(treeListNode);
                }
            }
            if (list.Count == roiLayerNode.Nodes.Count)
            {
                foreach (ROIElementClass rOIElementClass in rOILayerClass.ElementList)
                {
                    if (rOIElementClass.Checked)
                    {
                        rOIElementClass.Checked = false;
                        if (this.IsExistElement(rOIElementClass.Element))
                        {
                            this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(rOIElementClass.Element);
                        }
                    }
                }
                FrmROI.RoiLayerDic.Remove(rOILayerClass.ID);
                this.treeListROILayer.DeleteNode(roiLayerNode);
            }
            else
            {
                foreach (TreeListNode treeListNode in list)
                {
                    ROIElementClass rOIElementClass = treeListNode.Tag as ROIElementClass;
                    rOIElementClass.Checked = false;
                    if (this.IsExistElement(rOIElementClass.Element))
                    {
                        this.m_pMapControl.ActiveView.GraphicsContainer.DeleteElement(rOIElementClass.Element);
                    }
                    this.treeListROILayer.DeleteNode(treeListNode);
                    FrmROI.RoiLayerDic[rOILayerClass.ID].ElementList.Remove(rOIElementClass);
                }
                roiLayerNode.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            this.m_pMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_pMapControl.ActiveView.Extent);
        }

        private void FrmROI_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            //HelpManager.ShowHelp(this);
        }
    }
}
