// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdRendererLayer.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.XtraEditors;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
//using SDJT.Const;
//using SDJT.Sys;
using GFS.Commands.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GFS.BLL;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdRendererLayer. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None), Guid("70aa6080-5fc7-4b9e-a395-282f27fde202"), ProgId("GFS.Commands.CmdRendererLayer")]
    public sealed class CmdRendererLayer : BaseCommand
    {
        /// <summary>
        /// The m_current layer
        /// </summary>
        private ILayer m_currentLayer = null;

        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper = null;

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
                bool result;
                if (this.m_currentLayer == null || this.m_currentLayer is IGroupLayer)
                {
                    result = false;
                }
                else
                {
                    if (this.m_currentLayer is IRasterLayer)
                    {
                        string format = ((this.m_currentLayer as IRasterLayer).Raster as IRaster2).RasterDataset.Format;
                        if (format.StartsWith("Cache", StringComparison.OrdinalIgnoreCase))
                        {
                            result = false;
                            return result;
                        }
                        if ((this.m_currentLayer as IRasterLayer).BandCount > 1)
                        {
                            result = false;
                            return result;
                        }
                    }
                    result = true;
                }
                return result;
            }
        }

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdRendererLayer.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdRendererLayer.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdRendererLayer"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdRendererLayer()
        {
            this.m_category = "TocMenu";
            this.m_caption = "图层渲染";
            this.m_message = "图层渲染";
            this.m_toolTip = "图层渲染";
            this.m_name = "CmdRendererLayer";
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
            if (this.m_currentLayer != null)
            {
                try
                {
                    frmLayerRender frmLayerRender = new frmLayerRender(this.m_currentLayer);
                    if (frmLayerRender.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        GFS.BLL.EnviVars.instance.TOCControl.Update();
                        IViewRefresh viewRefresh = this.m_hookHelper.FocusMap as IViewRefresh;
                        viewRefresh.RefreshItem(this.m_currentLayer);
                        this.m_hookHelper.ActiveView.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("渲染图层出错！原因如下：" + "\r\n" + ex.Message, "提示信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    GFS.BLL.Log.WriteLog(typeof(CmdRendererLayer), ex);
                }
            }
        }
    }
}
