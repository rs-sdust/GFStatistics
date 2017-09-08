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
    public partial class frmClassifyAdjustment1 : DevExpress.XtraEditors.XtraForm
    {
        public frmClassifyAdjustment1()
        {
            InitializeComponent();
        }

        private void siBAdd_Click(object sender, EventArgs e)
        {

        }

        private void siBMinus_Click(object sender, EventArgs e)
        {
               
        }
            private void siBReneme_Click(object sender, EventArgs e)
        {
            frmReName ReName = new frmReName();
            ReName.ShowDialog();
        }

        private void siBStatistical_Click(object sender, EventArgs e)
        {
            frmStatisticsResult StatisticalResult = new frmStatisticsResult();
            StatisticalResult.ShowDialog();
        }

        private void siBRepeal_Click(object sender, EventArgs e)
        {

        }

      private void siBReturn_Click(object sender, EventArgs e)
        {

        }

        private void siBsave_Click(object sender, EventArgs e)
        {
            string localFilePath = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "tiff(*.tif)|*.tif|All files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog1.FileName.ToString();
                cBEresult.Text = saveFileDialog1.FileName;


            }
        }

        private void siBOK_Click(object sender, EventArgs e)
        {

        }

        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBHelp_Click(object sender, EventArgs e)
        {
            if (this.Size == MinimumSize)
            {
                this.Size = this.MaximumSize;
                siBHelp.Text = "<<隐藏帮助";
            }
            else
            {
                this.Size = this.MinimumSize;
                siBHelp.Text = "显示帮助>>";
            }
        }

      
    }
}