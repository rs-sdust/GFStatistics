using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GFS.BLL;
using GFS.Sample;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using GFS.SampleBLL;

namespace GFS.Sample
{
    public partial class frmSampleSimulation : DevExpress.XtraEditors.XtraForm
    {
        private int SamplingSum = 0; //统计样本总量
        private int sampleNum = 0;//样本量
        private DataTable sampleSumTable = new DataTable();//总体样本的属性表
        private DataTable sampleTable = new DataTable();//第n次抽样得到的样本表
        private List<DataTable> SampleZones = new List<DataTable>();//n次重复抽样得到的样本表汇总表
        public frmSampleSimulation()
        {
            InitializeComponent();
        }
        private void frmSampleSimulation_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            MapAPI.GetAllLayers(null, cBFile);//加载地图图层中的数据
        }
        //入样总体
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName.ToString();
                cBFile.Text = filepath;//获取文件路径
                SampleSimulation.BindFields(cBFile.Text, cBELayer);
                SampleSimulation.BindFields(cBFile.Text, cBEBasis);
                SampleSimulation.BindFields(cBFile.Text, cBEClassic);
            }
        }
        //抽样仿真
        private void siBSimulation_Click(object sender, EventArgs e)//抽样仿真
        {
            sampleSumTable.Clear();
            sampleSumTable.Columns.Clear();
            if (string.IsNullOrEmpty(cBFile.Text.TrimEnd()) || string.IsNullOrEmpty(cBEBasis.Text.TrimEnd()) || string.IsNullOrEmpty(cBELayer.Text.TrimEnd()))
            {
                MessageBox.Show("错误信息：\n入样总体文件是必需的！\n抽样依据的值：是必需的！\n分层的值是：必需的！");
            }
            else
            {
                IFeatureClass allVillage = EngineAPI.OpenFeatureClass(cBFile.Text);
                ITableConversion conver = new TableConversion();

                this.sampleSumTable = conver.AETableToDataTable(allVillage);
                SamplingSum = sampleSumTable.Rows.Count;
                if (string.IsNullOrEmpty(tENum.Text.TrimEnd()) && string.IsNullOrEmpty(tEProportion.Text.TrimEnd()) || string.IsNullOrEmpty(tETimes.Text.TrimEnd()))
                {
                    MessageBox.Show("错误信息：\n样本量与抽样比例的值二选一，必须有一个有值！\n抽样次数值是：必需的！");
                }
                else
                {
                    if (cENum.Checked == true)
                    {
                        sampleNum = Convert.ToInt32(tENum.Text);
                    }
                    else
                    {
                        sampleNum = Convert.ToInt32(SamplingSum * (Convert.ToDouble(tEProportion.Text) / 100));
                    }
                    if (0 > sampleNum || sampleNum > SamplingSum)
                    {
                        MessageBox.Show("输入的样本量超出范围,请重新输入！");
                        return;
                    }
                    //显示
                    groupCResult.Visible = true;
                    groupC.Visible = true;
                    this.MinimumSize = new Size(755, 425);
                    groupCHelp.Location = new Point(758, 12);
                    //结果汇总
                    lBCResult.Items.Clear();//清空
                    lBCResult.Items.Add("抽样单元的总数：" + SamplingSum);
                    lBCResult.Items.Add("抽中样本数：" + sampleNum);
                    int sampleTimes = Convert.ToInt32(tETimes.Text);
                    double Cv = 0.0;
                    double MSEYr = 0.0;
                    //EstArea 重复抽样得到的估算面积表
                    DataTable EstArea = new DataTable();
                    SampleSimulation Sim = new SampleSimulation();
                    if (Sim.SampleEvaluating(cBFile.Text, sampleTimes, sampleNum, cBELayer.Text,
                        cBEBasis.Text,cBEClassic.Text , EstArea, ref MSEYr, ref Cv, SampleZones))
                    {
                        lBCResult.Items.Add("均方误差(MSE)：" + MSEYr.ToString("f2"));
                        lBCResult.Items.Add("变异系数：" + Cv.ToString("f2"));
                        gridControl1.DataSource = EstArea;
                        //chartData 绑定估计结果
                        chartData.Series.Clear();
                        Series dataTable1Series = new Series("", ViewType.Spline);
                        dataTable1Series.ArgumentDataMember = EstArea.Columns[0].ColumnName;
                        dataTable1Series.ValueDataMembers[0] = EstArea.Columns[1].ColumnName;
                        dataTable1Series.DataSource = EstArea;
                        chartData.Series.Add(dataTable1Series);
                    }
                }
            }
        }
        //样本量
        private void cENum_CheckedChanged(object sender, EventArgs e)
        {
            if (cENum.Checked == true)
            {
                cEProportion.Checked = false;
            }
            else
            {
                tEProportion.Properties.ReadOnly = false;
            }
        }
        //样本比例
        private void cEProportion_CheckedChanged(object sender, EventArgs e)
        {
            if (cEProportion.Checked == true)
            {
                cENum.Checked = false;
            }
            else
            {
                tENum.Properties.ReadOnly = false;
            }
        }
        //选中表格某一行事件
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内 
                if (hi.InRow)
                {
                    int vsRowNum = hi.RowHandle;//鼠标选中行号
                    //每次抽样得到的样本
                    sampleTable = SampleZones[vsRowNum];
                    string outfile = Path.Combine(ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
                    try
                    {
                        SampleSimulation Sim = new SampleSimulation();
                        if (Sim.CreateShpFile(cBFile.Text, sampleTable, outfile))
                        {
                            //添加第i次得到的样本结果到主地图视图
                            //MapAPI.AddShpFileToMap(outfile);
                            MapAPI.AddShpFileToMap(outfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }              
            }
        }
        //扩充样本量
        private void cEExtend_CheckedChanged(object sender, EventArgs e)
        {
            if (cEExtend.Checked == true)
            {
                cERatio.Checked = false;
            }
            else
            {
                tEScale.Properties.ReadOnly = false;
            }
        }
        //扩充比例
        private void cERatio_CheckedChanged(object sender, EventArgs e)
        {
            if (cERatio.Checked == true)
            {
                cEExtend.Checked = false;
            }
            else
            {
                tEExtend.Properties.ReadOnly = false;
            }
        }
        //保存样本
        private void siBSave_Click(object sender, EventArgs e)
        {
            string localFilePath = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog1.FileName.ToString();
                cBESave.Text = saveFileDialog1.FileName;
            }
        }
        private void siBOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cBESave.Text.Trim()))
            {
                MessageBox.Show("错误信息：\n输出结果的值：是必需的");
            }
            else
            {
                WaitDialogForm frmWait = new WaitDialogForm("正在生成...", "提示信息");
                try
                {
                    DataTable ExtandTable = new DataTable();
                    SampleSimulation Sim = new SampleSimulation();
                    int sampleSum = SamplingSum - sampleNum;//第一次抽样,剩余的样本总量
                    int sampleExtandNum = 0;//扩充的样本量
                    if (string.IsNullOrEmpty(tEExtend.Text.Trim()) && string.IsNullOrEmpty(tEScale.Text.Trim()))
                    {
                        ExtandTable = sampleTable;
                    }
                    else
                    {
                        if (cEExtend.Checked == true)
                        {
                            sampleExtandNum = Convert.ToInt32(tEExtend.Text);
                        }
                        else
                        {
                            sampleExtandNum = Convert.ToInt32(sampleSum * (Convert.ToDouble(tEScale.Text) / 100));
                        }
                        if (0 > sampleExtandNum || sampleExtandNum > sampleSum)
                        {
                            MessageBox.Show("输入的扩充样本量超出范围,请重新输入！");
                            return;
                        }
                        else if (sampleExtandNum == 0)
                        {
                            ExtandTable = sampleTable;
                        }
                        else
                        {
                            ExtandTable = Sim.ExtendSample(sampleSumTable, sampleTable, sampleExtandNum, cBELayer.Text, cBEBasis.Text);
                        }
                    }
                    if (ExtandTable != null)
                    {
                        if (Sim.CreateShpFile(cBFile.Text, ExtandTable, cBESave.Text))
                        {
                            System.Windows.Forms.DialogResult dialogResult = XtraMessageBox.Show("保存样本成功,是否加载结果？", "提示信息", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
                            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                //添加结果到主地图视图
                                //MapAPI.AddShpFileToMap(cBESave.Text);
                                MapAPI.AddShpFileToMap(cBESave.Text);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Log.WriteLog(typeof(frmSampleSimulation), ex);
                }
                finally
                {
                    frmWait.Close();
                    this.Close();
                }
            }
        }

        private void siBConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siBHelp_Click(object sender, EventArgs e)
        {
            if (groupC.Visible == true && groupCResult.Visible == true)
            {
                this.MinimumSize = new Size(755, 425);
                this.MaximumSize = new Size(960, 425);
                groupCHelp.Location = new Point(758, 12);
            }
            else
            {
                this.MinimumSize = new Size(435, 425);
                this.MaximumSize = new Size(635, 425);
                groupCHelp.Location = new Point(433, 11);
            }
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
