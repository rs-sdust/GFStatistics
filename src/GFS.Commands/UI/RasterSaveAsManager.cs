using DevExpress.Utils;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GFS.Common;

namespace GFS.Commands.UI
{
    public class RasterSaveAsManager
    {
        private System.Windows.Forms.Form m_frm = null;

        private ComboBoxEdit m_cmbOutputType = null;

        private CheckedComboBoxEdit m_checkedCmbBand = null;

        private ComboBoxEdit m_cmbResamplingType = null;

        private ComboBoxEdit m_cmbPixelType = null;

        private IRaster m_raster = null;

        private List<IRasterBand> m_bandList = new List<IRasterBand>();

        private string m_sOutputPath = "";

        public IRaster Raster
        {
            get
            {
                return this.m_raster;
            }
            set
            {
                this.m_raster = value;
            }
        }

        public RasterSaveAsManager(System.Windows.Forms.Form frm)
        {
            this.m_frm = frm;
        }

        public void Init(IRaster raster, ComboBoxEdit cmbOutputType, ComboBoxEdit cmbPixelType, ComboBoxEdit cmbResamplingType, CheckedComboBoxEdit checkedCmbBand)
        {
            this.m_raster = raster;
            this.m_cmbOutputType = cmbOutputType;
            this.m_cmbPixelType = cmbPixelType;
            this.m_cmbResamplingType = cmbResamplingType;
            this.m_checkedCmbBand = checkedCmbBand;
            this.InitOutputType(cmbOutputType);
            this.InitResamplingMethod(cmbResamplingType);
            this.InitPixelType(cmbPixelType);
            this.InitOutputBands(checkedCmbBand);
        }

        public void SetOutputPath(ButtonEdit btnOutputPath)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Title = "选择输出路径";
            switch (this.m_cmbOutputType.SelectedIndex)
            {
                case 0:
                    saveFileDialog.Filter = "TIFF(*.tif)|*.tif";
                    break;
                case 1:
                    saveFileDialog.Filter = "IMAGINEE Image(*.img)|*.img";
                    break;
                case 2:
                    saveFileDialog.Filter = "JPEG(*.jpg)|*.jpg";
                    break;
                case 3:
                    saveFileDialog.Filter = "JP2000(*.jp2)|*.jp2";
                    break;
                case 4:
                    saveFileDialog.Filter = "BMP(*.bmp)|*.bmp";
                    break;
                case 5:
                    saveFileDialog.Filter = "PNG(*.png)|*.png";
                    break;
                case 6:
                    saveFileDialog.Filter = "ENVI DAT(*.dat)|*.dat";
                    break;
                case 7:
                    saveFileDialog.Filter = "HDF4 (*.hdf)|*.hdf";
                    break;
                case 9:
                    saveFileDialog.Filter = "BIL(*.bil)|*.bil";
                    break;
                case 10:
                    saveFileDialog.Filter = "BIP(*.bip)|*.bip";
                    break;
                case 11:
                    saveFileDialog.Filter = "BSQ(*.bsq)|*.bsq";
                    break;
            }
            saveFileDialog.OverwritePrompt = false;
            if (saveFileDialog.ShowDialog(this.m_frm) == System.Windows.Forms.DialogResult.OK)
            {
                btnOutputPath.Text = saveFileDialog.FileName;
            }
            this.m_sOutputPath = btnOutputPath.Text;
        }

