using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace UpdateTaskStatus
{
    /// <summary>
    /// UpdateTaskStatus 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UpdateTaskStatus : System.Web.Services.WebService
    {

        [WebMethod]
        public string UpdateTask(string tableInfo)
        {
            string file = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "received.txt");
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
            {
                sw.WriteLine(tableInfo);
                sw.WriteLine();
                sw.Flush();
                sw.Close();
            }
            return tableInfo;

        }
    }
}
