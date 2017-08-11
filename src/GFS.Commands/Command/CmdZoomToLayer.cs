// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-11-2016
// ***********************************************************************
// <copyright file="CmdZoomToLayer.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdZoomToLayer. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("93f48f2d-45bd-4d4b-b4cf-a1b441d38b48")]
    [ProgId("GFS.Commands.CmdZoomToLayer")]
    public sealed class CmdZoomToLayer : BaseCommand
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
            CmdZoomToLayer.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdZoomToLayer.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdZoomToLayer"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdZoomToLayer()
        {
            this.m_category = "TocMenu";
            this.m_caption = "缩放到图层";
            this.m_message = "缩放到图层";
            this.m_toolTip = "缩放到图层";
            this.m_name = "CmdZoomToLayer";
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
                    (this.m_hookHelper.FocusMap as IActiveView).Extent = currentLayer.AreaOfInterest;
                    this.m_hookHelper.ActiveView.Refresh();
                    //logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0105, null);
                }
            }
            catch (Exception ex)
            {
                GFS.BLL.Log.WriteLog(typeof(CmdRemoveLayer), ex);
            }
        }
    }
}
