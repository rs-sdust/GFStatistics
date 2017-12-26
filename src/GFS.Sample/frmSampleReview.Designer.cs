namespace GFS.Sample
{
    partial class frmSampleReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleReview));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnOpenShp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRedo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnChart = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStatic = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.barBtnZoomTo = new DevExpress.XtraBars.BarButtonItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlTable = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTable)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AutoSaveInRegistry = true;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnDel,
            this.barBtnSave,
            this.barBtnChart,
            this.barBtnUndo,
            this.barBtnRedo,
            this.barBtnOpenShp,
            this.barStatic,
            this.barBtnZoomTo});
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(148, 171);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnOpenShp),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRedo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnChart)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Tools";
            // 
            // barBtnOpenShp
            // 
            this.barBtnOpenShp.Caption = "打开文件";
            this.barBtnOpenShp.Id = 7;
            this.barBtnOpenShp.ImageIndex = 3;
            this.barBtnOpenShp.Name = "barBtnOpenShp";
            this.barBtnOpenShp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOpenShp_ItemClick);
            // 
            // barBtnDel
            // 
            this.barBtnDel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barBtnDel.Caption = "删除样方";
            this.barBtnDel.Id = 0;
            this.barBtnDel.ImageIndex = 5;
            this.barBtnDel.Name = "barBtnDel";
            this.barBtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDel_ItemClick);
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "保存编辑";
            this.barBtnSave.Id = 1;
            this.barBtnSave.ImageIndex = 0;
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
            // 
            // barBtnUndo
            // 
            this.barBtnUndo.Caption = "撤销";
            this.barBtnUndo.Id = 5;
            this.barBtnUndo.ImageIndex = 2;
            this.barBtnUndo.Name = "barBtnUndo";
            this.barBtnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUndo_ItemClick);
            // 
            // barBtnRedo
            // 
            this.barBtnRedo.Caption = "重做";
            this.barBtnRedo.Id = 6;
            this.barBtnRedo.ImageIndex = 1;
            this.barBtnRedo.Name = "barBtnRedo";
            this.barBtnRedo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRedo_ItemClick);
            // 
            // barBtnChart
            // 
            this.barBtnChart.Caption = "散点图";
            this.barBtnChart.Id = 2;
            this.barBtnChart.ImageIndex = 4;
            this.barBtnChart.Name = "barBtnChart";
            this.barBtnChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnChart_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatic)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // barStatic
            // 
            this.barStatic.Caption = "样本总数：  已删样本数  合格样本数  ";
            this.barStatic.Id = 10;
            this.barStatic.Name = "barStatic";
            this.barStatic.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(524, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 384);
            this.barDockControlBottom.Size = new System.Drawing.Size(524, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 353);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(524, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 353);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "save.png");
            this.imageCollection1.Images.SetKeyName(1, "redo.png");
            this.imageCollection1.Images.SetKeyName(2, "undo.png");
            this.imageCollection1.Images.SetKeyName(3, "open.png");
            this.imageCollection1.Images.SetKeyName(4, "散点视图.png");
            this.imageCollection1.Images.SetKeyName(5, "delete.png");
            // 
            // barBtnZoomTo
            // 
            this.barBtnZoomTo.Caption = "barButtonItem1";
            this.barBtnZoomTo.Id = 11;
            this.barBtnZoomTo.Name = "barBtnZoomTo";
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
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // gridControlTable
            // 
            this.gridControlTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTable.Location = new System.Drawing.Point(0, 31);
            this.gridControlTable.MainView = this.gridView1;
            this.gridControlTable.Name = "gridControlTable";
            this.gridControlTable.Size = new System.Drawing.Size(524, 353);
            this.gridControlTable.TabIndex = 4;
            this.gridControlTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlTable.DoubleClick += new System.EventHandler(this.gridControlTable_DoubleClick);
            // 
            // frmSampleReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 411);
            this.Controls.Add(this.gridControlTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSampleReview";
            this.Text = "样本审核";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmSampleReview_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmSampleReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtnOpenShp;
        private DevExpress.XtraBars.BarButtonItem barBtnDel;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraBars.BarButtonItem barBtnChart;
        private DevExpress.XtraBars.BarButtonItem barBtnUndo;
        private DevExpress.XtraBars.BarButtonItem barBtnRedo;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem barStatic;
        private DevExpress.XtraBars.BarButtonItem barBtnZoomTo;
        private DevExpress.XtraGrid.GridControl gridControlTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}