// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : yxq
// Created          : 04-05-2016
//
// Last Modified By : yxq
// Last Modified On : 04-21-2016
// ***********************************************************************
// <copyright file="CmdOpenMxd.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary>Command CmdOpenMxd</summary>
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
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using SDJT.Log;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Class CmdOpenMxd. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("5e78994d-4e4f-487b-80f7-928b16183999")]
    [ProgId("SDJT.Commands.CmdOpenMxd")]
    public sealed class CmdOpenMxd : BaseCommand
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
            CmdOpenMxd.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdOpenMxd.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdOpenMxd" /> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdOpenMxd()
        {
            this.m_category = "AppMenu";
            this.m_caption = "打开文档";
            this.m_message = "打开文档";
            this.m_toolTip = "打开文档";
            this.m_name = "CmdOpenMxd";
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
            try
            {
                EnviVars.instance.MainForm.UseWaitCursor = true;
                //System.Windows.Forms.Cursor.Current=System.Windows.Forms.Cursors.WaitCursor;
                bool isCurrrentNew = (String.IsNullOrEmpty(EnviVars.instance.MapControl.DocumentFilename) &&
                    EnviVars.instance.MapControl.LayerCount > 0);
                if ((!String.IsNullOrEmpty(EnviVars.instance.MapControl.DocumentFilename) &&
                    EnviVars.instance.MapControl.CheckMxFile(EnviVars.instance.MapControl.DocumentFilename)) || isCurrrentNew)
                {
                    DialogResult res = XtraMessageBox.Show("保存当前文档?", AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        //if yes, launch the Save command
                        ICommand command = new CmdSaveFile();
                        command.OnCreate(EnviVars.instance.PageLayoutControl.Object);
                        command.OnClick();
                    }
                }
                logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0090, null);
                //launch the OpenMapDoc command

                //ICommand OpenMapDoc = new ControlsOpenDocCommandClass();
                //OpenMapDoc.OnCreate(this.m_hookHelper.Hook);
                //OpenMapDoc.OnClick();

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Map Documents (*.mxd)|*.mxd";
                dlg.Multiselect = false;
                dlg.Title = "打开文档";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string docName = dlg.FileName;
                    IMapDocument mapDoc = new MapDocumentClass();
                    if (mapDoc.get_IsPresent(docName) && !mapDoc.get_IsPasswordProtected(docName))
                    {
                        mapDoc.Open(docName, string.Empty);
                        // set the first map as the active view
                        IMap map = mapDoc.get_Map(0);
                        mapDoc.SetActiveView((IActiveView)map);
                        EnviVars.instance.PageLayoutControl.PageLayout = mapDoc.PageLayout;
                        EnviVars.instance.Synchronizer.ReplaceMap(map);
                        mapDoc.Close();
                        EnviVars.instance.MapControl.DocumentFilename = docName;
                        CommandAPI.AddRecentFile(docName, FileType.MXD);
                        CommandAPI.SaveRecentFilesInfo();
                        logger.Log(LogLevel.Info, EventType.UserManagement, AppMessage.MSG0090, null);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, EventType.UserManagement, AppMessage.MSG0090, ex);
            }
            finally
            {
                EnviVars.instance.MainForm.Text = EnviVars.instance.MapControl.DocumentFilename;
                EnviVars.instance.MainForm.UseWaitCursor = false;
            }
            }
        
    }
}
