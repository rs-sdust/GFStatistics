// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 09-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-01-2017
// ***********************************************************************
// <copyright file="frmOOClassification.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>面向对象分类UI</summary>
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
using GFS.ClassificationBLL;
using DevExpress.Utils;
using GFS.BLL;
using System.IO;

namespace GFS.Classification
{
    public partial class frmOOClassification : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        private int actFun ;
        public int hiddenLyr ;
        public int maxSweep ;
        public float minActThres;
        public frmOOClassification()
        {
            InitializeComponent();
        }
        private void frmOOClassification_Load(object sender, EventArgs e)
        {
            this.spinContribution.EditValue = 0.9;
            this.spinTraingRate.EditValue = 0.2;
            this.spinMomentum.EditValue = 0.9;
            this.chkLogistic.Checked = true;
            this.actFun = 0;
            this.spinCriteria.EditValue = 0.1;
            this.hiddenLyr = 2;
            this.maxSweep = 20;
            this.minActThres = 0.4f;
            MapAPI.GetAllLayers(cmbInRaster, null);
        }
        private void btnInRaster_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开栅格文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "栅格文件|*.tif";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbInRaster.Text = dlg.FileName;
        }
        private void btnInROI_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开样本文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "样本文件|*.sample";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtROI.Text = dlg.FileName;
        }


        private void chkLogistic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLogistic.Checked)
            {
                this.actFun = 0;
                this.chkHyperbolic.Checked = false;
            }
            else
            {
                this.actFun = 1;
                this.chkHyperbolic.Checked = true;
            }
        }

        private void chkHyperbolic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHyperbolic.Checked)
            {
                this.actFun = 1;
                this.chkLogistic.Checked = false;
            }
            else
            {
                this.actFun = 0;
                this.chkLogistic.Checked = true;
            }
        }
        private void ztbContribution_EditValueChanged(object sender, EventArgs e)
        {
            this.spinContribution.EditValue = float.Parse(this.ztbContribution.EditValue.ToString())/10f;
        }

        private void spinContribution_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbContribution.EditValue = float.Parse(this.spinContribution.EditValue.ToString()) *10;
        }

        private void ztbTraingRate_EditValueChanged(object sender, EventArgs e)
        {
            this.spinTraingRate.EditValue = float.Parse(this.ztbTraingRate.EditValue.ToString()) / 10f;
        }

        private void spinTraingRate_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbTraingRate.EditValue = float.Parse(this.spinTraingRate.EditValue.ToString()) * 10;
        }

        private void ztbMomentum_EditValueChanged(object sender, EventArgs e)
        {
            this.spinMomentum.EditValue = float.Parse(this.ztbMomentum.EditValue.ToString()) / 10f;
        }

        private void spinMomentum_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbMomentum.EditValue = float.Parse(this.spinMomentum.EditValue.ToString()) * 10;
        }

        private void ztbCriteria_EditValueChanged(object sender, EventArgs e)
        {
            this.spinCriteria.EditValue = float.Parse(this.ztbCriteria.EditValue.ToString()) / 10f;
        }

        private void spinCriteria_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbCriteria.EditValue = float.Parse(this.spinCriteria.EditValue.ToString()) * 10;
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            frmOOClassMorePara para = new frmOOClassMorePara(this);
            para.ShowDialog();
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtOut.Text = dialog.FileName;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            WaitDialogForm frmWait = new WaitDialogForm("正在分类...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                OOClassification ooC = new OOClassification(cmbInRaster.Text, txtROI.Text, actFun,
                    float.Parse(spinContribution.EditValue.ToString()), float.Parse(spinTraingRate.EditValue.ToString()),
                    float.Parse(spinMomentum.EditValue.ToString()), float.Parse(spinCriteria.EditValue.ToString()),
                    hiddenLyr, maxSweep, minActThres, txtOut.Text);
                ooC.Execute();
                if (XtraMessageBox.Show("分类完成，是否加载？", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    MAP.AddRasterFileToMap(txtOut.Text.TrimEnd());
                this.Close();
            }
            catch (Exception ex)
            {
                //此处调用成功并写出结果后仍会抛出异常。
                Log.WriteLog(typeof(frmSegmentation), ex);
                if (File.Exists(txtOut.Text.TrimEnd()))
                {
                    FileInfo fInfo = new FileInfo(txtOut.Text.TrimEnd());
                    if (fInfo.Length / (1024 * 1024) > 1)
                    {
                        if (XtraMessageBox.Show("分类完成，是否加载？", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            MAP.AddRasterFileToMap(txtOut.Text.TrimEnd());
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("分类失败：\r\n" + ex.Message, "提示信息");
                }
            }
            finally
            {
                frmWait.Close();
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }









    }
}