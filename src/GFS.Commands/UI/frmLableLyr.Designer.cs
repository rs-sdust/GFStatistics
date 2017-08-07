namespace SDJT.Commands.UI
{
    partial class frmLableLyr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLableLyr));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkIsLable = new DevExpress.XtraEditors.CheckEdit();
            this.cmbField = new SDJT.Commands.UI.CtrlFieldCmb();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnStyle = new DevExpress.XtraEditors.SimpleButton();
            this.btnStrikeThrough = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderLine = new DevExpress.XtraEditors.CheckButton();
            this.btnItalic = new DevExpress.XtraEditors.CheckButton();
            this.btnBold = new DevExpress.XtraEditors.CheckButton();
            this.picturePreview = new DevExpress.XtraEditors.PictureEdit();
            this.cmbSize = new DevExpress.XtraEditors.SpinEdit();
            this.cmbColor = new DevExpress.XtraEditors.ColorEdit();
            this.cmbFont = new DevExpress.XtraEditors.FontEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFont.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkIsLable);
            this.groupControl1.Controls.Add(this.cmbField);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(360, 77);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // chkIsLable
            // 
            this.chkIsLable.Location = new System.Drawing.Point(69, 12);
            this.chkIsLable.Name = "chkIsLable";
            this.chkIsLable.Properties.Caption = "标注图层";
            this.chkIsLable.Size = new System.Drawing.Size(75, 19);
            this.chkIsLable.TabIndex = 2;
            // 
            // cmbField
            // 
            this.cmbField.FieldName = "";
            this.cmbField.Location = new System.Drawing.Point(71, 43);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(270, 21);
            this.cmbField.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "标注字段：";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnStyle);
            this.groupControl2.Controls.Add(this.btnStrikeThrough);
            this.groupControl2.Controls.Add(this.btnUnderLine);
            this.groupControl2.Controls.Add(this.btnItalic);
            this.groupControl2.Controls.Add(this.btnBold);
            this.groupControl2.Controls.Add(this.picturePreview);
            this.groupControl2.Controls.Add(this.cmbSize);
            this.groupControl2.Controls.Add(this.cmbColor);
            this.groupControl2.Controls.Add(this.cmbFont);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(12, 95);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(360, 122);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "groupControl2";
            // 
            // btnStyle
            // 
            this.btnStyle.Location = new System.Drawing.Point(231, 89);
            this.btnStyle.Name = "btnStyle";
            this.btnStyle.Size = new System.Drawing.Size(110, 23);
            this.btnStyle.TabIndex = 13;
            this.btnStyle.Text = "更改样式...";
            this.btnStyle.Click += new System.EventHandler(this.btnStyle_Click);
            // 
            // btnStrikeThrough
            // 
            this.btnStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("btnStrikeThrough.Image")));
            this.btnStrikeThrough.Location = new System.Drawing.Point(318, 53);
            this.btnStrikeThrough.Name = "btnStrikeThrough";
            this.btnStrikeThrough.Size = new System.Drawing.Size(23, 23);
            this.btnStrikeThrough.TabIndex = 12;
            this.btnStrikeThrough.Text = "删除线";
            this.btnStrikeThrough.CheckedChanged += new System.EventHandler(this.btnStrikeThrough_CheckedChanged);
            // 
            // btnUnderLine
            // 
            this.btnUnderLine.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderLine.Image")));
            this.btnUnderLine.Location = new System.Drawing.Point(289, 53);
            this.btnUnderLine.Name = "btnUnderLine";
            this.btnUnderLine.Size = new System.Drawing.Size(23, 23);
            this.btnUnderLine.TabIndex = 11;
            this.btnUnderLine.Text = "下划线";
            this.btnUnderLine.CheckedChanged += new System.EventHandler(this.btnUnderLine_CheckedChanged);
            // 
            // btnItalic
            // 
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.Location = new System.Drawing.Point(260, 53);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 23);
            this.btnItalic.TabIndex = 10;
            this.btnItalic.Text = "斜体";
            this.btnItalic.CheckedChanged += new System.EventHandler(this.btnItalic_CheckedChanged);
            // 
            // btnBold
            // 
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.Location = new System.Drawing.Point(231, 53);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 23);
            this.btnBold.TabIndex = 9;
            this.btnBold.Text = "粗体";
            this.btnBold.CheckedChanged += new System.EventHandler(this.btnBold_CheckedChanged);
            // 
            // picturePreview
            // 
            this.picturePreview.Location = new System.Drawing.Point(69, 53);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(142, 60);
            this.picturePreview.TabIndex = 8;
            // 
            // cmbSize
            // 
            this.cmbSize.EditValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.cmbSize.Location = new System.Drawing.Point(291, 14);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbSize.Size = new System.Drawing.Size(50, 21);
            this.cmbSize.TabIndex = 7;
            this.cmbSize.EditValueChanged += new System.EventHandler(this.cmbSize_ValueChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.EditValue = System.Drawing.Color.Empty;
            this.cmbColor.Location = new System.Drawing.Point(179, 14);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbColor.Size = new System.Drawing.Size(50, 21);
            this.cmbColor.TabIndex = 6;
            this.cmbColor.EditValueChanged += new System.EventHandler(this.cmbColor_EditValueChanged);
            // 
            // cmbFont
            // 
            this.cmbFont.Location = new System.Drawing.Point(69, 14);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFont.Size = new System.Drawing.Size(50, 21);
            this.cmbFont.TabIndex = 5;
            this.cmbFont.EditValueChanged += new System.EventHandler(this.cmbFont_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(249, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "大小：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(137, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "颜色：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "字体：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(166, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            // 
            // frmLableLyr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLableLyr";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "标注图层";
            this.Load += new System.EventHandler(this.frmLableLyr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFont.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private CtrlFieldCmb cmbField;
        private DevExpress.XtraEditors.SimpleButton btnStyle;
        private DevExpress.XtraEditors.CheckButton btnStrikeThrough;
        private DevExpress.XtraEditors.CheckButton btnUnderLine;
        private DevExpress.XtraEditors.CheckButton btnItalic;
        private DevExpress.XtraEditors.CheckButton btnBold;
        private DevExpress.XtraEditors.PictureEdit picturePreview;
        private DevExpress.XtraEditors.SpinEdit cmbSize;
        private DevExpress.XtraEditors.ColorEdit cmbColor;
        private DevExpress.XtraEditors.FontEdit cmbFont;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit chkIsLable;
    }
}