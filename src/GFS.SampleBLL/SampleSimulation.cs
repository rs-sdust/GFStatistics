using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using System.IO;
using System.Runtime.InteropServices;
using GFS.Common;
using GFS.BLL;
using ESRI.ArcGIS.Display;

namespace GFS.SampleBLL
{
   public  class SampleSimulation
    {
       private string _expand = "KC";

       private struct Range   //区间
       {
           public double Max;
           public double Min;
       }
     /// <summary>
     /// 获取抽样矢量文件的属性表
     /// </summary>
       /// <param name="shpFile">入样总体</param>
     /// <param name="Population">属性表</param>
     /// <returns>是否成功信息反馈</returns>
       public static bool AttributeTable(string shpFile, DataTable Population)
       {
           bool result;
           IField pField = null;
           string folder = System.IO.Path.GetDirectoryName(shpFile);
           string filename = System.IO.Path.GetFileName(shpFile);
           try
           {
               IWorkspaceFactory wsf = new ShapefileWorkspaceFactory();
               IWorkspace ws = wsf.OpenFromFile(folder, 0);
               IFeatureWorkspace fws = ws as IFeatureWorkspace;
               IFeatureClass fc = fws.OpenFeatureClass(filename);

               if (fc.ShapeType == esriGeometryType.esriGeometryPolygon)
               {
                  
                   int Num = fc.Fields.FieldCount;
                   for (int i = 0; i < Num; i++)
                   {
                       pField = fc.Fields.get_Field(i);
                       //string name = fc.Fields.get_Field(i).Name;
                       DataColumn pDataColumn = new DataColumn(pField.Name );
                       //字段值是否允许为空
                       pDataColumn.AllowDBNull = pField.IsNullable;
                       //字段别名
                       pDataColumn.Caption = pField.AliasName;
                       //字段数据类型
                       pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                       //字段默认值
                       pDataColumn.DefaultValue = pField.DefaultValue;
                       //字段添加到表中
                       Population.Columns.Add(pDataColumn);
                   }
                   //ITable pTable = fc as ITable;
                   IFeatureCursor pCursor = fc.Search(null, false);
                   int ishape = fc.Fields.FindField("Shape");
                   IFeature pFea = pCursor.NextFeature();
                   while (pFea != null)
                   {
                       DataRow pRow = Population.NewRow();
                       for (int i = 0; i < fc.Fields.FieldCount; i++)
                       {
                           if (i == ishape)
                           {
                               pRow[i] = "Polygon";
                               continue;
                           }
                           pRow[i] = pFea.get_Value(i);
                       }
                       Population.Rows.Add(pRow);
                       pFea = pCursor.NextFeature();
                   }
               }
               else
               {
                   XtraMessageBox.Show("输入的数据类型不是面状的，不符合要求，请重新输入");
               }

               result = true;
           }
           catch (Exception ex)
           {
               XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

               result = false;
           }
           return result;
       }
      
       /// <summary>
       /// 将GeoDatabase字段类型转换成.Net相应的数据类型
       /// </summary>
       /// <param name="fieldType">字段类型</param>
       /// <returns></returns>
       public static string ParseFieldType(esriFieldType fieldType)
       {
           switch (fieldType)
           {
               case esriFieldType.esriFieldTypeBlob:
                   return "System.String";
               case esriFieldType.esriFieldTypeDate:
                   return "System.DateTime";
               case esriFieldType.esriFieldTypeDouble:
                   return "System.Double";
               case esriFieldType.esriFieldTypeGeometry:
                   return "System.String";
               case esriFieldType.esriFieldTypeGlobalID:
                   return "System.String";
               case esriFieldType.esriFieldTypeGUID:
                   return "System.String";
               case esriFieldType.esriFieldTypeInteger:
                   return "System.Int32";
               case esriFieldType.esriFieldTypeOID:
                   return "System.String";
               case esriFieldType.esriFieldTypeRaster:
                   return "System.String";
               case esriFieldType.esriFieldTypeSingle:
                   return "System.Single";
               case esriFieldType.esriFieldTypeSmallInteger:
                   return "System.Int32";
               case esriFieldType.esriFieldTypeString:
                   return "System.String";
               default:
                   return "System.String";
           }
       }
      
