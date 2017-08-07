// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmLayerBatch.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using SDJT.Sys;
using SDJT.Const;
using SDJT.Carto;
using SDJT.Log;

/// <summary>
/// The UI namespace.
/// </summary>
namespace SDJT.Commands.UI
{
    /// <summary>
    /// Class frmLayerBatch.
    /// </summary>
    public partial class frmLayerBatch : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// The M_P map
        /// </summary>
        private IMap m_pMap;

        private Logger m_logger = new Logger();

        /// <summary>
        /// The ms G01
        /// </summary>
        private static string MSG01 = "请选择图层！";
        /// <summary>
        /// Initializes a new instance of the <see cref="frmLayerBatch"/> class.
        /// </summary>
        /// <param name="pMap">The p map.</param>
        public frmLayerBatch(IMap pMap)
        {
            this.InitializeComponent();
            this.m_pMap = pMap;
            //EnviVars.instance.LanguageManager.SetLanguage(this);
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ctrlListboxLayers1.GetLayers.Count == 0)
                {
                    XtraMessageBox.Show(frmLayerBatch.MSG01, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    for (int i = 0; i < this.ctrlListboxLayers1.GetLayers.Count; i++)
                    {
                        ILayer layer = this.ctrlListboxLayers1.GetLayers[i];
                        this.m_pMap.DeleteLayer(layer);
                    }
                    //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                    base.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
            }
        }

        /// <summary>
        /// Handles the Load event of the frmLayerBatch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmLayerBatch_Load(object sender, EventArgs e)
        {
            List<ILayer> layersFromMap = LayerAPI.GetLayersFromMap(this.m_pMap);
            Dictionary<ILayer, bool> dictionary = new Dictionary<ILayer, bool>();
            for (int i = 0; i < layersFromMap.Count; i++)
            {
                dictionary.Add(layersFromMap[i], false);
            }
            this.ctrlListboxLayers1.InitTreelistLayers(dictionary, true);
        }

        /// <summary>
        /// Handles the HelpButtonClicked event of the frmLayerBatch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void frmLayerBatch_HelpButtonClicked(object sender, CancelEventArgs e)
        {
        }
    }
}