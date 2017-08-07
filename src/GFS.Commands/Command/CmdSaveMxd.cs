// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-21-2016
// ***********************************************************************
// <copyright file="CmdSaveMxd.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using SDJT.Const;
using SDJT.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Class CmdSaveMxd. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("de3dbc38-b40a-458d-924f-dec0d562f46c")]
    [ProgId("SDJT.Commands.CmdSaveMxd")]
    public sealed class CmdSaveMxd : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper;

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdSaveMxd.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdSaveMxd.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdSaveMxd"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdSaveMxd()
        {
            this.m_category = "AppMenu";
            this.m_caption = "保存文档";
            this.m_message = "保存文档";
            this.m_toolTip = "保存文档";
            this.m_name = "CmdSaveMxd";
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
            Logger logger = new Logger();
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Title = AppMessage.MSG0094;
                saveFileDialog.Filter = string.Format("{0} (*.mxd)|*.mxd", AppMessage.MSG0095);
                if (saveFileDialog.ShowDialog(EnviVars.instance.MainForm) == System.Windows.Forms.DialogResult.OK)
                {
                    IMxdContents mxdContents = this.m_hookHelper.FocusMap as IMxdContents;
                    if (EnviVars.instance.ActiveViewMode == ViewMode.PageLayout)
                    {
                        mxdContents = (this.m_hookHelper.PageLayout as IMxdContents);
                    }
                    MapAPI.SaveMapDocument(mxdContents, saveFileDialog.FileName, false);
                    //logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0095, null);
                }

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0095, ex);
            }
        }
    }
}
