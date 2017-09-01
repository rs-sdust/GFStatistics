// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : Ricker Yan
// Created          : 04-22-2016
//
// Last Modified By : Ricker Yan
// Last Modified On : 04-21-2016
// ***********************************************************************
// <copyright file="CmdSaveFile.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.ADF.BaseClasses;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF.CATIDs;
//using SDJT.Sys;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using GFS.BLL;
//using SDJT.Const;
//using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdSaveFile. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("a1ab3ca2-9cdf-4b73-bc04-c733086c845f")]
    [ProgId("GFS.Commands.CmdSaveFile")]
    public sealed class CmdSaveFile : BaseCommand
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
            CmdSaveFile.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdSaveFile.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdSaveFile"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdSaveFile()
        {
            this.m_category = "AppMenu";
            this.m_caption = "保存文档";
            this.m_message = "保存文档";
            this.m_toolTip = "保存文档";
            this.m_name = "CmdSaveFile";
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
            //Logger logger = new Logger();
            try
            {
                EnviVars.instance.MainForm.UseWaitCursor = true;
                if (!String.IsNullOrEmpty(EnviVars.instance.MapControl.DocumentFilename) &&
                    EnviVars.instance.MapControl.CheckMxFile(EnviVars.instance.MapControl.DocumentFilename))
                {
                    IMapDocument mapDocument = new MapDocumentClass();
                    mapDocument.Open(EnviVars.instance.MapControl.DocumentFilename, "");
                    mapDocument.ReplaceContents((IMxdContents)EnviVars.instance.MapControl.Map);
                    mapDocument.Save(mapDocument.UsesRelativePaths, true);
                    mapDocument.Close();
                }
                else
                {
                    //ICommand command = new ControlsSaveAsDocCommandClass();
                    //command.OnCreate(EnviVars.instance.PageLayoutControl.Object);
                    //command.OnClick();
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Title = "保存任务文档";
                    saveFileDialog.Filter = string.Format("{0} (*.mxd)|*.mxd", "任务文档");
                    if (saveFileDialog.ShowDialog(EnviVars.instance.MainForm) == System.Windows.Forms.DialogResult.OK)
                    {
                        IMxdContents mxdContents = this.m_hookHelper.FocusMap as IMxdContents;
                        //if (EnviVars.instance.ActiveViewMode == ViewMode.PageLayout)
                        //{
                        //    mxdContents = (this.m_hookHelper.PageLayout as IMxdContents);
                        //}
                        MapAPI.SaveMapDocument(mxdContents, saveFileDialog.FileName, false);
                        //logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0095, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0095, ex);
                Log.WriteLog(typeof(CmdSaveFile), ex);
            }
            finally
            {
                EnviVars.instance.MainForm.Text = EnviVars.instance.MapControl.DocumentFilename;
                EnviVars.instance.MainForm.UseWaitCursor = false;
            }
        }
    }
}
