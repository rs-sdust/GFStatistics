namespace SDJT.Commands.UI
{
    partial class frmPluginMan
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxMenu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxPage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkEditRightClear = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditRightAll = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditLeftClear = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditLeftAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnDele = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.checkedListRight = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkedListLeft = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnPluginInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnUninst = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxMenu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRightClear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRightAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLeftClear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLeftAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCancle);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 398);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(744, 37);
            this.panelControl2.TabIndex = 1;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(657, 8);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 11;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(421, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxMenu);
            this.panelControl1.Controls.Add(this.comboBoxGroup);
            this.panelControl1.Controls.Add(this.comboBoxPage);
            this.panelControl1.Controls.Add(this.checkEditRightClear);
            this.panelControl1.Controls.Add(this.checkEditRightAll);
            this.panelControl1.Controls.Add(this.checkEditLeftClear);
            this.panelControl1.Controls.Add(this.checkEditLeftAll);
            this.panelControl1.Controls.Add(this.btnDele);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.checkedListRight);
            this.panelControl1.Controls.Add(this.checkedListLeft);
            this.panelControl1.Controls.Add(this.btnPluginInfo);
            this.panelControl1.Controls.Add(this.btnUninst);
            this.panelControl1.Controls.Add(this.btnImport);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(744, 398);
            this.panelControl1.TabIndex = 2;
            // 
            // comboBoxMenu
            // 
            this.comboBoxMenu.Enabled = false;
            this.comboBoxMenu.Location = new System.Drawing.Point(633, 9);
            this.comboBoxMenu.Name = "comboBoxMenu";
            this.comboBoxMenu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxMenu.Size = new System.Drawing.Size(100, 21);
            this.comboBoxMenu.TabIndex = 12;
            this.comboBoxMenu.SelectedIndexChanged += new System.EventHandler(this.comboBoxMenu_SelectedIndexChanged);
            this.comboBoxMenu.Click += new System.EventHandler(this.comboBoxMenu_Click);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Enabled = false;
            this.comboBoxGroup.Location = new System.Drawing.Point(527, 9);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxGroup.Size = new System.Drawing.Size(100, 21);
            this.comboBoxGroup.TabIndex = 11;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            this.comboBoxGroup.Click += new System.EventHandler(this.comboBoxGroup_Click);
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.Location = new System.Drawing.Point(421, 9);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxPage.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPage.TabIndex = 10;
            this.comboBoxPage.SelectedIndexChanged += new System.EventHandler(this.comboBoxPage_SelectedIndexChanged);
            this.comboBoxPage.Click += new System.EventHandler(this.comboBoxPage_Click);
            // 
            // checkEditRightClear
            // 
            this.checkEditRightClear.Location = new System.Drawing.Point(657, 374);
            this.checkEditRightClear.Name = "checkEditRightClear";
            this.checkEditRightClear.Properties.Caption = "清除";
            this.checkEditRightClear.Size = new System.Drawing.Size(75, 19);
            this.checkEditRightClear.TabIndex = 9;
            this.checkEditRightClear.Click += new System.EventHandler(this.checkEditRightClear_Click);
            // 
            // checkEditRightAll
            // 
            this.checkEditRightAll.Location = new System.Drawing.Point(419, 371);
            this.checkEditRightAll.Name = "checkEditRightAll";
            this.checkEditRightAll.Properties.Caption = "全选";
            this.checkEditRightAll.Size = new System.Drawing.Size(75, 19);
            this.checkEditRightAll.TabIndex = 8;
            this.checkEditRightAll.Click += new System.EventHandler(this.checkEditRightAll_Click);
            this.checkEditRightAll.DoubleClick += new System.EventHandler(this.checkEditRightAll_Click);
            // 
            // checkEditLeftClear
            // 
            this.checkEditLeftClear.Location = new System.Drawing.Point(278, 371);
            this.checkEditLeftClear.Name = "checkEditLeftClear";
            this.checkEditLeftClear.Properties.Caption = "清除";
            this.checkEditLeftClear.Size = new System.Drawing.Size(75, 19);
            this.checkEditLeftClear.TabIndex = 7;
            this.checkEditLeftClear.Click += new System.EventHandler(this.checkEditLeftClear_Click);
            this.checkEditLeftClear.DoubleClick += new System.EventHandler(this.checkEditLeftClear_Click);
            // 
            // checkEditLeftAll
            // 
            this.checkEditLeftAll.Location = new System.Drawing.Point(91, 371);
            this.checkEditLeftAll.Name = "checkEditLeftAll";
            this.checkEditLeftAll.Properties.Caption = "全选";
            this.checkEditLeftAll.Size = new System.Drawing.Size(75, 19);
            this.checkEditLeftAll.TabIndex = 0;
            this.checkEditLeftAll.Click += new System.EventHandler(this.checkEditLeftAll_Click);
            this.checkEditLeftAll.DoubleClick += new System.EventHandler(this.checkEditLeftAll_Click);
            // 
            // btnDele
            // 
            this.btnDele.Location = new System.Drawing.Point(357, 163);
            this.btnDele.Name = "btnDele";
            this.btnDele.Size = new System.Drawing.Size(60, 23);
            this.btnDele.TabIndex = 6;
            this.btnDele.Text = "<< 删除";
            this.btnDele.Click += new System.EventHandler(this.btnDele_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(357, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加 >>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // checkedListRight
            // 
            this.checkedListRight.Location = new System.Drawing.Point(421, 36);
            this.checkedListRight.Name = "checkedListRight";
            this.checkedListRight.Size = new System.Drawing.Size(311, 329);
            this.checkedListRight.TabIndex = 4;
            // 
            // checkedListLeft
            // 
            this.checkedListLeft.Location = new System.Drawing.Point(93, 12);
            this.checkedListLeft.Name = "checkedListLeft";
            this.checkedListLeft.Size = new System.Drawing.Size(260, 353);
            this.checkedListLeft.TabIndex = 3;
            // 
            // btnPluginInfo
            // 
            this.btnPluginInfo.Location = new System.Drawing.Point(12, 104);
            this.btnPluginInfo.Name = "btnPluginInfo";
            this.btnPluginInfo.Size = new System.Drawing.Size(75, 23);
            this.btnPluginInfo.TabIndex = 2;
            this.btnPluginInfo.Text = "插件信息";
            this.btnPluginInfo.Click += new System.EventHandler(this.btnPluginInfo_Click);
            // 
            // btnUninst
            // 
            this.btnUninst.Location = new System.Drawing.Point(12, 56);
            this.btnUninst.Name = "btnUninst";
            this.btnUninst.Size = new System.Drawing.Size(75, 23);
            this.btnUninst.TabIndex = 1;
            this.btnUninst.Text = "卸载插件";
            this.btnUninst.Click += new System.EventHandler(this.btnUninst_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "导入插件";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmPluginMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 435);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPluginMan";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "插件管理";
            this.Load += new System.EventHandler(this.frmPluginMan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxMenu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRightClear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRightAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLeftClear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLeftAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckEdit checkEditLeftAll;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDele;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListRight;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListLeft;
        private DevExpress.XtraEditors.SimpleButton btnPluginInfo;
        private DevExpress.XtraEditors.SimpleButton btnUninst;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.CheckEdit checkEditRightClear;
        private DevExpress.XtraEditors.CheckEdit checkEditRightAll;
        private DevExpress.XtraEditors.CheckEdit checkEditLeftClear;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxMenu;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxGroup;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxPage;
    }
}