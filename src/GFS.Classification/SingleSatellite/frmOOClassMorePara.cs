using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GFS.Classification
{
    public partial class frmOOClassMorePara : DevExpress.XtraEditors.XtraForm
    {
        frmOOClassification parent = null;
        public frmOOClassMorePara(frmOOClassification form)
        {
            InitializeComponent();
            this.parent = form;
            this.spinHiddenLyr.EditValue = form.hiddenLyr;
            this.spinIteration.EditValue = form.maxSweep;
            this.spinMinActThres.EditValue = form.minActThres;
        }

        private void ztbHiddenLyr_EditValueChanged(object sender, EventArgs e)
        {
            this.spinHiddenLyr.EditValue = this.ztbHiddenLyr.EditValue;
        }

        private void spinHiddenLyr_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbHiddenLyr.EditValue = this.spinHiddenLyr.EditValue;
        }

        private void ztbIteration_EditValueChanged(object sender, EventArgs e)
        {
            this.spinIteration.EditValue = this.ztbIteration.EditValue;
        }

        private void spinIteration_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbIteration.EditValue = this.spinIteration.EditValue;
        }

        private void ztbMinActThres_EditValueChanged(object sender, EventArgs e)
        {
            this.spinMinActThres.EditValue = float.Parse(this.ztbMinActThres.EditValue.ToString()) / 10f;
        }

        private void spinMinActThres_EditValueChanged(object sender, EventArgs e)
        {
            this.ztbMinActThres.EditValue = float.Parse(this.spinMinActThres.EditValue.ToString()) * 10;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            parent.hiddenLyr = int.Parse(this.spinHiddenLyr.EditValue.ToString());
            parent.maxSweep = int.Parse(this.spinIteration.EditValue.ToString());
            parent.minActThres = float.Parse(this.spinMinActThres.EditValue.ToString());
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}