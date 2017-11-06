using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GFS.Sample
{

    public partial class UCWorkFlow : UserControl
    {
        private List<Button> flowList;
        public UCWorkFlow()
        {
            InitializeComponent();
            IniFlowList();
        }
        //刷新流程进度
        public void RefreshFlow(FlowStatus flowName)
        {
            if (flowName == FlowStatus.Start)
            {
                foreach (Button btn in flowList)
                {
                    btn.ImageKey = btn.Name + "Default";
                }
            }
            else if (flowName == FlowStatus.End)
            {
                foreach (Button btn in flowList)
                {
                    btn.ImageKey = btn.Name + "Done";
                }
            }
            else
            {
                int flowIndex = -1;
                foreach (Control ctrl in this.panel1.Controls)
                {
                    if (ctrl.Name == flowName.ToString())
                    {
                        flowIndex = flowList.IndexOf(ctrl as Button);
                    }
                }

                if (flowIndex < 0)
                    return;

                for (int i = 0; i < flowList.Count; i++)
                {
                    Button btn = flowList[i];
                    if (i < flowIndex)
                    {
                        btn.ImageKey = btn.Name + "Done";
                    }
                    else if (i == flowIndex)
                    {
                        btn.ImageKey = btn.Name + "Running";
                        this.panel1.ScrollControlIntoView(btn);
                    }
                    else
                    {
                        btn.ImageKey = btn.Name + "Default";
                    }
                }
            }

            this.panel1.Refresh();

        }
        //初始化流程列表
        private void IniFlowList()
        {
            flowList = new List<Button>() { btnFrame, btnErrorAnalyze, btnSimulation, btnSample,btnSummary, btnReview ,btnEstimate};
            
            //foreach(Control ctrl in this.panel1.Controls) 
            //{
            //    try
            //    {
            //        flowList.Add(ctrl as Button);
            //    }
            //    catch
            //    {
            //        continue;
            //    }
            //}
        }
        //获取流程右侧边中心坐标
        private Point GetLeftCenter(Button btn)
        {
            return new Point(btn.Location.X,btn.Location.Y+btn.Height/2);
        }
        //获取流程左侧边中心坐标
        private Point GetRightCenter(Button btn)
        {
            return new Point(btn.Location.X + btn.Width, btn.Location.Y + btn.Height / 2);
        }
        //绘制流程连接线
        private void UCWorkFlow_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Blue, 3);
            //尾部箭头
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //抗锯齿
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //绘制链接线
            Point start = GetRightCenter(btnFrame);
            Point end = GetLeftCenter(btnErrorAnalyze);
            ChangePenColor(ref pen, btnFrame, btnErrorAnalyze);
            e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnErrorAnalyze);
            end = GetLeftCenter(btnSimulation);
            ChangePenColor(ref pen,btnErrorAnalyze, btnSimulation);
            e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnSimulation);
            end = GetLeftCenter(btnSample);
            ChangePenColor(ref pen,btnSimulation, btnSample);
            e.Graphics.DrawLine(pen, start, end);

            //start = GetRightCenter(btnSample);
            //end = GetLeftCenter(btnSingleDate);
            //ChangePenColor(ref pen,btnSample, btnSingleDate);
            //e.Graphics.DrawLine(pen, start, end);
            //end = GetLeftCenter(btnMultiDate);
            //ChangePenColor(ref pen,btnSample, btnMultiDate);
            //e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnSample);
            end = GetLeftCenter(btnSummary);
            ChangePenColor(ref pen, btnSample, btnSummary);
            e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnSummary);
            end = GetLeftCenter(btnReview);
            ChangePenColor(ref pen, btnSummary, btnReview);
            e.Graphics.DrawLine(pen, start, end);
            //start = GetRightCenter(btnMultiDate);
            //ChangePenColor(ref pen, btnMultiDate, btnReview);
            //e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnReview);
            end = GetLeftCenter(btnEstimate);
            ChangePenColor(ref pen, btnReview,btnEstimate);
            e.Graphics.DrawLine(pen, start, end);


        }
        //根据流程状态修改链接线颜色 
        private void ChangePenColor(ref Pen pen, Button start,Button end)
        {
            if (end.ImageKey.Contains("Default"))
                pen.Color = Color.Gray;
            else
            {
                if (start.ImageKey.Contains("Default"))
                    pen.Color = Color.Gray;
                else
                    pen.Color = Color.Blue;
            }
        }

    }
}
