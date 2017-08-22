// ***********************************************************************
// Assembly         : GFS.Commands
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-11-2017
// ***********************************************************************
// <copyright file="CMDInitializer.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>Initialize user ICommands</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

namespace GFS.Commands
{
    public  class CMDInitializer
    {
        /// <summary>
        /// 初始化自定义命令
        /// </summary>
        /// <param name="toolbar"></param>
        public static void Initialize(IToolbarControl2 toolbar)
        {
            toolbar.AddItem(new CmdClearLayers(), -1, -1);
            toolbar.AddItem(new CmdExportMap(), -1, -1);
            toolbar.AddItem(new CmdHelp(), -1, -1);
            toolbar.AddItem(new CmdLayerBatch(), -1, -1);
            toolbar.AddItem(new CmdLayerTransparency(), -1, -1);
            toolbar.AddItem(new CmdNewTask(), -1, -1);
            toolbar.AddItem(new CmdOpenLayerTable(), -1, -1);
            toolbar.AddItem(new CmdOpenMxd(), -1, -1);
            toolbar.AddItem(new CmdRemoveLayer(),-1,-1);
            toolbar.AddItem(new CmdRendererLayer(), -1, -1);
            toolbar.AddItem(new CmdSaveFile(), -1, -1);
            toolbar.AddItem(new CmdZoomToLayer(), -1, -1);
            toolbar.AddItem(new CmdZoomToRasterResolution(), -1, -1);
            toolbar.AddItem(new CmdLayerProperty(), -1, -1);
            toolbar.AddItem(new CmdIdentifyTool(), -1, -1);
            toolbar.AddItem(new CmdROI(), -1, -1); 
            
        }
        /// <summary>
        /// 设置地图控件当前的激活工具
        /// </summary>
        /// <param name="toolbar"></param>
        /// <param name="commandName"></param>
        public static void SetCurrentTool(IToolbarControl2 toolbar, string commandName)
        {
            if (commandName == null)
                return;
            ICommand pCommand;
            if (toolbar == null) return;
            for (int i = 0; i < toolbar.CommandPool.Count; i++)
            {
                pCommand = toolbar.CommandPool.get_Command(i);
                if (pCommand.Name == commandName)
                {
                    (toolbar.Buddy as IMapControl3).CurrentTool = pCommand as ITool;
                    pCommand.OnClick();
                    break;
                }
            }
        }
    }
}
