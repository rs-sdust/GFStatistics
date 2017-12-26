namespace GFS.Classification
{
    partial class frmGF3Classification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGF3Classification));
            this.cmbInROIPixel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnInROIPixel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbInROIFeature = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnInROIFeature = new DevExpress.XtraEditors.SimpleButton();
            this.cmbInGF1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnInGF1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbInGF3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnInGF3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelCilp1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInROIPixel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInROIFeature.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInGF1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInGF3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbInROIPixel
            // 
            this.cmbInROIPixel.Location = new System.Drawing.Point(116, 160);
            this.cmbInROIPixel.Name = "cmbInROIPixel";
            this.cmbInROIPixel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInROIPixel.Size = new System.Drawing.Size(290, 20);
            this.cmbInROIPixel.TabIndex = 8;
            this.cmbInROIPixel.TextChanged += new System.EventHandler(this.cmbInROIPixel_TextChanged);
            // 
            // btnOut
            // 
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageIndex = 0;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOut.Location = new System.Drawing.Point(426, 36);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(24, 24);
            this.btnOut.TabIndex = 12;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(276, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnInROIPixel
            // 
            this.btnInROIPixel.Image = ((System.Drawing.Image)(resources.GetObject("btnInROIPixel.Image")));
            this.btnInROIPixel.Location = new System.Drawing.Point(426, 158);
            this.btnInROIPixel.Name = "btnInROIPixel";
            this.btnInROIPixel.Size = new System.Drawing.Size(24, 24);
            this.btnInROIPixel.TabIndex = 7;
            this.btnInROIPixel.Click += new System.EventHandler(this.btnInROIPixel_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtOut);
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(12, 216);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(472, 77);
            this.groupControl3.TabIndex = 11;
            this.groupControl3.Text = "输出";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(116, 38);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(290, 20);
            this.txtOut.TabIndex = 13;
            this.txtOut.TextChanged += new System.EventHandler(this.txtOut_TextChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "结果文件";
            // 
            // cmbInROIFeature
            // 
            this.cmbInROIFeature.Location = new System.Drawing.Point(116, 118);
            this.cmbInROIFeature.Name = "cmbInROIFeature";
            this.cmbInROIFeature.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInROIFeature.Size = new System.Drawing.Size(290, 20);
            this.cmbInROIFeature.TabIndex = 8;
            this.cmbInROIFeature.TextChanged += new System.EventHandler(this.cmbInROIFeature_TextChanged);
            // 
            // btnInROIFeature
            // 
            this.btnInROIFeature.Image = ((System.Drawing.Image)(resources.GetObject("btnInROIFeature.Image")));
            this.btnInROIFeature.Location = new System.Drawing.Point(426, 116);
            this.btnInROIFeature.Name = "btnInROIFeature";
            this.btnInROIFeature.Size = new System.Drawing.Size(24, 24);
            this.btnInROIFeature.TabIndex = 7;
            this.btnInROIFeature.Click += new System.EventHandler(this.btnInROIFeature_Click);
            // 
            // cmbInGF1
            // 
            this.cmbInGF1.Location = new System.Drawing.Point(116, 75);
            this.cmbInGF1.Name = "cmbInGF1";
            this.cmbInGF1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInGF1.Size = new System.Drawing.Size(290, 20);
            this.cmbInGF1.TabIndex = 8;
            this.cmbInGF1.TextChanged += new System.EventHandler(this.cmbInGF1_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 163);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "像元样本";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(387, 322);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 13;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnInGF1
            // 
            this.btnInGF1.Image = ((System.Drawing.Image)(resources.GetObject("btnInGF1.Image")));
            this.btnInGF1.Location = new System.Drawing.Point(426, 73);
            this.btnInGF1.Name = "btnInGF1";
            this.btnInGF1.Size = new System.Drawing.Size(24, 24);
            this.btnInGF1.TabIndex = 7;
            this.btnInGF1.Click += new System.EventHandler(this.btnInGF1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 121);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "图斑样本";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbInROIPixel);
            this.groupControl1.Controls.Add(this.btnInROIPixel);
            this.groupControl1.Controls.Add(this.cmbInROIFeature);
            this.groupControl1.Controls.Add(this.btnInROIFeature);
            this.groupControl1.Controls.Add(this.cmbInGF1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnInGF1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cmbInGF3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnInGF3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 198);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "输入";
            // 
            // cmbInGF3
            // 
            this.cmbInGF3.Location = new System.Drawing.Point(116, 35);
            this.cmbInGF3.Name = "cmbInGF3";
            this.cmbInGF3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInGF3.Size = new System.Drawing.Size(290, 20);
            this.cmbInGF3.TabIndex = 8;
            this.cmbInGF3.TextChanged += new System.EventHandler(this.cmbInGF3_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "GF1分割影像";
            // 
            // btnInGF3
            // 
            this.btnInGF3.Image = ((System.Drawing.Image)(resources.GetObject("btnInGF3.Image")));
            this.btnInGF3.Location = new System.Drawing.Point(426, 33);
            this.btnInGF3.Name = "btnInGF3";
            this.btnInGF3.Size = new System.Drawing.Size(24, 24);
            this.btnInGF3.TabIndex = 7;
            this.btnInGF3.Click += new System.EventHandler(this.btnInGF3_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "GF3极化特征影像";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.labelCilp1);
            this.groupControl4.Location = new System.Drawing.Point(490, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(283, 333);
            this.groupControl4.TabIndex = 29;
            this.groupControl4.Text = "图斑像元综合分类";
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
            this.labelCilp1.Size = new System.Drawing.Size(279, 309);
            this.labelCilp1.TabIndex = 20;
            this.labelCilp1.Text = "该功能以GF-1（或者GF-2）为基础，\r\n支撑作物生长期内的多时相GF-3雷达\r\n卫星数据，采用极化分解、面向对象\r\n分割方法以及纯净/混合图斑分类的方\r\n法，" +
                "进行作物的提取";
            // 
            // frmGF3Classification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 369);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(796, 408);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(508, 408);
            this.Name = "frmGF3Classification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图斑像元综合分类";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmGF3Classification_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmGF3Classification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbInROIPixel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInROIFeature.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInGF1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInGF3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmbInROIPixel;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnInROIPixel;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInROIFeature;
        private DevExpress.XtraEditors.SimpleButton btnInROIFeature;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInGF1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnInGF1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInGF3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnInGF3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelCilp1;

    }
}