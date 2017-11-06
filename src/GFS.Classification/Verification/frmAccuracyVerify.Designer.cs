namespace GFS.Classification
{
    partial class frmAccuracyVerify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccuracyVerify));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbClassFile = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnClass = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtSample = new DevExpress.XtraEditors.TextEdit();
            this.btnSample = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelCilp1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSample.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbClassFile);
            this.groupControl1.Controls.Add(this.btnClass);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(11, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(435, 80);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "输入";
            // 
            // cmbClassFile
            // 
            this.cmbClassFile.Location = new System.Drawing.Point(102, 40);
            this.cmbClassFile.Name = "cmbClassFile";
            this.cmbClassFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClassFile.Size = new System.Drawing.Size(269, 20);
            this.cmbClassFile.TabIndex = 5;
            this.cmbClassFile.SelectedIndexChanged += new System.EventHandler(this.cmbClassFile_SelectedIndexChanged);
            // 
            // btnClass
            // 
            this.btnClass.Image = ((System.Drawing.Image)(resources.GetObject("btnClass.Image")));
            this.btnClass.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClass.Location = new System.Drawing.Point(389, 38);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(24, 24);
            this.btnClass.TabIndex = 1;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(20, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "分类结果";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtOut);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.btnOut);
            this.groupControl2.Location = new System.Drawing.Point(11, 184);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(435, 80);
            this.groupControl2.TabIndex = 24;
            this.groupControl2.Text = "输出";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(102, 41);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(269, 20);
            this.txtOut.TabIndex = 11;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(20, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "输出结果";
            // 
            // btnOut
            // 
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageIndex = 0;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOut.Location = new System.Drawing.Point(389, 39);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(24, 24);
            this.btnOut.TabIndex = 9;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtSample);
            this.groupControl3.Controls.Add(this.btnSample);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Location = new System.Drawing.Point(11, 98);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(435, 80);
            this.groupControl3.TabIndex = 24;
            this.groupControl3.Text = "输入";
            // 
            // txtSample
            // 
            this.txtSample.Location = new System.Drawing.Point(102, 40);
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(269, 20);
            this.txtSample.TabIndex = 12;
            // 
            // btnSample
            // 
            this.btnSample.Image = ((System.Drawing.Image)(resources.GetObject("btnSample.Image")));
            this.btnSample.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSample.Location = new System.Drawing.Point(389, 38);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(24, 24);
            this.btnSample.TabIndex = 1;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(20, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 25);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "检验样本";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(349, 287);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 27;
            this.btnHelp.Text = "显示帮助>>";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(259, 287);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 26;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(168, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.labelCilp1);
            this.groupControl4.Location = new System.Drawing.Point(455, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(283, 252);
            this.groupControl4.TabIndex = 28;
            this.groupControl4.Text = "精度验证";
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
            this.labelCilp1.Size = new System.Drawing.Size(279, 228);
            this.labelCilp1.TabIndex = 20;
            // 
            // frmAccuracyVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 328);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(763, 367);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(471, 367);
            this.Name = "frmAccuracyVerify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "精度验证";
            this.Load += new System.EventHandler(this.frmAccuracyVerify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSample.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClassFile;
        private DevExpress.XtraEditors.SimpleButton btnClass;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtSample;
        private DevExpress.XtraEditors.SimpleButton btnSample;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelCilp1;
    }
}