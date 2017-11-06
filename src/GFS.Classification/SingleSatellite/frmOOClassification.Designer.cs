namespace GFS.Classification
{
    partial class frmOOClassification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOOClassification));
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkHyperbolic = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.chkLogistic = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.spinCriteria = new DevExpress.XtraEditors.SpinEdit();
            this.ztbCriteria = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinContribution = new DevExpress.XtraEditors.SpinEdit();
            this.ztbMomentum = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.ztbTraingRate = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinMomentum = new DevExpress.XtraEditors.SpinEdit();
            this.spinTraingRate = new DevExpress.XtraEditors.SpinEdit();
            this.ztbContribution = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.btnMore = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtROI = new DevExpress.XtraEditors.TextEdit();
            this.btnInROI = new DevExpress.XtraEditors.SimpleButton();
            this.cmbInRaster = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnInRaster = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHyperbolic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLogistic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCriteria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbCriteria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbCriteria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinContribution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMomentum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbTraingRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbTraingRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMomentum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTraingRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbContribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbContribution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInRaster.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(288, 436);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(183, 436);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Controls.Add(this.txtOut);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(12, 340);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(360, 77);
            this.groupControl3.TabIndex = 7;
            this.groupControl3.Text = "输出";
            // 
            // btnOut
            // 
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageIndex = 0;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOut.Location = new System.Drawing.Point(320, 33);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(24, 24);
            this.btnOut.TabIndex = 15;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(94, 35);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(219, 20);
            this.txtOut.TabIndex = 14;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "分类结果";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Controls.Add(this.btnMore);
            this.groupControl2.Location = new System.Drawing.Point(12, 123);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(360, 211);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "参数设置";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkHyperbolic);
            this.panelControl1.Controls.Add(this.labelControl17);
            this.panelControl1.Controls.Add(this.chkLogistic);
            this.panelControl1.Controls.Add(this.labelControl18);
            this.panelControl1.Controls.Add(this.labelControl16);
            this.panelControl1.Controls.Add(this.spinCriteria);
            this.panelControl1.Controls.Add(this.ztbCriteria);
            this.panelControl1.Controls.Add(this.spinContribution);
            this.panelControl1.Controls.Add(this.ztbMomentum);
            this.panelControl1.Controls.Add(this.labelControl19);
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Controls.Add(this.ztbTraingRate);
            this.panelControl1.Controls.Add(this.spinMomentum);
            this.panelControl1.Controls.Add(this.spinTraingRate);
            this.panelControl1.Controls.Add(this.ztbContribution);
            this.panelControl1.Location = new System.Drawing.Point(7, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(344, 153);
            this.panelControl1.TabIndex = 19;
            // 
            // chkHyperbolic
            // 
            this.chkHyperbolic.Location = new System.Drawing.Point(201, 8);
            this.chkHyperbolic.Name = "chkHyperbolic";
            this.chkHyperbolic.Properties.Caption = "Hyperbolic";
            this.chkHyperbolic.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkHyperbolic.Size = new System.Drawing.Size(80, 19);
            this.chkHyperbolic.TabIndex = 6;
            this.chkHyperbolic.CheckedChanged += new System.EventHandler(this.chkHyperbolic_CheckedChanged);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(6, 94);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(48, 14);
            this.labelControl17.TabIndex = 2;
            this.labelControl17.Text = "训练动量";
            // 
            // chkLogistic
            // 
            this.chkLogistic.EditValue = true;
            this.chkLogistic.Location = new System.Drawing.Point(88, 8);
            this.chkLogistic.Name = "chkLogistic";
            this.chkLogistic.Properties.Caption = "Logistic";
            this.chkLogistic.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkLogistic.Size = new System.Drawing.Size(75, 19);
            this.chkLogistic.TabIndex = 5;
            this.chkLogistic.CheckedChanged += new System.EventHandler(this.chkLogistic_CheckedChanged);
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(6, 65);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(36, 14);
            this.labelControl18.TabIndex = 2;
            this.labelControl18.Text = "训练率";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(6, 11);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(48, 14);
            this.labelControl16.TabIndex = 4;
            this.labelControl16.Text = "激活方法";
            // 
            // spinCriteria
            // 
            this.spinCriteria.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinCriteria.Location = new System.Drawing.Point(286, 122);
            this.spinCriteria.Name = "spinCriteria";
            this.spinCriteria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinCriteria.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinCriteria.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinCriteria.Size = new System.Drawing.Size(50, 20);
            this.spinCriteria.TabIndex = 6;
            this.spinCriteria.EditValueChanged += new System.EventHandler(this.spinCriteria_EditValueChanged);
            // 
            // ztbCriteria
            // 
            this.ztbCriteria.EditValue = null;
            this.ztbCriteria.Location = new System.Drawing.Point(87, 123);
            this.ztbCriteria.Name = "ztbCriteria";
            this.ztbCriteria.Properties.Middle = 5;
            this.ztbCriteria.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbCriteria.Size = new System.Drawing.Size(194, 23);
            this.ztbCriteria.TabIndex = 8;
            this.ztbCriteria.EditValueChanged += new System.EventHandler(this.ztbCriteria_EditValueChanged);
            // 
            // spinContribution
            // 
            this.spinContribution.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinContribution.Location = new System.Drawing.Point(286, 35);
            this.spinContribution.Name = "spinContribution";
            this.spinContribution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinContribution.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinContribution.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinContribution.Size = new System.Drawing.Size(50, 20);
            this.spinContribution.TabIndex = 1;
            this.spinContribution.EditValueChanged += new System.EventHandler(this.spinContribution_EditValueChanged);
            // 
            // ztbMomentum
            // 
            this.ztbMomentum.EditValue = null;
            this.ztbMomentum.Location = new System.Drawing.Point(87, 94);
            this.ztbMomentum.Name = "ztbMomentum";
            this.ztbMomentum.Properties.Middle = 5;
            this.ztbMomentum.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbMomentum.Size = new System.Drawing.Size(194, 23);
            this.ztbMomentum.TabIndex = 2;
            this.ztbMomentum.EditValueChanged += new System.EventHandler(this.ztbMomentum_EditValueChanged);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(6, 36);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(48, 14);
            this.labelControl19.TabIndex = 2;
            this.labelControl19.Text = "训练阈值";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(6, 123);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(72, 14);
            this.labelControl15.TabIndex = 7;
            this.labelControl15.Text = "训练误差标准";
            // 
            // ztbTraingRate
            // 
            this.ztbTraingRate.EditValue = null;
            this.ztbTraingRate.Location = new System.Drawing.Point(87, 65);
            this.ztbTraingRate.Name = "ztbTraingRate";
            this.ztbTraingRate.Properties.Middle = 5;
            this.ztbTraingRate.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbTraingRate.Size = new System.Drawing.Size(194, 23);
            this.ztbTraingRate.TabIndex = 2;
            this.ztbTraingRate.EditValueChanged += new System.EventHandler(this.ztbTraingRate_EditValueChanged);
            // 
            // spinMomentum
            // 
            this.spinMomentum.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMomentum.Location = new System.Drawing.Point(286, 93);
            this.spinMomentum.Name = "spinMomentum";
            this.spinMomentum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMomentum.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinMomentum.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinMomentum.Size = new System.Drawing.Size(50, 20);
            this.spinMomentum.TabIndex = 1;
            this.spinMomentum.EditValueChanged += new System.EventHandler(this.spinMomentum_EditValueChanged);
            // 
            // spinTraingRate
            // 
            this.spinTraingRate.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinTraingRate.Location = new System.Drawing.Point(286, 64);
            this.spinTraingRate.Name = "spinTraingRate";
            this.spinTraingRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinTraingRate.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinTraingRate.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinTraingRate.Size = new System.Drawing.Size(50, 20);
            this.spinTraingRate.TabIndex = 1;
            this.spinTraingRate.EditValueChanged += new System.EventHandler(this.spinTraingRate_EditValueChanged);
            // 
            // ztbContribution
            // 
            this.ztbContribution.EditValue = null;
            this.ztbContribution.Location = new System.Drawing.Point(87, 36);
            this.ztbContribution.Name = "ztbContribution";
            this.ztbContribution.Properties.Middle = 5;
            this.ztbContribution.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbContribution.Size = new System.Drawing.Size(194, 23);
            this.ztbContribution.TabIndex = 2;
            this.ztbContribution.EditValueChanged += new System.EventHandler(this.ztbContribution_EditValueChanged);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(286, 183);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(65, 23);
            this.btnMore.TabIndex = 19;
            this.btnMore.Text = "更多设置";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtROI);
            this.groupControl1.Controls.Add(this.btnInROI);
            this.groupControl1.Controls.Add(this.cmbInRaster);
            this.groupControl1.Controls.Add(this.btnInRaster);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(360, 105);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "输入";
            // 
            // txtROI
            // 
            this.txtROI.Location = new System.Drawing.Point(94, 67);
            this.txtROI.Name = "txtROI";
            this.txtROI.Size = new System.Drawing.Size(219, 20);
            this.txtROI.TabIndex = 12;
            // 
            // btnInROI
            // 
            this.btnInROI.Image = ((System.Drawing.Image)(resources.GetObject("btnInROI.Image")));
            this.btnInROI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnInROI.Location = new System.Drawing.Point(318, 65);
            this.btnInROI.Name = "btnInROI";
            this.btnInROI.Size = new System.Drawing.Size(24, 24);
            this.btnInROI.TabIndex = 11;
            this.btnInROI.Click += new System.EventHandler(this.btnInROI_Click);
            // 
            // cmbInRaster
            // 
            this.cmbInRaster.Location = new System.Drawing.Point(95, 35);
            this.cmbInRaster.Name = "cmbInRaster";
            this.cmbInRaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInRaster.Size = new System.Drawing.Size(219, 20);
            this.cmbInRaster.TabIndex = 10;
            // 
            // btnInRaster
            // 
            this.btnInRaster.Image = ((System.Drawing.Image)(resources.GetObject("btnInRaster.Image")));
            this.btnInRaster.Location = new System.Drawing.Point(320, 33);
            this.btnInRaster.Name = "btnInRaster";
            this.btnInRaster.Size = new System.Drawing.Size(24, 24);
            this.btnInRaster.TabIndex = 9;
            this.btnInRaster.Click += new System.EventHandler(this.btnInRaster_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 70);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "样本文件";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "分割后影像";
            // 
            // frmOOClassification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 471);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 510);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 510);
            this.Name = "frmOOClassification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "面向对象分类";
            this.Load += new System.EventHandler(this.frmOOClassification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHyperbolic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLogistic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCriteria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbCriteria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbCriteria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinContribution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMomentum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbTraingRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbTraingRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMomentum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTraingRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbContribution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbContribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtROI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInRaster.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkHyperbolic;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.CheckEdit chkLogistic;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.SpinEdit spinCriteria;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbCriteria;
        private DevExpress.XtraEditors.SpinEdit spinContribution;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbMomentum;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbTraingRate;
        private DevExpress.XtraEditors.SpinEdit spinMomentum;
        private DevExpress.XtraEditors.SpinEdit spinTraingRate;
        private DevExpress.XtraEditors.SimpleButton btnMore;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ZoomTrackBarControl ztbContribution;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInRaster;
        private DevExpress.XtraEditors.SimpleButton btnInRaster;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.TextEdit txtROI;
        private DevExpress.XtraEditors.SimpleButton btnInROI;
        private DevExpress.XtraEditors.SimpleButton btnOut;
    }
}