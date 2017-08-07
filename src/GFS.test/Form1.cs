using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GFS.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        BLL.TaskHostory history = new BLL.TaskHostory("taskHistory.xml", 5);
        private void button1_Click(object sender, EventArgs e)
        {
            history.LoadHistory();
            this.listBox1.DataSource = null ;
            this.listBox1.DataSource = history.TaskHistory;
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
            GFS.BLL.Log.WriteLog(typeof(Form1), new Exception(textBox1.Text));
        }
    }
}
