// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-28-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-29-2017
// ***********************************************************************
// <copyright file="frmEditLeaf.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>叶子（类别）编辑UI</summary>
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
//using GFS.ClassificationBLL;

namespace GFS.ClassificationBLL
{
    public partial class frmEditLeaf : DevExpress.XtraEditors.XtraForm
    {
        private DecisionNode node = null;
        public frmEditLeaf()
        {
            InitializeComponent();
        }

        private void frmEditLeaf_Load(object sender, EventArgs e)
        {
            if (Canvas.instance.curNode == null)
                return;
            node = Canvas.instance.curNode;
            this.txtNodeaName.Text = node.Text;
            this.spinClassValue.Value =node.classValue; 
            this.colorEdit1.Color = node.nodeColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            node.Text = this.txtNodeaName.Text.TrimEnd();
            node.classValue = Convert.ToInt32(spinClassValue.Value);
            node.nodeColor = this.colorEdit1.Color;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNodeaName_EditValueChanged(object sender, EventArgs e)
        {
            Canvas.instance.treeSaved = false;
        }

    }
}