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

namespace GFS.Sample
{
    public partial class frmErrorAnalysis : DevExpress.XtraEditors.XtraForm
    {
        public frmErrorAnalysis()
        {
            InitializeComponent();
        }

        private void frmClipRaster_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            groupControlChart.Visible = true;
        }

        private void siBhelphide_Click(object sender, EventArgs e)
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

  

    }
}
