﻿// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 08-22-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-29-2017
// ***********************************************************************
// <copyright file="frmDecisionTree.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>决策树分类编辑UI</summary>
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
using System.Drawing.Drawing2D;
using DevExpress.Utils;
using GFS.BLL;

namespace GFS.Classification
{
    public partial class frmDecisionTree : DevExpress.XtraEditors.XtraForm
    {
        string _treeFile = "";
        public frmDecisionTree()
        {
            InitializeComponent();

            //this.panelCanvas.Tag = false;
            Canvas.instance.panelCanvas = this.panelCanvas; 
            Canvas.instance.nodeMenu = this.popupMenuRight;
            Canvas.instance.decisionTree = new DecisionTree();
            //Canvas.instance.gridTable = this.gridValueAndFile;
        }
        public frmDecisionTree(string treeFile)
        {
            InitializeComponent();

            //this.panelCanvas.Tag = false;
            Canvas.instance.panelCanvas = this.panelCanvas;
            Canvas.instance.nodeMenu = this.popupMenuRight;
            Canvas.instance.decisionTree = new DecisionTree();
            //Canvas.instance.gridTable = this.gridValueAndFile;
            _treeFile = treeFile;
        }
        private void frmDecisionTree_Load(object sender, EventArgs e)
        {
            Canvas.instance.decisionTree.RefreshTree();
            InitialGrigFile();
            this.gridValueAndFile.Visible = false;
            if(!string.IsNullOrEmpty(_treeFile))
                Canvas.instance.decisionTree.OpenDecisionTree(_treeFile);
        }
        //
        //新建决策树
        //
        private void btnNew_Click(object sender, EventArgs e)
        {
            Canvas.instance.decisionTree = new DecisionTree();
            //Canvas.instance.panelCanvas.Tag = true;
            Canvas.instance.decisionTree.RefreshTree();
            panelCanvas.Refresh();
            InitialGrigFile();
        }

        //
        //添加节点
        //
        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                DecisionNode father = Canvas.instance.curNode;
                if (father.lChild != null)
                    return;
                father.button.Appearance.BackColor = Color.Empty;
                father.button.Appearance.ForeColor = Color.Black;
                father.classValue = -1;
                father.Text = father.NodeName;
                int layerIndex = father.layer + 1;
                int lIndex = father.index * 2;
                int rIndex = father.index * 2 + 1;
                DecisionNode lChild = new DecisionNode(father, layerIndex, lIndex);
                DecisionNode rChild = new DecisionNode(father, layerIndex, rIndex);
                if (Canvas.instance.decisionTree.layerCount == layerIndex)
                {
                    DecisionTreeLayer layer = new DecisionTreeLayer(layerIndex);
                    layer.nodeList[lIndex] = lChild;
                    layer.nodeList[rIndex] = rChild;
                    Canvas.instance.decisionTree.AddLayer(layer);
                }
                else if (Canvas.instance.decisionTree.layerCount > layerIndex)
                {
                    DecisionTreeLayer layer = Canvas.instance.decisionTree.GetLayer(layerIndex);
                    {
                        layer.nodeList[lIndex] = lChild;
                        layer.nodeList[rIndex] = rChild;
                    }
                }
                Canvas.instance.treeSaved = false;
                Canvas.instance.decisionTree.RefreshTree();
                panelCanvas.Refresh();
        }
        //
        //编辑节点
        //
        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = null;
            if (Canvas.instance.curNode.lChild == null)
                frm = new frmEditLeaf();
            else
                frm = new frmEditNode();
            frm.ShowDialog();
        }
        //
        //显示变量
        //
        private void barChkValueFile_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridValueAndFile.Visible = barChkValueFile.Checked;
        }
        //
        //删除子节点
        //
        private void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Canvas.instance.decisionTree.RemoveChildTree(Canvas.instance.curNode);
            Canvas.instance.treeSaved = false;
            Canvas.instance.decisionTree.RefreshTree();
            panelCanvas.Refresh();
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.Title = "保存决策树";
            frm.Filter = "决策树文件（*.tree）|*.tree";
            if(frm.ShowDialog()==DialogResult.OK)
            {
                string file = frm.FileName;
                Canvas.instance.treeSaved = Canvas.instance.decisionTree.SaveDecisionTree(file);
            }
        }
        //打开
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = "打开决策树";
            frm.Filter = "决策树文件（*.tree）|*.tree";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string file = frm.FileName;
                Canvas.instance.decisionTree.OpenDecisionTree(file);
                Canvas.instance.treeSaved = true;
            }
        }

        private void frmDecisionTree_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Canvas.instance.treeSaved)
                return;
            if (XtraMessageBox.Show("是否保存决策树？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.btnSave_Click(null,null);
            }
        }

        private  void InitialGrigFile()
        {
            DecisionTree.variableTable = new DataTable();
            DecisionTree.variableTable.Columns.Add("变量");
            DecisionTree.variableTable.Columns.Add("文件");
            this.gridValueAndFile.DataSource = DecisionTree.variableTable;
            this.gridView1.Columns[0].Width = 30;
        }
        //
        //选择文件
        //
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "打开文件";
            fileDialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                int band = MAP.GetBandCount(file);
                if (band > 1)
                {
                    frmBandSelection frm = new frmBandSelection(band);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        file = file + ":" + frm.SelectedBand;
                    }
                }
                DataTable dt = this.gridValueAndFile.DataSource as DataTable;
                dt.Rows[gridView1.FocusedRowHandle][1] = file;
                Canvas.instance.treeSaved = false;

            }
        }
        //
        //执行
        //
        private void btnRun_Click(object sender, EventArgs e)
        {
            frmWaitDialog frmWait = new frmWaitDialog("正在分类...", "提示信息");
            try
            {
                frmWait.Owner = this;
                frmWait.TopMost = false;               
                //获取组合的条件运算公式，若检查失败，提示并返回
                RasterMapAlgebraOp op = new RasterMapAlgebraOp(Canvas.instance.decisionTree.GetLayer(0).nodeList[0], DecisionTree.variableTable);
                string msg = "";
                if (!op.CheckExp(Canvas.instance.decisionTree.GetLayer(0).nodeList[0], out msg))
                {
                    XtraMessageBox.Show(msg);
                    return;
                }
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "保存结果文件";
                dialog.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    op.Execute(dialog.FileName);
                }
                //元数据
                if (_treeFile.Contains( "gf4.tree"))
                {
                    BLL.ProductMeta meta = new ProductMeta(dialog.FileName, "GF4", "", "长时间序列识别结果", "作物识别结果");
                    meta.WriteGeoMeta();
                }
                else
                {
                    BLL.ProductMeta meta = new ProductMeta(dialog.FileName, "", "", "决策树识别结果", "作物识别结果");
                    meta.WriteGeoMeta();
                }
                //快视图
                BLL.ProductQuickView view = new BLL.ProductQuickView(dialog.FileName);
                view.Create();

                if (DialogResult.OK == XtraMessageBox.Show("分类完毕，是否加分类载结果？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    MAP.AddRasterFileToMap(dialog.FileName);
                //this.Close();
            }
            catch (Exception ex)
            { XtraMessageBox.Show("分类失败：" + ex.Message); }
            finally
            {
                frmWait.Close();
            }

        }

        private void frmDecisionTree_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ShowHelp(this);
        }
        


    }
}