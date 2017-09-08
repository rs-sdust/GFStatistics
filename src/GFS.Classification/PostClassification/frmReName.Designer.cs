namespace GFS.Classification
{
    partial class frmReName
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LiBCname = new DevExpress.XtraEditors.ListBoxControl();
            this.LiBCNewName = new DevExpress.XtraEditors.ListBoxControl();
            this.siBReset = new DevExpress.XtraEditors.SimpleButton();
            this.siBConcel = new DevExpress.XtraEditors.SimpleButton();
            this.siBOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.LiBCname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiBCNewName)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 25);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "原分类名称：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(202, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 25);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "新分类名称：";
            // 
            // LiBCname
            // 
            this.LiBCname.Location = new System.Drawing.Point(12, 37);
            this.LiBCname.Name = "LiBCname";
            this.LiBCname.Size = new System.Drawing.Size(165, 156);
            this.LiBCname.TabIndex = 17;
            // 
            // LiBCNewName
            // 
            this.LiBCNewName.Location = new System.Drawing.Point(202, 37);
            this.LiBCNewName.Name = "LiBCNewName";
            this.LiBCNewName.Size = new System.Drawing.Size(168, 156);
            this.LiBCNewName.TabIndex = 18;
            // 
            // siBReset
            // 
            this.siBReset.ImageIndex = 2;
            this.siBReset.Location = new System.Drawing.Point(24, 233);
            this.siBReset.Name = "siBReset";
            this.siBReset.Size = new System.Drawing.Size(78, 25);
            this.siBReset.TabIndex = 58;
            this.siBReset.Text = "重置";
            this.siBReset.Click += new System.EventHandler(this.siBReset_Click);
            // 
            // siBConcel
            // 
            this.siBConcel.ImageIndex = 2;
            this.siBConcel.Location = new System.Drawing.Point(271, 233);
            this.siBConcel.Name = "siBConcel";
            this.siBConcel.Size = new System.Drawing.Size(78, 25);
            this.siBConcel.TabIndex = 57;
            this.siBConcel.Text = "取消";
            this.siBConcel.Click += new System.EventHandler(this.siBConcel_Click);
            // 
            // siBOK
            // 
            this.siBOK.ImageIndex = 2;
            this.siBOK.Location = new System.Drawing.Point(158, 233);
            this.siBOK.Name = "siBOK";
            this.siBOK.Size = new System.Drawing.Size(78, 25);
            this.siBOK.TabIndex = 56;
            this.siBOK.Text = "确定";
            this.siBOK.Click += new System.EventHandler(this.siBOK_Click);
            // 
            // frmReName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 282);
            this.Controls.Add(this.siBReset);
            this.Controls.Add(this.siBConcel);
            this.Controls.Add(this.siBOK);
            this.Controls.Add(this.LiBCNewName);
            this.Controls.Add(this.LiBCname);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 310);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 310);
            this.Name = "frmReName";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "重编码";
            ((System.ComponentModel.ISupportInitialize)(this.LiBCname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiBCNewName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ListBoxControl LiBCname;
        private DevExpress.XtraEditors.ListBoxControl LiBCNewName;
        private DevExpress.XtraEditors.SimpleButton siBReset;
        private DevExpress.XtraEditors.SimpleButton siBConcel;
        private DevExpress.XtraEditors.SimpleButton siBOK;

    }
}