using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GFS.BLL
{
    partial class frmLayerRender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            this.cmbUniqueValueField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlUniqueValue = new DevExpress.XtraGrid.GridControl();
            this.gridViewUniqueValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemPictureEditUniqueValue = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnUniqueRemoveAllValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnUniqueRemoveValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnUniqueAddValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnUniqueAddAllValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnLayerPropertiesOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnLayerPropertiesCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmbUniqueValueColorRamp = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.pageVectorSimple = new DevExpress.XtraTab.XtraTabPage();
            this.txtSimpleDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelSimplePreview = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnSimpleChange = new DevExpress.XtraEditors.SimpleButton();
            this.pageVectorUniqueValue = new DevExpress.XtraTab.XtraTabPage();
            this.pageRasterUniqueValue = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRasterUniqueValueColorRamp = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cmbRasterUniqueValueField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlRasterUniqueValue = new DevExpress.XtraGrid.GridControl();
            this.gridViewRasterUniqueValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemPictureEditRasterUniqueValue = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnRasterUniqueAddAllValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnRasterUniqueAddValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnRasterUniqueRemoveAllValues = new DevExpress.XtraEditors.SimpleButton();
            this.btnRasterUniqueRemoveValues = new DevExpress.XtraEditors.SimpleButton();
            this.pageRasterClassify = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRasterClassifyClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRasterClassifyColorRamp = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cmbRasterClassifyField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlRasterClassify = new DevExpress.XtraGrid.GridControl();
            this.gridViewRasterClassify = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemPictureEditRasterClassify = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.pageRasterStretch = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkRasterStretchBackground = new DevExpress.XtraEditors.CheckEdit();
            this.txtRasterStretchBackground = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.colorRasterStretchBackground = new DevExpress.XtraEditors.ColorEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRasterStretchIntervals = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRasterStretchColorRamp = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnRasterStretchGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.chkRasterStretchInvert = new DevExpress.XtraEditors.CheckEdit();
            this.gridControlRasterStretch = new DevExpress.XtraGrid.GridControl();
            this.gridViewRasterStretch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemPictureEditRasterStretch = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.treeListRenderer = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUniqueValueField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUniqueValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUniqueValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditUniqueValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUniqueValueColorRamp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.pageVectorSimple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSimpleDescription.Properties)).BeginInit();
            this.pageVectorUniqueValue.SuspendLayout();
            this.pageRasterUniqueValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterUniqueValueColorRamp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterUniqueValueField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRasterUniqueValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRasterUniqueValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditRasterUniqueValue)).BeginInit();
            this.pageRasterClassify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterClassifyClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterClassifyColorRamp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterClassifyField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRasterClassify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRasterClassify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditRasterClassify)).BeginInit();
            this.pageRasterStretch.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRasterStretchBackground.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRasterStretchBackground.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorRasterStretchBackground.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRasterStretchIntervals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterStretchColorRamp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRasterStretchInvert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRasterStretch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRasterStretch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditRasterStretch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListRenderer)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUniqueValueField
            // 
            this.cmbUniqueValueField.Location = new System.Drawing.Point(3, 23);
            this.cmbUniqueValueField.Name = "cmbUniqueValueField";
            this.cmbUniqueValueField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUniqueValueField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbUniqueValueField.Size = new System.Drawing.Size(156, 20);
            this.cmbUniqueValueField.TabIndex = 9;
            this.cmbUniqueValueField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(3, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "渲染字段:";
            // 
            // gridControlUniqueValue
            // 
            gridLevelNode1.RelationName = "Level1";
            this.gridControlUniqueValue.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlUniqueValue.Location = new System.Drawing.Point(3, 50);
            this.gridControlUniqueValue.MainView = this.gridViewUniqueValue;
            this.gridControlUniqueValue.Name = "gridControlUniqueValue";
            this.gridControlUniqueValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEditUniqueValue});
            this.gridControlUniqueValue.Size = new System.Drawing.Size(411, 156);
            this.gridControlUniqueValue.TabIndex = 11;
            this.gridControlUniqueValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUniqueValue});
            // 
            // gridViewUniqueValue
            // 
            this.gridViewUniqueValue.GridControl = this.gridControlUniqueValue;
            this.gridViewUniqueValue.Name = "gridViewUniqueValue";
            this.gridViewUniqueValue.OptionsView.ShowGroupPanel = false;
            this.gridViewUniqueValue.OptionsView.ShowIndicator = false;
            // 
            // repositoryItemPictureEditUniqueValue
            // 
            this.repositoryItemPictureEditUniqueValue.Name = "repositoryItemPictureEditUniqueValue";
            this.repositoryItemPictureEditUniqueValue.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.repositoryItemPictureEditUniqueValue.DoubleClick += new System.EventHandler(this.repositoryItemPictureEdit_DoubleClick);
            // 
            // btnUniqueRemoveAllValues
            // 
            this.btnUniqueRemoveAllValues.Location = new System.Drawing.Point(246, 212);
            this.btnUniqueRemoveAllValues.Name = "btnUniqueRemoveAllValues";
            this.btnUniqueRemoveAllValues.Size = new System.Drawing.Size(75, 23);
            this.btnUniqueRemoveAllValues.TabIndex = 15;
            this.btnUniqueRemoveAllValues.Text = "移除所有值";
            this.btnUniqueRemoveAllValues.Click += new System.EventHandler(this.btnRemoveAllValues_Click);
            // 
            // btnUniqueRemoveValues
            // 
            this.btnUniqueRemoveValues.Location = new System.Drawing.Point(165, 212);
            this.btnUniqueRemoveValues.Name = "btnUniqueRemoveValues";
            this.btnUniqueRemoveValues.Size = new System.Drawing.Size(75, 23);
            this.btnUniqueRemoveValues.TabIndex = 14;
            this.btnUniqueRemoveValues.Text = "移除值";
            this.btnUniqueRemoveValues.Click += new System.EventHandler(this.btnRemoveValues_Click);
            // 
            // btnUniqueAddValues
            // 
            this.btnUniqueAddValues.Location = new System.Drawing.Point(84, 212);
            this.btnUniqueAddValues.Name = "btnUniqueAddValues";
            this.btnUniqueAddValues.Size = new System.Drawing.Size(75, 23);
            this.btnUniqueAddValues.TabIndex = 13;
            this.btnUniqueAddValues.Text = "添加值";
            this.btnUniqueAddValues.Click += new System.EventHandler(this.btnAddValues_Click);
            // 
            // btnUniqueAddAllValues
            // 
            this.btnUniqueAddAllValues.Location = new System.Drawing.Point(3, 212);
            this.btnUniqueAddAllValues.Name = "btnUniqueAddAllValues";
            this.btnUniqueAddAllValues.Size = new System.Drawing.Size(75, 23);
            this.btnUniqueAddAllValues.TabIndex = 12;
            this.btnUniqueAddAllValues.Text = "添加所有值";
            this.btnUniqueAddAllValues.Click += new System.EventHandler(this.btnAddAllValues_Click);
            // 
            // btnLayerPropertiesOK
            // 
            this.btnLayerPropertiesOK.Location = new System.Drawing.Point(366, 289);
            this.btnLayerPropertiesOK.Name = "btnLayerPropertiesOK";
            this.btnLayerPropertiesOK.Size = new System.Drawing.Size(87, 27);
            this.btnLayerPropertiesOK.TabIndex = 16;
            this.btnLayerPropertiesOK.Text = "确定";
            this.btnLayerPropertiesOK.Click += new System.EventHandler(this.btnLayerPropertiesOK_Click);
            // 
            // btnLayerPropertiesCancel
            // 
            this.btnLayerPropertiesCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLayerPropertiesCancel.Location = new System.Drawing.Point(488, 289);
            this.btnLayerPropertiesCancel.Name = "btnLayerPropertiesCancel";
            this.btnLayerPropertiesCancel.Size = new System.Drawing.Size(87, 27);
            this.btnLayerPropertiesCancel.TabIndex = 17;
            this.btnLayerPropertiesCancel.Text = "取消";
            // 
            // cmbUniqueValueColorRamp
            // 
            this.cmbUniqueValueColorRamp.Location = new System.Drawing.Point(203, 23);
            this.cmbUniqueValueColorRamp.Name = "cmbUniqueValueColorRamp";
            this.cmbUniqueValueColorRamp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUniqueValueColorRamp.Size = new System.Drawing.Size(211, 20);
            this.cmbUniqueValueColorRamp.TabIndex = 19;
            this.cmbUniqueValueColorRamp.SelectedIndexChanged += new System.EventHandler(this.cmbColorRamp_SelectedIndexChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(203, 3);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 14);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "配色方案:";
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Location = new System.Drawing.Point(164, 12);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.pageVectorSimple;
            this.xtraTabControl.Size = new System.Drawing.Size(423, 271);
            this.xtraTabControl.TabIndex = 20;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageVectorSimple,
            this.pageVectorUniqueValue,
            this.pageRasterUniqueValue,
            this.pageRasterClassify,
            this.pageRasterStretch});
            // 
            // pageVectorSimple
            // 
            this.pageVectorSimple.Controls.Add(this.txtSimpleDescription);
            this.pageVectorSimple.Controls.Add(this.labelSimplePreview);
            this.pageVectorSimple.Controls.Add(this.labelControl6);
            this.pageVectorSimple.Controls.Add(this.btnSimpleChange);
            this.pageVectorSimple.Name = "pageVectorSimple";
            this.pageVectorSimple.Size = new System.Drawing.Size(417, 242);
            this.pageVectorSimple.Text = "矢量简单";
            // 
            // txtSimpleDescription
            // 
            this.txtSimpleDescription.Location = new System.Drawing.Point(8, 116);
            this.txtSimpleDescription.Name = "txtSimpleDescription";
            this.txtSimpleDescription.Size = new System.Drawing.Size(203, 20);
            this.txtSimpleDescription.TabIndex = 1;
            // 
            // labelSimplePreview
            // 
            this.labelSimplePreview.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelSimplePreview.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelSimplePreview.Location = new System.Drawing.Point(8, 13);
            this.labelSimplePreview.Name = "labelSimplePreview";
            this.labelSimplePreview.Size = new System.Drawing.Size(111, 63);
            this.labelSimplePreview.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 96);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "图例符号注释:";
            // 
            // btnSimpleChange
            // 
            this.btnSimpleChange.Location = new System.Drawing.Point(125, 30);
            this.btnSimpleChange.Name = "btnSimpleChange";
            this.btnSimpleChange.Size = new System.Drawing.Size(75, 23);
            this.btnSimpleChange.TabIndex = 1;
            this.btnSimpleChange.Text = "更改符号";
            this.btnSimpleChange.Click += new System.EventHandler(this.btnSimpleChange_Click);
            // 
            // pageVectorUniqueValue
            // 
            this.pageVectorUniqueValue.Controls.Add(this.labelControl7);
            this.pageVectorUniqueValue.Controls.Add(this.cmbUniqueValueColorRamp);
            this.pageVectorUniqueValue.Controls.Add(this.cmbUniqueValueField);
            this.pageVectorUniqueValue.Controls.Add(this.labelControl8);
            this.pageVectorUniqueValue.Controls.Add(this.gridControlUniqueValue);
            this.pageVectorUniqueValue.Controls.Add(this.btnUniqueAddAllValues);
            this.pageVectorUniqueValue.Controls.Add(this.btnUniqueAddValues);
            this.pageVectorUniqueValue.Controls.Add(this.btnUniqueRemoveAllValues);
            this.pageVectorUniqueValue.Controls.Add(this.btnUniqueRemoveValues);
            this.pageVectorUniqueValue.Name = "pageVectorUniqueValue";
            this.pageVectorUniqueValue.Size = new System.Drawing.Size(417, 242);
            this.pageVectorUniqueValue.Text = "矢量唯一值";
            // 
            // pageRasterUniqueValue
            // 
            this.pageRasterUniqueValue.Controls.Add(this.labelControl1);
            this.pageRasterUniqueValue.Controls.Add(this.cmbRasterUniqueValueColorRamp);
            this.pageRasterUniqueValue.Controls.Add(this.cmbRasterUniqueValueField);
            this.pageRasterUniqueValue.Controls.Add(this.labelControl2);
            this.pageRasterUniqueValue.Controls.Add(this.gridControlRasterUniqueValue);
            this.pageRasterUniqueValue.Controls.Add(this.btnRasterUniqueAddAllValues);
            this.pageRasterUniqueValue.Controls.Add(this.btnRasterUniqueAddValues);
            this.pageRasterUniqueValue.Controls.Add(this.btnRasterUniqueRemoveAllValues);
            this.pageRasterUniqueValue.Controls.Add(this.btnRasterUniqueRemoveValues);
            this.pageRasterUniqueValue.Name = "pageRasterUniqueValue";
            this.pageRasterUniqueValue.Size = new System.Drawing.Size(417, 242);
            this.pageRasterUniqueValue.Text = "栅格唯一值";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "渲染字段:";
            // 
            // cmbRasterUniqueValueColorRamp
            // 
            this.cmbRasterUniqueValueColorRamp.Location = new System.Drawing.Point(203, 23);
            this.cmbRasterUniqueValueColorRamp.Name = "cmbRasterUniqueValueColorRamp";
            this.cmbRasterUniqueValueColorRamp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRasterUniqueValueColorRamp.Size = new System.Drawing.Size(211, 20);
            this.cmbRasterUniqueValueColorRamp.TabIndex = 28;
            this.cmbRasterUniqueValueColorRamp.SelectedIndexChanged += new System.EventHandler(this.cmbColorRamp_SelectedIndexChanged);
            // 
            // cmbRasterUniqueValueField
            // 
            this.cmbRasterUniqueValueField.Location = new System.Drawing.Point(3, 23);
            this.cmbRasterUniqueValueField.Name = "cmbRasterUniqueValueField";
            this.cmbRasterUniqueValueField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRasterUniqueValueField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRasterUniqueValueField.Size = new System.Drawing.Size(156, 20);
            this.cmbRasterUniqueValueField.TabIndex = 21;
            this.cmbRasterUniqueValueField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(203, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "配色方案:";
            // 
            // gridControlRasterUniqueValue
            // 
            gridLevelNode2.RelationName = "Level1";
            this.gridControlRasterUniqueValue.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlRasterUniqueValue.Location = new System.Drawing.Point(3, 50);
            this.gridControlRasterUniqueValue.MainView = this.gridViewRasterUniqueValue;
            this.gridControlRasterUniqueValue.Name = "gridControlRasterUniqueValue";
            this.gridControlRasterUniqueValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEditRasterUniqueValue});
            this.gridControlRasterUniqueValue.Size = new System.Drawing.Size(411, 156);
            this.gridControlRasterUniqueValue.TabIndex = 22;
            this.gridControlRasterUniqueValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRasterUniqueValue});
            // 
            // gridViewRasterUniqueValue
            // 
            this.gridViewRasterUniqueValue.GridControl = this.gridControlRasterUniqueValue;
            this.gridViewRasterUniqueValue.Name = "gridViewRasterUniqueValue";
            this.gridViewRasterUniqueValue.OptionsView.ShowGroupPanel = false;
            this.gridViewRasterUniqueValue.OptionsView.ShowIndicator = false;
            // 
            // repositoryItemPictureEditRasterUniqueValue
            // 
            this.repositoryItemPictureEditRasterUniqueValue.Name = "repositoryItemPictureEditRasterUniqueValue";
            this.repositoryItemPictureEditRasterUniqueValue.DoubleClick += new System.EventHandler(this.repositoryItemPictureEdit_DoubleClick);
            // 
            // btnRasterUniqueAddAllValues
            // 
            this.btnRasterUniqueAddAllValues.Location = new System.Drawing.Point(3, 212);
            this.btnRasterUniqueAddAllValues.Name = "btnRasterUniqueAddAllValues";
            this.btnRasterUniqueAddAllValues.Size = new System.Drawing.Size(75, 23);
            this.btnRasterUniqueAddAllValues.TabIndex = 23;
            this.btnRasterUniqueAddAllValues.Text = "添加所有值";
            this.btnRasterUniqueAddAllValues.Click += new System.EventHandler(this.btnAddAllValues_Click);
            // 
            // btnRasterUniqueAddValues
            // 
            this.btnRasterUniqueAddValues.Location = new System.Drawing.Point(84, 212);
            this.btnRasterUniqueAddValues.Name = "btnRasterUniqueAddValues";
            this.btnRasterUniqueAddValues.Size = new System.Drawing.Size(75, 23);
            this.btnRasterUniqueAddValues.TabIndex = 24;
            this.btnRasterUniqueAddValues.Text = "添加值";
            this.btnRasterUniqueAddValues.Click += new System.EventHandler(this.btnAddValues_Click);
            // 
            // btnRasterUniqueRemoveAllValues
            // 
            this.btnRasterUniqueRemoveAllValues.Location = new System.Drawing.Point(246, 212);
            this.btnRasterUniqueRemoveAllValues.Name = "btnRasterUniqueRemoveAllValues";
            this.btnRasterUniqueRemoveAllValues.Size = new System.Drawing.Size(75, 23);
            this.btnRasterUniqueRemoveAllValues.TabIndex = 26;
            this.btnRasterUniqueRemoveAllValues.Text = "移除所有值";
            this.btnRasterUniqueRemoveAllValues.Click += new System.EventHandler(this.btnRemoveAllValues_Click);
            // 
            // btnRasterUniqueRemoveValues
            // 
            this.btnRasterUniqueRemoveValues.Location = new System.Drawing.Point(165, 212);
            this.btnRasterUniqueRemoveValues.Name = "btnRasterUniqueRemoveValues";
            this.btnRasterUniqueRemoveValues.Size = new System.Drawing.Size(75, 23);
            this.btnRasterUniqueRemoveValues.TabIndex = 25;
            this.btnRasterUniqueRemoveValues.Text = "移除值";
            this.btnRasterUniqueRemoveValues.Click += new System.EventHandler(this.btnRemoveValues_Click);
            // 
            // pageRasterClassify
            // 
            this.pageRasterClassify.Controls.Add(this.labelControl5);
            this.pageRasterClassify.Controls.Add(this.cmbRasterClassifyClass);
            this.pageRasterClassify.Controls.Add(this.labelControl3);
            this.pageRasterClassify.Controls.Add(this.cmbRasterClassifyColorRamp);
            this.pageRasterClassify.Controls.Add(this.cmbRasterClassifyField);
            this.pageRasterClassify.Controls.Add(this.labelControl4);
            this.pageRasterClassify.Controls.Add(this.gridControlRasterClassify);
            this.pageRasterClassify.Name = "pageRasterClassify";
            this.pageRasterClassify.Size = new System.Drawing.Size(417, 242);
            this.pageRasterClassify.Text = "栅格分类";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(117, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 14);
            this.labelControl5.TabIndex = 34;
            this.labelControl5.Text = "类别:";
            // 
            // cmbRasterClassifyClass
            // 
            this.cmbRasterClassifyClass.EditValue = "5";
            this.cmbRasterClassifyClass.Location = new System.Drawing.Point(117, 23);
            this.cmbRasterClassifyClass.Name = "cmbRasterClassifyClass";
            this.cmbRasterClassifyClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRasterClassifyClass.Size = new System.Drawing.Size(80, 20);
            this.cmbRasterClassifyClass.TabIndex = 35;
            this.cmbRasterClassifyClass.SelectedIndexChanged += new System.EventHandler(this.cmbRasterClassifyClass_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "渲染字段:";
            // 
            // cmbRasterClassifyColorRamp
            // 
            this.cmbRasterClassifyColorRamp.Location = new System.Drawing.Point(203, 23);
            this.cmbRasterClassifyColorRamp.Name = "cmbRasterClassifyColorRamp";
            this.cmbRasterClassifyColorRamp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRasterClassifyColorRamp.Size = new System.Drawing.Size(211, 20);
            this.cmbRasterClassifyColorRamp.TabIndex = 33;
            this.cmbRasterClassifyColorRamp.SelectedIndexChanged += new System.EventHandler(this.cmbColorRamp_SelectedIndexChanged);
            // 
            // cmbRasterClassifyField
            // 
            this.cmbRasterClassifyField.Location = new System.Drawing.Point(3, 23);
            this.cmbRasterClassifyField.Name = "cmbRasterClassifyField";
            this.cmbRasterClassifyField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRasterClassifyField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRasterClassifyField.Size = new System.Drawing.Size(108, 20);
            this.cmbRasterClassifyField.TabIndex = 30;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(203, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 32;
            this.labelControl4.Text = "配色方案:";
            // 
            // gridControlRasterClassify
            // 
            this.gridControlRasterClassify.Location = new System.Drawing.Point(3, 50);
            this.gridControlRasterClassify.MainView = this.gridViewRasterClassify;
            this.gridControlRasterClassify.Name = "gridControlRasterClassify";
            this.gridControlRasterClassify.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEditRasterClassify});
            this.gridControlRasterClassify.Size = new System.Drawing.Size(411, 190);
            this.gridControlRasterClassify.TabIndex = 31;
            this.gridControlRasterClassify.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRasterClassify});
            // 
            // gridViewRasterClassify
            // 
            this.gridViewRasterClassify.GridControl = this.gridControlRasterClassify;
            this.gridViewRasterClassify.Name = "gridViewRasterClassify";
            this.gridViewRasterClassify.OptionsView.ShowGroupPanel = false;
            this.gridViewRasterClassify.OptionsView.ShowIndicator = false;
            // 
            // repositoryItemPictureEditRasterClassify
            // 
            this.repositoryItemPictureEditRasterClassify.Name = "repositoryItemPictureEditRasterClassify";
            this.repositoryItemPictureEditRasterClassify.DoubleClick += new System.EventHandler(this.repositoryItemPictureEdit_DoubleClick);
            // 
            // pageRasterStretch
            // 
            this.pageRasterStretch.Controls.Add(this.tableLayoutPanel2);
            this.pageRasterStretch.Controls.Add(this.tableLayoutPanel1);
            this.pageRasterStretch.Controls.Add(this.gridControlRasterStretch);
            this.pageRasterStretch.Name = "pageRasterStretch";
            this.pageRasterStretch.Size = new System.Drawing.Size(417, 242);
            this.pageRasterStretch.Text = "栅格拉伸";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.chkRasterStretchBackground, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtRasterStretchBackground, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.colorRasterStretchBackground, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 209);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(315, 29);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // chkRasterStretchBackground
            // 
            this.chkRasterStretchBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRasterStretchBackground.Location = new System.Drawing.Point(3, 5);
            this.chkRasterStretchBackground.Name = "chkRasterStretchBackground";
            this.chkRasterStretchBackground.Properties.Caption = "显示背景值：";
            this.chkRasterStretchBackground.Size = new System.Drawing.Size(90, 19);
            this.chkRasterStretchBackground.TabIndex = 38;
            // 
            // txtRasterStretchBackground
            // 
            this.txtRasterStretchBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRasterStretchBackground.EditValue = "0";
            this.txtRasterStretchBackground.Location = new System.Drawing.Point(99, 4);
            this.txtRasterStretchBackground.Name = "txtRasterStretchBackground";
            this.txtRasterStretchBackground.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRasterStretchBackground.Size = new System.Drawing.Size(70, 20);
            this.txtRasterStretchBackground.TabIndex = 39;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl10.Location = new System.Drawing.Point(175, 7);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 14);
            this.labelControl10.TabIndex = 41;
            this.labelControl10.Text = "背景颜色：";
            // 
            // colorRasterStretchBackground
            // 
            this.colorRasterStretchBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorRasterStretchBackground.EditValue = System.Drawing.Color.Empty;
            this.colorRasterStretchBackground.Location = new System.Drawing.Point(241, 4);
            this.colorRasterStretchBackground.Name = "colorRasterStretchBackground";
            this.colorRasterStretchBackground.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorRasterStretchBackground.Size = new System.Drawing.Size(71, 20);
            this.colorRasterStretchBackground.TabIndex = 40;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.txtRasterStretchIntervals, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbRasterStretchColorRamp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRasterStretchGenerate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkRasterStretchInvert, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.72414F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.27586F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 58);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // txtRasterStretchIntervals
            // 
            this.txtRasterStretchIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRasterStretchIntervals.EditValue = "";
            this.txtRasterStretchIntervals.Location = new System.Drawing.Point(61, 33);
            this.txtRasterStretchIntervals.Name = "txtRasterStretchIntervals";
            this.txtRasterStretchIntervals.Size = new System.Drawing.Size(183, 20);
            this.txtRasterStretchIntervals.TabIndex = 43;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl11.Location = new System.Drawing.Point(3, 37);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(52, 14);
            this.labelControl11.TabIndex = 44;
            this.labelControl11.Text = "间隔数量:";
            // 
            // cmbRasterStretchColorRamp
            // 
            this.cmbRasterStretchColorRamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRasterStretchColorRamp.Location = new System.Drawing.Point(61, 4);
            this.cmbRasterStretchColorRamp.Name = "cmbRasterStretchColorRamp";
            this.cmbRasterStretchColorRamp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRasterStretchColorRamp.Size = new System.Drawing.Size(183, 20);
            this.cmbRasterStretchColorRamp.TabIndex = 34;
            this.cmbRasterStretchColorRamp.SelectedIndexChanged += new System.EventHandler(this.cmbRasterStretchColorRamp_SelectedIndexChanged);
            // 
            // btnRasterStretchGenerate
            // 
            this.btnRasterStretchGenerate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRasterStretchGenerate.Location = new System.Drawing.Point(250, 33);
            this.btnRasterStretchGenerate.Name = "btnRasterStretchGenerate";
            this.btnRasterStretchGenerate.Size = new System.Drawing.Size(72, 22);
            this.btnRasterStretchGenerate.TabIndex = 45;
            this.btnRasterStretchGenerate.Text = "生成";
            this.btnRasterStretchGenerate.Click += new System.EventHandler(this.btnRasterStretchGenerate_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl9.Location = new System.Drawing.Point(3, 8);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 14);
            this.labelControl9.TabIndex = 35;
            this.labelControl9.Text = "配色方案:";
            // 
            // chkRasterStretchInvert
            // 
            this.chkRasterStretchInvert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkRasterStretchInvert.Location = new System.Drawing.Point(250, 5);
            this.chkRasterStretchInvert.Name = "chkRasterStretchInvert";
            this.chkRasterStretchInvert.Properties.Caption = "翻转";
            this.chkRasterStretchInvert.Size = new System.Drawing.Size(55, 19);
            this.chkRasterStretchInvert.TabIndex = 42;
            this.chkRasterStretchInvert.Visible = false;
            this.chkRasterStretchInvert.CheckedChanged += new System.EventHandler(this.chkRasterStretchInvert_CheckedChanged);
            // 
            // gridControlRasterStretch
            // 
            gridLevelNode3.RelationName = "Level1";
            this.gridControlRasterStretch.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.gridControlRasterStretch.Location = new System.Drawing.Point(6, 67);
            this.gridControlRasterStretch.MainView = this.gridViewRasterStretch;
            this.gridControlRasterStretch.Name = "gridControlRasterStretch";
            this.gridControlRasterStretch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEditRasterStretch});
            this.gridControlRasterStretch.Size = new System.Drawing.Size(411, 138);
            this.gridControlRasterStretch.TabIndex = 46;
            this.gridControlRasterStretch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRasterStretch});
            // 
            // gridViewRasterStretch
            // 
            this.gridViewRasterStretch.GridControl = this.gridControlRasterStretch;
            this.gridViewRasterStretch.Name = "gridViewRasterStretch";
            this.gridViewRasterStretch.OptionsView.ShowGroupPanel = false;
            this.gridViewRasterStretch.OptionsView.ShowIndicator = false;
            this.gridViewRasterStretch.RowHeight = 22;
            // 
            // repositoryItemPictureEditRasterStretch
            // 
            this.repositoryItemPictureEditRasterStretch.Name = "repositoryItemPictureEditRasterStretch";
            this.repositoryItemPictureEditRasterStretch.DoubleClick += new System.EventHandler(this.repositoryItemPictureEdit_DoubleClick);
            // 
            // treeListRenderer
            // 
            this.treeListRenderer.Location = new System.Drawing.Point(12, 12);
            this.treeListRenderer.Name = "treeListRenderer";
            this.treeListRenderer.Size = new System.Drawing.Size(146, 266);
            this.treeListRenderer.TabIndex = 3;
            this.treeListRenderer.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListRenderer_FocusedNodeChanged);
            // 
            // frmLayerRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 324);
            this.Controls.Add(this.treeListRenderer);
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.btnLayerPropertiesCancel);
            this.Controls.Add(this.btnLayerPropertiesOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLayerRender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层渲染";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmLayerRender_HelpButtonClicked);
            this.Load += new System.EventHandler(this.FormLayerProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbUniqueValueField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUniqueValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUniqueValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditUniqueValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUniqueValueColorRamp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.pageVectorSimple.ResumeLayout(false);
            this.pageVectorSimple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSimpleDescription.Properties)).EndInit();
            this.pageVectorUniqueValue.ResumeLayout(false);
            this.pageVectorUniqueValue.PerformLayout();
            this.pageRasterUniqueValue.ResumeLayout(false);
            this.pageRasterUniqueValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterUniqueValueColorRamp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterUniqueValueField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRasterUniqueValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRasterUniqueValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditRasterUniqueValue)).EndInit();
            this.pageRasterClassify.ResumeLayout(false);
            this.pageRasterClassify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterClassifyClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterClassifyColorRamp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterClassifyField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRasterClassify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRasterClassify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditRasterClassify)).EndInit();
            this.pageRasterStretch.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRasterStretchBackground.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRasterStretchBackground.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorRasterStretchBackground.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRasterStretchIntervals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRasterStretchColorRamp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRasterStretchInvert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRasterStretch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRasterStretch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEditRasterStretch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListRenderer)).EndInit();
            this.ResumeLayout(false);

        }


        private ComboBoxEdit cmbUniqueValueField;

        private LabelControl labelControl7;

        private GridControl gridControlUniqueValue;

        private GridView gridViewUniqueValue;

        private RepositoryItemPictureEdit repositoryItemPictureEditUniqueValue;

        private SimpleButton btnUniqueRemoveAllValues;

        private SimpleButton btnUniqueRemoveValues;

        private SimpleButton btnUniqueAddValues;

        private SimpleButton btnUniqueAddAllValues;

        private SimpleButton btnLayerPropertiesOK;

        private SimpleButton btnLayerPropertiesCancel;

        private ImageComboBoxEdit cmbUniqueValueColorRamp;

        private LabelControl labelControl8;

        private XtraTabControl xtraTabControl;

        private XtraTabPage pageVectorUniqueValue;

        private XtraTabPage pageVectorSimple;

        private XtraTabPage pageRasterUniqueValue;

        private TreeList treeListRenderer;

        private TextEdit txtSimpleDescription;

        private LabelControl labelControl6;

        private LabelControl labelSimplePreview;

        private SimpleButton btnSimpleChange;

        private LabelControl labelControl1;

        private ImageComboBoxEdit cmbRasterUniqueValueColorRamp;

        private ComboBoxEdit cmbRasterUniqueValueField;

        private LabelControl labelControl2;

        private GridControl gridControlRasterUniqueValue;

        private GridView gridViewRasterUniqueValue;

        private SimpleButton btnRasterUniqueAddAllValues;

        private SimpleButton btnRasterUniqueAddValues;

        private SimpleButton btnRasterUniqueRemoveAllValues;

        private SimpleButton btnRasterUniqueRemoveValues;

        private RepositoryItemPictureEdit repositoryItemPictureEditRasterUniqueValue;

        private XtraTabPage pageRasterClassify;

        private LabelControl labelControl3;

        private ImageComboBoxEdit cmbRasterClassifyColorRamp;

        private ComboBoxEdit cmbRasterClassifyField;

        private LabelControl labelControl4;

        private GridControl gridControlRasterClassify;

        private GridView gridViewRasterClassify;

        private RepositoryItemPictureEdit repositoryItemPictureEditRasterClassify;

        private LabelControl labelControl5;

        private ComboBoxEdit cmbRasterClassifyClass;

        private XtraTabPage pageRasterStretch;

        private LabelControl labelControl9;

        private ImageComboBoxEdit cmbRasterStretchColorRamp;

        private TextEdit txtRasterStretchBackground;

        private CheckEdit chkRasterStretchBackground;

        private LabelControl labelControl10;

        private ColorEdit colorRasterStretchBackground;

        private CheckEdit chkRasterStretchInvert;

        private SimpleButton btnRasterStretchGenerate;

        private LabelControl labelControl11;

        private TextEdit txtRasterStretchIntervals;

        private GridControl gridControlRasterStretch;

        private GridView gridViewRasterStretch;

        private RepositoryItemPictureEdit repositoryItemPictureEditRasterStretch;

        private TableLayoutPanel tableLayoutPanel1;

        private TableLayoutPanel tableLayoutPanel2;

        #endregion
    }
}