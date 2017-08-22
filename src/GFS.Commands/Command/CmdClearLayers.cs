// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-21-2016
// ***********************************************************************
// <copyright file="CmdClearLayers.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
//using SDJT.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using GFS.BLL;
//using SDJT.Const;
//using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdClearLayers. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("46718493-e23c-4645-8d0e-7ee83454f19a")]
    [ProgId("SDJT.Commands.CmdClearLayers")]
    public sealed class CmdClearLayers : BaseCommand
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
            CmdClearLayers.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdClearLayers.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdClearLayers"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdClearLayers()
        {
            this.m_category = "TocMenu";
            this.m_caption = "重置图框";
            this.m_message = "重置图框";
            this.m_toolTip = "重置图框";
            this.m_name = "CmdClearLayers";
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
                //MapAPI.NewDocument();
                //logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0103, null);
                bool isCurrrentNew = (String.IsNullOrEmpty(EnviVars.instance.MapControl.DocumentFilename) &&
                    EnviVars.instance.MapControl.LayerCount > 0);
                if ((!String.IsNullOrEmpty(EnviVars.instance.MapControl.DocumentFilename) &&
                    EnviVars.instance.MapControl.CheckMxFile(EnviVars.instance.MapControl.DocumentFilename)) || isCurrrentNew)
                {
                    //ask the user whether he'd like to save the current doc
                    DialogResult res = XtraMessageBox.Show("保存当前文档?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        //if yes, launch the Save command
                        ICommand command = new CmdSaveFile();
                        command.OnCreate(EnviVars.instance.MapControl.Object);
                        command.OnClick();
                    }
                }
                EnviVars.instance.MapControl.ClearLayers();
                //(EnviVars.instance.PageLayoutControl.PageLayout as IGraphicsContainer).DeleteAllElements();
                IMap map = new MapClass();
                map.Name = "图层";
                EnviVars.instance.MapControl.Map = map;
                //EnviVars.instance.Synchronizer.ReplaceMap(map);

                EnviVars.instance.MapControl.DocumentFilename = string.Empty;
            }
            catch (Exception ex)
            {
                //logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0103, ex);
                Log.WriteLog(typeof(CmdClearLayers), ex);
            }
            finally
            {
                EnviVars.instance.MainForm.Text = EnviVars.instance.MapControl.DocumentFilename;
            }
        }
    }
}