       /// <summary>
       /// PPS抽样算法
       /// </summary>
       /// <param name="Population4">入样总体表</param>
       /// <param name="sampleNum">样本数量</param>
       /// <param name="Basis">抽样依据字段名称</param>
       /// <returns>样本</returns>
       private DataTable PPSSampling(DataTable Population4, int sampleNum, string Basis)// int sampleTimes,
       {
           try
           {
               DataTable Samples = Population4.Clone();
               //计算耕地总面积
               double sumArea = Population4.AsEnumerable().Select(t => t.Field<double>(Basis)).Sum();
               //double sumArea = ColumnSum(Population4, Basis);
               //计算总样本量
               int i_popuNum = Population4.Rows.Count; 
               //归一化计算入样概率
               //获取抽样依据的最大值、最小值
               double d_max = Population4.AsEnumerable().Select(t => t.Field<double>(Basis)).Max();
               double d_min = Population4.AsEnumerable().Select(t => t.Field<double>(Basis)).Min();
               Range[] ranges = null;
              
               //最大最小值不同时
               if (d_min != d_max)
               {
                 double[] probability = new double[i_popuNum]; 
                //计算[入样概率i]=[样本量]*[耕地面积i]/[耕地总面积]
                for (int i = 0; i < i_popuNum; i++)
                {
                    double Mi = Convert.ToDouble(Population4.Rows[i][Basis]);
                    probability[i] = sampleNum * (Mi / sumArea);
                    //Population.Rows[i]["入样概率"] = probability[i];
                }
                   //计算累计区间ranges[]
                   ranges = new Range[i_popuNum];//累计区间
                   ranges[0].Min = 0;
                   ranges[0].Max = ranges[0].Min + probability[0] * 1000;
                   for (int i = 1; i < i_popuNum; i++)
                   {
                       ranges[i].Min = ranges[i - 1].Max;
                       ranges[i].Max = ranges[i].Min + probability[i] * 1000;
                   }
                   //随机取样本
                   Random ran = new Random();
                   List<int> list = new List<int>();
                   int RandKey;
                   for (int index = 0; index < sampleNum; index++)
                   {
                       RandKey = UniqueRandom(list,0, (int)ranges[i_popuNum - 1].Max);
                       //取出符合条件的记录作为样本
                       //即select * from 【入样总体】 where 【累积区间Min】<=随机数 and 【累积区间Max】>=随机数
                       for (int i = 0; i < i_popuNum; i++)
                       {
                           if (ranges[i].Min <= RandKey && ranges[i].Max >= RandKey)
                           {
                               DataRow drss = Population4.Rows[i];
                               Samples.Rows.Add(drss.ItemArray);
                               Population4.Rows.RemoveAt(i);
                               i_popuNum--;
                           }
                       }
                   }
               }
               //最大最小值相同时
               else
               { 
                   //简单随机取样本
                   Random ran = new Random();
                   int RandKey;
                   for (int index = 0; index < sampleNum; index++)
                   {
                       RandKey = ran.Next(0, i_popuNum - 1);//取1到i_popuNum - 1的随机数
                       DataRow drss = Population4.Rows[RandKey];//取随机的记录为样本记录
                       Samples.Rows.Add(drss.ItemArray);
                       Population4.Rows.RemoveAt(RandKey);//删除已选为样本的记录
                       i_popuNum--;
                   }
               }
            return Samples;
           }
           catch (Exception ex)
           {
               XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               return null;
           }
       }
       /// <summary>
       /// 取唯一随机数
       /// </summary>
       /// <param name="list">随机数数组</param>
       /// <param name="min">最小值</param>
       /// <param name="max">最大值</param>
       /// <returns></returns>
       private static int UniqueRandom(List<int> list, int min, int max)
       {
           int randKey = new Random().Next(min, max);
           if (!list.Contains(randKey))
           {
               list.Add(randKey);
               return randKey;
           }
           else
           {
               return UniqueRandom(list, min, max);
           }
       }
       /// <summary>
       /// 分层PPS抽样算法
       /// </summary>
       /// <param name="Population">总体分层</param>
       /// <param name="i_samplesNum">抽样的总样本量</param>
       /// <param name="ZoneNum">层号字段名称</param>
       /// <param name="Basis">抽样依据字段名称</param>
       /// <returns>样本表</returns>
       private DataTable StratifiedPPSSampling(DataTable Population3, int i_samplesNum, string ZoneNum, string Basis)
       {
           DataTable Samples = Population3.Clone();
           //计算总样本量
           int i_popuNum = Population3.Rows.Count;
           //int i_samplesNum = Convert.ToInt32(i_popuNum * d_Scale);
           //得出:总体分层的层数i_ZoneCount、各层的样本量i_ZoneSamplesNum[]、按分层整合的记录ZonePopu[]
           int i_ZoneCount = 0;//层数
           int[] i_ZoneSamplesNum = null;
           DataTable[] ZonePopu = GetStratifiedSamples(Population3, i_samplesNum, ZoneNum, ref i_ZoneCount, ref i_ZoneSamplesNum);
           //分层进行PPS抽样
           DataTable[] ZoneSamp = new DataTable[i_ZoneCount];
           for (int i = 0; i < i_ZoneCount; i++)
               ZoneSamp[i] = PPSSampling(ZonePopu[i], i_ZoneSamplesNum[i], Basis);
           //合并抽样结果
           for (int i = 0; i < i_ZoneCount; i++)
               for (int j = 0; j < ZoneSamp[i].Rows.Count; j++)
               {
                   DataRow drss = ZoneSamp[i].Rows[j];
                   Samples.Rows.Add(drss.ItemArray);
               }
           return Samples;
       }
       
