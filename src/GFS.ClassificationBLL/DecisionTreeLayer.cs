// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-24-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-24-2017
// ***********************************************************************
// <copyright file="DecisionTreeLayer.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>节点层类，存储整层节点</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFS.ClassificationBLL
{
    public class DecisionTreeLayer
    {
        //
        //层号
        //
        public int layerIndex=-1;
        //
        //节点列表
        //
        public DecisionNode[] nodeList = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="layerIndex">Index of the layer.</param>
        public DecisionTreeLayer(int layerIndex)
        {
            if (layerIndex < 0)
                layerIndex = 0;

                this.layerIndex = layerIndex;
                int nodeCount = (int)Math.Pow(2,layerIndex);
                nodeList = new DecisionNode[nodeCount];
        }

    }
}
