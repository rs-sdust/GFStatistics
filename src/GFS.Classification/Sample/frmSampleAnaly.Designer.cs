namespace GFS.Classification
{
    partial class frmSampleAnaly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleAnaly));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbRaster = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtROI = new DevExpress.XtraEditors.TextEdit();
            this.btnOpenROI = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpenRaster = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkListParam = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelCilp1 = new DevExpress.XtraEditors.LabelControl();
            this.labelCilp = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkListParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbRaster);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtROI);
            this.groupControl1.Controls.Add(this.btnOpenROI);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnOpenRaster);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(342, 145);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "输入";
            // 
            // cmbRaster
            // 
            this.cmbRaster.Location = new System.Drawing.Point(84, 46);
            this.cmbRaster.Name = "cmbRaster";
            this.cmbRaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRaster.Size = new System.Drawing.Size(206, 20);
            this.cmbRaster.TabIndex = 6;
            this.cmbRaster.SelectedIndexChanged += new System.EventHandler(this.cmbRaster_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "样本文件：";
            // 
            // txtROI
            // 
            this.txtROI.Location = new System.Drawing.Point(84, 98);
            this.txtROI.Name = "txtROI";
            this.txtROI.Size = new System.Drawing.Size(206, 20);
            this.txtROI.TabIndex = 4;
            // 
            // btnOpenROI
            // 
            this.btnOpenROI.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenROI.Image")));
            this.btnOpenROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOpenROI.Location = new System.Drawing.Point(298, 96);
            this.btnOpenROI.Name = "btnOpenROI";
            this.btnOpenROI.Size = new System.Drawing.Size(24, 24);
            this.btnOpenROI.TabIndex = 3;
            this.btnOpenROI.Click += new System.EventHandler(this.btnOpenROI_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "栅格影像：";
            // 
            // btnOpenRaster
            // 
            this.btnOpenRaster.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenRaster.Image")));
            this.btnOpenRaster.Location = new System.Drawing.Point(298, 44);
            this.btnOpenRaster.Name = "btnOpenRaster";
            this.btnOpenRaster.Size = new System.Drawing.Size(24, 24);
            this.btnOpenRaster.TabIndex = 0;
            this.btnOpenRaster.Click += new System.EventHandler(this.btnOpenRaster_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(188, 322);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(279, 322);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "显示帮助>>";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkListParam);
            this.groupControl2.Location = new System.Drawing.Point(14, 163);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(342, 145);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "选择类别";
            // 
            // chkListParam
            // 
            this.chkListParam.Location = new System.Drawing.Point(16, 35);
            this.chkListParam.Name = "chkListParam";
            this.chkListParam.Size = new System.Drawing.Size(304, 95);
            this.chkListParam.TabIndex = 0;
            this.chkListParam.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkListParam_ItemCheck);
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
            this.labelCilp1.Size = new System.Drawing.Size(242, 272);
            this.labelCilp1.TabIndex = 22;
            this.labelCilp1.Text = "该工具用于统计所选样本类别\r\n像元个数和统计信息等";
            // 
            // labelCilp
            // 
            this.labelCilp.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCilp.Location = new System.Drawing.Point(457, 12);
            this.labelCilp.Name = "labelCilp";
            this.labelCilp.Size = new System.Drawing.Size(80, 23);
            this.labelCilp.TabIndex = 21;
            this.labelCilp.Text = "样本分析";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelCilp1);
            this.groupControl3.Location = new System.Drawing.Point(374, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(246, 296);
            this.groupControl3.TabIndex = 23;
            this.groupControl3.Text = "样本分析帮助";
            // 
            // frmSampleAnaly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 355);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.labelCilp);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(638, 384);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(372, 384);
            this.Name = "frmSampleAnaly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "样本分析";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmSampleAnaly_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmSampleAnaly_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkListParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRaster;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtROI;
        private DevExpress.XtraEditors.SimpleButton btnOpenROI;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpenRaster;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListParam;
        private DevExpress.XtraEditors.LabelControl labelCilp1;
        private DevExpress.XtraEditors.LabelControl labelCilp;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}