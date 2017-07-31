using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process process = BLL.ProcessCheck.RuningInstance();
            if (process != null)
            {
                BLL.ProcessCheck.HandleRunningInstance(process);
                //System.Threading.Thread.Sleep(1000);  
                System.Environment.Exit(1);
            } 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
