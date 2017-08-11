// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdOpenLayerTable.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
//using SDJT.Sys;
using GFS.Commands.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using ESRI.ArcGIS.Geodatabase;
using GFS.BLL;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdOpenLayerTable. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("857a9977-721e-4240-b07c-8cef78343a89")]
    [ProgId("GFS.Commands.CmdOpenLayerTable")]
    public sealed class CmdOpenLayerTable : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper = null;

        /// <summary>
        /// The m_current layer
        /// </summary>
        private ILayer m_currentLayer = null;

        /// <summary>
        /// The _FRM
        /// </summary>
        private frmLayerTable _frm = null;

        //private Logger m_logger = new Logger();

        /// <summary>
        /// The enabled state of this command, determines whether the command is usable.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        /// <remarks>Note to inheritors: By default, the 
        /// <see cref="F:ESRI.ArcGIS.ADF.BaseClasses.BaseCommand.m_enabled" /> field is returned from this member. 
        ///             It is possible to override this member, if you should need to provide a different implementation.</remarks>
        public override bool Enabled
        {
            get
            {
                this.m_currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
                return this.m_currentLayer is IFeatureLayer && (this.m_currentLayer as IFeatureLayer).FeatureClass != null;
            }
        }

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdOpenLayerTable.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdOpenLayerTable.ArcGISCategoryUnregistration(registerType);
        }

        /// <summary>
        /// Arcs the gis category registration.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(cLSID);
            ControlsCommands.Register(cLSID);
        }

        /// <summary>
        /// Arcs the gis category unregistration.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(cLSID);
            ControlsCommands.Unregister(cLSID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CmdOpenLayerTable"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdOpenLayerTable()
        {
            this.m_category = "TocMenu";
            this.m_caption = "属性表";
            this.m_message = "属性表";
            this.m_toolTip = "属性表";
            this.m_name = "CmdOpenLayerTable";
        }

        /// <summary>
        /// Called when the command is created inside the application.
        /// </summary>
        /// <param name="hook">A reference to the application in which the command was created.
        ///             The hook may be an IApplication reference (for commands created in ArcGIS Desktop applications)
        ///             or an IHookHelper reference (for commands created on an Engine ToolbarControl).</param>
        /// <remarks>Note to inheritors: classes inheriting from BaseCommand must always 
        ///             override the OnCreate method. Use this method to store a reference to the host 
        ///             application, passed in via the hook parameter.</remarks>
        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        /// <summary>
        /// Called when the user clicks a command.
        /// </summary>
        /// <remarks>Note to inheritors: override OnClick and use this method to 
        ///             perform the actual work of the custom command.</remarks>
        public override void OnClick()
        {
            try
            {
                //EnviVars.instance.TablePanel.Visibility = DockVisibility.Visible;
                
                DockPanel panel = EnviVars.instance.TableContainer.Parent as DockPanel;
                panel.Visibility = DockVisibility.Visible;
                if (this._frm == null)
                {
                    this._frm = new frmLayerTable(this.m_hookHelper.FocusMap, this.m_currentLayer as IFeatureLayer);
                    this._frm.FormClosed += delegate(object s1, System.Windows.Forms.FormClosedEventArgs ev1)
                    {
                        this._frm = null;
                    };
                    this._frm.Owner = EnviVars.instance.MainForm;
                    //ControlWrapper.SetFormLocation(this.m_frm, FormPositionMode.Center);
                    EnviVars.instance.TableContainer.Controls.Clear();
                    _frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    _frm.TopLevel = false;
                    _frm.Dock = DockStyle.Fill;
                    _frm.Show();
                    panel.Text = _frm.Text;
                    EnviVars.instance.TableContainer.Controls.Add(_frm);
                }
                else
                {
                    if (this.m_currentLayer == _frm.GridControl._pFtLayer)
                        return;

                    if((this.m_currentLayer as IFeatureLayer)!=null )
                    {
                        panel.Text = "属性表：" + this.m_currentLayer.Name;
                        _frm.GridControl._pFtLayer = this.m_currentLayer as IFeatureLayer;
                        _frm.GridControl.Initialize(_frm.GridControl._pFtLayer.FeatureClass as ITable, null, this.m_hookHelper.FocusMap);
                    }

                }


                //this.m_logger.Log(LogLevel.Info, EventType.UserManagement, this._frm.Text, null);
            }
            catch (Exception ex)
            {
                //this.m_logger.Log(LogLevel.Error, EventType.UserManagement, this._frm.Text, ex);
                Log.WriteLog(typeof(CmdOpenLayerTable), ex);
            }
        }
    }
}
