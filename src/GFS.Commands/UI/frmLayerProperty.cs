using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using ESRI.ArcGIS.Carto;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Data;

namespace GFS.Commands.UI
{
    public class frmLayerProperty : XtraForm
    {
        private IContainer components = null;

        private XtraTabControl xtraTabControl1;

        private XtraTabPage xtraTabPageBasic;

        private XtraTabPage xtraTabPageFields;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.GroupBox groupBox1;

        private LabelControl labelControl3;

        private LabelControl labelControl2;

        private LabelControl labelControl1;

        private LabelControl labelControl4;

        private LabelControl lblBottom;

        private LabelControl lblRight;

        private LabelControl lblLeft;

        private LabelControl lblTop;

        private GridControl gridControl1;

        private GridView gridView1;

        private RepositoryItemCheckEdit repositoryItemCheckEdit1;

        private XtraScrollableControl xtraScrollableControl1;

        private ctrlGeographicCoordinateInfo ctrlGeographicCoordinateInfo1;

        private ctrlProjectionCoordinateInfo ctrlProjectionCoordinateInfo1;

        private PanelControl panelUnkownSystem;

        private LabelControl lblUnknown;

        private LabelControl labelControl5;

        private XtraTabPage xtraTabPageRaster;

        private LabelControl lblSensorType;

        private LabelControl labelControl19;

        private LabelControl lblFormat;

        private LabelControl labelControl15;

        private LabelControl lblPixelType;

        private LabelControl labelControl13;

        private LabelControl lblCellSize;

        private LabelControl labelControl8;

        private LabelControl lblBandCount;

        private LabelControl labelControl9;

        private LabelControl lblColAndRow;

        private LabelControl labelControl7;

        private LabelControl lblCompresionType;

        private LabelControl labelControl10;

        private LabelControl lblPhotoDate;

        private LabelControl labelControl12;

        private LabelControl lblSize;

        private LabelControl labelControl14;

        private MemoEdit memoDataSource;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

        private System.Windows.Forms.GroupBox groupBox3;

