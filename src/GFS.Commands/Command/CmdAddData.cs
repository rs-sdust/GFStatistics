// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdAddData.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SDJT.Commands.UI;
using SDJT.Common;
using SDJT.Sys;
using SDJT.Const;
using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Class CmdAddData. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("cea1f602-3086-4e96-aacf-fd4c9dfd3b29")]
    [ProgId("SDJT.Commands.CmdAddData")]
    public sealed class CmdAddData : BaseCommand
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
            CmdAddData.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdAddData.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdAddData"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdAddData()
        {
            this.m_category = "TocMenu";
            this.m_caption = "加载数据";
            this.m_message = "加载数据";
            this.m_toolTip = "加载数据";
            this.m_name = "CmdAddData";
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
                try
                {
                    this.m_hookHelper = new HookHelperClass();
                    this.m_hookHelper.Hook = hook;
                    if (this.m_hookHelper.ActiveView == null)
                    {
                        this.m_hookHelper = null;
                    }
                }
                catch
                {
                    this.m_hookHelper = null;
                }
                if (this.m_hookHelper == null)
                {
                    this.m_enabled = false;
                }
                else
                {
                    this.m_enabled = true;
                }
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
                frmSelectFeatures frmSelectFeatures = new frmSelectFeatures();
                frmSelectFeatures.Text = AppMessage.MSG0054;
                frmSelectFeatures.DataType = DataType.all;
                frmSelectFeatures.Owner = EnviVars.instance.MainForm;
                if (frmSelectFeatures.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CommandAPI.AddRasterLayersToMap(frmSelectFeatures.RasterDict);
                    CommandAPI.AddFeatureLayersToMap(frmSelectFeatures.SelectedFeatures);
                    if (frmSelectFeatures.SelectedFeatures != null && frmSelectFeatures.SelectedFeatures.Count > 0)
                    {
                        this.m_hookHelper.ActiveView.Refresh();
                    }
                    ////logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0102, null);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0102, ex);
            }
        }
    }
}
