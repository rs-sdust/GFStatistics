// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 09-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-01-2017
// ***********************************************************************
// <copyright file="frmSampleAnalystResult.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>UI for display sample analyst result</summary>
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

namespace GFS.Classification
{
    public partial class frmSampleAnalystResult : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dt = null;
        public frmSampleAnalystResult(DataTable dt)
        {
            InitializeComponent();
            this._dt = dt;
        }

        private void frmSampleAnalystResult_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = this._dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存xls文件";
            dialog.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //System.IO.FileStream fs = (System.IO.FileStream)kk.OpenFile();
                    this.gridControl1.ExportToXls(dialog.FileName);
                    //fs.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show("数据导出成功！", "提示");
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("数据导出失败！" + ex.Message, "提示");
                    Log.WriteLog(typeof(frmStatisticsResult), ex);
                }
                finally
                {
                    this.Close();
                }
            }
        }

    }
}