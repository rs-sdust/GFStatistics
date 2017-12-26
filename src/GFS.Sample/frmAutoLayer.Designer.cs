namespace GFS.Sample
{
    partial class frmAutoLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoLayer));
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.spinLyrNum = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLyrField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnUnit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinLyrNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLyrField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFUnit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.spinLyrNum);
            this.groupControl4.Controls.Add(this.labelControl2);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Controls.Add(this.cmbLyrField);
            this.groupControl4.Controls.Add(this.cmbFUnit);
            this.groupControl4.Controls.Add(this.btnUnit);
            this.groupControl4.Controls.Add(this.labelControl5);
            this.groupControl4.Location = new System.Drawing.Point(12, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(472, 163);
            this.groupControl4.TabIndex = 28;
            this.groupControl4.Text = "输入";
            // 
            // spinLyrNum
            // 
            this.spinLyrNum.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinLyrNum.Location = new System.Drawing.Point(102, 117);
            this.spinLyrNum.Name = "spinLyrNum";
            this.spinLyrNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinLyrNum.Size = new System.Drawing.Size(100, 20);
            this.spinLyrNum.TabIndex = 14;
            this.spinLyrNum.EditValueChanged += new System.EventHandler(this.spinLyrNum_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(35, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 25);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "分层数";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(35, 77);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 25);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "分层指标";
            // 
            // cmbLyrField
            // 
            this.cmbLyrField.Location = new System.Drawing.Point(102, 79);
            this.cmbLyrField.Name = "cmbLyrField";
            this.cmbLyrField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLyrField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbLyrField.Size = new System.Drawing.Size(100, 20);
            this.cmbLyrField.TabIndex = 12;
            this.cmbLyrField.SelectedIndexChanged += new System.EventHandler(this.cmbLyrField_SelectedIndexChanged);
            // 
            // cmbFUnit
            // 
            this.cmbFUnit.Location = new System.Drawing.Point(102, 43);
            this.cmbFUnit.Name = "cmbFUnit";
            this.cmbFUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFUnit.Size = new System.Drawing.Size(303, 20);
            this.cmbFUnit.TabIndex = 5;
            this.cmbFUnit.SelectedIndexChanged += new System.EventHandler(this.cmbFUnit_SelectedIndexChanged);
            this.cmbFUnit.TextChanged += new System.EventHandler(this.cmbFUnit_TextChanged);
            // 
            // btnUnit
            // 
            this.btnUnit.Image = ((System.Drawing.Image)(resources.GetObject("btnUnit.Image")));
            this.btnUnit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUnit.Location = new System.Drawing.Point(424, 41);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(24, 24);
            this.btnUnit.TabIndex = 1;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(35, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 25);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "入样总体";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(292, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(385, 203);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 29;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmAutoLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 250);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupControl4);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 289);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 289);
            this.Name = "frmAutoLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自动分层";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmAutoLayer_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmAutoLayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinLyrNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLyrField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFUnit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLyrField;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFUnit;
        private DevExpress.XtraEditors.SimpleButton btnUnit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinLyrNum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
    }
}