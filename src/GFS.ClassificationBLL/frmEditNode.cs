// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-28-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-28-2017
// ***********************************************************************
// <copyright file="frmEditNode.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>节点（分类条件）编辑UI</summary>
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
    public partial class frmEditNode : DevExpress.XtraEditors.XtraForm
    {
        DecisionNode _curNode = null;
        public frmEditNode()
        {
            InitializeComponent();
        }

        private void frmEditNode_Load(object sender, EventArgs e)
        {
            if (Canvas.instance.curNode == null)
                return;
            this._curNode = Canvas.instance.curNode;
            this.txtNodeaName.Text = _curNode.Text;
            this.txtExp.Text = _curNode.expression;
            this.txtExp.Text=this.txtExp.Text.Replace("[", "");
            this.txtExp.Text=this.txtExp.Text.Replace("]", "");
            //this.txtData.Text = _curNode.decisionData;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _curNode.Text = this.txtNodeaName.Text.TrimEnd();
            //_curNode.expression = this.txtExp.Text.TrimEnd();
            //_curNode.decisionData = this.txtData.Text.TrimEnd();
            //get variable list
            List<string> variable = DecisionTree.ParseExpression(this.txtExp.Text, out _curNode.expression);
            if (variable != null)
            {
                foreach (string str in variable)
                {
                    if (!IsVariableExists(str))
                    {
                        DataRow row = DecisionTree.variableTable.NewRow();
                        row[0] = str;
                        DecisionTree.variableTable.Rows.Add(row);
                    }
                }
            }
            //refresh variable table
            //Canvas.instance.RefreshVariable();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNodeaName_EditValueChanged(object sender, EventArgs e)
        {
            Canvas.instance.treeSaved = false;
        }

        private void txtData_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "打开文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                int band =MAP.GetBandCount(file);
                if ( band > 1)
                {
                    frmBandSelection frm = new frmBandSelection(band);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        file = file + ":" + frm.SelectedBand;
                    }
                }
                //this.txtData.Text = file;
            }
        }

        private bool IsVariableExists(string name)
        {
            if (DecisionTree.variableTable.Rows.Count == 0)
                return false;
            else
            {
                for (int i = 0; i < DecisionTree.variableTable.Rows.Count; i++)
                {
                    if (name == DecisionTree.variableTable.Rows[i][0].ToString())
                        return true;
                }
                return false;
            }
        }

    }
}