        public bool SaveAs(bool bSetRepresentationType = false, rstRepresentationType representationType = rstRepresentationType.DT_ATHEMATIC, bool bUseMessagebox = true)
        {
            object editValue = this.m_checkedCmbBand.EditValue;
            bool result;
            if (editValue == null)
            {
                XtraMessageBox.Show("请设置输出波段！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                result = false;
            }
            else if (string.IsNullOrEmpty(this.m_sOutputPath))
            {
                XtraMessageBox.Show("请选择文件输出路径！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                result = false;
            }
            else
            {
                FileInfo fileInfo = new FileInfo(this.m_sOutputPath);
                if (fileInfo.Exists)
                {
                    if (XtraMessageBox.Show("此文件已存在,是否覆盖？", "提示信息", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.OK)
                    {
                        result = false;
                        return result;
                    }
                    fileInfo.Delete();
                }
                IRaster raster = this.m_raster;
                string[] array = editValue.ToString().Split(new char[]
				{
					','
				});
                if (array.Length != this.m_bandList.Count)
                {
                    IRaster raster2 = ((this.m_raster as IRaster2).RasterDataset as IRasterDataset3).CreateRaster();
                    IRasterProps rasterProps = raster2 as IRasterProps;
                    rasterProps.Width = (this.m_raster as IRasterProps).Width;
                    rasterProps.Height = (this.m_raster as IRasterProps).Height;
                    IRasterBandCollection rasterBandCollection = raster2 as IRasterBandCollection;
                    IRasterBandCollection rasterBandCollection2 = (this.m_raster as IRaster2).RasterDataset as IRasterBandCollection;
                    for (int i = 0; i < rasterBandCollection2.Count; i++)
                    {
                        IRasterBand rasterBand = rasterBandCollection2.Item(i);
                        string[] array2 = array;
                        for (int j = 0; j < array2.Length; j++)
                        {
                            string text = array2[j];
                            if (text.Trim() == rasterBand.Bandname)
                            {
                                rasterBandCollection.AppendBand(rasterBand);
                                break;
                            }
                        }
                    }
                    raster = raster2;
                }
                this.SetResamplingMethod(raster, this.m_cmbResamplingType);
                this.SetPixelType(raster, this.m_cmbPixelType);
                if (bSetRepresentationType)
                {
                    this.SetRepresentationType(raster, representationType);
                }
                WaitDialogForm waitDialogForm = new WaitDialogForm("正在输出......", "提示信息");
                IWorkspace workspace = null;
                string text2 = "输出成功！";
                //Logger logger = new Logger();
                try
                {
                    waitDialogForm.Owner = this.m_frm;
                    waitDialogForm.TopMost = false;
                    string text3 = this.m_cmbOutputType.Text;
                    ISaveAs2 saveAs = raster as ISaveAs2;
                    if (!saveAs.CanSaveAs(text3))
                    {
                        XtraMessageBox.Show("不支持指定像素类型或文件格式的输出！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        result = false;
                    }
                    else
                    {
                        IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();
                        workspace = workspaceFactory.OpenFromFile(Path.GetDirectoryName(this.m_sOutputPath), 0);
                        IDataset o = saveAs.SaveAs(Path.GetFileName(this.m_sOutputPath), workspace, text3);
                        if (o != null)
                        Marshal.ReleaseComObject(o);
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    text2 = "输出失败！";
                    result = false;
                }
                finally
                {
                    if (workspace != null)
                    {
                        Marshal.ReleaseComObject(workspace);
                    }
                    waitDialogForm.Close();
                    if (bUseMessagebox)
                    {
                        XtraMessageBox.Show(text2, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    }
                }
            }
            return result;
        }

        private void InitOutputType(ComboBoxEdit cmbOutputType)
        {
            if (cmbOutputType != null)
            {
                cmbOutputType.Properties.Items.BeginUpdate();
                try
                {
                    cmbOutputType.Properties.Items.Clear();
                    Array values = Enum.GetValues(typeof(RasterFormat));
                    foreach (RasterFormat rasterFormat in values)
                    {
                        cmbOutputType.Properties.Items.Add(CommonAPI.GetEnumDescription(rasterFormat));
                    }
                    cmbOutputType.SelectedIndex = 0;
                }
                finally
                {
                    cmbOutputType.Properties.Items.EndUpdate();
                }
            }
        }

        private void InitPixelType(ComboBoxEdit cmbPixelType)
        {
            if (cmbPixelType != null)
            {
                cmbPixelType.Properties.Items.BeginUpdate();
                try
                {
                    cmbPixelType.Properties.Items.Clear();
                    Array values = Enum.GetValues(typeof(PixelType));
                    foreach (PixelType pixelType in values)
                    {
                        cmbPixelType.Properties.Items.Add(CommonAPI.GetEnumDescription(pixelType));
                    }
                    IRasterProps rasterProps = this.m_raster as IRasterProps;
                    switch (rasterProps.PixelType)
                    {
                        case rstPixelType.PT_UCHAR:
                            cmbPixelType.SelectedIndex = 0;
                            break;
                        case rstPixelType.PT_CHAR:
                            cmbPixelType.SelectedIndex = 1;
                            break;
                        case rstPixelType.PT_USHORT:
                            cmbPixelType.SelectedIndex = 2;
                            break;
                        case rstPixelType.PT_SHORT:
                            cmbPixelType.SelectedIndex = 3;
                            break;
                        case rstPixelType.PT_ULONG:
                            cmbPixelType.SelectedIndex = 4;
                            break;
                        case rstPixelType.PT_LONG:
                            cmbPixelType.SelectedIndex = 5;
                            break;
                        case rstPixelType.PT_FLOAT:
                            cmbPixelType.SelectedIndex = 6;
                            break;
                        case rstPixelType.PT_DOUBLE:
                            cmbPixelType.SelectedIndex = 7;
                            break;
                        default:
                            cmbPixelType.SelectedIndex = 0;
                            break;
                    }
                }
                finally
                {
                    cmbPixelType.Properties.Items.EndUpdate();
                }
            }
        }

        private void InitResamplingMethod(ComboBoxEdit cmbResamplingType)
        {
            if (cmbResamplingType != null)
            {
                cmbResamplingType.Properties.Items.BeginUpdate();
                try
                {
                    cmbResamplingType.Properties.Items.Clear();
                    Array values = Enum.GetValues(typeof(ResamplingMethod));
                    foreach (ResamplingMethod resamplingMethod in values)
                    {
                        cmbResamplingType.Properties.Items.Add(CommonAPI.GetEnumDescription(resamplingMethod));
                    }
                    switch (this.m_raster.ResampleMethod)
                    {
                        case rstResamplingTypes.RSP_NearestNeighbor:
                            cmbResamplingType.SelectedIndex = 0;
                            break;
                        case rstResamplingTypes.RSP_BilinearInterpolation:
                            cmbResamplingType.SelectedIndex = 1;
                            break;
                        case rstResamplingTypes.RSP_CubicConvolution:
                            cmbResamplingType.SelectedIndex = 2;
                            break;
                        case rstResamplingTypes.RSP_Majority:
                            cmbResamplingType.SelectedIndex = 3;
                            break;
                        default:
                            cmbResamplingType.SelectedIndex = 0;
                            break;
                    }
                }
                finally
                {
                    cmbResamplingType.Properties.Items.EndUpdate();
                }
            }
        }

        private void InitOutputBands(CheckedComboBoxEdit checkedCmbBand)
        {
            if (checkedCmbBand != null)
            {
                checkedCmbBand.Properties.Items.BeginUpdate();
                try
                {
                    checkedCmbBand.Properties.Items.Clear();
                    this.m_bandList.Clear();
                    IRasterBandCollection rasterBandCollection = (this.m_raster as IRaster2).RasterDataset as IRasterBandCollection;
                    for (int i = 0; i < rasterBandCollection.Count; i++)
                    {
                        IRasterBand rasterBand = rasterBandCollection.Item(i);
                        checkedCmbBand.Properties.Items.Add(rasterBand.Bandname);
                        this.m_bandList.Add(rasterBand);
                    }
                    checkedCmbBand.CheckAll();
                }
                finally
                {
                    checkedCmbBand.Properties.Items.EndUpdate();
                }
            }
        }

        private void SetPixelType(IRaster raster, ComboBoxEdit cmbPixelType)
        {
            if (cmbPixelType != null)
            {
                IRasterProps rasterProps = raster as IRasterProps;
                switch (cmbPixelType.SelectedIndex)
                {
                    case 0:
                        rasterProps.PixelType = rstPixelType.PT_UCHAR;
                        rasterProps.NoDataValue = 128;
                        break;
                    case 1:
                        rasterProps.PixelType = rstPixelType.PT_CHAR;
                        rasterProps.NoDataValue = 127;
                        break;
                    case 2:
                        rasterProps.PixelType = rstPixelType.PT_USHORT;
                        break;
                    case 3:
                        rasterProps.PixelType = rstPixelType.PT_SHORT;
                        break;
                    case 4:
                        rasterProps.PixelType = rstPixelType.PT_ULONG;
                        break;
                    case 5:
                        rasterProps.PixelType = rstPixelType.PT_LONG;
                        break;
                    case 6:
                        rasterProps.PixelType = rstPixelType.PT_FLOAT;
                        break;
                    case 7:
                        rasterProps.PixelType = rstPixelType.PT_DOUBLE;
                        break;
                }
            }
        }

        private void SetResamplingMethod(IRaster raster, ComboBoxEdit cmbResamplingType)
        {
            if (cmbResamplingType != null)
            {
                switch (cmbResamplingType.SelectedIndex)
                {
                    case 0:
                        raster.ResampleMethod = rstResamplingTypes.RSP_NearestNeighbor;
                        break;
                    case 1:
                        raster.ResampleMethod = rstResamplingTypes.RSP_BilinearInterpolation;
                        break;
                    case 2:
                        raster.ResampleMethod = rstResamplingTypes.RSP_CubicConvolution;
                        break;
                    case 3:
                        raster.ResampleMethod = rstResamplingTypes.RSP_Majority;
                        break;
                }
            }
        }

        private void SetRepresentationType(IRaster raster, rstRepresentationType rasterRepresentationType)
        {
            IRasterBandCollection rasterBandCollection = (raster as IRaster2).RasterDataset as IRasterBandCollection;
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                rasterBandCollection.Item(i).RepresentationType = rasterRepresentationType;
            }
        }
    }
}
