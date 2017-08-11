// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CtrlListboxLayers.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using DevExpress.XtraTreeList.Nodes;
//using SDJT.Sys;

/// <summary>
/// The UI namespace.
/// </summary>
namespace GFS.Commands.UI
{
    /// <summary>
    /// Class CtrlListboxLayers.
    /// </summary>
    public partial class CtrlListboxLayers : UserControl
    {
        /// <summary>
        /// The layers
        /// </summary>
        private List<ILayer> layers = new List<ILayer>();
        /// <summary>
        /// Gets the get layers.
        /// </summary>
        /// <value>The get layers.</value>
        public List<ILayer> GetLayers
        {
            get
            {
                this.layers.Clear();
                for (int i = 0; i < this.treeList1.Nodes.Count; i++)
                {
                    TreeListNode treeListNode = this.treeList1.Nodes[i];
                    if (treeListNode.Checked)
                    {
                        this.layers.Add((ILayer)treeListNode.Tag);
                    }
                }
                return this.layers;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtrlListboxLayers"/> class.
        /// </summary>
        public CtrlListboxLayers()
        {
            this.InitializeComponent();
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }

        /// <summary>
        /// Initializes the treelist layers.
        /// </summary>
        /// <param name="pLayers">The p layers.</param>
        /// <param name="bCheck">if set to <c>true</c> [b check].</param>
        public void InitTreelistLayers(Dictionary<ILayer, bool> pLayers, bool bCheck)
        {
            this.treeList1.Nodes.Clear();
            this.treeList1.OptionsView.ShowCheckBoxes = bCheck;
            this.treeList1.BeginUnboundLoad();
            foreach (ILayer current in pLayers.Keys)
            {
                TreeListNode treeListNode = this.treeList1.AppendNode(new object[]
                {
                    current.Name
                }, null);
                treeListNode.Checked = pLayers[current];
                treeListNode.Tag = current;
            }
            this.treeList1.EndUnboundLoad();
            this.treeList1.ExpandAll();
        }

        /// <summary>
        /// Handles the Click event of the btnSelectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeList1.Nodes.Count; i++)
            {
                this.treeList1.Nodes[i].Checked = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.treeList1.Nodes.Count; i++)
            {
                this.treeList1.Nodes[i].Checked = false;
            }
        }
    }
}
