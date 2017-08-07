// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : yxq
// Created          : 04-01-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdOpenRaster.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Command CmdOpenRaster</summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using SDJT.Const;
using SDJT.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SDJT.Commands.UI;
using SDJT.Common;
using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Class CmdOpenRaster. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("df4cbfb3-9181-4abc-8827-0393fd664b3f")]
    [ProgId("SDJT.Commands.CmdOpenRaster")]
    public sealed class CmdOpenRaster : BaseCommand
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
            CmdOpenRaster.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdOpenRaster.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdOpenRaster" /> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdOpenRaster()
        {
            this.m_category = "AppMenu";
            this.m_caption = "打开影像";
            this.m_message = "打开影像";
            this.m_toolTip = "打开影像";
            this.m_name = "CmdOpenRaster";
        }

        /// <summary>
        /// Called when the command is created inside the application.
        /// </summary>
        /// <param name="hook">A reference to the application in which the command was created.
        /// The hook may be an IApplication reference (for commands created in ArcGIS Desktop applications)
        /// or an IHookHelper reference (for commands created on an Engine ToolbarControl).</param>
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
            frmSelectFeatures frmSelectFeatures = new frmSelectFeatures();
            try
            {
                frmSelectFeatures.Text = AppMessage.MSG0051;
                frmSelectFeatures.DataType = DataType.raster;
                frmSelectFeatures.Owner = EnviVars.instance.MainForm;
                if (frmSelectFeatures.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CommandAPI.AddRasterLayersToMap(frmSelectFeatures.RasterDict);
                    //logger.Log(LogLevel.Info, EventType.UserManagement, frmSelectFeatures.Text, null);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, frmSelectFeatures.Text, ex);
            }
        }
    }
}
