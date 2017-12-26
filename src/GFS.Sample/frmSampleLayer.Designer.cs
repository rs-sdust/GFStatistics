namespace GFS.Sample
{
    partial class frmSampleLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleLayer));
            this.gridControlTable = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnOpenShp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAddField = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnBatch = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLayerField = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRedo = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.barBtnEditLayer = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTable
            // 
            this.gridControlTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTable.Location = new System.Drawing.Point(0, 31);
            this.gridControlTable.MainView = this.gridView1;
            this.gridControlTable.Name = "gridControlTable";
            this.gridControlTable.Size = new System.Drawing.Size(813, 426);
            this.gridControlTable.TabIndex = 2;
            this.gridControlTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlTable.DoubleClick += new System.EventHandler(this.gridControlTable_DoubleClick);
            this.gridControlTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControlTable_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlTable;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsDetail.AllowZoomDetail = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AutoSaveInRegistry = true;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnEdit,
            this.barBtnSave,
            this.barBtnAddField,
            this.barBtnBatch,
            this.barBtnLayerField,
            this.barBtnUndo,
            this.barBtnRedo,
            this.barBtnOpenShp,
            this.barBtnSearch,
            this.barBtnEditLayer});
            this.barManager1.MaxItemId = 10;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnOpenShp),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAddField),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnBatch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnLayerField),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRedo)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Tools";
            // 
            // barBtnOpenShp
            // 
            this.barBtnOpenShp.Caption = "打开文件";
            this.barBtnOpenShp.Id = 7;
            this.barBtnOpenShp.ImageIndex = 7;
            this.barBtnOpenShp.Name = "barBtnOpenShp";
            this.barBtnOpenShp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOpenShp_ItemClick);
            // 
            // barBtnEdit
            // 
            this.barBtnEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnEdit.Caption = "开始编辑";
            this.barBtnEdit.Id = 0;
            this.barBtnEdit.ImageIndex = 0;
            this.barBtnEdit.Name = "barBtnEdit";
            this.barBtnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEdit_ItemClick);
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "保存编辑";
            this.barBtnSave.Id = 1;
            this.barBtnSave.ImageIndex = 1;
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
            // 
            // barBtnAddField
            // 
            this.barBtnAddField.Caption = "添加字段";
            this.barBtnAddField.Id = 2;
            this.barBtnAddField.ImageIndex = 2;
            this.barBtnAddField.Name = "barBtnAddField";
            this.barBtnAddField.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAddField_ItemClick);
            // 
            // barBtnSearch
            // 
            this.barBtnSearch.Caption = "搜索";
            this.barBtnSearch.Id = 8;
            this.barBtnSearch.ImageIndex = 8;
            this.barBtnSearch.Name = "barBtnSearch";
            this.barBtnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSearch_ItemClick);
            // 
            // barBtnBatch
            // 
            this.barBtnBatch.Caption = "批量编辑";
            this.barBtnBatch.Id = 3;
            this.barBtnBatch.ImageIndex = 3;
            this.barBtnBatch.Name = "barBtnBatch";
            this.barBtnBatch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnBatch_ItemClick);
            // 
            // barBtnLayerField
            // 
            this.barBtnLayerField.Caption = "设为分层字段";
            this.barBtnLayerField.Id = 4;
            this.barBtnLayerField.ImageIndex = 4;
            this.barBtnLayerField.Name = "barBtnLayerField";
            this.barBtnLayerField.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLayerField_ItemClick);
            // 
            // barBtnUndo
            // 
            this.barBtnUndo.Caption = "撤销";
            this.barBtnUndo.Id = 5;
            this.barBtnUndo.ImageIndex = 6;
            this.barBtnUndo.Name = "barBtnUndo";
            this.barBtnUndo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUndo_ItemClick);
            // 
            // barBtnRedo
            // 
            this.barBtnRedo.Caption = "重做";
            this.barBtnRedo.Id = 6;
            this.barBtnRedo.ImageIndex = 5;
            this.barBtnRedo.Name = "barBtnRedo";
            this.barBtnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barBtnRedo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRedo_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(813, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 457);
            this.barDockControlBottom.Size = new System.Drawing.Size(813, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 426);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(813, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 426);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "edit.png");
            this.imageCollection1.Images.SetKeyName(1, "save.png");
            this.imageCollection1.Images.SetKeyName(2, "add.png");
            this.imageCollection1.Images.SetKeyName(3, "calcu.png");
            this.imageCollection1.Images.SetKeyName(4, "muliSelect.png");
            this.imageCollection1.Images.SetKeyName(5, "redo.png");
            this.imageCollection1.Images.SetKeyName(6, "undo.png");
            this.imageCollection1.Images.SetKeyName(7, "open.png");
            this.imageCollection1.Images.SetKeyName(8, "find.png");
            // 
            // barBtnEditLayer
            // 
            this.barBtnEditLayer.Caption = "编辑分层";
            this.barBtnEditLayer.Id = 9;
            this.barBtnEditLayer.Name = "barBtnEditLayer";
            this.barBtnEditLayer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEditLayer_ItemClick);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnEditLayer)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // frmSampleLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 457);
            this.Controls.Add(this.gridControlTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSampleLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "预分层";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmSampleLayer_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSampleLayer_FormClosing);
            this.Load += new System.EventHandler(this.SampleLayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtnEdit;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraBars.BarButtonItem barBtnAddField;
        private DevExpress.XtraBars.BarButtonItem barBtnBatch;
        private DevExpress.XtraBars.BarButtonItem barBtnLayerField;
        private DevExpress.XtraBars.BarButtonItem barBtnUndo;
        private DevExpress.XtraBars.BarButtonItem barBtnRedo;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem barBtnOpenShp;
        private DevExpress.XtraBars.BarButtonItem barBtnSearch;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnEditLayer;
    }
}