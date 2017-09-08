// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-23-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-24-2017
// ***********************************************************************
// <copyright file="DecisionNode.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>决策树节点类，存储节点位置及控件等信息</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace GFS.ClassificationBLL
{
    /// <summary>
    /// Class DecisionNode.
    /// </summary>
    public class DecisionNode
    {
        public string expression = string.Empty;
        //public string decisionData;
        public int classValue=-1;
        public Color nodeColor
        { 
            get
            {
                if (this.button == null)
                    return Color.Empty;
                else
                    return button.Appearance.BackColor;
            }
            set 
            {
                if (button != null)
                    button.Appearance.BackColor = value;
            }
        }
        //
        //节点名称
        //
        private string name;
        public string NodeName
        { 
            get { return name; }
        }
        //
        //节点控件
        //
        public SimpleButton button = null;
        //
        //节点显示文本
        //
        public string Text
        {
            get { return this.button.Text; }
            set { this.button.Text = value; }
        }
        //
        //节点层号
        //
        public int layer;
        //
        //节点序号
        //
        public int index;
        //
        //父节点对象
        //
        public DecisionNode father;
        //
        //左右子节点
        //
        public DecisionNode lChild;
        public DecisionNode rChild;

        /// <summary>
        /// 构造函数 <see cref="DecisionNode"/> class.
        /// </summary>
        /// <param name="father">父节点.</param>
        /// <param name="layer">层号</param>
        /// <param name="index">序号</param>
        public DecisionNode(DecisionNode father, int layer, int index)
        {
            this.layer = layer;
            this.index = index;
            name = "node" + layer + index;
            this.father = father;
            if (father != null)
            {
                if (this.index == father.index * 2)
                    this.father.lChild = this;
                else
                    this.father.rChild = this;
            }
            this.button = DecisionNode.NewNodeButton(this);
        }

        /// <summary>
        /// 新建节点显示控件.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>SimpleButton.</returns>
        public static SimpleButton NewNodeButton(DecisionNode node)
        {
            SimpleButton btn = new SimpleButton();
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            btn.Name = node.NodeName;
            btn.Size = new System.Drawing.Size(60, 24);
            btn.Text = node.NodeName;
            btn.Tag = node;
            btn.Appearance.Options.UseBackColor = true;
            //if (node.layer > 0)
            {
                btn.MouseDown += new MouseEventHandler(simpleButton_MouseDown);
                btn.DoubleClick += new EventHandler(simpleButton_DoubleClick);
            }
            if (node.layer > 0)
            {
                Random random=new Random();
                btn.Appearance.BackColor = RandomColor.GetRandomColor();
                btn.Appearance.ForeColor = Color.White;
            }
            return btn;
        }
        //
        //右键点击弹出菜单
        //
        private static void simpleButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Canvas.instance.curNode = (sender as SimpleButton).Tag as DecisionNode;
                Canvas.instance.nodeMenu.ShowPopup(Control.MousePosition);
            }
        }
        //
        //编辑节点击逻辑
        //
        private static void simpleButton_DoubleClick(object sender, EventArgs e)
        {
            Form frm = null;
            Canvas.instance.curNode = (sender as SimpleButton).Tag as DecisionNode;
            if (Canvas.instance.curNode.lChild == null)
                frm = new frmEditLeaf();
            else
                frm = new frmEditNode();
            frm.ShowDialog();
        }
    }
}
