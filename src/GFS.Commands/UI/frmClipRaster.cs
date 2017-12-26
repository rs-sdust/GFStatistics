using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
//using HTES.TAS.Const;
//using HTES.TAS.DB.Model;
//using HTES.TAS.Log;
//using HTES.TAS.Sys;
//using PS.Plot.Common;
//using PS.Plot.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GFS.Common;
using GFS.BLL;

namespace GFS.Commands.UI
{
    public class frmClipRaster : XtraForm
    {
        private IContainer components = null;

        private SimpleButton btnOK;

        private SimpleButton btnClose;

        private SimpleButton btnROI;

        private System.Windows.Forms.GroupBox groupBoxDataType;

        private ComboBoxEdit cmbEditRepresType;

        private LabelControl lblOutputRepresType;

        private LabelControl lblOutputPixelType;

        private LabelControl lblCtrInputPixelDepth;

        private LabelControl lblInputPixelType;

        private LabelControl lblOutputBand;

        private CheckedComboBoxEdit checkedCmbBand;

        private ButtonEdit btnOutputPath;

        private ComboBoxEdit cmbOutputType;

        private LabelControl lblOutputFilePath;

        private LabelControl lblOutputFileType;

        private ComboBoxEdit cmbPixelType;

        private PanelControl panelCtrClipExtent;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

        private IRasterDataset m_pRasterDataset = null;

        private IGeoDataset m_pClipExtentGeoDataset = null;

        private RasterSaveAsManager m_saveAsManager = null;

        private string[] m_rasterPropsArray = new string[4];

        private string m_clippingGeometry = string.Empty;

        private ClipUtility m_clipUtility;

        //private Logger m_logger = new Logger();

        private IEnvelope m_Envelope;

        private static string MSG01 = "基于范围裁切";

        private static string MSG02 = "专题图像";

        private static string MSG03 = "连续值图像";

        private static string MSG04 = "请选择需要裁切的栅格文件！";

        private static string MSG05 = "地理坐标";

        private static string MSG06 = "像素坐标";

        private static string MSG07 = "两角点";

        private static string MSG08 = "四角点";

        private static string MSG09 = "加载数据失败！";

        private static string MSG10 = "选择的裁切范围文件坐标系未知！请重新选择！";
        private GroupControl groupControlOutputExtent;
        private TableLayoutPanel tableLayoutPanel2;
        private RadioGroup radioGroupExtent;
        private LabelControl lblULX;
        private SpinEdit spinEditLLY;
        private LabelControl lblULY;
        private SpinEdit spinEditLLX;
        private LabelControl lblLLY;
        private SpinEdit spinEditLRY;
        private LabelControl lblLLX;
        private SpinEdit spinEditLRX;
        private SpinEdit spinEditURX;
        private SpinEdit spinEditURY;
        private SpinEdit spinEditULX;
        private LabelControl lblURX;
        private SpinEdit spinEditULY;
        private LabelControl lblURY;
        private LabelControl lblLRX;
        private LabelControl lblLRY;
        private GroupBox groupBox1;
        private RadioGroup radioGroupCoordinate;
        private GroupControl groupControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private ButtonEdit btnInputExtentFile;
        private LabelControl lblInputRaster;
        private RadioGroup radioGroupClipMethod;
        private LabelControl lblClipMethod;
        private LabelControl lblClipExtentFile;
        //private SimpleButton btnOpenRaster;
        private CtrCurrentLayer ctrCurrentLayer1;
        private GroupControl groupControl2;
        //private SimpleButton btnOpenRaster;
        private SimpleButton btnOpenRaster;

