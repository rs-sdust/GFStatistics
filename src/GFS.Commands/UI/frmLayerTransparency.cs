// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="frmLayerTransparency.cs" company="SDJT">
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
//using SDJT.Sys;
using GFS.BLL;

/// <summary>
/// The UI namespace.
/// </summary>
namespace GFS.Commands.UI
{
    /// <summary>
    /// Class frmLayerTransparency.
    /// </summary>
    public partial class frmLayerTransparency : DevExpress.XtraEditors.XtraForm
    {
        //private Logger m_logger = new Logger();

        /// <summary>
        /// The M_P layer
        /// </summary>
        private ILayer m_pLayer;

        /// <summary>
        /// The M_P map
        /// </summary>
        private IMap m_pMap;
        /// <summary>
        /// Initializes a new instance of the <see cref="frmLayerTransparency"/> class.
        /// </summary>
        /// <param name="pMap">The p map.</param>
        /// <param name="pLayer">The p layer.</param>
        public frmLayerTransparency(IMap pMap, ILayer pLayer)
        {
            this.m_pLayer = pLayer;
            this.m_pMap = pMap;
            this.InitializeComponent();
            //EnviVars.instance.LanguageManager.SetLanguage(this);
            //ControlWrapper.SetTableLayoutPanel(this.tableLayoutPanel1);
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
                this.SetLayerTransparency();
                //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, this.Text, null);
                base.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                Log.WriteLog(typeof(frmLayerTransparency), ex);
            }
        }

        /// <summary>
        /// Sets the layer transparency.
        /// </summary>
        private void SetLayerTransparency()
        {
            try
            {
                ILayerEffects layerEffects = this.m_pLayer as ILayerEffects;
                string s = this.zoomTrackBarControl1.EditValue.ToString();
                layerEffects.Transparency = short.Parse(s);
                IViewRefresh viewRefresh = this.m_pMap as IViewRefresh;
                viewRefresh.RefreshItem(this.m_pLayer);
            }
            catch(Exception ex)
            {
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this.Text, ex);
                Log.WriteLog(typeof(frmLayerTransparency), ex);
            }
        }

        /// <summary>
        /// Gets the layer transparency.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetLayerTransparency()
        {
            int result;
            try
            {
                ILayerEffects layerEffects = this.m_pLayer as ILayerEffects;
                int transparency = (int)layerEffects.Transparency;
                result = transparency;
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Handles the Load event of the frmLayerTransparency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmLayerTransparency_Load(object sender, EventArgs e)
        {
            this.zoomTrackBarControl1.Value = this.GetLayerTransparency();
            this.spinTransparency.Value = this.zoomTrackBarControl1.Value;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the spinTransparency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void spinTransparency_EditValueChanged(object sender, EventArgs e)
        {
            this.zoomTrackBarControl1.Value = (int)this.spinTransparency.Value;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the zoomTrackBarControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            this.spinTransparency.Value = this.zoomTrackBarControl1.Value;
        }

        /// <summary>
        /// Handles the HelpButtonClicked event of the frmLayerTransparency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void frmLayerTransparency_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            //HelpManager.ShowHelp(this);
        }
    }
}