        private ILayer m_lyr = null;

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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageBasic = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.memoDataSource = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelUnkownSystem = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblUnknown = new DevExpress.XtraEditors.LabelControl();
            this.ctrlGeographicCoordinateInfo1 = new GFS.Commands.UI.ctrlGeographicCoordinateInfo();
            this.ctrlProjectionCoordinateInfo1 = new GFS.Commands.UI.ctrlProjectionCoordinateInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRight = new DevExpress.XtraEditors.LabelControl();
            this.lblBottom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblTop = new DevExpress.XtraEditors.LabelControl();
            this.lblLeft = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageFields = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraTabPageRaster = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblPhotoDate = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.lblSensorType = new DevExpress.XtraEditors.LabelControl();
            this.lblCompresionType = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblFormat = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblPixelType = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.lblCellSize = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.lblBandCount = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lblColAndRow = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageBasic.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDataSource.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelUnkownSystem)).BeginInit();
            this.panelUnkownSystem.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.xtraTabPageFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.xtraTabPageRaster.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageBasic;
            this.xtraTabControl1.Size = new System.Drawing.Size(477, 485);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageBasic,
            this.xtraTabPageFields,
            this.xtraTabPageRaster});
            // 
            // xtraTabPageBasic
            // 
            this.xtraTabPageBasic.Controls.Add(this.groupBox3);
            this.xtraTabPageBasic.Controls.Add(this.groupBox2);
            this.xtraTabPageBasic.Controls.Add(this.groupBox1);
            this.xtraTabPageBasic.Name = "xtraTabPageBasic";
            this.xtraTabPageBasic.Size = new System.Drawing.Size(471, 456);
            this.xtraTabPageBasic.Text = "基本属性";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.memoDataSource);
            this.groupBox3.Location = new System.Drawing.Point(11, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 70);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据源";
            // 
            // memoDataSource
            // 
            this.memoDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoDataSource.Location = new System.Drawing.Point(3, 18);
            this.memoDataSource.Name = "memoDataSource";
            this.memoDataSource.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.memoDataSource.Properties.Appearance.Options.UseBackColor = true;
            this.memoDataSource.Properties.ReadOnly = true;
            this.memoDataSource.Size = new System.Drawing.Size(529, 49);
            this.memoDataSource.TabIndex = 3;
            this.memoDataSource.UseOptimizedRendering = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.xtraScrollableControl1);
            this.groupBox2.Location = new System.Drawing.Point(11, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐标系";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.panelUnkownSystem);
            this.xtraScrollableControl1.Controls.Add(this.ctrlGeographicCoordinateInfo1);
            this.xtraScrollableControl1.Controls.Add(this.ctrlProjectionCoordinateInfo1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(3, 18);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(447, 222);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // panelUnkownSystem
            // 
            this.panelUnkownSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnkownSystem.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelUnkownSystem.Appearance.Options.UseBackColor = true;
            this.panelUnkownSystem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelUnkownSystem.Controls.Add(this.tableLayoutPanel1);
            this.panelUnkownSystem.Location = new System.Drawing.Point(3, 0);
            this.panelUnkownSystem.Name = "panelUnkownSystem";
            this.panelUnkownSystem.Size = new System.Drawing.Size(339, 1014);
            this.panelUnkownSystem.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUnknown, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 33);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl5.Location = new System.Drawing.Point(3, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "坐标系名称：";
            // 
            // lblUnknown
            // 
            this.lblUnknown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnknown.Location = new System.Drawing.Point(81, 9);
            this.lblUnknown.Name = "lblUnknown";
            this.lblUnknown.Size = new System.Drawing.Size(0, 14);
            this.lblUnknown.TabIndex = 1;
            // 
            // ctrlGeographicCoordinateInfo1
            // 
            this.ctrlGeographicCoordinateInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGeographicCoordinateInfo1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ctrlGeographicCoordinateInfo1.Appearance.Options.UseBackColor = true;
            this.ctrlGeographicCoordinateInfo1.Location = new System.Drawing.Point(3, 0);
            this.ctrlGeographicCoordinateInfo1.Name = "ctrlGeographicCoordinateInfo1";
            this.ctrlGeographicCoordinateInfo1.Size = new System.Drawing.Size(339, 219);
            this.ctrlGeographicCoordinateInfo1.TabIndex = 1;
            // 
            // ctrlProjectionCoordinateInfo1
            // 
            this.ctrlProjectionCoordinateInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlProjectionCoordinateInfo1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ctrlProjectionCoordinateInfo1.Appearance.Options.UseBackColor = true;
            this.ctrlProjectionCoordinateInfo1.Location = new System.Drawing.Point(3, 0);
            this.ctrlProjectionCoordinateInfo1.Name = "ctrlProjectionCoordinateInfo1";
            this.ctrlProjectionCoordinateInfo1.Size = new System.Drawing.Size(339, 381);
            this.ctrlProjectionCoordinateInfo1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(11, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图层范围";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lblRight, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblBottom, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTop, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLeft, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(419, 97);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // lblRight
            // 
            this.lblRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRight.Location = new System.Drawing.Point(294, 41);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(0, 14);
            this.lblRight.TabIndex = 6;
            // 
            // lblBottom
            // 
            this.lblBottom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.lblBottom, 2);
            this.lblBottom.Location = new System.Drawing.Point(190, 73);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(0, 14);
            this.lblBottom.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl4.Location = new System.Drawing.Point(264, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "右：";
            // 
            // lblTop
            // 
            this.lblTop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.lblTop, 2);
            this.lblTop.Location = new System.Drawing.Point(190, 9);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(0, 14);
            this.lblTop.TabIndex = 4;
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLeft.Location = new System.Drawing.Point(86, 41);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(0, 14);
            this.lblLeft.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl3.Location = new System.Drawing.Point(56, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "左：";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.SetColumnSpan(this.labelControl1, 2);
            this.labelControl1.Location = new System.Drawing.Point(160, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "上：";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.SetColumnSpan(this.labelControl2, 2);
            this.labelControl2.Location = new System.Drawing.Point(160, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "下：";
            // 
            // xtraTabPageFields
            // 
            this.xtraTabPageFields.Controls.Add(this.gridControl1);
            this.xtraTabPageFields.Name = "xtraTabPageFields";
            this.xtraTabPageFields.Size = new System.Drawing.Size(471, 456);
            this.xtraTabPageFields.Text = "字段信息";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControl1.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridControl1.EmbeddedNavigator.TextStringFormat = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(471, 456);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // xtraTabPageRaster
            // 
            this.xtraTabPageRaster.Controls.Add(this.tableLayoutPanel3);
            this.xtraTabPageRaster.Name = "xtraTabPageRaster";
            this.xtraTabPageRaster.Size = new System.Drawing.Size(471, 456);
            this.xtraTabPageRaster.Text = "栅格信息";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.labelControl7, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblPhotoDate, 2, 8);
            this.tableLayoutPanel3.Controls.Add(this.lblSize, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.lblSensorType, 2, 7);
            this.tableLayoutPanel3.Controls.Add(this.lblCompresionType, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelControl9, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl14, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.labelControl12, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.labelControl8, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblFormat, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelControl13, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblPixelType, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl10, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.lblCellSize, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelControl19, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.lblBandCount, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl15, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblColAndRow, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(553, 424);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl7.Location = new System.Drawing.Point(53, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "列和行：";
            // 
            // lblPhotoDate
            // 
            this.lblPhotoDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhotoDate.Location = new System.Drawing.Point(131, 393);
            this.lblPhotoDate.Name = "lblPhotoDate";
            this.lblPhotoDate.Size = new System.Drawing.Size(0, 14);
            this.lblPhotoDate.TabIndex = 17;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSize.Location = new System.Drawing.Point(131, 251);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 14);
            this.lblSize.TabIndex = 21;
            // 
            // lblSensorType
            // 
            this.lblSensorType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSensorType.Location = new System.Drawing.Point(131, 345);
            this.lblSensorType.Name = "lblSensorType";
            this.lblSensorType.Size = new System.Drawing.Size(0, 14);
            this.lblSensorType.TabIndex = 13;
            // 
            // lblCompresionType
            // 
            this.lblCompresionType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCompresionType.Location = new System.Drawing.Point(131, 298);
            this.lblCompresionType.Name = "lblCompresionType";
            this.lblCompresionType.Size = new System.Drawing.Size(0, 14);
            this.lblCompresionType.TabIndex = 15;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Location = new System.Drawing.Point(53, 63);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(48, 14);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "波段数：";
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl14.Location = new System.Drawing.Point(53, 251);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(60, 14);
            this.labelControl14.TabIndex = 20;
            this.labelControl14.Text = "图像大小：";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl12.Location = new System.Drawing.Point(53, 393);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(60, 14);
            this.labelControl12.TabIndex = 16;
            this.labelControl12.Text = "拍摄时间：";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Location = new System.Drawing.Point(53, 110);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "像元大小：";
            // 
            // lblFormat
            // 
            this.lblFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFormat.Location = new System.Drawing.Point(131, 204);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(0, 14);
            this.lblFormat.TabIndex = 9;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Location = new System.Drawing.Point(53, 157);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(60, 14);
            this.labelControl13.TabIndex = 6;
            this.labelControl13.Text = "像素类型：";
            // 
            // lblPixelType
            // 
            this.lblPixelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPixelType.Location = new System.Drawing.Point(131, 157);
            this.lblPixelType.Name = "lblPixelType";
            this.lblPixelType.Size = new System.Drawing.Size(0, 14);
            this.lblPixelType.TabIndex = 7;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Location = new System.Drawing.Point(53, 298);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 14);
            this.labelControl10.TabIndex = 14;
            this.labelControl10.Text = "压缩方式：";
            // 
            // lblCellSize
            // 
            this.lblCellSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCellSize.Location = new System.Drawing.Point(131, 110);
            this.lblCellSize.Name = "lblCellSize";
            this.lblCellSize.Size = new System.Drawing.Size(0, 14);
            this.lblCellSize.TabIndex = 5;
            // 
            // labelControl19
            // 
            this.labelControl19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl19.Location = new System.Drawing.Point(53, 345);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(72, 14);
            this.labelControl19.TabIndex = 12;
            this.labelControl19.Text = "传感器类型：";
            // 
            // lblBandCount
            // 
            this.lblBandCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBandCount.Location = new System.Drawing.Point(131, 63);
            this.lblBandCount.Name = "lblBandCount";
            this.lblBandCount.Size = new System.Drawing.Size(0, 14);
            this.lblBandCount.TabIndex = 3;
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl15.Location = new System.Drawing.Point(53, 204);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(60, 14);
            this.labelControl15.TabIndex = 8;
            this.labelControl15.Text = "数据格式：";
            // 
            // lblColAndRow
            // 
            this.lblColAndRow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColAndRow.Location = new System.Drawing.Point(131, 16);
            this.lblColAndRow.Name = "lblColAndRow";
            this.lblColAndRow.Size = new System.Drawing.Size(0, 14);
            this.lblColAndRow.TabIndex = 1;
            // 
            // frmLayerProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 485);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLayerProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层属性";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmLayerProperty_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmVectorLayerProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageBasic.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoDataSource.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelUnkownSystem)).EndInit();
            this.panelUnkownSystem.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.xtraTabPageFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.xtraTabPageRaster.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        public frmLayerProperty(ILayer layer)
        {
            this.InitializeComponent();
            this.m_lyr = layer;

            //ScrollHelper scrollHelper = new ScrollHelper(this.xtraScrollableControl1);
            //scrollHelper.EnableScrollOnMouseWheel();
        }

        private void frmVectorLayerProperty_Load(object sender, EventArgs e)
        {
            if (this.m_lyr != null)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                try
                {
                    ISpatialReference spatialReferenceInfo = null;
                    string text = "";
                    if (this.m_lyr is IFeatureLayer)
                    {
                        this.xtraTabPageFields.PageVisible = true;
                        this.xtraTabPageRaster.PageVisible = false;
                        IFeatureClass featureClass = (this.m_lyr as IFeatureLayer).FeatureClass;
                        if (featureClass != null)
                        {
                            this.SetExtent((featureClass as IGeoDataset).Extent);
                            text = (featureClass as IDataset).Workspace.PathName + "\\" + (featureClass as IDataset).Name;
                            spatialReferenceInfo = (featureClass as IGeoDataset).SpatialReference;
                            this.SetFieldsInfo(featureClass);
                        }
                    }
                    else if (this.m_lyr is IRasterLayer)
                    {
                        this.xtraTabPageFields.PageVisible = false;
                        this.xtraTabPageRaster.PageVisible = true;
                        IRasterLayer rasterLayer = this.m_lyr as IRasterLayer;
                        text = rasterLayer.FilePath;
                        this.lblColAndRow.Text = rasterLayer.ColumnCount + "，" + rasterLayer.RowCount;
                        int bandCount = rasterLayer.BandCount;
                        this.lblBandCount.Text = bandCount.ToString();
                        IRaster raster = rasterLayer.Raster;
                        IRasterProps rasterProps = raster as IRasterProps;
                        this.SetExtent(rasterProps.Extent);
                        IPnt pnt = rasterProps.MeanCellSize();
                        this.lblCellSize.Text = pnt.X.ToString("f1") + "，" + pnt.Y.ToString("f1");
                        string pixelType = this.GetPixelType(rasterProps);
                        this.lblPixelType.Text = pixelType;
                        double num = (double)(rasterProps.Width * rasterProps.Height * bandCount) / 1024.0;
                        string str = "KB";
                        if (num >= 1048576.0)
                        {
                            num /= 1048576.0;
                            str = "G";
                        }
                        else if (num >= 1024.0)
                        {
                            num /= 1024.0;
                            str = "MB";
                        }
                        this.lblSize.Text = num.ToString("f2") + str;
                        spatialReferenceInfo = rasterProps.SpatialReference;
                        IRasterDataset rasterDataset = (raster as IRaster2).RasterDataset;
                        this.lblFormat.Text = rasterDataset.Format;
                        this.lblSensorType.Text = rasterDataset.SensorType;
                        this.lblCompresionType.Text = rasterDataset.CompressionType;
                    }
                    this.memoDataSource.Text = text;
                    this.SetSpatialReferenceInfo(spatialReferenceInfo);
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        private void SetExtent(IEnvelope extent)
        {
            this.lblTop.Text = extent.YMax.ToString("f5");
            this.lblBottom.Text = extent.YMin.ToString("f5");
            this.lblLeft.Text = extent.XMin.ToString("f5");
            this.lblRight.Text = extent.XMax.ToString("f5");
        }

        private string GetPixelType(IRasterProps rasterProps)
        {
            string result = "";
            switch (rasterProps.PixelType)
            {
                case rstPixelType.PT_UNKNOWN:
                    result = "Unknown";
                    break;
                case rstPixelType.PT_U1:
                    result = "1 bit";
                    break;
                case rstPixelType.PT_U2:
                    result = "2 bit";
                    break;
                case rstPixelType.PT_U4:
                    result = "4 bit";
                    break;
                case rstPixelType.PT_UCHAR:
                    result = "unsigned 8 bit integers";
                    break;
                case rstPixelType.PT_CHAR:
                    result = "8 bit integers";
                    break;
                case rstPixelType.PT_USHORT:
                    result = "unsigned 16 bit integers";
                    break;
                case rstPixelType.PT_SHORT:
                    result = "16 bit integers";
                    break;
                case rstPixelType.PT_ULONG:
                    result = "unsigned 32 bit integers";
                    break;
                case rstPixelType.PT_LONG:
                    result = "32 bit integers";
                    break;
                case rstPixelType.PT_FLOAT:
                    result = "single precision floating point";
                    break;
                case rstPixelType.PT_DOUBLE:
                    result = "double precision floating point";
                    break;
                case rstPixelType.PT_COMPLEX:
                    result = "single precsion complex";
                    break;
                case rstPixelType.PT_DCOMPLEX:
                    result = "double precision complex";
                    break;
                case rstPixelType.PT_CSHORT:
                    result = "short integer complex";
                    break;
                case rstPixelType.PT_CLONG:
                    result = "long integer complex";
                    break;
            }
            return result;
        }

        private void SetFieldsInfo(IFeatureClass featClass)
        {
            DataTable dataTable = new DataTable();
            DataColumn dataColumn = dataTable.Columns.Add("字段名称", Type.GetType("System.String"));
            DataColumn dataColumn2 = dataTable.Columns.Add("字段类型", Type.GetType("System.String"));
            DataColumn dataColumn3 = dataTable.Columns.Add("允许空值", Type.GetType("System.Boolean"));
            DataColumn dataColumn4 = dataTable.Columns.Add("字段长度", Type.GetType("System.Int32"));
            this.gridControl1.DataSource = dataTable;
            this.gridView1.Columns["允许空值"].ColumnEdit = this.repositoryItemCheckEdit1;
            for (int i = 0; i < featClass.Fields.FieldCount; i++)
            {
                IField field = featClass.Fields.get_Field(i);
                DataRow dataRow = dataTable.NewRow();
                dataRow["字段名称"] = field.Name;
                string value = "";
                switch (field.Type)
                {
                    case esriFieldType.esriFieldTypeSmallInteger:
                        value = "Short";
                        break;
                    case esriFieldType.esriFieldTypeInteger:
                        value = "Long";
                        break;
                    case esriFieldType.esriFieldTypeSingle:
                        value = "Float";
                        break;
                    case esriFieldType.esriFieldTypeDouble:
                        value = "Double";
                        break;
                    case esriFieldType.esriFieldTypeString:
                        value = "Text";
                        break;
                    case esriFieldType.esriFieldTypeDate:
                        value = "Date";
                        break;
                    case esriFieldType.esriFieldTypeOID:
                        value = "Object ID";
                        break;
                    case esriFieldType.esriFieldTypeGeometry:
                        value = "Geometry";
                        break;
                    case esriFieldType.esriFieldTypeBlob:
                        value = "Blob";
                        break;
                }
                dataRow["字段类型"] = value;
                dataRow["允许空值"] = field.IsNullable;
                dataRow["字段长度"] = field.Length;
                dataTable.Rows.Add(dataRow);
            }
            this.gridView1.BestFitColumns();
        }

        private void SetSpatialReferenceInfo(ISpatialReference spatialRef)
        {
            if (spatialRef is IProjectedCoordinateSystem)
            {
                this.ctrlProjectionCoordinateInfo1.Visible = true;
                this.ctrlGeographicCoordinateInfo1.Visible = false;
                this.panelUnkownSystem.Visible = false;
                this.ctrlProjectionCoordinateInfo1.Init(spatialRef);
            }
            else if (spatialRef is IGeographicCoordinateSystem)
            {
                this.ctrlProjectionCoordinateInfo1.Visible = false;
                this.ctrlGeographicCoordinateInfo1.Visible = true;
                this.panelUnkownSystem.Visible = false;
                this.ctrlGeographicCoordinateInfo1.Init(spatialRef);
            }
            else
            {
                this.lblUnknown.Text = "未知坐标系";
                this.ctrlProjectionCoordinateInfo1.Visible = false;
                this.ctrlGeographicCoordinateInfo1.Visible = false;
                this.panelUnkownSystem.Visible = true;
            }
        }

        private void frmLayerProperty_HelpButtonClicked(object sender, CancelEventArgs e)
        {
        }
    }
}

