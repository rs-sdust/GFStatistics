// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 10-16-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-20-2017
// ***********************************************************************
// <copyright file="CmdClipRaster.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>栅格裁剪</summary>
// ***********************************************************************
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
//using HTES.TAS.Sys;
//using HTES.TAS.Tools;
//using PS.Plot.Common;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GFS.Commands.UI;
using GFS.BLL;

/// <summary>
/// The Commands namespace.
/// </summary>
namespace GFS.Commands
{
    /// <summary>
    /// Class CmdClipRaster. This class cannot be inherited.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None), Guid("c89844c5-e06d-47a6-a734-a54061542b3d"), ProgId("HTES.TAS.Commands.CmdClipRaster")]
    public sealed class CmdClipRaster : BaseCommand
    {
        /// <summary>
        /// The m_hook helper
        /// </summary>
        private IHookHelper m_hookHelper;

        /// <summary>
        /// The M_FRM
        /// </summary>
        private frmClipRaster m_frm = null;

        /// <summary>
        /// Registers the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdClipRaster.ArcGISCategoryRegistration(registerType);
        }

        /// <summary>
        /// Unregisters the function.
        /// </summary>
        /// <param name="registerType">Type of the register.</param>
        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdClipRaster.ArcGISCategoryUnregistration(registerType);
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
        /// Initializes a new instance of the <see cref="CmdClipRaster"/> class.
        /// </summary>
        public CmdClipRaster()
        {
            this.m_category = "";
            this.m_caption = "";
            this.m_message = "";
            this.m_toolTip = "";
            this.m_name = "";
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="hook">The hook.</param>
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
        /// Called when [click].
        /// </summary>
        public override void OnClick()
        {
            this.Init();
            this.m_frm.Owner = EnviVars.instance.MainForm;
            //ControlWrapper.SetFormLocation(this.m_frm, FormPositionMode.Center);
            m_frm.StartPosition = FormStartPosition.CenterScreen;
            this.m_frm.Show(EnviVars.instance.MainForm);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            if (this.m_frm == null)
            {
                this.m_frm = new frmClipRaster();
                this.m_frm.FormClosed += delegate(object w, System.Windows.Forms.FormClosedEventArgs ev)
                {
                    this.m_frm = null;
                    ROIManager.instance.GpExecutor = null;
                };
            }
        }
    }
}