        private static string MSG11 = "请设置正确的输出范围!";

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnROI = new DevExpress.XtraEditors.SimpleButton();
            this.groupBoxDataType = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInputPixelType = new DevExpress.XtraEditors.LabelControl();
            this.cmbEditRepresType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbPixelType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOutputRepresType = new DevExpress.XtraEditors.LabelControl();
            this.lblOutputPixelType = new DevExpress.XtraEditors.LabelControl();
            this.lblCtrInputPixelDepth = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOutputBand = new DevExpress.XtraEditors.LabelControl();
            this.btnOutputPath = new DevExpress.XtraEditors.ButtonEdit();
            this.cmbOutputType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOutputFilePath = new DevExpress.XtraEditors.LabelControl();
            this.checkedCmbBand = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblOutputFileType = new DevExpress.XtraEditors.LabelControl();
            this.panelCtrClipExtent = new DevExpress.XtraEditors.PanelControl();
            this.groupControlOutputExtent = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioGroupExtent = new DevExpress.XtraEditors.RadioGroup();
            this.lblULX = new DevExpress.XtraEditors.LabelControl();
            this.spinEditLLY = new DevExpress.XtraEditors.SpinEdit();
            this.lblULY = new DevExpress.XtraEditors.LabelControl();
            this.spinEditLLX = new DevExpress.XtraEditors.SpinEdit();
            this.lblLLY = new DevExpress.XtraEditors.LabelControl();
            this.spinEditLRY = new DevExpress.XtraEditors.SpinEdit();
            this.lblLLX = new DevExpress.XtraEditors.LabelControl();
            this.spinEditLRX = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditURX = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditURY = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditULX = new DevExpress.XtraEditors.SpinEdit();
            this.lblURX = new DevExpress.XtraEditors.LabelControl();
            this.spinEditULY = new DevExpress.XtraEditors.SpinEdit();
            this.lblURY = new DevExpress.XtraEditors.LabelControl();
            this.lblLRX = new DevExpress.XtraEditors.LabelControl();
            this.lblLRY = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioGroupCoordinate = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenRaster = new DevExpress.XtraEditors.SimpleButton();
            this.lblInputRaster = new DevExpress.XtraEditors.LabelControl();
            this.lblClipMethod = new DevExpress.XtraEditors.LabelControl();
            this.lblClipExtentFile = new DevExpress.XtraEditors.LabelControl();
            this.ctrCurrentLayer1 = new GFS.Commands.UI.CtrCurrentLayer();
            this.btnInputExtentFile = new DevExpress.XtraEditors.ButtonEdit();
            this.radioGroupClipMethod = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupBoxDataType.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditRepresType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPixelType.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOutputPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOutputType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCmbBand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrClipExtent)).BeginInit();
            this.panelCtrClipExtent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOutputExtent)).BeginInit();
            this.groupControlOutputExtent.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupExtent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLLY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLLX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLRY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLRX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditURX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditURY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditULX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditULY.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCoordinate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInputExtentFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupClipMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(272, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(381, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnROI
            // 
            this.btnROI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnROI.Enabled = false;
            this.btnROI.Location = new System.Drawing.Point(398, 83);
            this.btnROI.Name = "btnROI";
            this.btnROI.Size = new System.Drawing.Size(36, 23);
            this.btnROI.TabIndex = 10;
            this.btnROI.Text = "ROI";
            this.btnROI.Click += new System.EventHandler(this.btnROI_Click);
            // 
            // groupBoxDataType
            // 
            this.groupBoxDataType.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxDataType.Location = new System.Drawing.Point(12, 441);
            this.groupBoxDataType.Name = "groupBoxDataType";
            this.groupBoxDataType.Size = new System.Drawing.Size(451, 78);
            this.groupBoxDataType.TabIndex = 13;
            this.groupBoxDataType.TabStop = false;
            this.groupBoxDataType.Text = "数据类型";
            this.groupBoxDataType.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblInputPixelType, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbEditRepresType, 5, 1);
            this.tableLayoutPanel4.Controls.Add(this.cmbPixelType, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblOutputRepresType, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblOutputPixelType, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblCtrInputPixelDepth, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(445, 57);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // lblInputPixelType
            // 
            this.lblInputPixelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInputPixelType.Location = new System.Drawing.Point(13, 7);
            this.lblInputPixelType.Name = "lblInputPixelType";
            this.lblInputPixelType.Size = new System.Drawing.Size(84, 14);
            this.lblInputPixelType.TabIndex = 0;
            this.lblInputPixelType.Text = "输入像素类型：";
            // 
            // cmbEditRepresType
            // 
            this.cmbEditRepresType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEditRepresType.EditValue = "";
            this.cmbEditRepresType.Location = new System.Drawing.Point(299, 32);
            this.cmbEditRepresType.Name = "cmbEditRepresType";
            this.cmbEditRepresType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEditRepresType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEditRepresType.Size = new System.Drawing.Size(143, 20);
            this.cmbEditRepresType.TabIndex = 5;
            // 
            // cmbPixelType
            // 
            this.cmbPixelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPixelType.EditValue = "";
            this.cmbPixelType.Location = new System.Drawing.Point(103, 32);
            this.cmbPixelType.Name = "cmbPixelType";
            this.cmbPixelType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPixelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPixelType.Size = new System.Drawing.Size(143, 20);
            this.cmbPixelType.TabIndex = 6;
            // 
            // lblOutputRepresType
            // 
            this.lblOutputRepresType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputRepresType.Location = new System.Drawing.Point(257, 35);
            this.lblOutputRepresType.Name = "lblOutputRepresType";
            this.lblOutputRepresType.Size = new System.Drawing.Size(36, 14);
            this.lblOutputRepresType.TabIndex = 4;
            this.lblOutputRepresType.Text = "输出：";
            // 
            // lblOutputPixelType
            // 
            this.lblOutputPixelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputPixelType.Location = new System.Drawing.Point(13, 35);
            this.lblOutputPixelType.Name = "lblOutputPixelType";
            this.lblOutputPixelType.Size = new System.Drawing.Size(84, 14);
            this.lblOutputPixelType.TabIndex = 2;
            this.lblOutputPixelType.Text = "输出像素类型：";
            // 
            // lblCtrInputPixelDepth
            // 
            this.lblCtrInputPixelDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.lblCtrInputPixelDepth, 4);
            this.lblCtrInputPixelDepth.Location = new System.Drawing.Point(103, 7);
            this.lblCtrInputPixelDepth.Name = "lblCtrInputPixelDepth";
            this.lblCtrInputPixelDepth.Size = new System.Drawing.Size(0, 14);
            this.lblCtrInputPixelDepth.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.Controls.Add(this.lblOutputBand, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnOutputPath, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbOutputType, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblOutputFilePath, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.checkedCmbBand, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblOutputFileType, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(447, 104);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // lblOutputBand
            // 
            this.lblOutputBand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputBand.Location = new System.Drawing.Point(13, 10);
            this.lblOutputBand.Name = "lblOutputBand";
            this.lblOutputBand.Size = new System.Drawing.Size(84, 14);
            this.lblOutputBand.TabIndex = 0;
            this.lblOutputBand.Text = "选择输出波段：";
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputPath.Location = new System.Drawing.Point(103, 76);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnOutputPath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnOutputPath.Size = new System.Drawing.Size(331, 20);
            this.btnOutputPath.TabIndex = 17;
            this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
            // 
            // cmbOutputType
            // 
            this.cmbOutputType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutputType.EditValue = "";
            this.cmbOutputType.Location = new System.Drawing.Point(103, 41);
            this.cmbOutputType.Name = "cmbOutputType";
            this.cmbOutputType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOutputType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbOutputType.Size = new System.Drawing.Size(331, 20);
            this.cmbOutputType.TabIndex = 12;
            // 
            // lblOutputFilePath
            // 
            this.lblOutputFilePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputFilePath.Location = new System.Drawing.Point(13, 79);
            this.lblOutputFilePath.Name = "lblOutputFilePath";
            this.lblOutputFilePath.Size = new System.Drawing.Size(84, 14);
            this.lblOutputFilePath.TabIndex = 16;
            this.lblOutputFilePath.Text = "输出文件路径：";
            // 
            // checkedCmbBand
            // 
            this.checkedCmbBand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedCmbBand.Location = new System.Drawing.Point(103, 7);
            this.checkedCmbBand.Name = "checkedCmbBand";
            this.checkedCmbBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCmbBand.Size = new System.Drawing.Size(331, 20);
            this.checkedCmbBand.TabIndex = 10;
            // 
            // lblOutputFileType
            // 
            this.lblOutputFileType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutputFileType.Location = new System.Drawing.Point(13, 44);
            this.lblOutputFileType.Name = "lblOutputFileType";
            this.lblOutputFileType.Size = new System.Drawing.Size(84, 14);
            this.lblOutputFileType.TabIndex = 11;
            this.lblOutputFileType.Text = "输出文件类型：";
            // 
            // panelCtrClipExtent
            // 
            this.panelCtrClipExtent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelCtrClipExtent.Appearance.Options.UseBackColor = true;
            this.panelCtrClipExtent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCtrClipExtent.Controls.Add(this.groupControlOutputExtent);
            this.panelCtrClipExtent.Location = new System.Drawing.Point(12, 525);
            this.panelCtrClipExtent.Name = "panelCtrClipExtent";
            this.panelCtrClipExtent.Size = new System.Drawing.Size(451, 172);
            this.panelCtrClipExtent.TabIndex = 16;
            // 
            // groupControlOutputExtent
            // 
            this.groupControlOutputExtent.Controls.Add(this.tableLayoutPanel2);
            this.groupControlOutputExtent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlOutputExtent.Location = new System.Drawing.Point(0, 0);
            this.groupControlOutputExtent.Name = "groupControlOutputExtent";
            this.groupControlOutputExtent.Size = new System.Drawing.Size(451, 172);
            this.groupControlOutputExtent.TabIndex = 14;
            this.groupControlOutputExtent.Text = "输出范围";
            this.groupControlOutputExtent.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.radioGroupExtent, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblULX, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.spinEditLLY, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblULY, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.spinEditLLX, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblLLY, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.spinEditLRY, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLLX, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.spinEditLRX, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.spinEditURX, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.spinEditURY, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.spinEditULX, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblURX, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.spinEditULY, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblURY, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblLRX, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLRY, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(447, 148);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // radioGroupExtent
            // 
            this.radioGroupExtent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.radioGroupExtent, 4);
            this.radioGroupExtent.Location = new System.Drawing.Point(124, 3);
            this.radioGroupExtent.Name = "radioGroupExtent";
            this.radioGroupExtent.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupExtent.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupExtent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupExtent.Properties.Columns = 2;
            this.radioGroupExtent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroupExtent.Size = new System.Drawing.Size(320, 22);
            this.radioGroupExtent.TabIndex = 0;
            // 
            // lblULX
            // 
            this.lblULX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblULX.Location = new System.Drawing.Point(124, 36);
            this.lblULX.Name = "lblULX";
            this.lblULX.Size = new System.Drawing.Size(43, 14);
            this.lblULX.TabIndex = 1;
            this.lblULX.Text = "左上X：";
            // 
            // spinEditLLY
            // 
            this.spinEditLLY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditLLY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditLLY.Enabled = false;
            this.spinEditLLY.Location = new System.Drawing.Point(337, 123);
            this.spinEditLLY.Name = "spinEditLLY";
            this.spinEditLLY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLLY.Size = new System.Drawing.Size(107, 20);
            this.spinEditLLY.TabIndex = 24;
            // 
            // lblULY
            // 
            this.lblULY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblULY.Location = new System.Drawing.Point(124, 66);
            this.lblULY.Name = "lblULY";
            this.lblULY.Size = new System.Drawing.Size(44, 14);
            this.lblULY.TabIndex = 13;
            this.lblULY.Text = "左上Y：";
            // 
            // spinEditLLX
            // 
            this.spinEditLLX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditLLX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditLLX.Enabled = false;
            this.spinEditLLX.Location = new System.Drawing.Point(337, 93);
            this.spinEditLLX.Name = "spinEditLLX";
            this.spinEditLLX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLLX.Size = new System.Drawing.Size(107, 20);
            this.spinEditLLX.TabIndex = 20;
            // 
            // lblLLY
            // 
            this.lblLLY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLLY.Location = new System.Drawing.Point(287, 126);
            this.lblLLY.Name = "lblLLY";
            this.lblLLY.Size = new System.Drawing.Size(44, 14);
            this.lblLLY.TabIndex = 22;
            this.lblLLY.Text = "左下Y：";
            // 
            // spinEditLRY
            // 
            this.spinEditLRY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditLRY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditLRY.Location = new System.Drawing.Point(337, 63);
            this.spinEditLRY.Name = "spinEditLRY";
            this.spinEditLRY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLRY.Size = new System.Drawing.Size(107, 20);
            this.spinEditLRY.TabIndex = 16;
            // 
            // lblLLX
            // 
            this.lblLLX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLLX.Location = new System.Drawing.Point(287, 96);
            this.lblLLX.Name = "lblLLX";
            this.lblLLX.Size = new System.Drawing.Size(43, 14);
            this.lblLLX.TabIndex = 18;
            this.lblLLX.Text = "左下X：";
            // 
            // spinEditLRX
            // 
            this.spinEditLRX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditLRX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditLRX.Location = new System.Drawing.Point(337, 33);
            this.spinEditLRX.Name = "spinEditLRX";
            this.spinEditLRX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLRX.Size = new System.Drawing.Size(107, 20);
            this.spinEditLRX.TabIndex = 9;
            // 
            // spinEditURX
            // 
            this.spinEditURX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditURX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditURX.Enabled = false;
            this.spinEditURX.Location = new System.Drawing.Point(174, 93);
            this.spinEditURX.Name = "spinEditURX";
            this.spinEditURX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditURX.Size = new System.Drawing.Size(107, 20);
            this.spinEditURX.TabIndex = 19;
            // 
            // spinEditURY
            // 
            this.spinEditURY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditURY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditURY.Enabled = false;
            this.spinEditURY.Location = new System.Drawing.Point(174, 123);
            this.spinEditURY.Name = "spinEditURY";
            this.spinEditURY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditURY.Size = new System.Drawing.Size(107, 20);
            this.spinEditURY.TabIndex = 23;
            // 
            // spinEditULX
            // 
            this.spinEditULX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditULX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditULX.Location = new System.Drawing.Point(174, 33);
            this.spinEditULX.Name = "spinEditULX";
            this.spinEditULX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditULX.Size = new System.Drawing.Size(107, 20);
            this.spinEditULX.TabIndex = 8;
            // 
            // lblURX
            // 
            this.lblURX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblURX.Location = new System.Drawing.Point(124, 96);
            this.lblURX.Name = "lblURX";
            this.lblURX.Size = new System.Drawing.Size(43, 14);
            this.lblURX.TabIndex = 17;
            this.lblURX.Text = "右上X：";
            // 
            // spinEditULY
            // 
            this.spinEditULY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEditULY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditULY.Location = new System.Drawing.Point(174, 63);
            this.spinEditULY.Name = "spinEditULY";
            this.spinEditULY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditULY.Size = new System.Drawing.Size(107, 20);
            this.spinEditULY.TabIndex = 15;
            // 
            // lblURY
            // 
            this.lblURY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblURY.Location = new System.Drawing.Point(124, 126);
            this.lblURY.Name = "lblURY";
            this.lblURY.Size = new System.Drawing.Size(44, 14);
            this.lblURY.TabIndex = 21;
            this.lblURY.Text = "右上Y：";
            // 
            // lblLRX
            // 
            this.lblLRX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLRX.Location = new System.Drawing.Point(287, 36);
            this.lblLRX.Name = "lblLRX";
            this.lblLRX.Size = new System.Drawing.Size(43, 14);
            this.lblLRX.TabIndex = 3;
            this.lblLRX.Text = "右下X：";
            // 
            // lblLRY
            // 
            this.lblLRY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLRY.Location = new System.Drawing.Point(287, 66);
            this.lblLRY.Name = "lblLRY";
            this.lblLRY.Size = new System.Drawing.Size(44, 14);
            this.lblLRY.TabIndex = 14;
            this.lblLRY.Text = "右下Y：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioGroupCoordinate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel2.SetRowSpan(this.groupBox1, 5);
            this.groupBox1.Size = new System.Drawing.Size(115, 142);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坐标类型";
            // 
            // radioGroupCoordinate
            // 
            this.radioGroupCoordinate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupCoordinate.Location = new System.Drawing.Point(3, 18);
            this.radioGroupCoordinate.Name = "radioGroupCoordinate";
            this.radioGroupCoordinate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupCoordinate.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupCoordinate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupCoordinate.Size = new System.Drawing.Size(109, 121);
            this.radioGroupCoordinate.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(451, 138);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "输入";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpenRaster, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInputRaster, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblClipMethod, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblClipExtentFile, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnROI, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ctrCurrentLayer1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInputExtentFile, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioGroupClipMethod, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 114);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOpenRaster
            // 
            this.btnOpenRaster.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOpenRaster.Location = new System.Drawing.Point(398, 7);
            this.btnOpenRaster.Name = "btnOpenRaster";
            this.btnOpenRaster.Size = new System.Drawing.Size(36, 23);
            this.btnOpenRaster.TabIndex = 20;
            this.btnOpenRaster.Text = "...";
            this.btnOpenRaster.Click += new System.EventHandler(this.btnOpenRaster_Click);
            // 
            // lblInputRaster
            // 
            this.lblInputRaster.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInputRaster.Location = new System.Drawing.Point(13, 12);
            this.lblInputRaster.Name = "lblInputRaster";
            this.lblInputRaster.Size = new System.Drawing.Size(84, 14);
            this.lblInputRaster.TabIndex = 0;
            this.lblInputRaster.Text = "输入栅格文件：";
            // 
            // lblClipMethod
            // 
            this.lblClipMethod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClipMethod.Location = new System.Drawing.Point(13, 88);
            this.lblClipMethod.Name = "lblClipMethod";
            this.lblClipMethod.Size = new System.Drawing.Size(84, 14);
            this.lblClipMethod.TabIndex = 18;
            this.lblClipMethod.Text = "裁切文件方式：";
            // 
            // lblClipExtentFile
            // 
            this.lblClipExtentFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClipExtentFile.Location = new System.Drawing.Point(13, 50);
            this.lblClipExtentFile.Name = "lblClipExtentFile";
            this.lblClipExtentFile.Size = new System.Drawing.Size(84, 14);
            this.lblClipExtentFile.TabIndex = 4;
            this.lblClipExtentFile.Text = "裁切范围文件：";
            // 
            // ctrCurrentLayer1
            // 
            this.ctrCurrentLayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrCurrentLayer1.EnumLayerType = GFS.Commands.UI.EnumLayerType.Vector;
            this.ctrCurrentLayer1.EnumRasterBandCount = GFS.Commands.UI.EnumRasterBandCount.Zero;
            this.ctrCurrentLayer1.Location = new System.Drawing.Point(103, 8);
            this.ctrCurrentLayer1.MapControl = null;
            this.ctrCurrentLayer1.Name = "ctrCurrentLayer1";
            this.ctrCurrentLayer1.Size = new System.Drawing.Size(289, 21);
            this.ctrCurrentLayer1.TabIndex = 19;
            // 
            // btnInputExtentFile
            // 
            this.btnInputExtentFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnInputExtentFile, 2);
            this.btnInputExtentFile.Location = new System.Drawing.Point(103, 47);
            this.btnInputExtentFile.Name = "btnInputExtentFile";
            this.btnInputExtentFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnInputExtentFile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnInputExtentFile.Size = new System.Drawing.Size(331, 20);
            this.btnInputExtentFile.TabIndex = 5;
            this.btnInputExtentFile.Click += new System.EventHandler(this.btnInputExtentFile_Click);
            // 
            // radioGroupClipMethod
            // 
            this.radioGroupClipMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupClipMethod.Location = new System.Drawing.Point(103, 83);
            this.radioGroupClipMethod.Name = "radioGroupClipMethod";
            this.radioGroupClipMethod.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupClipMethod.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupClipMethod.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupClipMethod.Properties.Columns = 2;
            this.radioGroupClipMethod.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroupClipMethod.Size = new System.Drawing.Size(289, 23);
            this.radioGroupClipMethod.TabIndex = 17;
            this.radioGroupClipMethod.SelectedIndexChanged += new System.EventHandler(this.radioGroupClipMethod_SelectedIndexChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.tableLayoutPanel3);
            this.groupControl2.Location = new System.Drawing.Point(12, 156);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(451, 128);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "输出";
            // 
            // frmClipRaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(473, 348);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelCtrClipExtent);
            this.Controls.Add(this.groupBoxDataType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClipRaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "栅格数据裁切";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FrmClipRaster_HelpButtonClicked);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClipRaster_FormClosed);
            this.Load += new System.EventHandler(this.FrmClipRaster_Load);
            this.groupBoxDataType.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditRepresType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPixelType.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOutputPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOutputType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCmbBand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrClipExtent)).EndInit();
            this.panelCtrClipExtent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOutputExtent)).EndInit();
            this.groupControlOutputExtent.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupExtent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLLY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLLX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLRY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLRX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditURX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditURY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditULX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditULY.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCoordinate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInputExtentFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupClipMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public frmClipRaster()
        {
            this.InitializeComponent();
            this.m_saveAsManager = new RasterSaveAsManager(this);

            this.m_clipUtility = new ClipUtility();
        }

        private void FrmClipRaster_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.ctrCurrentLayer1.MapControl = null;
            this.ctrCurrentLayer1.ReleaseMapEvent();
        }

        private void FrmClipRaster_Load(object sender, EventArgs e)
        {
            this.AddRadioGroupItem(this.radioGroupCoordinate, frmClipRaster.MSG05);
            this.AddRadioGroupItem(this.radioGroupCoordinate, frmClipRaster.MSG06);
            this.AddRadioGroupItem(this.radioGroupExtent, frmClipRaster.MSG07);
            this.AddRadioGroupItem(this.radioGroupExtent, frmClipRaster.MSG08);
            //this.AddRadioGroupItem(this.radioGroupClipMethod, frmClipRaster.MSG01);
            this.AddRadioGroupItem(this.radioGroupClipMethod, "基于文件裁切");
            this.AddRadioGroupItem(this.radioGroupClipMethod, "基于ROI裁切");
            
            this.cmbEditRepresType.Properties.Items.Add(frmClipRaster.MSG02);
            this.cmbEditRepresType.Properties.Items.Add(frmClipRaster.MSG03);
            this.radioGroupCoordinate.SelectedIndexChanged += new EventHandler(this.radioGroupCoordinate_SelectedIndexChanged);
            this.radioGroupExtent.SelectedIndexChanged += new EventHandler(this.radioGroupExtent_SelectedIndexChanged);
            this.radioGroupClipMethod.SelectedIndexChanged += new EventHandler(this.radioGroupClipMethod_SelectedIndexChanged);
            this.ctrCurrentLayer1.MapControl = EnviVars.instance.MapControl;
            this.ctrCurrentLayer1.EnumLayerType = EnumLayerType.Raster;
            this.ctrCurrentLayer1.EnumRasterBandCount = EnumRasterBandCount.Any;
            this.ctrCurrentLayer1.OnSelectChanged += new CtrCurrentLayer.SelectChangedHandle(this.ctrCurrentLayer1_OnSelectChanged);
            this.ctrCurrentLayer1.BeforeInit += new CtrCurrentLayer.BefroeInitEventHander(this.ctrCurrentLayer1.RegisterMapEvent);
            this.ctrCurrentLayer1.Init();
        }

        private void btnOpenRaster_Click(object sender, EventArgs e)
        {
            try
            {
                frmSelectFeatures frmSelectFeatures = new frmSelectFeatures();
                frmSelectFeatures.DataType = DataType.raster;
                frmSelectFeatures.IsMultiSelect = false;
                if (frmSelectFeatures.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (KeyValuePair<string, IRasterDataset> current in frmSelectFeatures.RasterDict)
                    {
                        this.AddRasterLayerToMap(current.Key);
                        //CurrentLayer layer = new CurrentLayer();
                        //layer.Name = current.Key;
                        //IRasterLayer rastLyr = new RasterLayerClass();
                        //rastLyr.CreateFromDataset(current.Value);
                        //layer.Layer = rastLyr as ILayer;
                        //this.ctrCurrentLayer1.SetCurrentLayer(layer);
                    }
                }
            }
            catch (Exception ex)
            {
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                Log.WriteLog(typeof(frmClipRaster),ex);
                XtraMessageBox.Show("无效的数据，加载数据失败！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
        }

        private void ctrCurrentLayer1_OnSelectChanged(ILayer layer)
        {
            IRasterLayer rasterLayer = layer as IRasterLayer;
            IRasterDataset rasterDataset = (rasterLayer.Raster as IRaster2).RasterDataset;
            if (this.m_pRasterDataset != null)
            {
                Marshal.ReleaseComObject(this.m_pRasterDataset);
            }
            this.m_pRasterDataset = rasterDataset;
            this.InitDataExtent(null);
            IRaster raster = rasterDataset.CreateDefaultRaster();
            this.InitRasterRepresentationType(rasterDataset);
            this.m_saveAsManager.Init(raster, this.cmbOutputType, this.cmbPixelType, null, this.checkedCmbBand);
            this.m_rasterPropsArray[0] = this.cmbPixelType.Text;
            this.m_rasterPropsArray[1] = this.cmbEditRepresType.Text;
            this.m_rasterPropsArray[2] = this.checkedCmbBand.Text;
            this.m_rasterPropsArray[3] = this.cmbOutputType.Text;
            this.lblCtrInputPixelDepth.Text = this.cmbPixelType.Text;
        }

        private void btnInputExtentFile_Click(object sender, EventArgs e)
        {
            frmSelectFeatures frmSelectFeatures = new frmSelectFeatures();
            frmSelectFeatures.DataType = DataType.all;
            frmSelectFeatures.IsMultiSelect = false;
            if (frmSelectFeatures.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (KeyValuePair<string, IRasterDataset> current in frmSelectFeatures.RasterDict)
                {
                    this.btnInputExtentFile.Text = current.Key;
                    this.m_pClipExtentGeoDataset = (current.Value as IGeoDataset);
                    this.m_clippingGeometry = "NONE";
                }
                foreach (IFeatureClass current2 in frmSelectFeatures.SelectedFeatures)
                {
                    string feaClassPath = this.m_clipUtility.GetFeaClassPath(current2);
                    this.btnInputExtentFile.Text = feaClassPath;
                    this.m_pClipExtentGeoDataset = (current2 as IGeoDataset);
                    this.m_clippingGeometry = "ClippingGeometry";
                }
            }
        }

        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            if (this.ctrCurrentLayer1.CurrentLayer == null)
            {
                XtraMessageBox.Show(frmClipRaster.MSG04, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
            else
            this.m_saveAsManager.SetOutputPath(this.btnOutputPath);
        }

        private void radioGroupClipMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.radioGroupClipMethod.SelectedIndex)
            {
                //case 0:
                //    this.btnInputExtentFile.Text = string.Empty;
                //    this.m_pClipExtentGeoDataset = null;
                //    this.btnInputExtentFile.Enabled = false;
                //    this.panelCtrClipExtent.Enabled = true;
                //    break;
                case 0:
                    this.btnInputExtentFile.Enabled = true;
                    this.panelCtrClipExtent.Enabled = false;
                    this.btnROI.Enabled = false;
                    break;
                case 1:
                    this.btnInputExtentFile.Text = string.Empty;
                    this.m_pClipExtentGeoDataset = null;
                    this.btnInputExtentFile.Enabled = false;
                    this.panelCtrClipExtent.Enabled = false;
                    this.btnROI.Enabled = true;
                    break;
            }
        }

        private void radioGroupExtent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroupExtent.SelectedIndex == 0)
            {
                this.lblURX.Enabled = false;
                this.spinEditURX.Enabled = false;
                this.lblURY.Enabled = false;
                this.spinEditURY.Enabled = false;
                this.lblLLX.Enabled = false;
                this.spinEditLLX.Enabled = false;
                this.lblLLY.Enabled = false;
                this.spinEditLLY.Enabled = false;
            }
            else if (this.radioGroupExtent.SelectedIndex == 1)
            {
                this.lblURX.Enabled = true;
                this.spinEditURX.Enabled = true;
                this.lblURY.Enabled = true;
                this.spinEditURY.Enabled = true;
                this.lblLLX.Enabled = true;
                this.spinEditLLX.Enabled = true;
                this.lblLLY.Enabled = true;
                this.spinEditLLY.Enabled = true;
            }
        }

        private void radioGroupCoordinate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitDataExtent(null);
        }

        private void btnROI_Click(object sender, EventArgs e)
        {
            List<ILayer> layers = EngineAPI.GetLayers(EnviVars.instance.MapControl.ActiveView.FocusMap, "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}", null);
            if (layers.Count > 0 && EnviVars.instance.MapControl.SpatialReference != null)
            {
                ROIManager.instance.FrmROI.Owner = EnviVars.instance.MainForm;
                //ControlWrapper.SetFormLocation(ROIManager.instance.FrmROI, FormPositionMode.LeftBottom);
                ROIManager.instance.FrmROI.Show();
            }
            else
            {
                XtraMessageBox.Show(frmClipRaster.MSG04, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string in_raster = string.Empty;
            if (this.ctrCurrentLayer1.CurrentLayer == null)
            {
                XtraMessageBox.Show(frmClipRaster.MSG04, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
            else
            {
                in_raster = (this.ctrCurrentLayer1.CurrentLayer as IRasterLayer).FilePath;
                if (string.IsNullOrEmpty(this.btnOutputPath.Text))
                {
                    XtraMessageBox.Show("请选择文件输出路径！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                }
                else
                {
                    //if (this.radioGroupClipMethod.SelectedIndex == 0)
                    //{
                    //    double num = CommonAPI.ConvertToDouble(this.spinEditULX.Text);
                    //    double num2 = CommonAPI.ConvertToDouble(this.spinEditULY.Text);
                    //    double num3 = CommonAPI.ConvertToDouble(this.spinEditLRX.Text);
                    //    double num4 = CommonAPI.ConvertToDouble(this.spinEditLRY.Text);
                    //    double num5 = CommonAPI.ConvertToDouble(this.spinEditURX.Text);
                    //    double num6 = CommonAPI.ConvertToDouble(this.spinEditURY.Text);
                    //    double num7 = CommonAPI.ConvertToDouble(this.spinEditLLX.Text);
                    //    double num8 = CommonAPI.ConvertToDouble(this.spinEditLLY.Text);
                    //    if (this.radioGroupExtent.SelectedIndex == 0)
                    //    {
                    //        if (this.m_Envelope != null)
                    //        {
                    //            if (num >= num3 || num2 <= num4)
                    //            {
                    //                XtraMessageBox.Show(frmClipRaster.MSG11, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //    else if (this.radioGroupExtent.SelectedIndex == 1)
                    //    {
                    //        if (this.m_Envelope != null)
                    //        {
                    //            if (num >= num3 || num7 >= num5 || num2 <= num4 || num8 >= num6)
                    //            {
                    //                XtraMessageBox.Show(frmClipRaster.MSG11, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //}
                    string empty = string.Empty;
                    bool flag = false;
                    frmWaitDialog frmWait = new frmWaitDialog("正在裁切数据......", "提示信息");
                    try
                    {
                        frmWait.Owner = this;
                        frmWait.TopMost = false;
                        IRaster2 pRaster = this.m_pRasterDataset.CreateDefaultRaster() as IRaster2;
                        string empty2 = string.Empty;
                        this.CalculateRectangle(pRaster, ref empty2);
                        string text = string.Empty;
                        switch (this.radioGroupClipMethod.SelectedIndex)
                        {
                            case 0:
                                if (this.m_pClipExtentGeoDataset is IRasterDataset)
                                {
                                    this.m_clippingGeometry = "NONE";
                                }
                                else if (this.m_pClipExtentGeoDataset is IFeatureClass)
                                {
                                    this.m_clippingGeometry = "ClippingGeometry";
                                }
                                if (this.m_pClipExtentGeoDataset == null || this.m_pClipExtentGeoDataset.SpatialReference is IUnknownCoordinateSystem)
                                {
                                    XtraMessageBox.Show(frmClipRaster.MSG10, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                                    return;
                                }
                                text = this.btnInputExtentFile.Text;
                                break;
                            case 1:
                                text = this.m_clipUtility.CreateShpByROI();
                                this.m_clippingGeometry = "ClippingGeometry";
                                break;
                        }
                        bool flag2;
                        string outputRasterPath = this.GetOutputRasterPath(out flag2);
                        if (ROIManager.instance.GpExecutor.ClipRster(in_raster, text, empty2, outputRasterPath, this.m_clippingGeometry, out empty))
                        {
                            flag = true;
                            if (flag2)
                            {
                                if (File.Exists(this.btnOutputPath.Text))
                                {
                                    this.DeleteRasterDataset(this.btnOutputPath.Text);
                                }
                                this.SaveAsRaster(outputRasterPath);
                            }
                            if (this.radioGroupClipMethod.SelectedIndex == 2)
                            {
                                this.m_clipUtility.DeleteShpFile(text);
                            }
                            //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                            base.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("裁切失败！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                            //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, new Exception(empty));
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog(typeof(frmClipRaster), ex);
                        XtraMessageBox.Show("裁切失败！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                    }
                    finally
                    {
                        frmWait.Close();
                    }
                    if (flag)
                    {
                        ROIManager.instance.FrmROI.UnDisplayROIElements();
                        System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("裁切成功，是否加载？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.AddRasterLayerToMap(this.btnOutputPath.Text);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void AddRasterLayerToMap(string rasterPath)
        {
            try
            {
                IRasterLayer rasterLayer = new RasterLayerClass();
                string directoryName = System.IO.Path.GetDirectoryName(rasterPath);
                string fileName = System.IO.Path.GetFileName(rasterPath);
                IRasterWorkspace rasterWorkspace = EngineAPI.OpenWorkspace(directoryName, DataType.raster) as IRasterWorkspace;
                IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                rasterLayer.CreateFromDataset(rasterDataset);
                IRasterPyramid3 rasterPyramid = rasterDataset as IRasterPyramid3;
                if (rasterPyramid != null && !rasterPyramid.Present)
                {
                    //new frmCreatePyramid(new List<string>
                    //{
                    //    rasterLayer.FilePath
                    //})
                    //{
                    //    Owner = EnviVars.instance.MainForm
                    //}.ShowDialog();
                    //using(GPExecutor gp = new GPExecutor())
                    {
                        EnviVars.instance.GpExecutor.CreatePyramid(new List<string>
                    {
                        rasterLayer.FilePath
                    });
                    }

                }
                EnviVars.instance.MapControl.AddLayer(rasterLayer, 0);
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(frmClipRaster), ex);
                XtraMessageBox.Show(frmClipRaster.MSG09, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
        }

        private bool InitDataExtent(IGeoDataset geoDataset = null)
        {
            bool result;
            try
            {
                if (this.m_pRasterDataset == null)
                {
                    result = false;
                }
                else
                {
                    IRaster raster = this.m_pRasterDataset.CreateDefaultRaster();
                    IRasterProps rasterProps = (IRasterProps)raster;
                    int width = rasterProps.Width;
                    int height = rasterProps.Height;
                    IEnvelope envelope = this.TransEnvelopeToWGS84((this.m_pRasterDataset as IGeoDataset).Extent);
                    this.m_Envelope = envelope;
                    if (geoDataset == null)
                    {
                        if (this.radioGroupCoordinate.SelectedIndex == 0)
                        {
                            this.spinEditULX.EditValue = envelope.XMin;
                            this.spinEditULY.EditValue = envelope.YMax;
                            this.spinEditLRX.EditValue = envelope.XMax;
                            this.spinEditLRY.EditValue = envelope.YMin;
                            this.spinEditURX.EditValue = envelope.XMax;
                            this.spinEditURY.EditValue = envelope.YMax;
                            this.spinEditLLX.EditValue = envelope.XMin;
                            this.spinEditLLY.EditValue = envelope.YMin;
                        }
                        else if (this.radioGroupCoordinate.SelectedIndex == 1)
                        {
                            this.spinEditULX.EditValue = 0;
                            this.spinEditULY.EditValue = 0;
                            this.spinEditLRX.EditValue = width;
                            this.spinEditLRY.EditValue = height;
                            this.spinEditURX.EditValue = width;
                            this.spinEditURY.EditValue = 0;
                            this.spinEditLLX.EditValue = 0;
                            this.spinEditLLY.EditValue = height;
                        }
                    }
                    else
                    {
                        IRaster2 raster2 = raster as IRaster2;
                        IEnvelope envelope2 = this.TransEnvelopeToWGS84(geoDataset.Extent);
                        this.m_Envelope = envelope2;
                        if (this.radioGroupCoordinate.SelectedIndex == 0)
                        {
                            this.spinEditULX.EditValue = envelope2.XMin;
                            this.spinEditULY.EditValue = envelope2.YMax;
                            this.spinEditLRX.EditValue = envelope2.XMax;
                            this.spinEditLRY.EditValue = envelope2.YMin;
                            this.spinEditURX.EditValue = envelope2.XMax;
                            this.spinEditURY.EditValue = envelope2.YMax;
                            this.spinEditLLX.EditValue = envelope2.XMin;
                            this.spinEditLLY.EditValue = envelope2.YMin;
                        }
                        else if (this.radioGroupCoordinate.SelectedIndex == 1)
                        {
                            IEnvelope envelope3 = (geoDataset.Extent as IClone).Clone() as IEnvelope;
                            envelope3.Project((raster2.RasterDataset as IGeoDataset).SpatialReference);
                            int num;
                            int num2;
                            raster2.MapToPixel(envelope3.XMin, envelope3.YMax, out num, out num2);
                            int num3;
                            int num4;
                            raster2.MapToPixel(envelope3.XMax, envelope3.YMin, out num3, out num4);
                            this.spinEditULX.EditValue = num;
                            this.spinEditULY.EditValue = num2;
                            this.spinEditLRX.EditValue = num3;
                            this.spinEditLRY.EditValue = num4;
                            this.spinEditURX.EditValue = num3;
                            this.spinEditURY.EditValue = num2;
                            this.spinEditLLX.EditValue = num;
                            this.spinEditLLY.EditValue = num4;
                        }
                    }
                    result = true;
                }
            }
            catch (Exception )
            {
                result = false;
            }
            return result;
        }

        private IEnvelope TransEnvelopeToWGS84(IEnvelope envelope)
        {
            IEnvelope result;
            if (envelope == null)
            {
                result = null;
            }
            else
            {
                IEnvelope envelope2 = (envelope as IClone).Clone() as IEnvelope;
                try
                {
                    ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                    ISpatialReference spatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);
                    if (envelope2.SpatialReference != null && spatialReference != null)
                    {
                        if (envelope2.SpatialReference.Name != spatialReference.Name)
                        {
                            envelope2.Project(spatialReference);
                        }
                    }
                    result = envelope2;
                }
                catch
                {
                    result = envelope;
                }
            }
            return result;
        }

        private void CalculateRectangle(IRaster2 pRaster2, ref string in_rectangle)
        {
            switch (this.radioGroupCoordinate.SelectedIndex)
            {
                case 0:
                    {
                        double num = CommonAPI.ConvertToDouble(this.spinEditULX.EditValue);
                        double num2 = CommonAPI.ConvertToDouble(this.spinEditLRY.EditValue);
                        double num3 = CommonAPI.ConvertToDouble(this.spinEditLRX.EditValue);
                        double num4 = CommonAPI.ConvertToDouble(this.spinEditULY.EditValue);
                        IEnvelope envelope = new EnvelopeClass();
                        envelope.PutCoords(num, num2, num3, num4);
                        ISpatialReference spatialReference = (pRaster2.RasterDataset as IGeoDataset).SpatialReference;
                        if (spatialReference is IUnknownCoordinateSystem)
                        {
                            in_rectangle = string.Format("{0} {1} {2} {3}", new object[]
					{
						num,
						num2,
						num3,
						num4
					});
                        }
                        else
                        {
                            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                            ISpatialReference spatialReference2 = spatialReferenceFactory.CreateGeographicCoordinateSystem(4326);
                            envelope.SpatialReference = spatialReference2;
                            envelope.Project(spatialReference);
                            in_rectangle = string.Format("{0} {1} {2} {3}", new object[]
					{
						envelope.XMin,
						envelope.YMin,
						envelope.XMax,
						envelope.YMax
					});
                        }
                        break;
                    }
                case 1:
                    {
                        int iColumn = CommonAPI.ConvertToInt(this.spinEditULX.EditValue);
                        int iRow = CommonAPI.ConvertToInt(this.spinEditULY.EditValue);
                        int iColumn2 = CommonAPI.ConvertToInt(this.spinEditLRX.EditValue);
                        int iRow2 = CommonAPI.ConvertToInt(this.spinEditLRY.EditValue);
                        double num;
                        double num4;
                        pRaster2.PixelToMap(iColumn, iRow, out num, out num4);
                        double num2;
                        double num3;
                        pRaster2.PixelToMap(iColumn2, iRow2, out num3, out num2);
                        in_rectangle = string.Format("{0} {1} {2} {3}", new object[]
				{
					num,
					num2,
					num3,
					num4
				});
                        break;
                    }
            }
        }

        private void InitRasterRepresentationType(IRasterDataset rasterDataset)
        {
            IRasterBandCollection rasterBandCollection = rasterDataset as IRasterBandCollection;
            IRasterBand rasterBand = rasterBandCollection.Item(0);
            switch (rasterBand.RepresentationType)
            {
                case rstRepresentationType.DT_THEMATIC:
                    this.cmbEditRepresType.Text = frmClipRaster.MSG02;
                    break;
                case rstRepresentationType.DT_ATHEMATIC:
                    this.cmbEditRepresType.Text = frmClipRaster.MSG03;
                    break;
            }
        }

        private string GetOutputRasterPath(out bool IsNeedSaveAs)
        {
            string result = string.Empty;
            if (this.m_rasterPropsArray[0] == this.cmbPixelType.Text && this.m_rasterPropsArray[1] == this.cmbEditRepresType.Text && this.m_rasterPropsArray[2] == this.checkedCmbBand.Text && this.m_rasterPropsArray[3] == this.cmbOutputType.Text)
            {
                result = this.btnOutputPath.Text;
                IsNeedSaveAs = false;
            }
            else
            {
                Guid guid = Guid.NewGuid();
                string directoryName = System.IO.Path.GetDirectoryName(this.btnOutputPath.Text);
                string extension = System.IO.Path.GetExtension((this.ctrCurrentLayer1.CurrentLayer as IRasterLayer).FilePath);
                result = directoryName + "\\" + guid.ToString() + extension;
                IsNeedSaveAs = true;
            }
            return result;
        }

        private void SaveAsRaster(string saveAsOutputPath)
        {
            IRasterDataset rasterDataset = EngineAPI.OpenRasterFile(saveAsOutputPath);
            try
            {
                IRaster raster = (rasterDataset as IRasterDataset2).CreateFullRaster();
                this.m_saveAsManager.Raster = raster;
                rstRepresentationType representationType = (this.cmbEditRepresType.SelectedIndex == 0) ? rstRepresentationType.DT_THEMATIC : rstRepresentationType.DT_ATHEMATIC;
                this.m_saveAsManager.SaveAs(true, representationType, false);
            }
            finally
            {
                if (rasterDataset != null)
                {
                    (rasterDataset as IDataset).Delete();
                }
            }
        }

        private void DeleteRasterDataset(string rasterPath)
        {
            string directoryName = System.IO.Path.GetDirectoryName(rasterPath);
            string fileName = System.IO.Path.GetFileName(rasterPath);
            IRasterWorkspace rasterWorkspace = EngineAPI.OpenWorkspace(directoryName, DataType.raster) as IRasterWorkspace;
            IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
            (rasterDataset as IDataset).Delete();
        }

        private void FrmClipRaster_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }

        private  void AddRadioGroupItem(RadioGroup radioGroup, string sDesc)
        {
            RadioGroupItem radioGroupItem = new RadioGroupItem();
            radioGroupItem.Description = sDesc;
            radioGroup.Properties.Items.Add(radioGroupItem);
        }
    }
}
