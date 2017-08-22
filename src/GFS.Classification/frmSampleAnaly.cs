// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 08-17-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-21-2017
// ***********************************************************************
// <copyright file="frmSampleAnaly.cs" company="BNU">
//     Copyright (c)BNU . All rights reserved.
// </copyright>
// <summary>sample analyst UI</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using GFS.BLL;
using GFS.Common;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using GFS.ClassificationBLL;
using GFS.Commands;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace GFS.Classification
{
    public partial class frmSampleAnaly : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        //business class
        private SampleAnalyst sample = new SampleAnalyst();
        public frmSampleAnaly()
        {
            InitializeComponent();
        }
        private void frmSampleAnaly_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;            
            MapAPI.GetAllLayers(cmbRaster,null);
        }


        private void cmbRaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbRaster.Text) && File.Exists(cmbRaster.Text))
                sample.rasterFile = cmbRaster.Text;
        }

        private void btnOpenRaster_Click(object sender, EventArgs e)
        {

            dlg.Title = "打开栅格文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "栅格文件|*.tif";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbRaster.Text = dlg.FileName;

            if (!string.IsNullOrEmpty(cmbRaster.Text) && File.Exists(cmbRaster.Text))
                sample.rasterFile = cmbRaster.Text;

        }

        private void btnOpenROI_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开样本文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "样本文件|*.xml";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtROI.Text = dlg.FileName;

            if (!string.IsNullOrEmpty(txtROI.Text) && File.Exists(txtROI.Text))
            {
                sample.roiFile = txtROI.Text;
                sample.LoadROI();
                this.chkListParam.Items.Clear();
                foreach(KeyValuePair<int,ROILayerClass> current in sample.RoiLayerDic)
                {
                    this.chkListParam.Items.Add(current.Value.Name);
                }
                this.chkListParam.CheckAll();
            }
        }

        private void chkListParam_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (this.chkListParam.CheckedItems.Count == 0)
            {
                XtraMessageBox.Show("至少选择一个类别！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.chkListParam.CheckSelectedItems();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WaitDialogForm frmWait = new WaitDialogForm("正在分析样本...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                List<string> list = new List<string>();
                foreach (CheckedListBoxItem item in this.chkListParam.CheckedItems)
                {
                    list.Add(item.ToString());
                }
                DataTable result = sample.Execute(list);
                if (result == null)
                {
                    XtraMessageBox.Show("执行样本分析失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    frmSampleAnalystResult frm = new frmSampleAnalystResult(result);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(frmSampleAnaly), ex);
            }
            finally
            {
                frmWait.Close();
                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (this.Size == this.MinimumSize)
            {
                this.btnHelp.Text = "隐藏帮助<<";
                this.Size = this.MaximumSize;
            }
            else
            {
                this.btnHelp.Text = "显示帮助>>";
                this.Size = this.MinimumSize;
            }
        }

    }
}