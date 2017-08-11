using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ESRI.ArcGIS.esriSystem;
using DevExpress.XtraEditors;
using GFS.BLL;

namespace GFS.Carbon
{
    static class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new LicenseInitializer();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process process = ProcessCheck.RuningInstance();
            if (process != null)
            {
                ProcessCheck.HandleRunningInstance(process);
                //System.Threading.Thread.Sleep(1000);  
                System.Environment.Exit(1);
            }
            try
            {
                bool licensed = m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine, esriLicenseProductCode.esriLicenseProductCodeStandard, esriLicenseProductCode .esriLicenseProductCodeAdvanced},
                                new esriLicenseExtensionCode[] { });
                if (!licensed)
                {
                    XtraMessageBox.Show(m_AOLicenseInitializer.LicenseMessage(), "初始化许可失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + ex.StackTrace, "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                m_AOLicenseInitializer.ShutdownApplication();
            }
        }
    }
}
