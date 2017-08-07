// ***********************************************************************
// Assembly         : SDJT.Commands
// Author           : YXQ
// Created          : 04-22-2016
//
// Last Modified By : YXQ
// Last Modified On : 04-22-2016
// ***********************************************************************
// <copyright file="CmdLableLayer.cs" company="SDJT">
//     Copyright (c) SDJT. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.XtraEditors;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using SDJT.Const;
using SDJT.Sys;
using SDJT.Commands.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace SDJT.Commands
{
    /// <summary>
    /// Class CmdLableLayer. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("88037307-ea5f-4438-a8bb-14abd09ba66b")]
    [ProgId("SDJT.Commands.CmdLableLayer")]
    public sealed class CmdLableLayer : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper = null;

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
                ILayer currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
                return currentLayer is IFeatureLayer && (currentLayer as IFeatureLayer).FeatureClass != null;
            }
        }

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdLableLayer.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdLableLayer.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdLableLayer"/> class.
        /// </summary>
        /// <overloads>The constructor has two overloads.</overloads>
        public CmdLableLayer()
        {
            this.m_category = "TocMenu";
            this.m_caption = "图层标注";
            this.m_message = "图层标注";
            this.m_toolTip = "图层标注";
            this.m_name = "CmdLableLayer";
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
            ILayer currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
            try
            {
                if (new frmLableLyr(this.m_hookHelper.FocusMap, currentLayer as IFeatureLayer)
                {
                    Owner = EnviVars.instance.MainForm
                }.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    IViewRefresh viewRefresh = this.m_hookHelper.FocusMap as IViewRefresh;
                    viewRefresh.RefreshItem(currentLayer);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(AppMessage.MSG0109 + "\r\n" + ex.Message, AppMessage.MSG0000, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
        }
    }
}
