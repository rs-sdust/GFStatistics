// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Zhen Lu
// Created          : 08-17-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-21-2017
// ***********************************************************************
// <copyright file="frmClipRaster.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>Raster clip UI</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Threading;
using GFS.BLL;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
//using ESRI.ArcGIS.DataSourcesRaster;
//using GFS.Common;
//using ESRI.ArcGIS.Geodatabase;
using GFS.Commands.UI;
using System.IO;
using GFS.Common;
using GFS.SampleBLL;
using ESRI.ArcGIS.Geodatabase;

namespace GFS.Sample
{
    public partial class frmSampleFrame : DevExpress.XtraEditors.XtraForm
    {

        //private DataTable _dt = null;
        private string areaField = string.Empty;
        private OpenFileDialog openDlg = new OpenFileDialog();
        public frmSampleFrame()
        {
            InitializeComponent();
        }

        private void frmClipRaster_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            MapAPI.GetAllLayers(cmbASCDL, cmbUnit);
            MapAPI.GetAllLayers(null, cmbCrop);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                this.btnHelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                this.btnHelp.Text = "显示帮助>>";
            }
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            openDlg.Title = "打开文件";
            openDlg.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                SampleData.firstUnit = this.cmbUnit.Text = openDlg.FileName;
                try
                {
                    List<string> fields = new List<string>();
                    EngineAPI.GetValueFields(this.cmbUnit.Text.TrimEnd(), fields);
                    this.cmbAreaField.Properties.Items.Clear();
                    this.cmbAreaField.Properties.Items.AddRange(fields);
                    this.cmbVillage.Properties.Items.Clear();
                    this.cmbVillage.Properties.Items.AddRange(fields);
                    SampleData.hasArea = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("读取字段失败：" + ex.Message);
                    Log.WriteLog(typeof(frmSampleFrame), ex);
                }
            }
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUnit.Text.TrimEnd()))
            {
                XtraMessageBox.Show("请选择抽样单元");
                return;
            }
            openDlg.Title = "打开文件";
            openDlg.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                SampleData.farmLand = this.cmbCrop.Text = openDlg.FileName;
            }
        }

        private void btnASCDL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUnit.Text.TrimEnd()))
            {
                XtraMessageBox.Show("请选择抽样单元");
                return;
            }
            openDlg.Title = "打开文件";
            openDlg.Filter = "栅格文件(*.tif)|*.tif|All files(*.*)|*.*";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
               SampleData.ASCDL = this.cmbASCDL.Text = openDlg.FileName;
            }
        }
        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleData.targetCrop = cmbDestination.SelectedIndex;
        }

        private void chkArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArea.Checked == true)
            {
                this.cmbAreaField.Enabled = true;
                //this.cmbVillage.Enabled = false;
                this.cmbCrop.Enabled = false;
                this.btnCrop.Enabled = false;
                SampleData.hasArea = true;
                if (string.IsNullOrEmpty(this.cmbUnit.Text.TrimEnd()))
                {
                    XtraMessageBox.Show("读取字段失败：抽样单元为空！");
                    this.chkArea.Checked = false;
                    this.cmbAreaField.Enabled = false;
                    //this.cmbVillage.Enabled = false;
                    this.cmbCrop.Enabled = true;
                    this.btnCrop.Enabled = true;
                    return;
                }
            }
            else
            {
                this.cmbAreaField.Enabled = false;
                //this.cmbVillage.Enabled = true;
                SampleData.hasArea = false;
                SampleData.areaField = string.Empty;
                this.cmbCrop.Enabled = true;
                this.btnCrop.Enabled = true;
            }
        }

        private void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillage.SelectedItem != null)
            {
                SampleData.villageField = cmbVillage.SelectedItem.ToString();
            }
        }
        private void cmbAreaField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAreaField.SelectedItem != null)
            {
                SampleData.areaField = cmbAreaField.SelectedItem.ToString();
            }
        }

        private void cmbASCDL_TextChanged(object sender, EventArgs e)
        {
            string filePath = cmbASCDL.Text.TrimEnd();
            FileInfo file = new FileInfo(filePath);
            string fileHdr = filePath.Replace(file.Extension, ".hdr");
            try
            {
                if (File.Exists(fileHdr))
                {
                    SampleData.classNames = SampleFrame.GetClassFromHdr(fileHdr);
                    this.cmbDestination.Properties.Items.Clear();
                    this.cmbDestination.Properties.Items.AddRange(SampleData.classNames);
                }
                else
                {
                    SampleData.classNames = SampleFrame.GetClassFromRaster(filePath);
                    this.cmbDestination.Properties.Items.Clear();
                    this.cmbDestination.Properties.Items.AddRange(SampleData.classNames);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WriteLog(typeof(frmSampleFrame), ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                SampleFrame sampleFrame = new SampleFrame();
                WaitDialogForm frmWait = new WaitDialogForm("正在处理...", "提示信息");
                try
                {
                    frmWait.Owner = this;
                    frmWait.TopMost = false;
                    string msg = string.Empty;
                    if (chkArea.Checked)
                    {
                        SampleData.hasArea = true;
                        SampleData.areaField = cmbAreaField.Text;
                        SampleData.firstUnit = this.cmbUnit.Text.TrimEnd();
                        SampleData.farmLand = this.cmbCrop.Text.TrimEnd();
                        SampleData.ASCDL = cmbASCDL.Text;
                        SampleData.targetCrop = this.cmbDestination.SelectedIndex;
                        frmWait.Caption = "参数检查...";
                        if (!sampleFrame.ChkData(out msg))
                        {
                            XtraMessageBox.Show(msg);
                            return;
                        }
                        frmWait.Caption = "计算分类面积...";
                        if (!sampleFrame.CalClassArea(SampleData.firstUnit, SampleData.ASCDL, SampleData.targetCrop, out msg))
                        {
                            XtraMessageBox.Show(msg);
                            return;
                        }
                    }
                    else
                    {
                        SampleData.hasArea = false;
                        SampleData.areaField = string.Empty;
                        SampleData.firstUnit = this.cmbUnit.Text.TrimEnd();
                        SampleData.farmLand = this.cmbCrop.Text.TrimEnd();
                        SampleData.ASCDL = cmbASCDL.Text;
                        SampleData.targetCrop = this.cmbDestination.SelectedIndex;
                        frmWait.Caption = "参数检查...";
                        if (!sampleFrame.ChkData(out msg))
                        {
                            XtraMessageBox.Show(msg);
                            return;
                        }
                        frmWait.Caption = "计算耕地面积...";
                        if (!sampleFrame.CalLandArea(SampleData.firstUnit, SampleData.farmLand, out msg))
                        {
                            XtraMessageBox.Show(msg);
                            return;
                        }
                        frmWait.Caption = "计算分类面积...";
                        if (!sampleFrame.CalClassArea(SampleData.firstUnit, SampleData.ASCDL, SampleData.targetCrop, out msg))
                        {
                            XtraMessageBox.Show(msg);
                            return;
                        }

                    }
                    if (DialogResult.OK == XtraMessageBox.Show("处理完毕.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        MapAPI.AddShpFileToMap(SampleData.firstUnit);
                        MapAPI.AddShpFileToMap(SampleData.farmLand);
                        MapAPI.AddRasterFileToMap(SampleData.ASCDL);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message,"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    frmWait.Close();
                }
            }
 
            }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                //if (string.IsNullOrEmpty(SampleData.firstUnit))
                //{
                //    XtraMessageBox.Show("请选择一级抽样单元！");
                //    return;
                //}

                //IFeatureClass pFeatureClass = null;
                //pFeatureClass = EngineAPI.OpenFeatureClass(SampleData.firstUnit);
                //IFeatureLayer pLayer = new FeatureLayerClass();
                //pLayer.FeatureClass = pFeatureClass;
                //EnviVars.instance.MapControl.AddLayer(pLayer);
                //ITableConversion conver = new TableConversion();
                //_dt = conver.AETableToDataTable(pFeatureClass);
                //this.gridControlTable.DataSource = _dt;
                //frmSampleLayer frm = new frmSampleLayer();
                //frm.Show();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }








  

    }
}
