namespace GFS.Sample
{
    partial class frmSampleFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleFrame));
            this.labelCilp1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageData = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlTable = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnMuiltiSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCalcu = new DevExpress.XtraEditors.SimpleButton();
            this.btnRedo = new DevExpress.XtraEditors.SimpleButton();
            this.btnUndo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkArea = new DevExpress.XtraEditors.CheckEdit();
            this.cmbAreaField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnASCDL = new DevExpress.XtraEditors.SimpleButton();
            this.btnCrop = new DevExpress.XtraEditors.SimpleButton();
            this.cmbUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDestination = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbASCDL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCrop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnUnit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAreaField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbASCDL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrop.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCilp1
            // 
            this.labelCilp1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelCilp1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCilp1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelCilp1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelCilp1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.labelCilp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCilp1.LineVisible = true;
            this.labelCilp1.Location = new System.Drawing.Point(2, 22);
            this.labelCilp1.Name = "labelCilp1";
            this.labelCilp1.Size = new System.Drawing.Size(279, 223);
            this.labelCilp1.TabIndex = 20;
            this.labelCilp1.Text = "该工具用于将栅格图像按\r\n照面状矢量文件的边界进\r\n行裁剪，得到矢量文件范\r\n围内的栅格图像。";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(311, 290);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 18;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(401, 290);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 21;
            this.btnHelp.Text = "显示帮助>>";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelCilp1);
            this.groupControl3.Location = new System.Drawing.Point(503, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(283, 247);
            this.groupControl3.TabIndex = 24;
            this.groupControl3.Text = "构建抽样框帮助";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 381);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageData;
            this.xtraTabControl1.Size = new System.Drawing.Size(485, 276);
            this.xtraTabControl1.TabIndex = 26;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageData,
            this.xtraTabPage});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPageData
            // 
            this.xtraTabPageData.Name = "xtraTabPageData";
            this.xtraTabPageData.Size = new System.Drawing.Size(479, 247);
            this.xtraTabPageData.Text = "数据";
            // 
            // xtraTabPage
            // 
            this.xtraTabPage.Controls.Add(this.groupControl5);
            this.xtraTabPage.Name = "xtraTabPage";
            this.xtraTabPage.Size = new System.Drawing.Size(479, 247);
            this.xtraTabPage.Text = "预分层";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.gridControlTable);
            this.groupControl5.Controls.Add(this.panelControl1);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(479, 247);
            this.groupControl5.TabIndex = 23;
            this.groupControl5.Text = "输入";
            // 
            // gridControlTable
            // 
            this.gridControlTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTable.Location = new System.Drawing.Point(2, 50);
            this.gridControlTable.MainView = this.gridView1;
            this.gridControlTable.Name = "gridControlTable";
            this.gridControlTable.Size = new System.Drawing.Size(475, 195);
            this.gridControlTable.TabIndex = 1;
            this.gridControlTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlTable;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnMuiltiSelect);
            this.panelControl1.Controls.Add(this.btnCalcu);
            this.panelControl1.Controls.Add(this.btnRedo);
            this.panelControl1.Controls.Add(this.btnUndo);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(475, 28);
            this.panelControl1.TabIndex = 0;
            // 
            // btnMuiltiSelect
            // 
            this.btnMuiltiSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnMuiltiSelect.Image")));
            this.btnMuiltiSelect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMuiltiSelect.Location = new System.Drawing.Point(184, 3);
            this.btnMuiltiSelect.Name = "btnMuiltiSelect";
            this.btnMuiltiSelect.Size = new System.Drawing.Size(24, 24);
            this.btnMuiltiSelect.TabIndex = 8;
            this.btnMuiltiSelect.ToolTip = "设为分层字段";
            // 
            // btnCalcu
            // 
            this.btnCalcu.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcu.Image")));
            this.btnCalcu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCalcu.Location = new System.Drawing.Point(154, 3);
            this.btnCalcu.Name = "btnCalcu";
            this.btnCalcu.Size = new System.Drawing.Size(24, 24);
            this.btnCalcu.TabIndex = 7;
            this.btnCalcu.ToolTip = "批量编辑";
            // 
            // btnRedo
            // 
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRedo.Location = new System.Drawing.Point(124, 3);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(24, 24);
            this.btnRedo.TabIndex = 6;
            this.btnRedo.ToolTip = "重做";
            // 
            // btnUndo
            // 
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUndo.Location = new System.Drawing.Point(94, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(24, 24);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.ToolTip = "撤销";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(64, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.ToolTip = "保存";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(34, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.ToolTip = "添加字段";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEdit.Location = new System.Drawing.Point(4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.ToolTip = "编辑";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Controls.Add(this.cmbVillage);
            this.groupControl4.Controls.Add(this.chkArea);
            this.groupControl4.Controls.Add(this.cmbAreaField);
            this.groupControl4.Controls.Add(this.btnASCDL);
            this.groupControl4.Controls.Add(this.btnCrop);
            this.groupControl4.Controls.Add(this.cmbUnit);
            this.groupControl4.Controls.Add(this.cmbDestination);
            this.groupControl4.Controls.Add(this.cmbASCDL);
            this.groupControl4.Controls.Add(this.labelControl7);
            this.groupControl4.Controls.Add(this.cmbCrop);
            this.groupControl4.Controls.Add(this.labelControl6);
            this.groupControl4.Controls.Add(this.btnUnit);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Controls.Add(this.labelControl5);
            this.groupControl4.Location = new System.Drawing.Point(12, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(479, 247);
            this.groupControl4.TabIndex = 27;
            this.groupControl4.Text = "输入";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(16, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 25);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "村代码字段";
            // 
            // cmbVillage
            // 
            this.cmbVillage.Location = new System.Drawing.Point(102, 87);
            this.cmbVillage.Name = "cmbVillage";
            this.cmbVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbVillage.Size = new System.Drawing.Size(100, 20);
            this.cmbVillage.TabIndex = 12;
            this.cmbVillage.SelectedIndexChanged += new System.EventHandler(this.cmbVillage_SelectedIndexChanged);
            // 
            // chkArea
            // 
            this.chkArea.Location = new System.Drawing.Point(234, 87);
            this.chkArea.Name = "chkArea";
            this.chkArea.Properties.Caption = "包含面积字段";
            this.chkArea.Size = new System.Drawing.Size(94, 19);
            this.chkArea.TabIndex = 11;
            this.chkArea.CheckedChanged += new System.EventHandler(this.chkArea_CheckedChanged);
            // 
            // cmbAreaField
            // 
            this.cmbAreaField.Enabled = false;
            this.cmbAreaField.Location = new System.Drawing.Point(334, 87);
            this.cmbAreaField.Name = "cmbAreaField";
            this.cmbAreaField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAreaField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAreaField.Size = new System.Drawing.Size(100, 20);
            this.cmbAreaField.TabIndex = 10;
            this.cmbAreaField.SelectedIndexChanged += new System.EventHandler(this.cmbAreaField_SelectedIndexChanged);
            // 
            // btnASCDL
            // 
            this.btnASCDL.Image = ((System.Drawing.Image)(resources.GetObject("btnASCDL.Image")));
            this.btnASCDL.ImageIndex = 1;
            this.btnASCDL.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnASCDL.Location = new System.Drawing.Point(440, 160);
            this.btnASCDL.Name = "btnASCDL";
            this.btnASCDL.Size = new System.Drawing.Size(24, 24);
            this.btnASCDL.TabIndex = 9;
            this.btnASCDL.Click += new System.EventHandler(this.btnASCDL_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Image = ((System.Drawing.Image)(resources.GetObject("btnCrop.Image")));
            this.btnCrop.ImageIndex = 1;
            this.btnCrop.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCrop.Location = new System.Drawing.Point(440, 121);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(24, 24);
            this.btnCrop.TabIndex = 9;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.Location = new System.Drawing.Point(102, 44);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbUnit.Size = new System.Drawing.Size(332, 20);
            this.cmbUnit.TabIndex = 5;
            // 
            // cmbDestination
            // 
            this.cmbDestination.Location = new System.Drawing.Point(102, 200);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDestination.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDestination.Size = new System.Drawing.Size(332, 20);
            this.cmbDestination.TabIndex = 8;
            this.cmbDestination.SelectedIndexChanged += new System.EventHandler(this.cmbDestination_SelectedIndexChanged);
            // 
            // cmbASCDL
            // 
            this.cmbASCDL.Location = new System.Drawing.Point(102, 162);
            this.cmbASCDL.Name = "cmbASCDL";
            this.cmbASCDL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbASCDL.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbASCDL.Size = new System.Drawing.Size(332, 20);
            this.cmbASCDL.TabIndex = 8;
            this.cmbASCDL.TextChanged += new System.EventHandler(this.cmbASCDL_TextChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(19, 203);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 14);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "目标作物";
            // 
            // cmbCrop
            // 
            this.cmbCrop.Location = new System.Drawing.Point(102, 123);
            this.cmbCrop.Name = "cmbCrop";
            this.cmbCrop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCrop.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCrop.Size = new System.Drawing.Size(332, 20);
            this.cmbCrop.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(19, 165);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 14);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "ASCDL/误差层";
            // 
            // btnUnit
            // 
            this.btnUnit.Image = ((System.Drawing.Image)(resources.GetObject("btnUnit.Image")));
            this.btnUnit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUnit.Location = new System.Drawing.Point(440, 42);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(24, 24);
            this.btnUnit.TabIndex = 1;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(19, 126);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "农作物数据";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(19, 42);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 25);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "抽样单元";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(218, 290);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSampleFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 340);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(509, 369);
            this.Name = "frmSampleFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抽样框";
            this.Load += new System.EventHandler(this.frmClipRaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAreaField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbASCDL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrop.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelCilp1;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageData;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.CheckEdit chkArea;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAreaField;
        private DevExpress.XtraEditors.SimpleButton btnASCDL;
        private DevExpress.XtraEditors.SimpleButton btnCrop;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUnit;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDestination;
        private DevExpress.XtraEditors.ComboBoxEdit cmbASCDL;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCrop;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnUnit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl gridControlTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnMuiltiSelect;
        private DevExpress.XtraEditors.SimpleButton btnCalcu;
        private DevExpress.XtraEditors.SimpleButton btnRedo;
        private DevExpress.XtraEditors.SimpleButton btnUndo;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbVillage;


    }
}

