namespace GFS.Classification
{
    partial class frmSpatialError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpatialError));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtOut = new DevExpress.XtraEditors.TextEdit();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbInCrop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbInClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnInClass = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInCrop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInClass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(276, 238);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtOut);
            this.groupControl3.Controls.Add(this.btnOut);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Location = new System.Drawing.Point(12, 132);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(472, 77);
            this.groupControl3.TabIndex = 15;
            this.groupControl3.Text = "输出";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(116, 38);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(290, 20);
            this.txtOut.TabIndex = 13;
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
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(387, 238);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 17;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbInCrop);
            this.groupControl1.Controls.Add(this.cmbInClass);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnInClass);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 114);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "输入";
            // 
            // cmbInCrop
            // 
            this.cmbInCrop.Location = new System.Drawing.Point(116, 75);
            this.cmbInCrop.Name = "cmbInCrop";
            this.cmbInCrop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInCrop.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInCrop.Size = new System.Drawing.Size(290, 20);
            this.cmbInCrop.TabIndex = 8;
            this.cmbInCrop.TextChanged += new System.EventHandler(this.cmbInCrop_TextChanged);
            // 
            // cmbInClass
            // 
            this.cmbInClass.Location = new System.Drawing.Point(116, 35);
            this.cmbInClass.Name = "cmbInClass";
            this.cmbInClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInClass.Size = new System.Drawing.Size(290, 20);
            this.cmbInClass.TabIndex = 8;
            this.cmbInClass.TextChanged += new System.EventHandler(this.cmbInClass_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "目标作物";
            // 
            // btnInClass
            // 
            this.btnInClass.Image = ((System.Drawing.Image)(resources.GetObject("btnInClass.Image")));
            this.btnInClass.Location = new System.Drawing.Point(426, 33);
            this.btnInClass.Name = "btnInClass";
            this.btnInClass.Size = new System.Drawing.Size(24, 24);
            this.btnInClass.TabIndex = 7;
            this.btnInClass.Click += new System.EventHandler(this.btnInClass_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "分类结果";
            // 
            // frmSpatialError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 288);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpatialError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "误差空间表达";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmSpatialError_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmSpatialError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInCrop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInClass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtOut;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInCrop;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInClass;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnInClass;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}