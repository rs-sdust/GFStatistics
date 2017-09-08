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

    }
}