using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFS.SampleBLL
{
    public class SpatialError
    {
        private string _inFile = "";
        private int _classVaue = 0;
        private string _outFile = "";
        private int _windowSize = 5;

        public SpatialError(string inFile, int classVaue, int windowSize, string outFile)
        {
            _inFile = inFile;
            _classVaue = classVaue;
            _windowSize = windowSize;
            _outFile = outFile;
        }

        public bool ChkParam(out string msg)
        {
            if(string.IsNullOrEmpty(_inFile))
            {
                msg = "输入分类文件为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_outFile))
            {
                msg = "输出文件为空！";
                return false;
            }
            else if (_windowSize <= 0)
            {
                msg = "窗口大小必须大于0！！";
                return false;
            }
            else
            {
                msg = "";
                return true;
            }
        }

        public bool Execute(out string msg)
        {
            try
            {
                string cmd = BLL.ConstDef.IDL_FUN_SpatialError + ",'" + _inFile + "'," + _windowSize + "," + _classVaue + ",'" + _outFile + "'";
                BLL.EnviVars.instance.IdlModel.Execute(cmd);
                msg = "";
                return true;              
            }
            catch (Exception ex)
            {
                BLL.Log.WriteLog(typeof(SpatialError), ex);
                msg = ex.Message;
                return false;
            }
        }
    }
}
