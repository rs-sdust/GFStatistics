using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GFS.BLL;
using ESRI.ArcGIS.esriSystem;
using GFS.License;

namespace GFS.Test
{
    static class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new LicenseInitializer();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool licensed = m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeAdvanced },
                               new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst });
            if (!licensed)
            {
                MessageBox.Show(m_AOLicenseInitializer.LicenseMessage(), "初始化许可失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
