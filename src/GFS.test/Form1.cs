using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GFS.BLL;
using ESRI.ArcGIS.Geoprocessor;
using GFS.Commands.UI;

namespace GFS.Test
{
    public partial class Form1 : Form
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        GFS.BLL.TaskHistory history = new GFS.BLL.TaskHistory("taskHistory.xml", 5);
        private void button1_Click(object sender, EventArgs e)
        {
            history.LoadHistory();
            this.listBox1.DataSource = null ;
            //this.listBox1.DataSource = history.TaskHistory;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            history.AddTask("test addTask " + i);
            i++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            history.SaveHistory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GFS.BLL.Log.WriteLog(typeof(Form1), textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GFS.BLL.Log.WriteLog(typeof(Form1), new Exception(textBox2.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //Geoprocessor gp = new Geoprocessor();
            //GFS.Classification.frmClipRaster frm = new Classification.frmClipRaster();
            //frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> file = new List<string>(){ @"F:\LC81230322014135LGN00_AOD.tif" };
            frmCreatePyramid frm = new frmCreatePyramid(file);
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开栅格文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "栅格文件|*.tif";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox3.Text = dlg.FileName;


        }

        private void button9_Click(object sender, EventArgs e)
        {
            dlg.Title = "打开样本文件";
            dlg.FileName = string.Empty;
            dlg.Filter = "样本文件|*.xml";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox4.Text = dlg.FileName;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "tiff(*.tif)|*.tif";
            //saveFileDialog1.FileName = DateTime.Now.ToString("****") + ".tif";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox5.Text = saveFileDialog1.FileName;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GP gp= new GP();
            string msg="";
            gp.ExtractByMask(textBox3.Text,textBox4.Text,textBox5.Text,out msg);
            MessageBox.Show(msg);

        }
    }
}
