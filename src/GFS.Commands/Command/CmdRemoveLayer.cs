// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-11-2016
// ***********************************************************************
// <copyright file="CmdRemoveLayer.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
//using SDJT.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
//using SDJT.Log;
//using SDJT.Const;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdRemoveLayer. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("31d6ff09-0a34-4974-955f-444e195a1986")]
    [ProgId("GFS.Commands.CmdRemoveLayer")]
    public sealed class CmdRemoveLayer : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper = null;

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdRemoveLayer.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdRemoveLayer.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdRemoveLayer"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdRemoveLayer()
        {
            this.m_category = "TocMenu";
            this.m_caption = "移除图层";
            this.m_message = "移除图层";
            this.m_toolTip = "移除图层";
            this.m_name = "CmdRemoveLayer";
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
                ILayer currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
                if (currentLayer != null)
                {
                    this.m_hookHelper.ActiveView.FocusMap.DeleteLayer(currentLayer);
                    (this.m_hookHelper.ActiveView.FocusMap as IActiveView).Refresh();
                    GFS.BLL.EnviVars.instance.TOCControl.Update();
                }
            }
            catch (Exception ex)
            {
                //logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0104, ex);
                GFS.BLL.Log.WriteLog(typeof(CmdRemoveLayer), ex);
            }
        }
    }
}
