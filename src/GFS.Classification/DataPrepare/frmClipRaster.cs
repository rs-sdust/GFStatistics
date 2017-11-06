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
using GFS.ClassificationBLL;
using DevExpress.Utils;
using System.Threading;
using GFS.BLL;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using GFS.Common;
using ESRI.ArcGIS.Geodatabase;
using GFS.Commands.UI;
using System.IO;

namespace GFS.Classification
{
    public partial class frmClipRaster : DevExpress.XtraEditors.XtraForm
    {

        public frmClipRaster()
        {
            InitializeComponent();
        }

        private void siBgrid_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                cBEreaster.Text = file;
            }
        }

        private void siBvector_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                if (file.Contains(".shp") == false)
                {
                    MessageBox.Show("添加文件的格式不正确，请重新选择");
                }
                else
                    cBEvector.Text = file;
            }
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "保存文件";
            dlg.Filter = "栅格文件|*.tif|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
                this.txtOut.Text = dlg.FileName;
        }

        private void siBOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cBEreaster.Text.TrimEnd()) || string.IsNullOrEmpty(cBEvector.Text.TrimEnd()) || string.IsNullOrEmpty(txtOut.Text.TrimEnd()))
            {
                MessageBox.Show("错误信息：\n栅格图像的值：是必需的\n矢量数据的值：是必需的\n输出结果的值：是必需的");
            }
            else
            {                
                string msg = string.Empty;
                WaitDialogForm frmWait = new WaitDialogForm("正在裁剪...", "提示信息");
                try
                {
                    frmWait.Owner= this;
                    frmWait.TopMost = false;
                    if (EnviVars.instance.GpExecutor.ExtractByMask(cBEreaster.Text.TrimEnd(), cBEvector.Text.TrimEnd(), txtOut.Text.TrimEnd(), out msg))
                    {
                        System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("裁剪成功,是否加载结果？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            MAP.AddRasterFileToMap(txtOut.Text);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Log.WriteLog(typeof(frmClipRaster), ex);
                }
                finally
                {
                    frmWait.Close();
                    this.Close();
                }               
            }
        }

        private void siBconcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBhelphide_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBhelphide.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize ;
                siBhelphide.Text = "显示帮助>>";
            }
        }

        private void frmClipRaster_Load(object sender, EventArgs e)
        {
            MapAPI.GetAllLayers(cBEreaster, cBEvector);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            List<string> fList = new List<string>();
            if (!string.IsNullOrEmpty(cBEreaster.Text.TrimEnd()))
                fList.Add(cBEreaster.Text.TrimEnd());
            if(!string.IsNullOrEmpty(cBEvector.Text.TrimEnd()))
                fList.Add(cBEvector.Text.TrimEnd());
            frmPreview frm = new frmPreview(fList);
            //frm.AddAllLayers();
            frm.ShowDialog();
        }





    }
}
