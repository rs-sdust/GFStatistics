using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GFS.Carbon
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
            flowList = new List<Button>() 
            { btnForest,btnShrub,btnGrass,btnVeg,btnSoil};
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
            Point start = GetRightCenter(btnForest);
            Point end = GetLeftCenter(btnShrub);
            e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnShrub);
            end = GetLeftCenter(btnGrass);
            ChangePenColor(ref pen,btnShrub, btnGrass);
            e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnGrass);
            end = GetLeftCenter(btnVeg);
            ChangePenColor(ref pen,btnGrass, btnVeg);
            e.Graphics.DrawLine(pen, start, end);

            start = GetRightCenter(btnVeg);
            //end = GetLeftCenter(btnSingleDate);
            //ChangePenColor(ref pen,btnVeg, btnSingleDate);
            //e.Graphics.DrawLine(pen, start, end);
            //end = GetLeftCenter(btnMultiDate);
            //ChangePenColor(ref pen,btnVeg, btnMultiDate);
            //e.Graphics.DrawLine(pen, start, end);

            //start = GetRightCenter(btnSingleDate);
            end = GetLeftCenter(btnSoil);
            ChangePenColor(ref pen, btnVeg, btnSoil);
            e.Graphics.DrawLine(pen, start, end);
            //start = GetRightCenter(btnMultiDate);
            //ChangePenColor(ref pen, btnMultiDate, btnSoil);
            //e.Graphics.DrawLine(pen, start, end);

            //start = GetRightCenter(btnSoil);
            //end = GetLeftCenter(btnVerification);
            //ChangePenColor(ref pen, btnSoil,btnVerification);
            //e.Graphics.DrawLine(pen, start, end);


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
