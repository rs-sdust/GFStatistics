// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 08-23-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-24-2017
// ***********************************************************************
// <copyright file="DecisionTree.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>决策树类，存储所有节点及显示逻辑</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GFS.BLL;
using System.Xml;
using System.Data;

namespace GFS.ClassificationBLL
{
    public class DecisionTree
    {
        private static readonly string operators = "+ - * / < <= > >= == != & |";
        public static DataTable variableTable = null;
        //
        //节点层列表
        //
        private List<DecisionTreeLayer> layerList = null;
        //
        //决策树左下角坐标
        //
        public int lowerLeftX = 0;
        public int lowerLeftY = 0;
        //
        //层数
        //
        public int layerCount
        {
            get 
            {
                return layerList.Count;
            }
        }
        public DecisionTree()
        {
            InitialLayerList();
            Canvas.instance.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(panelCanvas_Paint);
            Canvas.instance.panelCanvas.SizeChanged += new System.EventHandler(this.panelCanvas_SizeChanged);
            //Canvas.instance.panelCanvas.Scroll +=new XtraScrollEventHandler(panelCanvas_Scroll);
            //Canvas.instance.panelCanvas.MouseWheel +=new MouseEventHandler(panelCanvas_MouseWheel);
            //Canvas.instance.panelCanvas.Invalidated +=new InvalidateEventHandler(panelCanvas_Invalidated);
        }
        //
        //初始化层列表
        //
        private void  InitialLayerList()
        {
            layerList = new List<DecisionTreeLayer>();
            DecisionTreeLayer layer0 = new DecisionTreeLayer(0);
            DecisionNode rootNode = new DecisionNode(null, 0, 0);
            layer0.nodeList[0] = rootNode;
            DecisionTreeLayer layer1 = new DecisionTreeLayer(1);
            DecisionNode node10 = new DecisionNode(rootNode, 1, 0);
            DecisionNode node11 = new DecisionNode(rootNode, 1, 1);
            layer1.nodeList[0] = node10;
            layer1.nodeList[1] = node11;
            layerList.Add(layer0);
            layerList.Add(layer1);
        }
        /// <summary>
        /// Opens the decision tree.
        /// </summary>
        /// <param name="file">The file.</param>
        public void OpenDecisionTree(string file)
        {
            XmlTextReader xmlReader = new XmlTextReader(file);
            try
            {
                if (DecisionTree.variableTable.Rows.Count > 0)
                    DecisionTree.variableTable.Rows.Clear();

                DecisionTree newTree = Canvas.instance.decisionTree = new DecisionTree();
                DecisionNode root = newTree.layerList[0].nodeList[0];
                DecisionNode left = newTree.layerList[1].nodeList[0];
                DecisionNode right = newTree.layerList[1].nodeList[1];
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlReader.Name == "Node")
                        {
                            if (!xmlReader.HasAttributes || xmlReader.AttributeCount < 7)
                            {
                                XtraMessageBox.Show("打开决策树文件失败，文件已损坏！", "提示信息", MessageBoxButtons.OK);
                                return;
                            }
                            string nodeName = xmlReader.GetAttribute(0);
                            string text = xmlReader.GetAttribute(1);
                            Color nodeColor = ColorTranslator.FromHtml(xmlReader.GetAttribute(2));
                            int nodeLayer = int.Parse(xmlReader.GetAttribute(3));
                            int nodeIndex = int.Parse(xmlReader.GetAttribute(4));
                            string exp = xmlReader.GetAttribute(5);
                            //string decisionData = xmlReader.GetAttribute(6);
                            int classValue = int.Parse(xmlReader.GetAttribute(6));

                            if (nodeName == root.NodeName)
                            {
                                root.Text = text;
                                root.nodeColor = nodeColor;
                                root.expression = exp;
                                //root.decisionData = decisionData;
                                root.classValue = classValue;
                            }
                            else if (nodeName == left.NodeName)
                            {
                                left.Text = text;
                                left.nodeColor = nodeColor;
                                left.expression = exp;
                                //left.decisionData = decisionData;
                                left.classValue = classValue;
                            }
                            else if (nodeName == right.NodeName)
                            {
                                right.Text = text;
                                right.nodeColor = nodeColor;
                                right.expression = exp;
                                //right.decisionData = decisionData;
                                right.classValue = classValue;
                            }
                            else
                            {
                                DecisionTreeLayer layer = null;
                                if (newTree.layerCount < nodeLayer + 1)
                                {
                                    layer = new DecisionTreeLayer(nodeLayer);
                                    newTree.AddLayer(layer);
                                }
                                else
                                {
                                    layer = newTree.GetLayer(nodeLayer);
                                }

                                DecisionNode father = newTree.GetLayer(nodeLayer - 1).nodeList[nodeIndex / 2];
                                father.nodeColor = Color.Empty;
                                father.button.Appearance.ForeColor = Color.Black;
                                DecisionNode node = new DecisionNode(father, nodeLayer, nodeIndex);
                                node.Text = text;
                                node.nodeColor = nodeColor;
                                node.expression = exp;
                                //node.decisionData = decisionData;
                                node.classValue = classValue;
                                layer.nodeList[nodeIndex] = node;
                            }

                        }
                        else if(xmlReader.Name =="Variable")
                        {
                            if (!xmlReader.HasAttributes || xmlReader.AttributeCount < 2)
                            {
                                XtraMessageBox.Show("打开决策树文件失败，文件已损坏！", "提示信息", MessageBoxButtons.OK);
                                return;
                            }
                            DataRow row = DecisionTree.variableTable.NewRow();
                            row[0] = xmlReader.GetAttribute(0);
                            row[1] = xmlReader.GetAttribute(1);
                            DecisionTree.variableTable.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(DecisionTree), ex);
            }
            finally
            {
                xmlReader.Close();
                //Canvas.instance.panelCanvas.Tag = true;
                Canvas.instance.decisionTree.RefreshTree();
                Canvas.instance.panelCanvas.Refresh();
            }
        }
        /// <summary>
        /// Saves the decision tree.
        /// </summary>
        /// <param name="file">The file.</param>
        public bool SaveDecisionTree(string file)
        {
            if (layerList == null)
                return false;
            if (layerList[0] == null)
                return false;
            if (layerList[0].nodeList == null)
                return false;
            if (layerList[0].nodeList[0] == null)
                return false;
            return SaveTree(layerList[0].nodeList[0], file);
        }
        private bool SaveTree(DecisionNode root,string file)
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(file, Encoding.UTF8);
            try
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("DecisionTree");

