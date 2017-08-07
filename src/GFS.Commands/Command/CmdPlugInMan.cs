// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : yxq
// Created          : 03-31-2016
//
// Last Modified By : yxq
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdPlugInMan.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Command CmdPlugInMan</summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using SDJT.Commands.UI;
using SDJT.Sys;
using SDJT.PluginEngine.PluginMan;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("db303838-0e42-4597-bcc9-1a284e3df740")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SDJT.Commands.CmdPlugInMan")]
    public sealed class CmdPlugInMan : BaseCommand
    {
        #region COM Registration Function(s)
        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CmdPlugInMan" /> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdPlugInMan()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "AppMenu"; //localizable text
            base.m_caption = "插件管理";  //localizable text 
            base.m_message = "插件管理";  //localizable text
            base.m_toolTip = "插件管理";  //localizable text
            base.m_name = "CmdPluginMan";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        /// <remarks>Note to inheritors: classes inheriting from BaseCommand must always 
        ///             override the OnCreate method. Use this method to store a reference to the host 
        ///             application, passed in via the hook parameter.</remarks>
        public override void OnCreate(object hook)
        {       
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        /// <remarks>Note to inheritors: override OnClick and use this method to 
        ///             perform the actual work of the custom command.</remarks>
        public override void OnClick()
        {
            // TODO: Add CmdPlugInMan.OnClick implementation
            new frmPluginMan(EnviVars.instance.MainForm as IContainerContext)
            {
                Owner = EnviVars.instance.MainForm
            }.Show();
        }

        #endregion
    }
}
