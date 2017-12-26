namespace GFS.Classification
{
    partial class frmMosaic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMosaic));
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.labelCilp = new DevExpress.XtraEditors.LabelControl();
            this.siBDown = new DevExpress.XtraEditors.SimpleButton();
            this.siBUp = new DevExpress.XtraEditors.SimpleButton();
            this.siBshow = new DevExpress.XtraEditors.SimpleButton();
            this.siBdelete = new DevExpress.XtraEditors.SimpleButton();
            this.siBHelpShow = new DevExpress.XtraEditors.SimpleButton();
            this.siBConcel = new DevExpress.XtraEditors.SimpleButton();
            this.siBOK = new DevExpress.XtraEditors.SimpleButton();
            this.chkUpload = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.siBAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.listDataSet = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cmbPixelType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpload.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPixelType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(76, 36);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(297, 20);
            this.txtOut.TabIndex = 57;
            // 
            // labelCilp
            // 
            this.labelCilp.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCilp.Location = new System.Drawing.Point(496, 18);
            this.labelCilp.Name = "labelCilp";
            this.labelCilp.Size = new System.Drawing.Size(80, 23);
            this.labelCilp.TabIndex = 52;
            this.labelCilp.Text = "图像拼接";
            // 
            // siBDown
            // 
            this.siBDown.Image = ((System.Drawing.Image)(resources.GetObject("siBDown.Image")));
            this.siBDown.ImageIndex = 1;
            this.siBDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBDown.Location = new System.Drawing.Point(381, 122);
            this.siBDown.Name = "siBDown";
            this.siBDown.Size = new System.Drawing.Size(20, 32);
            this.siBDown.TabIndex = 51;
            this.siBDown.Click += new System.EventHandler(this.siBDown_Click);
            // 
            // siBUp
            // 
            this.siBUp.Image = ((System.Drawing.Image)(resources.GetObject("siBUp.Image")));
            this.siBUp.ImageIndex = 0;
            this.siBUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBUp.Location = new System.Drawing.Point(381, 84);
            this.siBUp.Name = "siBUp";
            this.siBUp.Size = new System.Drawing.Size(20, 32);
            this.siBUp.TabIndex = 50;
            this.siBUp.Click += new System.EventHandler(this.siBUp_Click);
            // 
            // siBshow
            // 
            this.siBshow.Image = ((System.Drawing.Image)(resources.GetObject("siBshow.Image")));
            this.siBshow.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBshow.Location = new System.Drawing.Point(75, 31);
            this.siBshow.Name = "siBshow";
            this.siBshow.Size = new System.Drawing.Size(24, 24);
            this.siBshow.TabIndex = 43;
            this.siBshow.Visible = false;
            // 
            // siBdelete
            // 
            this.siBdelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("siBdelete.BackgroundImage")));
            this.siBdelete.Image = ((System.Drawing.Image)(resources.GetObject("siBdelete.Image")));
            this.siBdelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBdelete.Location = new System.Drawing.Point(44, 31);
            this.siBdelete.Name = "siBdelete";
            this.siBdelete.Size = new System.Drawing.Size(24, 24);
            this.siBdelete.TabIndex = 44;
            this.siBdelete.Click += new System.EventHandler(this.siBdelete_Click);
            // 
            // siBHelpShow
            // 
            this.siBHelpShow.ImageIndex = 2;
            this.siBHelpShow.Location = new System.Drawing.Point(336, 401);
            this.siBHelpShow.Name = "siBHelpShow";
            this.siBHelpShow.Size = new System.Drawing.Size(78, 25);
            this.siBHelpShow.TabIndex = 49;
            this.siBHelpShow.Text = "显示帮助>>";
            this.siBHelpShow.Click += new System.EventHandler(this.siBHelpShow_Click);
            // 
            // siBConcel
            // 
            this.siBConcel.ImageIndex = 2;
            this.siBConcel.Location = new System.Drawing.Point(239, 401);
            this.siBConcel.Name = "siBConcel";
            this.siBConcel.Size = new System.Drawing.Size(78, 25);
            this.siBConcel.TabIndex = 48;
            this.siBConcel.Text = "取消";
            this.siBConcel.Click += new System.EventHandler(this.siBConcel_Click);
            // 
            // siBOK
            // 
            this.siBOK.ImageIndex = 2;
            this.siBOK.Location = new System.Drawing.Point(140, 401);
            this.siBOK.Name = "siBOK";
            this.siBOK.Size = new System.Drawing.Size(78, 25);
            this.siBOK.TabIndex = 47;
            this.siBOK.Text = "确定";
            this.siBOK.Click += new System.EventHandler(this.siBOK_Click);
            // 
            // chkUpload
            // 
            this.chkUpload.Location = new System.Drawing.Point(76, 72);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Properties.Caption = "结果上传至服务器";
            this.chkUpload.Size = new System.Drawing.Size(119, 19);
            this.chkUpload.TabIndex = 46;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "输出结果";
            // 
            // siBAdd
            // 
            this.siBAdd.Image = ((System.Drawing.Image)(resources.GetObject("siBAdd.Image")));
            this.siBAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.siBAdd.Location = new System.Drawing.Point(14, 31);
            this.siBAdd.Name = "siBAdd";
            this.siBAdd.Size = new System.Drawing.Size(24, 24);
            this.siBAdd.TabIndex = 40;
            this.siBAdd.Click += new System.EventHandler(this.siBAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(381, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 55;
            this.btnSave.Click += new System.EventHandler(this.siBPath_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Controls.Add(this.listDataSet);
            this.groupControl1.Controls.Add(this.siBUp);
            this.groupControl1.Controls.Add(this.siBDown);
            this.groupControl1.Controls.Add(this.siBAdd);
            this.groupControl1.Controls.Add(this.siBdelete);
            this.groupControl1.Controls.Add(this.siBshow);
            this.groupControl1.Location = new System.Drawing.Point(10, 18);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(412, 191);
            this.groupControl1.TabIndex = 67;
            this.groupControl1.Text = "拼接影像集";
            // 
            // btnPreview
            // 
            this.btnPreview.ImageIndex = 2;
            this.btnPreview.Location = new System.Drawing.Point(334, 31);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(39, 24);
            this.btnPreview.TabIndex = 72;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // listDataSet
            // 
            this.listDataSet.Location = new System.Drawing.Point(14, 61);
            this.listDataSet.Name = "listDataSet";
            this.listDataSet.Size = new System.Drawing.Size(359, 115);
            this.listDataSet.TabIndex = 67;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.txtOut);
            this.groupControl2.Controls.Add(this.chkUpload);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(10, 288);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(412, 102);
            this.groupControl2.TabIndex = 68;
            this.groupControl2.Text = "拼接结果";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(2, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(217, 348);
            this.labelControl2.TabIndex = 69;
            this.labelControl2.Text = "将多个栅格数据集\r\n拼接成一个新的栅格数据集。";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Location = new System.Drawing.Point(437, 18);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(221, 372);
            this.groupControl3.TabIndex = 70;
            this.groupControl3.Text = "图像拼接帮助";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.cmbPixelType);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Location = new System.Drawing.Point(10, 215);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(412, 67);
            this.groupControl4.TabIndex = 71;
            this.groupControl4.Text = "参数设置";
            // 
            // cmbPixelType
            // 
            this.cmbPixelType.Location = new System.Drawing.Point(76, 32);
            this.cmbPixelType.Name = "cmbPixelType";
            this.cmbPixelType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPixelType.Size = new System.Drawing.Size(226, 20);
            this.cmbPixelType.TabIndex = 58;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 41;
            this.labelControl3.Text = "像素类型";
            // 
            // frmMosaic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 433);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelCilp);
            this.Controls.Add(this.siBHelpShow);
            this.Controls.Add(this.siBConcel);
            this.Controls.Add(this.siBOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 462);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 462);
            this.Name = "frmMosaic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图像拼接";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMosaic_HelpButtonClicked);
            this.Load += new System.EventHandler(this.mosaic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpload.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPixelType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.LabelControl labelCilp;
        private DevExpress.XtraEditors.SimpleButton siBDown;
        private DevExpress.XtraEditors.SimpleButton siBUp;
        private DevExpress.XtraEditors.SimpleButton siBshow;
        private DevExpress.XtraEditors.SimpleButton siBdelete;
        private DevExpress.XtraEditors.SimpleButton siBHelpShow;
        private DevExpress.XtraEditors.SimpleButton siBConcel;
        private DevExpress.XtraEditors.SimpleButton siBOK;
        private DevExpress.XtraEditors.CheckEdit chkUpload;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton siBAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPixelType;
        private DevExpress.XtraEditors.ListBoxControl listDataSet;
        private DevExpress.XtraEditors.SimpleButton btnPreview;

        // private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridcview;

    }
}

