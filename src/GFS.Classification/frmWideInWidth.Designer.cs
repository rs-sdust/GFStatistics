namespace GFS.Classification
{
    partial class frmWideInWidth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWideInWidth));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbInSample = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnInSample = new DevExpress.XtraEditors.SimpleButton();
            this.cmbInImg = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnInImg = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInSample.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInImg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbInSample);
            this.groupControl1.Controls.Add(this.btnInSample);
            this.groupControl1.Controls.Add(this.cmbInImg);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnInImg);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 113);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "输入";
            // 
            // cmbInSample
            // 
            this.cmbInSample.Location = new System.Drawing.Point(116, 75);
            this.cmbInSample.Name = "cmbInSample";
            this.cmbInSample.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInSample.Size = new System.Drawing.Size(290, 20);
            this.cmbInSample.TabIndex = 8;
            this.cmbInSample.TextChanged += new System.EventHandler(this.cmbInSample_TextChanged);
            // 
            // btnInSample
            // 
            this.btnInSample.Image = ((System.Drawing.Image)(resources.GetObject("btnInSample.Image")));
            this.btnInSample.Location = new System.Drawing.Point(426, 73);
            this.btnInSample.Name = "btnInSample";
            this.btnInSample.Size = new System.Drawing.Size(24, 24);
            this.btnInSample.TabIndex = 7;
            this.btnInSample.Click += new System.EventHandler(this.btnInSample_Click);
            // 
            // cmbInImg
            // 
            this.cmbInImg.Location = new System.Drawing.Point(116, 35);
            this.cmbInImg.Name = "cmbInImg";
            this.cmbInImg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInImg.Size = new System.Drawing.Size(290, 20);
            this.cmbInImg.TabIndex = 8;
            this.cmbInImg.TextChanged += new System.EventHandler(this.cmbInImg_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "样本文件";
            // 
            // btnInImg
            // 
            this.btnInImg.Image = ((System.Drawing.Image)(resources.GetObject("btnInImg.Image")));
            this.btnInImg.Location = new System.Drawing.Point(426, 33);
            this.btnInImg.Name = "btnInImg";
            this.btnInImg.Size = new System.Drawing.Size(24, 24);
            this.btnInImg.TabIndex = 7;
            this.btnInImg.Click += new System.EventHandler(this.btnInImg_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "中分宽幅影像";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(387, 237);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(276, 237);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtOut);
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(12, 131);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(472, 77);
            this.groupControl3.TabIndex = 7;
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
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "结果文件";
            // 
            // frmWideInWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 294);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 333);
            this.Name = "frmWideInWidth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "中分宽幅作物识别";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmWideInWidth_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmWideInWidth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInSample.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInImg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInSample;
        private DevExpress.XtraEditors.SimpleButton btnInSample;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInImg;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnInImg;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}