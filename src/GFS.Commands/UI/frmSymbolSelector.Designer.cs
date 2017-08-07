namespace GFS.Commands.UI
{
    partial class frmSymbolSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSymbolSelector));
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.panelFill = new DevExpress.XtraEditors.PanelControl();
            this.cmbFillLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.cmbFillWidth = new DevExpress.XtraEditors.SpinEdit();
            this.cmbFillColor = new DevExpress.XtraEditors.ColorEdit();
            this.btnChangeOutlineStyle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelLine = new DevExpress.XtraEditors.PanelControl();
            this.cmbLineWith = new DevExpress.XtraEditors.SpinEdit();
            this.cmbLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectStyle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelTxt = new DevExpress.XtraEditors.PanelControl();
            this.cmbTxtFont = new DevExpress.XtraEditors.FontEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTxtSize = new DevExpress.XtraEditors.SpinEdit();
            this.cmbTxtColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelScaleBar = new DevExpress.XtraEditors.PanelControl();
            this.cmbScaleBarUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.panelMarker = new DevExpress.XtraEditors.PanelControl();
            this.cmbMarkerAngel = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMarkerSize = new DevExpress.XtraEditors.SpinEdit();
            this.cmbMarkerColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).BeginInit();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFillLineColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFillWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLine)).BeginInit();
            this.panelLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineWith.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTxt)).BeginInit();
            this.panelTxt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTxtFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTxtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTxtColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelScaleBar)).BeginInit();
            this.panelScaleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbScaleBarUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMarker)).BeginInit();
            this.panelMarker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMarkerAngel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMarkerSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMarkerColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(6, 6);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(331, 393);
            this.axSymbologyControl1.TabIndex = 0;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // pictureEdit
            // 
            this.pictureEdit.Location = new System.Drawing.Point(343, 6);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Size = new System.Drawing.Size(233, 122);
            this.pictureEdit.TabIndex = 1;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.cmbFillLineColor);
            this.panelFill.Controls.Add(this.cmbFillWidth);
            this.panelFill.Controls.Add(this.cmbFillColor);
            this.panelFill.Controls.Add(this.btnChangeOutlineStyle);
            this.panelFill.Controls.Add(this.labelControl3);
            this.panelFill.Controls.Add(this.labelControl2);
            this.panelFill.Controls.Add(this.labelControl1);
            this.panelFill.Location = new System.Drawing.Point(343, 134);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(233, 173);
            this.panelFill.TabIndex = 2;
            this.panelFill.Visible = false;
            // 
            // cmbFillLineColor
            // 
            this.cmbFillLineColor.EditValue = System.Drawing.Color.Empty;
            this.cmbFillLineColor.Location = new System.Drawing.Point(105, 93);
            this.cmbFillLineColor.Name = "cmbFillLineColor";
            this.cmbFillLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFillLineColor.Size = new System.Drawing.Size(100, 21);
            this.cmbFillLineColor.TabIndex = 9;
            this.cmbFillLineColor.EditValueChanged += new System.EventHandler(this.cmbFillOutlineColor_EditValueChanged);
            // 
            // cmbFillWidth
            // 
            this.cmbFillWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbFillWidth.Location = new System.Drawing.Point(105, 61);
            this.cmbFillWidth.Name = "cmbFillWidth";
            this.cmbFillWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbFillWidth.Size = new System.Drawing.Size(100, 21);
            this.cmbFillWidth.TabIndex = 8;
            this.cmbFillWidth.EditValueChanged += new System.EventHandler(this.cmbFillAndLineWidth_EditValueChanged);
            // 
            // cmbFillColor
            // 
            this.cmbFillColor.EditValue = System.Drawing.Color.Empty;
            this.cmbFillColor.Location = new System.Drawing.Point(105, 30);
            this.cmbFillColor.Name = "cmbFillColor";
            this.cmbFillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFillColor.Size = new System.Drawing.Size(100, 21);
            this.cmbFillColor.TabIndex = 7;
            this.cmbFillColor.EditValueChanged += new System.EventHandler(this.cmbColor_EditValueChanged);
            // 
            // btnChangeOutlineStyle
            // 
            this.btnChangeOutlineStyle.Location = new System.Drawing.Point(105, 120);
            this.btnChangeOutlineStyle.Name = "btnChangeOutlineStyle";
            this.btnChangeOutlineStyle.Size = new System.Drawing.Size(100, 23);
            this.btnChangeOutlineStyle.TabIndex = 6;
            this.btnChangeOutlineStyle.Text = "更改边线样式";
            this.btnChangeOutlineStyle.Click += new System.EventHandler(this.btnChangeOutlineStyle_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "边线宽度：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "边线颜色：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "填充颜色：";
            // 
            // panelLine
            // 
            this.panelLine.Controls.Add(this.cmbLineWith);
            this.panelLine.Controls.Add(this.cmbLineColor);
            this.panelLine.Controls.Add(this.labelControl4);
            this.panelLine.Controls.Add(this.labelControl6);
            this.panelLine.Location = new System.Drawing.Point(343, 134);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(233, 173);
            this.panelLine.TabIndex = 10;
            this.panelLine.Visible = false;
            // 
            // cmbLineWith
            // 
            this.cmbLineWith.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbLineWith.Location = new System.Drawing.Point(93, 87);
            this.cmbLineWith.Name = "cmbLineWith";
            this.cmbLineWith.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbLineWith.Size = new System.Drawing.Size(100, 21);
            this.cmbLineWith.TabIndex = 8;
            this.cmbLineWith.EditValueChanged += new System.EventHandler(this.cmbFillAndLineWidth_EditValueChanged);
            // 
            // cmbLineColor
            // 
            this.cmbLineColor.EditValue = System.Drawing.Color.Empty;
            this.cmbLineColor.Location = new System.Drawing.Point(93, 56);
            this.cmbLineColor.Name = "cmbLineColor";
            this.cmbLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLineColor.Size = new System.Drawing.Size(100, 21);
            this.cmbLineColor.TabIndex = 7;
            this.cmbLineColor.EditValueChanged += new System.EventHandler(this.cmbColor_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 90);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "宽度：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(39, 59);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "颜色：";
            // 
            // btnSelectStyle
            // 
            this.btnSelectStyle.Location = new System.Drawing.Point(343, 313);
            this.btnSelectStyle.Name = "btnSelectStyle";
            this.btnSelectStyle.Size = new System.Drawing.Size(233, 23);
            this.btnSelectStyle.TabIndex = 3;
            this.btnSelectStyle.Text = "选择符号文件...";
            this.btnSelectStyle.Click += new System.EventHandler(this.btnSelectStyle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(343, 376);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(497, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelTxt
            // 
            this.panelTxt.Controls.Add(this.cmbTxtFont);
            this.panelTxt.Controls.Add(this.labelControl8);
            this.panelTxt.Controls.Add(this.cmbTxtSize);
            this.panelTxt.Controls.Add(this.cmbTxtColor);
            this.panelTxt.Controls.Add(this.labelControl5);
            this.panelTxt.Controls.Add(this.labelControl7);
            this.panelTxt.Location = new System.Drawing.Point(343, 134);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(233, 173);
            this.panelTxt.TabIndex = 11;
            this.panelTxt.Visible = false;
            // 
            // cmbTxtFont
            // 
            this.cmbTxtFont.Location = new System.Drawing.Point(93, 72);
            this.cmbTxtFont.Name = "cmbTxtFont";
            this.cmbTxtFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTxtFont.Size = new System.Drawing.Size(100, 21);
            this.cmbTxtFont.TabIndex = 10;
            this.cmbTxtFont.EditValueChanged += new System.EventHandler(this.cmbTxtFont_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(40, 112);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "大小：";
            // 
            // cmbTxtSize
            // 
            this.cmbTxtSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbTxtSize.Location = new System.Drawing.Point(93, 109);
            this.cmbTxtSize.Name = "cmbTxtSize";
            this.cmbTxtSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbTxtSize.Size = new System.Drawing.Size(100, 21);
            this.cmbTxtSize.TabIndex = 8;
            this.cmbTxtSize.EditValueChanged += new System.EventHandler(this.cmbTxtSize_EditValueChanged);
            // 
            // cmbTxtColor
            // 
            this.cmbTxtColor.EditValue = System.Drawing.Color.Empty;
            this.cmbTxtColor.Location = new System.Drawing.Point(93, 34);
            this.cmbTxtColor.Name = "cmbTxtColor";
            this.cmbTxtColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTxtColor.Size = new System.Drawing.Size(100, 21);
            this.cmbTxtColor.TabIndex = 7;
            this.cmbTxtColor.EditValueChanged += new System.EventHandler(this.cmbColor_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(39, 75);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "字体：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(39, 37);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "颜色：";
            // 
            // panelScaleBar
            // 
            this.panelScaleBar.Controls.Add(this.cmbScaleBarUnit);
            this.panelScaleBar.Controls.Add(this.labelControl11);
            this.panelScaleBar.Location = new System.Drawing.Point(343, 134);
            this.panelScaleBar.Name = "panelScaleBar";
            this.panelScaleBar.Size = new System.Drawing.Size(233, 173);
            this.panelScaleBar.TabIndex = 12;
            this.panelScaleBar.Visible = false;
            // 
            // cmbScaleBarUnit
            // 
            this.cmbScaleBarUnit.Location = new System.Drawing.Point(83, 69);
            this.cmbScaleBarUnit.Name = "cmbScaleBarUnit";
            this.cmbScaleBarUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbScaleBarUnit.Size = new System.Drawing.Size(90, 21);
            this.cmbScaleBarUnit.TabIndex = 1;
            this.cmbScaleBarUnit.EditValueChanged += new System.EventHandler(this.cmbScaleBarUnit_EditValueChanged);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(40, 69);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(36, 14);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "单位：";
            // 
            // panelMarker
            // 
            this.panelMarker.Controls.Add(this.cmbMarkerAngel);
            this.panelMarker.Controls.Add(this.labelControl12);
            this.panelMarker.Controls.Add(this.cmbMarkerSize);
            this.panelMarker.Controls.Add(this.cmbMarkerColor);
            this.panelMarker.Controls.Add(this.labelControl9);
            this.panelMarker.Controls.Add(this.labelControl10);
            this.panelMarker.Location = new System.Drawing.Point(343, 134);
            this.panelMarker.Name = "panelMarker";
            this.panelMarker.Size = new System.Drawing.Size(233, 173);
            this.panelMarker.TabIndex = 13;
            this.panelMarker.Visible = false;
            // 
            // cmbMarkerAngel
            // 
            this.cmbMarkerAngel.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbMarkerAngel.Location = new System.Drawing.Point(93, 108);
            this.cmbMarkerAngel.Name = "cmbMarkerAngel";
            this.cmbMarkerAngel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbMarkerAngel.Size = new System.Drawing.Size(100, 21);
            this.cmbMarkerAngel.TabIndex = 10;
            this.cmbMarkerAngel.EditValueChanged += new System.EventHandler(this.cmbMarkerAngel_EditValueChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(39, 111);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(36, 14);
            this.labelControl12.TabIndex = 9;
            this.labelControl12.Text = "角度：";
            // 
            // cmbMarkerSize
            // 
            this.cmbMarkerSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbMarkerSize.Location = new System.Drawing.Point(93, 72);
            this.cmbMarkerSize.Name = "cmbMarkerSize";
            this.cmbMarkerSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cmbMarkerSize.Size = new System.Drawing.Size(100, 21);
            this.cmbMarkerSize.TabIndex = 8;
            this.cmbMarkerSize.EditValueChanged += new System.EventHandler(this.cmbMarkerSize_EditValueChanged);
            // 
            // cmbMarkerColor
            // 
            this.cmbMarkerColor.EditValue = System.Drawing.Color.Empty;
            this.cmbMarkerColor.Location = new System.Drawing.Point(93, 35);
            this.cmbMarkerColor.Name = "cmbMarkerColor";
            this.cmbMarkerColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMarkerColor.Size = new System.Drawing.Size(100, 21);
            this.cmbMarkerColor.TabIndex = 7;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(39, 75);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(36, 14);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "大小：";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(39, 38);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(36, 14);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "颜色：";
            // 
            // frmSymbolSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 403);
            this.Controls.Add(this.panelMarker);
            this.Controls.Add(this.panelLine);
            this.Controls.Add(this.panelTxt);
            this.Controls.Add(this.panelScaleBar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.btnSelectStyle);
            this.Controls.Add(this.pictureEdit);
            this.Controls.Add(this.axSymbologyControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSymbolSelector";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "符号选择";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSymbolSelector_FormClosed);
            this.Load += new System.EventHandler(this.frmSymbolSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).EndInit();
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFillLineColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFillWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLine)).EndInit();
            this.panelLine.ResumeLayout(false);
            this.panelLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineWith.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTxt)).EndInit();
            this.panelTxt.ResumeLayout(false);
            this.panelTxt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTxtFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTxtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTxtColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelScaleBar)).EndInit();
            this.panelScaleBar.ResumeLayout(false);
            this.panelScaleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbScaleBarUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMarker)).EndInit();
            this.panelMarker.ResumeLayout(false);
            this.panelMarker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMarkerAngel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMarkerSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMarkerColor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
        private DevExpress.XtraEditors.PanelControl panelFill;
        private DevExpress.XtraEditors.SpinEdit cmbFillWidth;
        private DevExpress.XtraEditors.ColorEdit cmbFillColor;
        private DevExpress.XtraEditors.SimpleButton btnChangeOutlineStyle;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSelectStyle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelLine;
        private DevExpress.XtraEditors.ColorEdit cmbLineColor;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelTxt;
        private DevExpress.XtraEditors.FontEdit cmbTxtFont;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SpinEdit cmbTxtSize;
        private DevExpress.XtraEditors.ColorEdit cmbTxtColor;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ColorEdit cmbFillLineColor;
        private DevExpress.XtraEditors.PanelControl panelScaleBar;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.ComboBoxEdit cmbScaleBarUnit;
        private DevExpress.XtraEditors.SpinEdit cmbLineWith;
        private DevExpress.XtraEditors.PanelControl panelMarker;
        private DevExpress.XtraEditors.SpinEdit cmbMarkerAngel;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SpinEdit cmbMarkerSize;
        private DevExpress.XtraEditors.ColorEdit cmbMarkerColor;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}