       /// <summary>
       /// 分层抽样前获取各层记录（分层抽样算法中调用）
       /// </summary>
       /// <param name="Population">总体分层</param>
       /// <param name="i_samplesNum">抽样的总样本量</param>
       /// <param name="ZoneNum"> 层号字段名称</param>
       /// <param name="i_ZoneCount">（传出参数）总体分层的层数</param>
       /// <param name="i_ZoneSamplesNum">（传出参数）各层的样本量</param>
       /// <returns>总体分层的各层记录</returns>
       public static DataTable[] GetStratifiedSamples(DataTable Population2, int i_samplesNum, string ZoneNum,
                                             ref int i_ZoneCount, ref int[] i_ZoneSamplesNum)
       {
           //查出共有几层,即总体分层的层数i_ZoneCount
           List<double> zones = new List<double>();
           for (int i = 0; i < Population2.Rows.Count; i++)
           {
               double i_temp = Convert.ToDouble(Population2.Rows[i][ZoneNum].ToString());
               if (!zones.Contains(i_temp))
               {
                   zones.Add(i_temp);
               }                 
           }
           i_ZoneCount = zones.Count;
           if (i_ZoneCount == 0)//没有分层
               return null;
           //总体分层按层分为i_ZoneCount个datatable
           DataTable[] ZonePopu = new DataTable[i_ZoneCount];
           for (int i = 0; i < i_ZoneCount; i++)
               ZonePopu[i] = Population2.Clone();
           for (int i = 0; i < Population2.Rows.Count; i++)
           {
               double i_temp = Convert.ToDouble(Population2.Rows[i][ZoneNum]);
               DataRow drss = Population2.Rows[i];
               int index = zones.FindIndex(item => item == i_temp);
               ZonePopu[index].Rows.Add(drss.ItemArray);
           }
           //各层的样本量
           i_ZoneSamplesNum = new int[i_ZoneCount];
           int t_samplesNum = 0;
           for (int i = 0; i < i_ZoneCount - 1; i++)
           {
               i_ZoneSamplesNum[i] = Convert.ToInt32(Math.Round(Convert.ToDouble(i_samplesNum * ZonePopu[i].Rows.Count) / Convert.ToDouble(Population2.Rows.Count)));
               t_samplesNum = t_samplesNum + i_ZoneSamplesNum[i];
           }
           //保证∑【各层样本量】=【样本总量】
           i_ZoneSamplesNum[i_ZoneCount - 1] = i_samplesNum - t_samplesNum;

           return ZonePopu;
       }
      
