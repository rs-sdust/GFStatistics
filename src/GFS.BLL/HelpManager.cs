using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GFS.BLL
{
    public class HelpManager
    {
        public static void ShowHelp(Control ctrl)
        {
            Type type = ctrl.GetType();
            if (EnviVars.instance.HelpTopics.ContainsKey(type.FullName))
            {
                string parameter = EnviVars.instance.HelpTopics[type.FullName];
                Help.ShowHelp(ctrl, ConstDef.FILE_HELPFILE, HelpNavigator.Topic, parameter);
            }
        }
    }
}
