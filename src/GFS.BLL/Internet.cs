// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 09-18-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-18-2017
// ***********************************************************************
// <copyright file="Internet.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>检查是否可连接网络</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
//方法一
using System.Runtime;
using System.Runtime.InteropServices;
//方法二 Net2.0新增类库
using System.Net.NetworkInformation;

/// <summary>
/// The BLL namespace.
/// </summary>
namespace GFS.BLL
{
    /// <summary>
    /// Class Internet.
    /// </summary>
    public class Internet
    {
        /// <summary>
        /// Internets the state of the get connected.
        /// </summary>
        /// <param name="Description">The description.</param>
        /// <param name="ReservedValue">The reserved value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);

        #region 方法一
        /// <summary>
        /// 用于检查网络是否可以连接互联网,true表示连接成功,false表示连接失败
        /// </summary>
        /// <returns><c>true</c> if [is connect internet]; otherwise, <c>false</c>.</returns>
        public static bool IsConnectInternet()
        {
            int Description = 0;
            return InternetGetConnectedState(Description, 0);
        }
        #endregion

        #region 方法二
        /// <summary>
        /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败
        /// </summary>
        /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}