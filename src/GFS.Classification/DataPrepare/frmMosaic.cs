// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Zhen Lu
// Created          : 08-17-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-18-2017
// ***********************************************************************
// <copyright file="frmMosaic.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>Mosaic UI</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GFS.ClassificationBLL;
using DevExpress.Utils;
using System.Threading;
using GFS.BLL;
using DevExpress.XtraEditors;

namespace GFS.Classification
{
    public partial class frmMosaic : DevExpress.XtraEditors.XtraForm
    {
        //
        //record band count
        //
        private int _bandCount = -1;
        //
        //record pixel type
        //
        private string _pixelType = string.Empty;

        public frmMosaic()
        {
            InitializeComponent();
            InitialPixelType();

        }

        private void mosaic_Load(object sender, EventArgs e)
        {
            this.Size = MinimumSize;         
        }
        
        private void siBAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in fileDialog.FileNames)
                {
                    int bandCount;
                    string pixelType;
                    //read band count and pixel type of file added
                    if (MapAPI.ReadBandAndPixelInfo(file, out bandCount, out pixelType))
                    {
                        //if current band count less than 0 record the band count of the first file .
                        if (_bandCount < 0)
                        {
                            _bandCount = bandCount;
                        }
                        //if current pixel type is empty record the pixel type of the first file.
                        if(string.IsNullOrEmpty(_pixelType))
                        {
                            _pixelType = pixelType;
                            this.cmbPixelType.Text = _pixelType;
                        }
                        //if the band count of current file is different with band count recorded.remind user and skip add this file
                        if (_bandCount != bandCount)
                        {
                            XtraMessageBox.Show("文件：" + file + "\r\n与其他栅格波段数不一致，请检查！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            continue;
                        }
                    }
                    //if read file failed skip add this file
                    else
                    {
                        continue;
                    }
                    //determain whether the file has been added
                    if (!this.Contains(file))
                    {
                        this.listDataSet.Items.Add(file);
                    }
                }
            }
        }

        private void siBdelete_Click(object sender, EventArgs e)
        {
            //移除选定文件
            int index = listDataSet.SelectedIndex;
            if (index > -1)
            {
                this.listDataSet.Items.RemoveAt(index);
            }
            //若文件列表被清空则重置记录的波段数和像素类型
            if (listDataSet.Items.Count < 1)
            {
                this._bandCount = -1;
                this._pixelType = string.Empty;
                this.cmbPixelType.Text = string.Empty;
            }
        }

        private void siBPath_Click(object sender, EventArgs e)
        {
            string localFilePath = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog1.FileName.ToString();
                txtOut.Text = saveFileDialog1.FileName;

            }
        }
        
        private void siBOK_Click(object sender, EventArgs e)
        {
            if (listDataSet.Items.Count <= 0 || string.IsNullOrEmpty(txtOut.Text.Trim()))
            {
                MessageBox.Show("错误信息：\n栅格图像的值：是必需的\n输出结果的值：是必需的");
            }
            else
            {
                WaitDialogForm frmWait = new WaitDialogForm("正在拼接...", "提示信息");
                try
                {
                    frmWait.Owner = this;
                    frmWait.TopMost = false;
                    //获取文件列表字符串以；分割
                    string fileList = GetFileList();
                    FileInfo fileInfo = new FileInfo(txtOut.Text);
                    string msg = string.Empty;
                    if (EnviVars.instance.GpExecutor.Mosaic(fileList, fileInfo.DirectoryName, fileInfo.Name, this.cmbPixelType.Text, out msg, this._bandCount))
                    {
                        System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("拼接成功,是否加载结果？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            //添加结果到主地图视图
                            MAP.AddRasterFileToMap(txtOut.Text);
                        }
                        else
                        {
                            XtraMessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

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
        
        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void siBHelpShow_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBHelpShow.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                siBHelpShow.Text = "显示帮助>>";
            }
        }
        
        private void siBUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == listDataSet.SelectedItem)
                    return;

                int index = this.listDataSet.SelectedIndex;
                if (index > 0)
                {
                    listDataSet.BeginUpdate();
                    var item = listDataSet.Items[index];
                    listDataSet.Items.RemoveAt(index);
                    listDataSet.Items.Insert(index - 1, item);
                    listDataSet.EndUpdate();
                    listDataSet.SelectedIndex = index - 1;
                }
            }
            catch (Exception)
            { }

        }
        
        private void siBDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == listDataSet.SelectedItem)
                    return;

                int index = this.listDataSet.SelectedIndex;
                if (index < 0)
                    return;
                if (index < listDataSet.Items.Count - 1)
                {
                    listDataSet.BeginUpdate();
                    var item = listDataSet.Items[index];
                    listDataSet.Items.RemoveAt(index);
                    listDataSet.Items.Insert(index + 1, item);
                    listDataSet.EndUpdate();
                    listDataSet.SelectedIndex = index + 1;
                }
            }
            catch (Exception)
            { }
        }
        //
        //determain whether the file has been added
        //
        private bool Contains(string file)
        {
            if (listDataSet.Items == null)
                return false;
            if (listDataSet.Items.Count < 1)
                return false;

            foreach (var item in listDataSet.Items)
            {
                if (file == item.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        //
        //initialize pixel type list
        //
        private void InitialPixelType()
        {
            this.cmbPixelType.Properties.Items.Clear();
            this.cmbPixelType.Properties.Items.Add("1_BIT");
            this.cmbPixelType.Properties.Items.Add("2_BIT");
            this.cmbPixelType.Properties.Items.Add("4_BIT");
            this.cmbPixelType.Properties.Items.Add("8_BIT_UNSIGNED");
            this.cmbPixelType.Properties.Items.Add("8_BIT_SIGNED");
            this.cmbPixelType.Properties.Items.Add("16_BIT_UNSIGNED");
            this.cmbPixelType.Properties.Items.Add("16_BIT_SIGNED");
            this.cmbPixelType.Properties.Items.Add("32_BIT_UNSIGNED");
            this.cmbPixelType.Properties.Items.Add("32_BIT_SIGNED");
            this.cmbPixelType.Properties.Items.Add("32_BIT_FLOAT");
            this.cmbPixelType.Properties.Items.Add("64_BIT");

        }
        //
        //get all file str split with ";"
        //
        private string GetFileList()
        {
            string fileList = string.Empty;
            foreach (var item in listDataSet.Items)
            {
                fileList += item.ToString().TrimEnd() + ";";
            }
            fileList = fileList.Substring(0, fileList.Length - 1);
            return fileList;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            List<string> fList = listDataSet.Items.Cast<string>().ToList<string>();
            frmPreview frm = new frmPreview(fList);
            frm.ShowDialog();
        }

        


       

   
    }
}
