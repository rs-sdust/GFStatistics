// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-11-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-04-2017
// ***********************************************************************
// <copyright file="Log.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>Log errors and exceptions</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace GFS.BLL
{
    public class Log
    {
        /// <summary>
        /// log exception
        /// </summary>
        /// <param name="t">obj type</param>
        /// <param name="ex">exception</param>
        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Exception", ex);
            log = null;
        }
        /// <summary>
        /// log error string
        /// </summary>
        /// <param name="t">obj type</param>
        /// <param name="msg">error string</param>
        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
            log = null;
        }

    }
}