using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GFS.ClassificationBLL;
using DevExpress.Utils;
using System.Threading;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using DevExpress.XtraEditors;
using GFS.BLL;
using System.Runtime.InteropServices;

namespace GFS.Classification
{
    public partial class frmRecode : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dt = null;
        public frmRecode()
        {
            InitializeComponent();
        }
        private void frmRecode_Load(object sender, EventArgs e)
        {
            this.Size = MinimumSize;
            _dt = new DataTable();
            _dt.Columns.Add("旧值");
            _dt.Columns.Add("新值");
            _dt.Columns[0].DataType = _dt.Columns[1].DataType =typeof(float);
            this.gridValueAndFile.DataSource = _dt;
            MapAPI.GetAllLayers(this.cBEIn,null);
        }
        //private void frmRecode_Load(object sender, EventArgs e)
        //{
        //    this.Size = MinimumSize;
        //    lvRecode.View = View.Details;
        //    ColumnHeader clh = new ColumnHeader();
        //    lvRecode.Columns[0].Width = 0;
        //}
        private void btnIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开文件";
            dlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!this.GetUniqueValues(dlg.FileName))
                    return;
                cBEIn.Text = dlg.FileName;
            }
        }
        private void cBEIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.GetUniqueValues(cBEIn.SelectedItem.ToString()))
                return;
            cBEIn.Text = cBEIn.SelectedItem.ToString();
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "保存文件";
            dlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
                this.txtOut.Text = dlg.FileName;
        }

        private void siBOK_Click(object sender, EventArgs e)
        {
            WaitDialogForm frmWait = new WaitDialogForm("正在重编码...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                string reMap = GetReMap();
                if (reMap == string.Empty)
                    return;
                string msg = "";
                if (!EnviVars.instance.GpExecutor.Reclassify(cBEIn.Text.TrimEnd(), txtOut.Text.TrimEnd(), reMap, out msg))
                    XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                {
                    System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("重编码完毕,是否加载结果？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        MAP.AddRasterFileToMap(txtOut.Text);
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(frmRecode),ex);
            }
            finally
            {
                frmWait.Close();
            }
            
        }

        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBHelp_Click(object sender, EventArgs e)
        {

            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBHelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                siBHelp.Text = "显示帮助>>";
            }
        }

        private bool CheckInRaster(string inFile)
        {
            int bandCount = MAP.GetBandCount(inFile);
            if (bandCount == 1)
                return true;
            else
                return false;
        }
        private bool GetUniqueValues(string inFile)
        {
            IRasterLayer pRasterLayer = null;
            IUniqueValues pUniqueValues = null;
            IRasterCalcUniqueValues pCalcUniqueValues = null;
            try
            {
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromFilePath(inFile);
                if (!(1 == pRasterLayer.BandCount))
                {
                    XtraMessageBox.Show("文件类型不正确，请选择分类结果文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                pUniqueValues = new UniqueValuesClass();
                pCalcUniqueValues = new RasterCalcUniqueValuesClass();
                pCalcUniqueValues.AddFromRaster(pRasterLayer.Raster, 0, pUniqueValues);
                if (_dt.Rows.Count > 0)
                    _dt.Rows.Clear();
                for (int i = 0; i < pUniqueValues.Count; i++)
                {
                    DataRow row = _dt.NewRow();
                    row[0] = pUniqueValues.get_UniqueValue(i);
                    _dt.Rows.Add(row);
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("读取唯一值失败！\r\n" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Log.WriteLog(typeof(frmRecode), ex);
                return false;
            }
            finally
            {
                if (pCalcUniqueValues != null)
                    Marshal.ReleaseComObject(pCalcUniqueValues);
                if (pUniqueValues != null)
                    Marshal.ReleaseComObject(pUniqueValues);
                if (pRasterLayer != null)
                    Marshal.ReleaseComObject(pRasterLayer);
            }
        }

        private string GetReMap()
        {
            string reMap = string.Empty;
            if (_dt.Rows.Count > 0)
            {
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DataRow row = _dt.Rows[i];
                    string newValue = row[1].ToString();
                    if (Common.CommonAPI.IsNumber(newValue))
                    {
                        reMap = reMap + row[0] + " " + row[1] + ";";
                    }
                    else
                    {
                        reMap = reMap + row[0] + " " + row[0] + ";";
                    }
                }
                reMap = reMap.Substring(0, reMap.Length - 1);
            }
            return reMap;
        }




       
    }
}
