﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace GFS.BLL
{
    /// <summary>
    /// 检查可执行程序是否启动。
    /// 若未启动可直接启动；
    /// 若已启动则切换到改程序界面
    /// </summary>
    public class ProcessCheck
    {
        /// 该函数设置由不同线程产生的窗口的显示状态  
        /// </summary>  
        /// <param name="hWnd">窗口句柄</param>  
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分</param>  
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零</returns>  
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        /// <summary>  
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。  
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。   
        /// </summary>  
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>  
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>  
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_SHOWNOMAL = 1;
        public static void HandleRunningInstance(Process instance)
        {
            //ShowWindowAsync(instance.MainWindowHandle, SW_SHOWNOMAL);//显示  
            SetForegroundWindow(instance.MainWindowHandle);//当到最前端  
        }

        public static Process RuningInstance()  
        {  
            Process currentProcess = Process.GetCurrentProcess();  

            Process[] Processes = Process.GetProcessesByName(currentProcess.ProcessName);  
            foreach (Process process in Processes)  
            {  
                if (process.Id != currentProcess.Id)  
                {
                    if (process.MainModule.FileName == currentProcess.MainModule.FileName)  
                    {  
                        return process;  
                    }  
                }  
            }  
            return null;  
        }  
    }
}