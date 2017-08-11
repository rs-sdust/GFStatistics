using GFS.BLL;
using System;
using GFS.Commands.UI;

namespace GFS.Commands
{
    public class IdentifyManager
    {
        public static readonly IdentifyManager instance = new IdentifyManager();

        private frmIdentify m_frmIdentify = null;

        public frmIdentify FrmIdentify
        {
            get
            {
                if (this.m_frmIdentify == null || this.m_frmIdentify.IsDisposed)
                {
                    this.m_frmIdentify = new frmIdentify(EnviVars.instance.MapControl.ActiveView.ScreenDisplay);
                    this.m_frmIdentify.Owner = EnviVars.instance.MainForm;
                }
                return this.m_frmIdentify;
            }
            set
            {
                this.m_frmIdentify = value;
            }
        }
    }
}
