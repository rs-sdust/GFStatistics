using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace GFS.Carbon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process process = GFS.BLL.ProcessCheck.RuningInstance();
            if (process != null)
            {
                GFS.BLL.ProcessCheck.HandleRunningInstance(process);
                //System.Threading.Thread.Sleep(1000);  
                System.Environment.Exit(1);
            } 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
