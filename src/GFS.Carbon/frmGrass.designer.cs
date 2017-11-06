namespace GFS.Carbon
{
    partial class frmGrass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrass));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnRParenthesis = new DevExpress.XtraEditors.SimpleButton();
            this.btnLParenthesis = new DevExpress.XtraEditors.SimpleButton();
            this.btnDivide = new DevExpress.XtraEditors.SimpleButton();
            this.btnMultiply = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubtract = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelIndex = new DevExpress.XtraEditors.SimpleButton();
            this.txtExpression = new DevExpress.XtraEditors.TextEdit();
            this.listIndex = new DevExpress.XtraEditors.ListBoxControl();
            this.spinCarbonIndex = new DevExpress.XtraEditors.SpinEdit();
            this.btnAddIndex = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLandCover = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLandCover = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtOutCarbon = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutCarbonDensity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnOutCarbon = new DevExpress.XtraEditors.SimpleButton();
            this.txtOutBiology = new DevExpress.XtraEditors.TextEdit();
            this.btnOutCarbonDensity = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnOutBiology = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPixel = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpression.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCarbonIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLandCover.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutCarbon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutCarbonDensity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutBiology.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPixel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbPixel);
            this.groupControl1.Controls.Add(this.btnRParenthesis);
            this.groupControl1.Controls.Add(this.btnLParenthesis);
            this.groupControl1.Controls.Add(this.btnDivide);
            this.groupControl1.Controls.Add(this.btnMultiply);
            this.groupControl1.Controls.Add(this.btnSubtract);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.btnDelIndex);
            this.groupControl1.Controls.Add(this.txtExpression);
            this.groupControl1.Controls.Add(this.listIndex);
            this.groupControl1.Controls.Add(this.spinCarbonIndex);
            this.groupControl1.Controls.Add(this.btnAddIndex);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cmbLandCover);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnLandCover);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 290);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "输入";
            // 
            // btnRParenthesis
            // 
            this.btnRParenthesis.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRParenthesis.Location = new System.Drawing.Point(262, 184);
            this.btnRParenthesis.Name = "btnRParenthesis";
            this.btnRParenthesis.Size = new System.Drawing.Size(24, 24);
            this.btnRParenthesis.TabIndex = 51;
            this.btnRParenthesis.Text = ")";
            this.btnRParenthesis.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // btnLParenthesis
            // 
            this.btnLParenthesis.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLParenthesis.Location = new System.Drawing.Point(234, 184);
            this.btnLParenthesis.Name = "btnLParenthesis";
            this.btnLParenthesis.Size = new System.Drawing.Size(24, 24);
            this.btnLParenthesis.TabIndex = 50;
            this.btnLParenthesis.Text = "(";
            this.btnLParenthesis.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDivide.Location = new System.Drawing.Point(204, 184);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(24, 24);
            this.btnDivide.TabIndex = 49;
            this.btnDivide.Text = " \\ ";
            this.btnDivide.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMultiply.Location = new System.Drawing.Point(174, 184);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(24, 24);
            this.btnMultiply.TabIndex = 48;
            this.btnMultiply.Text = " * ";
            this.btnMultiply.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSubtract.Location = new System.Drawing.Point(144, 184);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(24, 24);
            this.btnSubtract.TabIndex = 47;
            this.btnSubtract.Text = " - ";
            this.btnSubtract.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(114, 184);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = " + ";
            this.btnAdd.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // btnDelIndex
            // 
            this.btnDelIndex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelIndex.BackgroundImage")));
            this.btnDelIndex.Image = ((System.Drawing.Image)(resources.GetObject("btnDelIndex.Image")));
            this.btnDelIndex.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDelIndex.Location = new System.Drawing.Point(414, 143);
            this.btnDelIndex.Name = "btnDelIndex";
            this.btnDelIndex.Size = new System.Drawing.Size(24, 24);
            this.btnDelIndex.TabIndex = 45;
            this.btnDelIndex.Click += new System.EventHandler(this.siBdelete_Click);
            // 
            // txtExpression
            // 
            this.txtExpression.Location = new System.Drawing.Point(114, 214);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(281, 20);
            this.txtExpression.TabIndex = 15;
            // 
            // listIndex
            // 
            this.listIndex.Location = new System.Drawing.Point(114, 102);
            this.listIndex.Name = "listIndex";
            this.listIndex.Size = new System.Drawing.Size(281, 76);
            this.listIndex.TabIndex = 11;
            this.listIndex.DoubleClick += new System.EventHandler(this.listIndex_DoubleClick);
            // 
            // spinCarbonIndex
            // 
            this.spinCarbonIndex.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinCarbonIndex.Location = new System.Drawing.Point(114, 250);
            this.spinCarbonIndex.Name = "spinCarbonIndex";
            this.spinCarbonIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinCarbonIndex.Size = new System.Drawing.Size(100, 20);
            this.spinCarbonIndex.TabIndex = 10;
            // 
            // btnAddIndex
            // 
            this.btnAddIndex.Image = ((System.Drawing.Image)(resources.GetObject("btnAddIndex.Image")));
            this.btnAddIndex.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddIndex.Location = new System.Drawing.Point(414, 113);
            this.btnAddIndex.Name = "btnAddIndex";
            this.btnAddIndex.Size = new System.Drawing.Size(24, 24);
            this.btnAddIndex.TabIndex = 6;
            this.btnAddIndex.Click += new System.EventHandler(this.btnAddIndex_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(32, 248);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 25);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "碳转换系数";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(32, 212);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 25);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "反演模型";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(32, 124);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 25);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "指数数据";
            // 
            // cmbLandCover
            // 
            this.cmbLandCover.Location = new System.Drawing.Point(114, 35);
            this.cmbLandCover.Name = "cmbLandCover";
            this.cmbLandCover.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLandCover.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbLandCover.Size = new System.Drawing.Size(281, 20);
            this.cmbLandCover.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(32, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 25);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "草地像元值";
            // 
            // btnLandCover
            // 
            this.btnLandCover.Image = ((System.Drawing.Image)(resources.GetObject("btnLandCover.Image")));
            this.btnLandCover.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLandCover.Location = new System.Drawing.Point(414, 33);
            this.btnLandCover.Name = "btnLandCover";
            this.btnLandCover.Size = new System.Drawing.Size(24, 24);
            this.btnLandCover.TabIndex = 6;
            this.btnLandCover.Click += new System.EventHandler(this.btnLandCover_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(32, 33);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 25);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "土地覆盖分类";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtOutCarbon);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.txtOutCarbonDensity);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.btnOutCarbon);
            this.groupControl2.Controls.Add(this.txtOutBiology);
            this.groupControl2.Controls.Add(this.btnOutCarbonDensity);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.btnOutBiology);
            this.groupControl2.Location = new System.Drawing.Point(12, 308);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(472, 141);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "输出";
            // 
            // txtOutCarbon
            // 
            this.txtOutCarbon.Location = new System.Drawing.Point(114, 107);
            this.txtOutCarbon.Name = "txtOutCarbon";
            this.txtOutCarbon.Size = new System.Drawing.Size(281, 20);
            this.txtOutCarbon.TabIndex = 14;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(32, 110);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "草地碳储量";
            // 
            // txtOutCarbonDensity
            // 
            this.txtOutCarbonDensity.Location = new System.Drawing.Point(114, 75);
            this.txtOutCarbonDensity.Name = "txtOutCarbonDensity";
            this.txtOutCarbonDensity.Size = new System.Drawing.Size(281, 20);
            this.txtOutCarbonDensity.TabIndex = 14;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(32, 78);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "草地碳密度";
            // 
            // btnOutCarbon
            // 
            this.btnOutCarbon.Image = ((System.Drawing.Image)(resources.GetObject("btnOutCarbon.Image")));
            this.btnOutCarbon.ImageIndex = 0;
            this.btnOutCarbon.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOutCarbon.Location = new System.Drawing.Point(414, 105);
            this.btnOutCarbon.Name = "btnOutCarbon";
            this.btnOutCarbon.Size = new System.Drawing.Size(24, 24);
            this.btnOutCarbon.TabIndex = 13;
            this.btnOutCarbon.Click += new System.EventHandler(this.btnOutCarbon_Click);
            // 
            // txtOutBiology
            // 
            this.txtOutBiology.Location = new System.Drawing.Point(114, 37);
            this.txtOutBiology.Name = "txtOutBiology";
            this.txtOutBiology.Size = new System.Drawing.Size(281, 20);
            this.txtOutBiology.TabIndex = 14;
            // 
            // btnOutCarbonDensity
            // 
            this.btnOutCarbonDensity.Image = ((System.Drawing.Image)(resources.GetObject("btnOutCarbonDensity.Image")));
            this.btnOutCarbonDensity.ImageIndex = 0;
            this.btnOutCarbonDensity.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOutCarbonDensity.Location = new System.Drawing.Point(414, 73);
            this.btnOutCarbonDensity.Name = "btnOutCarbonDensity";
            this.btnOutCarbonDensity.Size = new System.Drawing.Size(24, 24);
            this.btnOutCarbonDensity.TabIndex = 13;
            this.btnOutCarbonDensity.Click += new System.EventHandler(this.btnOutCarbonDensity_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(32, 40);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "草地生物量";
            // 
            // btnOutBiology
            // 
            this.btnOutBiology.Image = ((System.Drawing.Image)(resources.GetObject("btnOutBiology.Image")));
            this.btnOutBiology.ImageIndex = 0;
            this.btnOutBiology.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOutBiology.Location = new System.Drawing.Point(414, 35);
            this.btnOutBiology.Name = "btnOutBiology";
            this.btnOutBiology.Size = new System.Drawing.Size(24, 24);
            this.btnOutBiology.TabIndex = 13;
            this.btnOutBiology.Click += new System.EventHandler(this.btnOutBiology_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(223, 464);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(375, 464);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 28;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // cmbPixel
            // 
            this.cmbPixel.Location = new System.Drawing.Point(114, 70);
            this.cmbPixel.Name = "cmbPixel";
            this.cmbPixel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPixel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPixel.Size = new System.Drawing.Size(100, 20);
            this.cmbPixel.TabIndex = 53;
            // 
            // frmGrass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 502);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGrass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "草地碳储量核算";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtExpression.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCarbonIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLandCover.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutCarbon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutCarbonDensity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutBiology.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPixel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnAddIndex;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLandCover;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLandCover;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ListBoxControl listIndex;
        private DevExpress.XtraEditors.SpinEdit spinCarbonIndex;
        private DevExpress.XtraEditors.TextEdit txtOutCarbon;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtOutCarbonDensity;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnOutCarbon;
        private DevExpress.XtraEditors.TextEdit txtOutBiology;
        private DevExpress.XtraEditors.SimpleButton btnOutCarbonDensity;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnOutBiology;
        private DevExpress.XtraEditors.TextEdit txtExpression;
        private DevExpress.XtraEditors.SimpleButton btnDelIndex;
        private DevExpress.XtraEditors.SimpleButton btnRParenthesis;
        private DevExpress.XtraEditors.SimpleButton btnLParenthesis;
        private DevExpress.XtraEditors.SimpleButton btnDivide;
        private DevExpress.XtraEditors.SimpleButton btnMultiply;
        private DevExpress.XtraEditors.SimpleButton btnSubtract;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPixel;
    }
}