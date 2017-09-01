// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-23-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-23-2017
// ***********************************************************************
// <copyright file="Canvas.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>提供可全局访问的决策树对象和绘制图形的panel对象</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace GFS.ClassificationBLL
{
    public class Canvas
    {
        public static readonly Canvas instance;
        public XtraScrollableControl panelCanvas = null;
        //public GridControl gridTable = null;
        public DecisionTree decisionTree = null;
        public PopupMenu nodeMenu = null;
        public DecisionNode curNode = null;
        public BarButtonItem addNode = null;
        public BarButtonItem editNode = null;
        public BarButtonItem delNode = null;
        public bool treeSaved = false;
        static Canvas()
        {
            Canvas.instance = new Canvas();
        }
    }
}
