// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 09-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-01-2017
// ***********************************************************************
// <copyright file="frmSegmentation.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>图像分割UI</summary>
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
using GFS.BLL;
using System.IO;
using DevExpress.Utils;
using GFS.ClassificationBLL;

namespace GFS.Classification
{
    public partial class frmSegmentation : DevExpress.XtraEditors.XtraForm
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        
        public frmSegmentation()
        {
            InitializeComponent();
        }

        private void frmSegmentation_Load(object sender, EventArgs e)
        {
            this.ztbSegment.Value = 50;
            this.ztbMerge.Value = 50;
            this.ztbKernel.Value = 3;
            MapAPI.GetAllLayers(cmbIn, null);
        }

        private void ztbSegment_EditValueChanged(object sender, EventArgs e)
        {
            this.spinSegment.EditValue = this.ztbSegment.EditValue;
        }

        private void spinSegment_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbSegment.EditValue = this.spinSegment.EditValue;
        }

        private void ztbMerge_EditValueChanged(object sender, EventArgs e)
        {
            this.spinMerge.EditValue = this.ztbMerge.EditValue;
        }

        private void spinMerge_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbMerge.EditValue = this.spinMerge.EditValue;
        }

        private void ztbKernel_EditValueChanged(object sender, EventArgs e)
        {
            this.spinKernel.EditValue = this.ztbKernel.EditValue;
        }

        private void spinKernel_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbKernel.EditValue = this.spinKernel.EditValue;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开栅格文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "栅格文件|*.tif";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.cmbIn.Text = dlg.FileName;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dilog = new SaveFileDialog();
            dilog.Title = "保存文件";
            dilog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (dilog.ShowDialog() == DialogResult.OK)
            {
                this.txtOut.Text = dilog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(cmbIn.Text.TrimEnd()))
            {
                XtraMessageBox.Show("输入文件不存在！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            frmWaitDialog frmWait = new frmWaitDialog("正在分割...", "提示信息");
                            //string segImage = Path.Combine(ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".tif");
            string segImg = txtOut.Text.TrimEnd();
            string vectorFile = segImg.Substring(0,segImg.LastIndexOf(".")) + ".shp";
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;
                string cmd = ConstDef.IDL_FUN_SEGMENTONLY + ",'" + cmbIn.Text.TrimEnd() + "'," +
                            spinSegment.Value.ToString() + "," + spinMerge.Value.ToString() + "," +
                            spinKernel.Value.ToString() + ",'" + segImg + "','" + vectorFile + "'";
                EnviVars.instance.IdlModel.Execute(cmd);

                if (XtraMessageBox.Show("分割完成，是否加载？","提示信息",MessageBoxButtons.OKCancel) == DialogResult.OK)
                    MAP.AddShpFileToMap(vectorFile);
                this.Close();
            }
            catch(Exception ex)
            {
                //此处调用成功并写出结果后仍会抛出异常。
                Log.WriteLog(typeof(frmSegmentation), ex);
                if (File.Exists(segImg))
                {
                    FileInfo fInfo = new FileInfo(segImg);
                    if (fInfo.Length / (1024 * 1024) > 1)
                    {
                        if (XtraMessageBox.Show("分割完成，是否加载？", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            MAP.AddShpFileToMap(vectorFile);
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("分割失败：\r\n"+ex.Message,"提示信息");
                }
                //XtraMessageBox.Show(ex.Message);
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

        private void frmSegmentation_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }





    }
}