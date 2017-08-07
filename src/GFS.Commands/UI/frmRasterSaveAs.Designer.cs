using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;

namespace SDJT.Commands.UI
{
    partial class frmRasterSaveAs
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
            this.lblOutputFilePath = new LabelControl();
            this.btnOutputPath = new ButtonEdit();
            this.lblOutputFileType = new LabelControl();
            this.cmbOutputType = new ComboBoxEdit();
            this.lblResampleMethod = new LabelControl();
            this.cmbResamplingType = new ComboBoxEdit();
            this.lblPixelType = new LabelControl();
            this.cmbPixelType = new ComboBoxEdit();
            this.btnOK = new SimpleButton();
            this.btnClose = new SimpleButton();
            this.lblOutputBand = new LabelControl();
            this.checkedCmbBand = new CheckedComboBoxEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((ISupportInitialize)this.btnOutputPath.Properties).BeginInit();
            ((ISupportInitialize)this.cmbOutputType.Properties).BeginInit();
            ((ISupportInitialize)this.cmbResamplingType.Properties).BeginInit();
            ((ISupportInitialize)this.cmbPixelType.Properties).BeginInit();
            ((ISupportInitialize)this.checkedCmbBand.Properties).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            this.lblOutputFilePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputFilePath.Location = new Point(3, 182);
            this.lblOutputFilePath.Name = "lblOutputFilePath";
            this.lblOutputFilePath.Size = new Size(84, 14);
            this.lblOutputFilePath.TabIndex = 0;
            this.lblOutputFilePath.Text = "输出文件路径：";
            this.btnOutputPath.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.btnOutputPath.Location = new Point(93, 179);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Properties.Buttons.AddRange(new EditorButton[]
            {
                new EditorButton()
            });
            this.btnOutputPath.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.btnOutputPath.Size = new Size(329, 20);
            this.btnOutputPath.TabIndex = 5;
            this.btnOutputPath.Click += new EventHandler(this.btnOutputPath_Click);
            this.lblOutputFileType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputFileType.Location = new Point(3, 14);
            this.lblOutputFileType.Name = "lblOutputFileType";
            this.lblOutputFileType.Size = new Size(84, 14);
            this.lblOutputFileType.TabIndex = 0;
            this.lblOutputFileType.Text = "输出文件类型：";
            this.cmbOutputType.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.cmbOutputType.EditValue = "";
            this.cmbOutputType.Location = new Point(93, 11);
            this.cmbOutputType.Name = "cmbOutputType";
            this.cmbOutputType.Properties.Buttons.AddRange(new EditorButton[]
            {
                new EditorButton(ButtonPredefines.Combo)
            });
            this.cmbOutputType.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cmbOutputType.Size = new Size(329, 20);
            this.cmbOutputType.TabIndex = 1;
            this.lblResampleMethod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblResampleMethod.Location = new Point(3, 56);
            this.lblResampleMethod.Name = "lblResampleMethod";
            this.lblResampleMethod.Size = new Size(72, 14);
            this.lblResampleMethod.TabIndex = 0;
            this.lblResampleMethod.Text = "重采样方法：";
            this.cmbResamplingType.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.cmbResamplingType.EditValue = "";
            this.cmbResamplingType.Location = new Point(93, 53);
            this.cmbResamplingType.Name = "cmbResamplingType";
            this.cmbResamplingType.Properties.Buttons.AddRange(new EditorButton[]
            {
                new EditorButton(ButtonPredefines.Combo)
            });
            this.cmbResamplingType.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cmbResamplingType.Size = new Size(329, 20);
            this.cmbResamplingType.TabIndex = 3;
            this.lblPixelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPixelType.Location = new Point(3, 98);
            this.lblPixelType.Name = "lblPixelType";
            this.lblPixelType.Size = new Size(60, 14);
            this.lblPixelType.TabIndex = 0;
            this.lblPixelType.Text = "像素类型：";
            this.cmbPixelType.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.cmbPixelType.EditValue = "";
            this.cmbPixelType.Location = new Point(93, 95);
            this.cmbPixelType.Name = "cmbPixelType";
            this.cmbPixelType.Properties.Buttons.AddRange(new EditorButton[]
            {
                new EditorButton(ButtonPredefines.Combo)
            });
            this.cmbPixelType.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cmbPixelType.Size = new Size(329, 20);
            this.cmbPixelType.TabIndex = 4;
            this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnOK.Location = new Point(267, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnClose.Location = new Point(362, 243);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new EventHandler(this.btnCancle_Click);
            this.lblOutputBand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputBand.Location = new Point(3, 140);
            this.lblOutputBand.Name = "lblOutputBand";
            this.lblOutputBand.Size = new Size(60, 14);
            this.lblOutputBand.TabIndex = 8;
            this.lblOutputBand.Text = "输出波段：";
            this.checkedCmbBand.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.checkedCmbBand.Location = new Point(93, 137);
            this.checkedCmbBand.Name = "checkedCmbBand";
            this.checkedCmbBand.Properties.Buttons.AddRange(new EditorButton[]
            {
                new EditorButton(ButtonPredefines.Combo)
            });
            this.checkedCmbBand.Size = new Size(329, 20);
            this.checkedCmbBand.TabIndex = 9;
            this.tableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.tableLayoutPanel1.Controls.Add(this.lblOutputFileType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkedCmbBand, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblResampleMethod, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOutputPath, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblOutputBand, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPixelType, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbPixelType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOutputFilePath, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbResamplingType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbOutputType, 1, 0);
            this.tableLayoutPanel1.Location = new Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20f));
            this.tableLayoutPanel1.Size = new Size(425, 210);
            this.tableLayoutPanel1.TabIndex = 10;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(449, 278);
            base.Controls.Add(this.tableLayoutPanel1);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnOK);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.HelpButton = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmRasterSaveAs";
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "栅格数据另存";
            base.HelpButtonClicked += new CancelEventHandler(this.frmRasterSaveAs_HelpButtonClicked);
            base.Load += new EventHandler(this.frmRasterSaveAs_Load);
            ((ISupportInitialize)this.btnOutputPath.Properties).EndInit();
            ((ISupportInitialize)this.cmbOutputType.Properties).EndInit();
            ((ISupportInitialize)this.cmbResamplingType.Properties).EndInit();
            ((ISupportInitialize)this.cmbPixelType.Properties).EndInit();
            ((ISupportInitialize)this.checkedCmbBand.Properties).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private LabelControl lblOutputFilePath;

        private ButtonEdit btnOutputPath;

        private LabelControl lblOutputFileType;

        private ComboBoxEdit cmbOutputType;

        private LabelControl lblResampleMethod;

        private ComboBoxEdit cmbResamplingType;

        private LabelControl lblPixelType;

        private ComboBoxEdit cmbPixelType;

        private SimpleButton btnOK;

        private SimpleButton btnClose;

        private LabelControl lblOutputBand;

        private CheckedComboBoxEdit checkedCmbBand;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}