       /// <summary>
       /// 获取属性表中的列名
       /// </summary>
       /// <param name="fPath">模拟抽样文件</param>
       /// <param name="cmb">下拉框</param>
       public static void BindFields(string fPath, ComboBoxEdit cmb)
       {
           cmb.Properties.Items.Clear();
           try
           {
               DataTable table = new DataTable();
               IFeatureClass allVillage = EngineAPI.OpenFeatureClass(fPath);
               ITableConversion conver = new TableConversion();
               table = conver.AETableToDataTable(allVillage);
              
                if (table == null)
                    return;
                for (int i = 0; i < table.Columns.Count; ++i)
                {
                     //Type type = table.Columns[i].DataType;
                    //if (type != typeof(string))
                    //{
                        string f_name = table.Columns[i].ColumnName;
                        cmb.Properties.Items.Add(f_name);
                    //}
                } 
               
           }
           catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }
       /// <summary>
       /// 结果汇总，计算抽取的样本的均方误差值、变异系数，以及每次抽样估算的总面积
       /// </summary>
       /// <param name="file">模拟抽样文件</param>
       /// <param name="sampleTimes">重复抽样次数</param>
       /// <param name="i_samplesNum">抽取样本量</param>
       /// <param name="ZoneNum">层号字段名称</param>
       /// <param name="Basis">抽样依据字段名称</param>
       /// <param name="Classic">总体样本</param>
       /// <param name="EstimationArea">重复抽样得到的估算面积表</param>
       /// <param name="MSE_Yr">均方误差值</param>
       /// <param name="CV">变异系数</param>
       /// <param name="zones">重复抽样得到的样本表汇总表</param>
       /// <returns>是否成功信息反馈</returns>
       public bool SampleEvaluating(string file, int sampleTimes, int i_samplesNum, string ZoneNum, string Basis, string Classic, DataTable EstimationArea
                                               , ref double MSE_Yr, ref double CV, List<DataTable> zones)
       {
           bool result;
           EstimationArea.Columns.Add("ID", typeof(Int32));
           EstimationArea.Columns.Add("估算结果(万亩)",typeof(double));
           try
           {
               zones.Clear();

               double YrArea2 = 0;
               DataTable Population1 = new DataTable();
               //AttributeTable(file, Population1);

               double sum_Area = 0; //耕地总面积
               for (int j = 0; j < sampleTimes; j++)
               {
                   Population1.Clear();
                   Population1.Columns.Clear();
                   IFeatureClass allVillage = EngineAPI.OpenFeatureClass(file);
                   ITableConversion conver = new TableConversion();
                   Population1 = conver.AETableToDataTable(allVillage);
                   sum_Area = Population1.AsEnumerable().Select(t => t.Field<double>(Basis)).Sum();
                   //sum_Area = ColumnSum(Population1, Basis);
                   double Yr_Area = 0;//第j套样本估算得到的总面积
                   //得出:总体分层的层数i_ZoneCount、各层的样本量i_ZoneSamplesNum[]、按分层整合的记录ZonePopu[]
                   int i_ZoneCount = 0;//层数
                   int[] i_ZoneSamplesNum = null;
                   DataTable SamplePopu =  StratifiedPPSSampling( Population1,i_samplesNum, ZoneNum, Basis);
                   DataTable[] ZonePopu = GetStratifiedSamples(SamplePopu, i_samplesNum, ZoneNum, ref i_ZoneCount, ref i_ZoneSamplesNum);
                   for (int h = 0; h < i_ZoneCount; h++)
                   {
                       double[] h_probability = new double[ZonePopu[h].Rows.Count];
                       for (int i = 0; i < ZonePopu[h].Rows.Count; i++)
                       {
                           //计算入样概率，公式为 【第h层的【层样本量】】 *【抽样单元内【耕地面积】】/【h层耕地总面积】
                           double SUMh_Area = ZonePopu[h].AsEnumerable().Select(t => t.Field<double>(Basis)).Sum(); //【h层耕地总面积】
                           //double SUMh_Area1 = ColumnSum(ZonePopu[h], Basis);//【h层耕地总面积】
                           h_probability[i] = ZonePopu[h].Rows.Count * Convert.ToDouble(ZonePopu[h].Rows[i][Basis]) / SUMh_Area;
                           if (h_probability[i] != 0)
                           {
                               //M_chi表示第h层第i个样本村的作物分类面积
                               double Chi_Area = Convert.ToDouble(ZonePopu[h].Rows[i][Classic]);//classic表示表中分类面积字段名称
                               Yr_Area += Chi_Area / h_probability[i];
                            }
                        }
                     }
                   if (!zones.Contains(SamplePopu))
                   {
                       zones.Add(SamplePopu);
                   }
                   double  Basis_Area = SamplePopu.AsEnumerable().Select(t => t.Field<double>(Basis)).Sum();//抽样单元村耕地总面积;

                   double Yr = Yr_Area * 0.0015/10000;//单位转化
                   EstimationArea.Rows.Add(new object[] { j + 1, Yr.ToString("f2")});

                   //YrArea2=(∑[(Y_r/n*M-Y)]^2 ),Y_r是第 r 套样本耕地总面积值，Y是【耕地总面积】,n是抽取样本村个数，M是入样总体村个数
                   YrArea2 += Math.Pow((Basis_Area / i_samplesNum * Population1.Rows .Count  - sum_Area), 2);
                 }
               //精度评价计算
               //均方误差计算,公式(∑【(Y_r-Y)】^2 )⁄k，k为【重复抽样次数】，Y_r是第 r 套样本对总体面积估计值，Y是【耕地总面积】
               MSE_Yr = YrArea2 / sampleTimes;
               //变异系数计算，公式（Sqrt(MSE(Y_r))/Y*100%
               CV = Math.Sqrt(MSE_Yr) / sum_Area; 
               result = true;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
               result = false;
           }
           return result;    
       }
       ///// <summary>
       ///// 获取表格中某一列的和
       ///// </summary>
       ///// <param name="dt">表格</param>
       ///// <param name="ColumnName">列名</param>
       ///// <returns>和</returns>
       //private double ColumnSum(DataTable dt, string ColumnName)
       //{
       //    double Sum = 0;
       //    if (dt.Columns.Contains(ColumnName))
       //    {
       //        foreach (DataRow row in dt.Rows)
       //        {
       //            Sum += double.Parse(row[ColumnName].ToString()); ;
       //        }
       //    }
       //    return Sum;
       //}
       /// <summary>
       /// 扩充样本
       /// </summary>
       /// <param name="Population">入样总体表</param>
       /// <param name="SampleTable">抽样表</param>
       /// <param name="i_samplesNum">扩充样本量</param>
       /// <param name="ZoneNum">分层</param>
       /// <param name="Basis">抽样依据</param>
       /// <returns>扩充后得到的样本表</returns>
       public DataTable ExtendSample(DataTable Population, DataTable SampleTable, int i_samplesNum,string ZoneNum, string Basis)
       {
           DataTable ExtendSamples = new DataTable();
           DataTable Extend=new DataTable ();
           //添加列名
           if (!Population.Columns.Contains(_expand))
           {
               DataColumn dc = new DataColumn(_expand, Type.GetType("System.Int32"));
               dc.DefaultValue = 0;
               Population.Columns.Add(dc);
           }
           if (!SampleTable.Columns.Contains(_expand))
           {
               DataColumn dc = new DataColumn(_expand, Type.GetType("System.Int32"));
               dc.DefaultValue = 0;
               SampleTable.Columns.Add(dc);
           }
           if(Population.Columns.Count ==SampleTable.Columns .Count)
           {
               for (int i=0;i<Population.Columns.Count;i++)
               {
                   if(Population.Columns[i].ColumnName==SampleTable.Columns[i].ColumnName)
                   {
                       Extend.Columns .Add (Population.Columns[i].ColumnName);//添加列名 
                   }
                   else return null;
               }
               IEnumerable<DataRow> query2 = Population.AsEnumerable().Except(SampleTable.AsEnumerable(), DataRowComparer.Default);//差集
               Extend = query2.CopyToDataTable();
               ExtendSamples = StratifiedPPSSampling(Extend, i_samplesNum, ZoneNum, Basis);

                //将扩充的抽样的样本与第一次抽样的样本合并
               foreach (DataRow row in ExtendSamples.Rows) 
               {
                   row[_expand] = 1;
                   SampleTable.ImportRow(row);
               }
               //for (int i = 0; i < SampleTable.Columns.Count; i++)
               //{
               //    var s = SampleTable.Columns[i].ColumnName;
               //}
           }        
           return SampleTable;
       } 
       /// <summary>
       /// 创建shp文件
       /// </summary>
       /// <param name="shpPath">入样总体文件</param>
       /// <param name="SampleTable">抽样样本表</param>
       /// <param name="sampleFile">生成样本shp</param>
       /// <returns>是否创建成功</returns>
       public bool CreateShpFile(string shpPath, DataTable SampleTable, string sampleFile)
       {
           bool result = true;
           IWorkspaceFactory2 workspaceFactory = null;
           IWorkspace workspace = null;
           IFeatureClass allVillage = null;
           ISpatialReference spatialReference = null;
           IFeatureClass sampleClass = null;
           try
           {
               //获取入样总体的坐标信息
               allVillage = EngineAPI.OpenFeatureClass(shpPath);
               spatialReference = (allVillage as IGeoDataset).SpatialReference;

               //ISpatialReference spatialReference = pGeoDataset.SpatialReference;

               FileInfo info = new FileInfo(sampleFile);
               string directory = info.DirectoryName;
               string name = info.Name.Substring(0, info.Name.Length - info.Extension.Length);
               if (!Directory.Exists(directory))
               {
                   Directory.CreateDirectory(directory);
               }
               workspaceFactory = new ShapefileWorkspaceFactoryClass();
               workspace = workspaceFactory.OpenFromFile(directory, 0);

               if (workspace == null)
               {
                   result = false;
               }
               else
               {
                   if (EngineAPI.IsNameExist(workspace, name, esriDatasetType.esriDTFeatureClass))
                   {
                       EngineAPI.DeleteDataset(workspace, name, esriDatasetType.esriDTFeatureClass);
                   }
                   
                   IFields requiredFields = allVillage.Fields;
                   if (requiredFields == null)
                       result = false;
                   sampleClass = CreateFeatureClass(workspace, name, requiredFields, spatialReference);
                   //添加字段
                   AddFields(sampleClass, _expand);
                   if (sampleClass == null)
                       result = false;

                   //添加要素
                   IFeatureCursor pFeaCur = sampleClass.Insert(true);
                   IFeatureBuffer pFeaBuf = null;
                   IFeature pFeature = null;
                   for (int i = 0; i < SampleTable.Rows.Count; i++)
                   {
                       pFeature = allVillage.GetFeature(Convert.ToInt32(SampleTable.Rows[i][0]));
                       pFeaBuf = sampleClass.CreateFeatureBuffer();
                       pFeaBuf.Shape = pFeature.ShapeCopy;
                       
                       //添加字段值
                       for (int j = 2; j < requiredFields.FieldCount; j++)
                       {
                           pFeaBuf.set_Value(j, SampleTable.Rows[i][j]);
                           //IField pField = requiredFields.get_Field(j);
                           //int iIndex = pFeaBuf.Fields.FindField(pField.Name);
                           //if (iIndex != -1)
                           //{
                           //    pFeaBuf.set_Value(iIndex, SampleTable.Rows [i][j]);
                           //}
                       }
                       int fIndex = pFeaBuf.Fields.FindField(_expand);
                       if (fIndex > 0 && SampleTable.Columns.Contains(_expand))
                           pFeaBuf.set_Value(fIndex, SampleTable.Rows[i][_expand]);

                       pFeaCur.InsertFeature(pFeaBuf);
                   }
                 
                   //保存要素
                   pFeaCur.Flush();
                   System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeaCur);
                   System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeaBuf);
                   System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeature);
                   
               }
               ////删除添加的字段
               //IFields fields = allVillage.Fields;
               //IField field = fields.get_Field(fields.FindField(_expand));
               //allVillage.DeleteField(field);
               return result;
           }
           catch (Exception ex)
           {
               XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               Log.WriteLog(typeof(SampleSimulation), ex);
               return result;
           }
           finally
           {
               if (sampleClass != null)
                   Marshal.ReleaseComObject(sampleClass);
               if (spatialReference != null)
                   Marshal.ReleaseComObject(spatialReference);
               if (allVillage != null)
                   Marshal.ReleaseComObject(allVillage);
               if (workspace != null)
                   Marshal.ReleaseComObject(workspace);
               if (workspaceFactory != null)
                   Marshal.ReleaseComObject(workspaceFactory);
           }
       }
       
       /// <summary>
       /// 创建要素类
       /// </summary>
       /// <param name="workspace"></param>
       /// <param name="sName"></param>
       /// <param name="fields"></param>
       /// <param name="spatialRef"></param>
       /// <param name="geoType"></param>
       /// <returns></returns>
       public static IFeatureClass CreateFeatureClass(IWorkspace workspace, string sName, IFields fields, ISpatialReference spatialRef)
       {
           return MapAPI.CreateFeatureClass(workspace, sName, fields, spatialRef, esriGeometryType.esriGeometryPolygon);
       }
       public void AddFields(IFeatureClass pFc, string fieldName)
       {
           try
           {
               int theField = pFc.Fields.FindField(fieldName);
               if (theField == -1)
               {
                   IField pField = new FieldClass();
                   IFieldEdit pFieldEdit = pField as IFieldEdit;
                   pFieldEdit.Name_2 = fieldName;
                   pFieldEdit.Type_2 = esriFieldType.esriFieldTypeSmallInteger;
                   pFieldEdit.AliasName_2 = fieldName;
                   pFc.AddField(pFieldEdit);
               }
               else
               {
                   return ;
               }
           }
           catch (Exception ex)
           {
               XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               Log.WriteLog(typeof(SampleSimulation), ex);
           }
       }
       public void Update(IFeatureClass pFc, string fieldName,DataRow extendRow)
       {
          
           ITable ptable = pFc as ITable;
           for (int j = 0; j < ptable.RowCount(null); j++)
           {
               int d = ptable.GetRow(j).OID;
                if (ptable.GetRow(j).OID ==Convert .ToInt32(extendRow[0]))
                {
                    IFeature pFeature = pFc.GetFeature(j);
                    pFeature.set_Value(pFeature.Fields.FindField(_expand), "1");   //每个要素的“A”字段存储的都是“B”。
                    pFeature.Store();   
                }
           }      
       }
      
   }
}
