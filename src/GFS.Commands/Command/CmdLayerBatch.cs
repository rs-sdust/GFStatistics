// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdLayerBatch.cs" company="SDJT">
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
using GFS.BLL;
using GFS.Commands.UI;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdLayerBatch. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None), Guid("8f06f430-3b9d-40de-9e5d-afc36928be06"), ProgId("SDJT.Commands.CmdLayerBatch")]
    public sealed class CmdLayerBatch : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper;

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
                return this.m_hookHelper.FocusMap.LayerCount != 0;
            }
        }

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdLayerBatch.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdLayerBatch.ArcGISCategoryUnregistration(registerType);
        }

        /// <summary>
        /// Arcs the gis category registration.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(cLSID);
        }

        /// <summary>
        /// Arcs the gis category unregistration.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(cLSID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CmdLayerBatch"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdLayerBatch()
        {
            this.m_category = "TocMenu";
            this.m_caption = "批量图层管理";
            this.m_message = "批量图层管理";
            this.m_toolTip = "批量图层管理";
            this.m_name = "CmdLayerBatch";
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
            if (new frmLayerBatch(this.m_hookHelper.ActiveView.FocusMap)
            {
                Owner = EnviVars.instance.MainForm
            }.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                (this.m_hookHelper.ActiveView.FocusMap as IActiveView).Refresh();
                EnviVars.instance.TOCControl.Update();
            }
        }
    }
}
