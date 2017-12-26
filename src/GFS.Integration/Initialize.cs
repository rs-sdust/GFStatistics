using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Sample.Integration;
using Sample.Utility;
using Sample.UtilityUI;
using ESRI.ArcGIS.Carto;
using DevExpress.XtraBars;
using ESRI.ArcGIS.Controls;

namespace GFS.Integration
{
    public class Initialize
    {
        public static void InitializeIDL()
        {
            COM_IDL_connectLib.COM_IDL_connectClass oComIDL = null;
            try
            {
                oComIDL = new COM_IDL_connectLib.COM_IDL_connectClass();
                oComIDL.CreateObject(0, 0, 0);
                IDLManagerModule.GlobeIDLManager.IDLDrawWidget = oComIDL;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("IDL初始化失败：" + ex.Message);
            }
        }
        public static void RegisterCMD(BarButtonItem btn, IMapControl3 curMap, ITOCControl2 toc,string cmd)
        {
            try
            {
                if (cmd == "MaxClassCommand")
                    CommandUtility.RegisterCommand(new MaxClassCommand(btn, curMap, toc));
                else if (cmd == "CV1Commad")
                    CommandUtility.RegisterCommand(new CV1Commad(btn, curMap));
                else
                    XtraMessageBox.Show("未知命令！");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("注册 MaxClassCommand失败：" + ex.Message);
            }
        }
    }
}
