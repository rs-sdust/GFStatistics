// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : yxq
// Created          : 08-11-2017
//
// Last Modified By : yxq
// Last Modified On : 08-10-2017
// ***********************************************************************
// <copyright file="CmdLayerProPerty.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>ICommand for display layer properties</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF.CATIDs;
using GFS.BLL;
using GFS.Commands.UI;

namespace GFS.Commands
{
    [ClassInterface(ClassInterfaceType.None), Guid("9a19da70-01d2-42fa-995c-cf3fecebc0df"), ProgId("GFS.Commands.CmdLayerProperty")]
    public sealed class CmdLayerProperty : BaseCommand
    {
        private ILayer m_currentLayer = null;

        private IHookHelper m_hookHelper;

        public override bool Enabled
        {
            get
            {
                this.m_currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
                return this.m_currentLayer != null && !(this.m_currentLayer is IGroupLayer);
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            CmdLayerProperty.ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            CmdLayerProperty.ArcGISCategoryUnregistration(registerType);
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string cLSID = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(cLSID);
        }

        public CmdLayerProperty()
        {
            this.m_category = "TocMenu";
            this.m_caption = "图层属性";
            this.m_message = "图层属性";
            this.m_toolTip = "图层属性";
            this.m_name = "CmdLayerProperty";
        }

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

        public override void OnClick()
        {
            ILayer currentLayer = CommandAPI.GetCurrentLayer(this.m_hookHelper);
            frmLayerProperty frmLayerProperty = new frmLayerProperty(currentLayer);
            try
            {
                frmLayerProperty.Owner = EnviVars.instance.MainForm;
                frmLayerProperty.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(CmdLayerProperty), ex);
            }
        }
    }
}

