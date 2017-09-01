using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GFS.ClassificationBLL
{
    public partial class frmBandSelection : DevExpress.XtraEditors.XtraForm
    {
        public string SelectedBand
        {
            get { return this.cmbBand.Text.TrimEnd(); }
        }
        public frmBandSelection(int band)
        {
            InitializeComponent();
            InitialBands(band);
            this.cmbBand.SelectedIndex = 0;
        }
        private void  InitialBands(int band)
        {
            this.cmbBand.Properties.Items.Clear();
            for (int i = 0; i < band; i++)
            {
                this.cmbBand.Properties.Items.Add("Band_"+ (i+1));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}