                this.WriteNode(xmlWriter, root);
                this.WriteVariable(xmlWriter);

                xmlWriter.WriteEndElement();
                return true;

            }
            catch (Exception ex)
            {
                GFS.BLL.Log.WriteLog(typeof(TaskHistory), ex);
                return false;
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }
        private void WriteNode(XmlTextWriter xmlWriter,DecisionNode node)
        {
            xmlWriter.WriteStartElement("Node");
            xmlWriter.WriteAttributeString("NodaName", node.NodeName);
            xmlWriter.WriteAttributeString("Text", node.Text);
            xmlWriter.WriteAttributeString("NodeColor", ColorTranslator.ToHtml(node.nodeColor));
            xmlWriter.WriteAttributeString("NodeLayer", node.layer.ToString());
            xmlWriter.WriteAttributeString("NodeIndex", node.index.ToString());
            xmlWriter.WriteAttributeString("Expression", node.expression);
            //xmlWriter.WriteAttributeString("DecisionData", node.decisionData);
            xmlWriter.WriteAttributeString("ClassValue", node.classValue.ToString());
            if (node.lChild != null)
            {
                //xmlWriter.WriteStartElement("LeftChild");
                this.WriteNode(xmlWriter,node.lChild);
                //xmlWriter.WriteStartElement("RightChild");
                this.WriteNode(xmlWriter, node.rChild);
            }
            xmlWriter.WriteEndElement();
        }
        private void WriteVariable(XmlTextWriter xmlWriter)
        {
            if (DecisionTree.variableTable == null)
                return;
            foreach (DataRow row in DecisionTree.variableTable.Rows)
            {
                xmlWriter.WriteStartElement("Variable");
                xmlWriter.WriteAttributeString("Name", row[0].ToString());
                xmlWriter.WriteAttributeString("File", row[1].ToString());
                xmlWriter.WriteEndElement();
            }
        }
        /// <summary>
        /// Adds the layer.
        /// </summary>
        /// <param name="layer">The layer.</param>
        public void AddLayer(DecisionTreeLayer layer)
        {
            if(layer==null)
                return;
            if (this.layerCount < layer.layerIndex + 1)
            {
                layerList.Add(layer);
            }
        }
        /// <summary>
        /// Removes the layer.
        /// </summary>
        /// <param name="layerIndex">Index of the layer.</param>
        public void RemoveLayer(int layerIndex)
        {
            if (this.layerCount >= layerIndex + 1)
            {
                layerList.RemoveAt(layerIndex);
            }
        }
        /// <summary>
        /// Removes the child tree.
        /// </summary>
        /// <param name="node">The node.</param>
        public void RemoveChildTree(DecisionNode node)
        {
            if (node == null)
                return;
            if (node.layer == 0)
                return;
            if (node.lChild == null)
                return;
            
            Canvas.instance.panelCanvas.Controls.Remove(node.lChild.button);
            Canvas.instance.panelCanvas.Controls.Remove(node.rChild.button);

            RemoveChildTree(node.lChild);
            RemoveChildTree(node.rChild);

            DecisionTreeLayer layer = GetLayer(node.layer + 1);
            layer.nodeList[node.lChild.index] = null;
            layer.nodeList[node.rChild.index] = null;
            if (IsLayerEmpty(layer))
                layerList.Remove(layer);
            node.lChild = null;
            node.rChild = null;
            node.nodeColor = RandomColor.GetRandomColor();
            node.button.Appearance.ForeColor = Color.White;
        }

        private bool IsLayerEmpty(DecisionTreeLayer layer)
        {
            bool res = true;
            foreach (DecisionNode node in layer.nodeList)
            {
                if (node != null)
                    res = false;
            }
            return res;
        }
        /// <summary>
        /// Gets the layer.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>DecisionTreeLayer.</returns>
        public DecisionTreeLayer GetLayer(int index)
        {
            if (layerCount < index + 1)
                return null;
            else
                return layerList[index];
        }
        /// <summary>
        /// Refreshes the treeList.
        /// </summary>
        public void RefreshTree()
        {
            lowerLeftX = 20;
            lowerLeftY = Canvas.instance.panelCanvas.Height-30;
            Canvas.instance.panelCanvas.Controls.Clear();
            for (int layerIndex = layerCount-1; layerIndex >= 0; layerIndex--)
            {
                DecisionTreeLayer layer = this.GetLayer(layerIndex);
                if(layer!=null)
                {
                    int nodeCount = (int)Math.Pow(2, layerIndex);
                    for(int i = 0;i<nodeCount;i++)
                    {
                        if (layer.nodeList[i] != null)
                        {
                            //if (layer.nodeList[i].lChild == null)
                            //    layer.nodeList[i].button.Location = new Point(lowerLeftX + (64) * i + 32 * ((int)Math.Pow(2, layerCount - layerIndex - 1) - 1), lowerLeftY - 44 * (layerCount - layerIndex - 1));
                            //else
                            layer.nodeList[i].button.Location = new Point(lowerLeftX + (64*(int)Math.Pow(2,layerCount-layerIndex-1)) * i + 32 * ((int)Math.Pow(2,layerCount-layerIndex-1)-1) , lowerLeftY - 48 * (layerCount - layerIndex-1));

                            Canvas.instance.panelCanvas.Controls.Add(layer.nodeList[i].button);
                        }
                    }
                }
            }
        }
        private void panelCanvas_SizeChanged(object sender, EventArgs e)
        {
            RefreshTree();
        }
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 0.5f);
            //尾部箭头
            pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            //字体
            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            //抗锯齿
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            this.DrawLine(e, pen, drawFont, drawBrush, Canvas.instance.decisionTree.layerList[0].nodeList[0], true);
        }
        //
        //获取节点上侧边中心坐标
        //
        private Point GetUperCenter(SimpleButton btn)
        {
            return new Point(btn.Location.X + btn.Width / 2, btn.Location.Y);
        }
        //
        //获取节点下侧边中心坐标
        //
        private Point GetLowerCenter(SimpleButton btn)
        {
            return new Point(btn.Location.X + btn.Width / 2, btn.Location.Y + btn.Height);
        }
        //
        //绘制节点链接线
        //
        private void DrawLine(PaintEventArgs e, Pen pen,Font drawFont,SolidBrush drawBrush ,DecisionNode node,bool clearAll)
        {
            if (clearAll)
            {
                e.Graphics.Clear(Color.White);
                //Canvas.instance.panelCanvas.Tag = false;
            }
            Point start = this.GetLowerCenter(node.button);
            if (node.lChild != null)
            {
                Point leftEnd = this.GetUperCenter(node.lChild.button);
                Point rightEnd = this.GetUperCenter(node.rChild.button);
                if (node.layer == 1 && node.index == 0)
                {
                    Log.WriteLog(typeof(DecisionTree), "start:" + start.ToString() + "\r\nleft:" + leftEnd.ToString() + "\r\nright" + rightEnd.ToString());
                }
                //MessageBox.Show("start:" + start.ToString() + "\r\nleft:" + leftEnd.ToString() + "\r\nright" + rightEnd.ToString());
                e.Graphics.DrawLine(pen, start, leftEnd);
                e.Graphics.DrawLine(pen, start, rightEnd);
                Point middleLeft = new Point(start.X-14+((leftEnd.X-start.X)/2),start.Y-7+((leftEnd.Y-start.Y)/2));
                Point middleRight = new Point(start.X+((rightEnd.X-start.X)/2),start.Y-7+((rightEnd.Y-start.Y)/2));
                e.Graphics.DrawString("No",drawFont,drawBrush,middleLeft);
                e.Graphics.DrawString("Yes", drawFont, drawBrush,middleRight);
                this.DrawLine(e, pen, drawFont,drawBrush,node.lChild, false);
                this.DrawLine(e, pen, drawFont, drawBrush, node.rChild, false);

            }
        }

        public static List<string> ParseExpression(string inExp,out string outExp)
        {
            List<string> variableList = null;
            try
            {
                outExp = inExp.TrimEnd();
                //if expression is null return null
                if (string.IsNullOrEmpty(outExp))
                    return variableList;
                //split expression by blank
                variableList = new List<string>();
                string[] expVariable = outExp.Split(' ');
                //parse variables in the expression and add []
                foreach (string ele in expVariable)
                {
                    if (Common.CommonAPI.IsNumber(ele))
                        continue;
                    if (DecisionTree.operators.Contains(ele))
                        continue;
                    outExp = outExp.Replace(ele, "[" + ele + "]");
                    variableList.Add(ele);
                }
                return variableList;

            }
            catch (Exception ex)
            {
                Log.WriteLog(typeof(DecisionTree), ex);
                outExp = string.Empty;
                return null;
            }
        }



    }
}
