using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Data;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using GFS.BLL;
using GFS.Common;
//using NPOI.HSSF.UserModel;
//using NPOI.XSSF.UserModel;
//using ESRI.ArcGIS.Carto;
//using NPOI.SS.UserModel;
//using ModelSystem;

namespace GFS.SampleBLL
{
   public  class SampleAduit
    {

       private int fUnitNum = 0;
       private int SampleNum = 0;
       private double unitLandArea = 0;
       private double unitClassArea = 0;
       private double sampleLandArea = 0;
       private double sampleClassArea = 0;
       private double sampleSurveyArea = 0;
       private double coefficient = 0;
        public void RemoveRow(DataTable dTable, object  Num)
        {
           
            int rows = dTable.Rows.Count;
            DataRow[] foundRow1 = new DataRow[rows];
            foundRow1 = dTable.Select();
            DataRow[] foundRow = new DataRow[rows];
            var SelectRow = dTable.Columns[0].ColumnName + " = "+Num;

            foundRow = dTable.Select(SelectRow);
            foreach (DataRow row in foundRow)
            {
                dTable.Rows.Remove(row);
            }
        }
       /// <summary>
       /// 删除要素
       /// </summary>
       /// <param name="shpFile"></param>
       /// <param name="Rowsname"></param>
       /// <returns></returns>
        public  bool DeleFeature(string shpFile, string Rowsname)
        {
            bool result;
            IFeatureClass allVillage = null;
            try
            {
                string fieldName = Rowsname.Substring(0, Rowsname.IndexOf("="));
                allVillage = EngineAPI.OpenFeatureClass(shpFile);
                //属性查询
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = Rowsname;
                //
                IFeatureCursor updateCursor = allVillage.Update(queryFilter ,false );
                IFeature feature = updateCursor.NextFeature();
                int m = 0;
                while (feature != null)
                {
                    m++;
                    updateCursor.DeleteFeature();
                    feature = updateCursor.NextFeature();
                }
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示信息");
                result = false;
            }
            return result;
        }

        public bool DeleFeature(IFeatureClass allVillage, string Rowsname)
        {
            bool result;
            try
            {
                //属性查询
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = Rowsname;
                //
                IFeatureCursor updateCursor = allVillage.Update(queryFilter, false);
                IFeature feature = updateCursor.NextFeature();
                int m = 0;
                while (feature != null)
                {
                    m++;
                    updateCursor.DeleteFeature();
                    feature = updateCursor.NextFeature();
                }
                
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息");
                result = false;
            }
            return result;
        }
       //分层比率估计
        /// <summary>
        /// 比率估计预处理（读写文件）
        /// </summary>
        /// PopulationPath      入样总体文件地址
        /// SamplesPath         抽样样本文件地址
        /// FieldName           测量结果字段名称
        /// Layer_Population    入样总体的层号
        /// Layer_Samples       抽样样本的层号
        /// Classify_Population 入样总体的分类结果
        /// Classify_Samples    抽样样本的分类结果
        /// SavePath            推算结果保存地址
        /// <returns>是否计算成功</returns>
        public bool RatioPreprocessing(string PopulationPath, string SamplesPath, string FieldName, string Layer_Population, string Layer_Samples,
                                       string Classify_Population, string Classify_Samples, string SavePath,string Sample_Basis)
        {
            try
            {
            DataTable Population = new DataTable ();
            DataTable Samples = new DataTable () ;

            IFeatureClass PopuIFeaClass = EngineAPI.OpenFeatureClass(PopulationPath);
            IFeatureClass SamIFeaClass = EngineAPI.OpenFeatureClass(SamplesPath);
            ITableConversion conver = new TableConversion();
            Population = conver.AETableToDataTable(PopuIFeaClass);
            Samples = conver.AETableToDataTable(SamIFeaClass);
            //比率估计计算
            if (Population == null || Samples == null || FieldName == ""
                || Layer_Population == "" || Layer_Samples == ""
                || Classify_Population == "" || Classify_Samples == ""
                || SavePath == "" || Sample_Basis=="")
                return false;
            fUnitNum = Population.Rows.Count;
            SampleNum = Samples.Rows.Count;
            unitLandArea =  double .Parse(Population.Compute(string.Format("sum({0})", Sample_Basis), "true").ToString())/666.67;
            unitClassArea = double.Parse(Population.Compute(string.Format("sum({0})", Classify_Population), "true").ToString()) / 666.67;
            sampleLandArea = double.Parse(Samples.Compute(string.Format("sum({0})", Sample_Basis), "true").ToString()) / 666.67;
            sampleClassArea = double.Parse(Samples.Compute(string.Format("sum({0})", Classify_Samples), "true").ToString()) / 666.67;
            sampleSurveyArea = double.Parse(Samples.Compute(string.Format("sum({0})", FieldName), "true").ToString()) / 666.67;
            double CV = 0;
            double d_result = RatioEstimating(Population, Samples, FieldName, Layer_Population, Layer_Samples, Classify_Population, Classify_Samples, Sample_Basis,ref CV)/666.667;
            //保存推算结果至EXCl
                string p0 = "        面积估算结果";
                string p1 = "估算方法：分层比率估计    ";
                string p2 = string.Format("估算面积：{0} 亩    CV值：{1}",d_result.ToString( "#0.00"),CV);
                string p3 = string.Format("一级抽样单元总数：{0}    样方总数：{1}",fUnitNum,SampleNum);
                //string p4 = string.Format("区域耕地总面积：{0} 亩    区域分类总面积：{1} 亩", unitLandArea.ToString("#0.00"), unitClassArea.ToString("#0.00"));
                string p5 = string.Format("二级样方总耕地面积：{0} 亩    二级样方总分类面积：{1} 亩    二级样方总调查面积：{2} 亩", 
                    sampleLandArea.ToString("#0.00"), sampleClassArea.ToString("#0.00"), sampleSurveyArea.ToString("#0.00"));
                string p6 = string.Format("分类面积与调查面积相关系数：{0}",coefficient);;
                List<string> list = new List<string>() { p0,p1,p2,p3,p5,p6};

                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(SavePath, true))
                {
                    foreach (string line in list)
                    {
                        file.WriteLine(line);// 直接追加文件末尾，换行 
                        file.WriteLine();
                    }
                    file.Flush();
                    file.Close();
                    return true;
                }
                //DataTable ptable = new DataTable();
                //ptable.Columns.Add ( "估算总面积",typeof(double));
                //ptable.Columns.Add("CV值", typeof(double));
                //ptable.Rows.Add();
                //DataRow dr = ptable.NewRow();
                //dr[0] = d_result;
                //dr[1] = CV;
                //ptable.Rows.Add(dr);
                //if (ptable == null)
                //    return false;
                //ExcelHelper excel = new ExcelHelper();
                //if (excel.DataTableToExcel(SavePath, "sheet1", ptable, true))
                //{
                //    MessageBox.Show("成功");
                //    return true;
                //}
                //else
                //{
                //    MessageBox.Show("失败");
                //    return false ;
                //}              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 比率估计算法
        /// </summary>
        /// Population          入样总体
        /// Samples             抽样样本
        /// Sample_Survey       测量结果字段名称
        /// Layer_Population    入样总体的层号
        /// Layer_Samples       抽样样本的层号
        /// Classify_Population 入样总体的分类结果
        /// Classify_Samples    抽样样本的分类结果
        /// Sample_Basis        抽样样本的耕地结果
        /// CV                  精度评价 CV值
        /// <returns>推算结果</returns>
        /// <summary>      
        private double RatioEstimating(DataTable Population, DataTable Samples, string Sample_Survey, string Layer_Population, string Layer_Samples, string Classify_Population, string Classify_Samples, string Sample_Basis,ref double CV)
        {
            //1.	计算所有【层号集】，即查出共有几层i_ZoneCount
            List<double> zones = new List<double>();
            for (int i = 0; i < Population.Rows.Count; i++)
            {
                double i_temp = Convert.ToDouble(Population.Rows[i][Layer_Population]);
                if (!zones.Contains(i_temp))
                    zones.Add(i_temp);
            }
            int i_ZoneCount = zones.Count;
            if (i_ZoneCount == 0)//没有分层
                return 0;
            //2.	获取第i层记录
            DataTable[] ZoneIPopu = new DataTable[i_ZoneCount];
            DataTable[] ZoneISamp = new DataTable[i_ZoneCount];
            for (int i = 0; i < i_ZoneCount; i++)
            {
                ZoneIPopu[i] = Population.Clone();
                ZoneISamp[i] = Samples.Clone();
            }
            //ZoneIPopu[i]为入样总体的第i层记录
            for (int i = 0; i < Population.Rows.Count; i++)
            {
                double i_temp = Convert.ToDouble(Population.Rows[i][Layer_Population]);
                DataRow drss = Population.Rows[i];
                int index = zones.FindIndex(item => item == i_temp);
                ZoneIPopu[index].Rows.Add(drss.ItemArray);
            }
            //ZoneISamp[i]为样本的第i层记录
            for (int i = 0; i < Samples.Rows.Count; i++)
            {
                double i_temp = Convert.ToDouble(Samples.Rows[i][Layer_Samples]);
                DataRow drss = Samples.Rows[i];
                int index = zones.FindIndex(item => item == i_temp);
                ZoneISamp[index].Rows.Add(drss.ItemArray);
            }
            //3.	计算第i层推算结果
            double[] d_IResult = new double[i_ZoneCount];
            for (int i = 0; i < i_ZoneCount; i++)
            {
                //第i层样本的测量结果和∑【样本i】.【测量结果】
                double MeasureSum = 0;
                //第i层样本的分类结果和∑【样本i】.【样本分类结果】
                double ClassSampSum = 0;
                for (int j = 0; j < ZoneISamp[i].Rows.Count; ++j)
                {
                    MeasureSum = MeasureSum + Convert.ToDouble(ZoneISamp[i].Rows[j][Sample_Survey]);
                    ClassSampSum = ClassSampSum + Convert.ToDouble(ZoneISamp[i].Rows[j][Classify_Samples]);
                }
                //第i层入样总体的分类结果和∑【入样总体i】.【总体分类结果】
                double ClassPopuSum = 0;
                for (int j = 0; j < ZoneIPopu[i].Rows.Count; ++j)
                    ClassPopuSum = ClassPopuSum + Convert.ToDouble(ZoneIPopu[i].Rows[j][Classify_Population]);
                //第i层推算结果
                if (ClassSampSum != 0)
                    d_IResult[i] = MeasureSum / ClassSampSum * ClassPopuSum;
                else
                    d_IResult[i] = MeasureSum / ZoneISamp[i].Rows.Count * ZoneIPopu[i].Rows.Count;
            }
            //4.	计算【推算结果】
            double d_result = 0;
            for (int i = 0; i < i_ZoneCount; i++)
                d_result = d_result + d_IResult[i];
            //5.     计算CV

            double V_Yr = 0;//估算面积值的方差
            //精度评价CV计算
            //List<double> f = new List<double>();
            //List<double> Nh_Num = new List<double>();
          
            for (int i = 0; i < i_ZoneCount; i++)
            {
                double f = 0;
                int  Nh_Num = 0;
                for (int j = 0; j < i_ZoneCount; j++)
                {
                    if (Convert.ToInt32(ZoneISamp[i].Rows[0][Layer_Samples]) == Convert.ToInt32(ZoneIPopu[j].Rows[0][Layer_Population]))
                    {
                        int Num = ZoneISamp[i].AsEnumerable().Select(t => t.Field<string>("XZQDM")).Distinct().Count();//i层含有的村的总个数
                        f = (Num * 1.0F) / (ZoneISamp[j].Rows.Count * 1.0F);
                        Nh_Num=ZoneIPopu[j].Rows.Count;
                    }
                }
                double[] arrSample_Basis = ZoneISamp[i].AsEnumerable().Select(d => d.Field<double>(Sample_Basis)).ToArray();
                double[] arrSample_Survey = ZoneISamp[i].AsEnumerable().Select(d => d.Field<double>(Sample_Survey)).ToArray();
                double[] arrSample_Classic = ZoneISamp[i].AsEnumerable().Select(d => d.Field<double>(Classify_Samples)).ToArray();
                int Nh = ZoneISamp[i].Rows.Count;// 是h层的样本数量
                double Sxh = CalculateStdDev(arrSample_Basis);//h层的样本遥感值的标准差
                double Syh = CalculateStdDev(arrSample_Survey);//h层的样本调查值的标准差
                double Rh = arrSample_Survey.Sum() / arrSample_Basis.Sum();//h层样本调查值与耕地面积的比例
                double Ph = correl(arrSample_Classic, arrSample_Survey);
                //coefficient = Ph;
                // Syh是h层样本调查值的方差
                V_Yr += Math.Pow(Nh_Num, 2) * (1 - f) / Nh * (Math.Pow(Syh, 2) + Math.Pow(Sxh, 2) * Math.Pow(Rh, 2) - 2 * Rh * Syh * Sxh * Ph);
            }
            //精度评价 
            CV = Math.Sqrt(V_Yr) / d_result;
            return d_result;
        }
        //基于抽样概率估计，新
     /// <summary>
     /// 
     /// </summary>
     /// <param name="Popu_File">入样总体</param>
     /// <param name="Sample_File">二级样本</param>
     /// <param name="Popu_Basis">总体耕地</param>
     /// <param name="Popu_Layer">总体分层</param>
     /// <param name="Sample_Layer">样本分层</param>
     /// <param name="Sample_Basis">样本耕地</param>
     /// <param name="Sample_Survey">样本调查面积</param>
     /// <param name="Sample_CunCode">村代码</param>
     /// <param name="Save_File">保存文件</param>
     /// <returns></returns>
        public bool ProbabilityProcessing(string Popu_File, string Sample_File, string Popu_Basis, string Popu_Layer, string Sample_Layer, string Sample_Basis, string Sample_Survey, string Sample_CunCode, string Save_File)
        {
            try
            {
            DataTable Population = new DataTable();
            DataTable Samples = new DataTable();

            IFeatureClass allVillage = EngineAPI.OpenFeatureClass(Popu_File);
            IFeatureClass allVillage1 = EngineAPI.OpenFeatureClass(Sample_File);
            ITableConversion conver = new TableConversion();
            Population = conver.AETableToDataTable(allVillage);
            Samples = conver.AETableToDataTable(allVillage1);
            
            //概率估计计算
            if (Population == null || Samples == null || Popu_Basis == "" || Popu_Layer == "" || Sample_Layer == ""
                || Sample_Basis == "" || Sample_Survey == "" || Sample_CunCode==""|| Save_File == "" )
                return false;

            fUnitNum = Population.Rows.Count;
            SampleNum = Samples.Rows.Count;
            unitLandArea = double.Parse(Population.Compute(string.Format("sum({0})", Sample_Basis), "true").ToString()) / 666.67;
            //unitClassArea = double.Parse(Population.Compute(string.Format("sum({0})", Sample_CunCode), "true").ToString()) / 666.67;
            sampleLandArea = double.Parse(Samples.Compute(string.Format("sum({0})", Sample_Basis), "true").ToString()) / 666.67;
            //sampleClassArea = double.Parse(Samples.Compute(string.Format("sum({0})", Sample_CunCode), "true").ToString());
            sampleSurveyArea = double.Parse(Samples.Compute(string.Format("sum({0})", Sample_Survey), "true").ToString()) / 666.67;

            double CV = 0;
            double M_Area = 0;
            if (SampleProbability(Population, Samples, Popu_Basis, Popu_Layer, Sample_Layer, Sample_Basis, Sample_Survey, Sample_CunCode, ref M_Area, ref  CV))
            {
                //保存推算结果至EXCl
                string p0 = "        面积估算结果";
                string p1 = "估算方法：基于入样概率估计    ";
                string p2 = string.Format("估算面积：{0} 亩    CV值：{1}", (M_Area/666.667).ToString("#0.00"), CV);
                string p3 = string.Format("一级抽样单元总数：{0}    样方总数：{1}", fUnitNum, SampleNum);
                //string p4 = string.Format("区域耕地总面积：{0} 亩    ", unitLandArea.ToString("#0.00"));
                string p5 = string.Format("二级样方总耕地面积：{0} 亩    二级样方总调查面积：{1} 亩",
                    sampleLandArea.ToString("#0.00"), sampleSurveyArea.ToString("#0.00"));
                string p6 = string.Format("耕地面积与调查面积相关系数：{0}", coefficient); ;
                List<string> list = new List<string>() { p0, p1, p2, p3, p5, p6 };

                if (File.Exists(Save_File))
                {
                    File.Delete(Save_File);
                }
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Save_File, true))
                    {
                        foreach (string line in list)
                        { 
                            file.WriteLine(line);// 直接追加文件末尾，换行 
                            file.WriteLine();
                        }
                        file.Flush();
                        file.Close();
                        return true;
                    }
                    //DataTable ptable = new DataTable();
                    //ptable.Columns.Add ( "估算总面积",typeof(double));
                    //ptable.Columns.Add("CV值", typeof(double));
                    //ptable.Rows.Add();
                    //DataRow dr = ptable.NewRow();
                    //dr[0] = M_Area;
                    //dr[1] = CV;
                    //ptable.Rows.Add(dr);
                    //if (ptable == null)
                    //    return false;
                    //ExcelHelper excel = new ExcelHelper();
                    //if (excel.DataTableToExcel(Save_File, "sheet1", ptable, true))
                    //{
                    //    MessageBox.Show("成功");
                    //    return true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("失败");
                    //    return false ;
                    //} 

            }
            else 
            return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
       /// <summary>
       /// 抽样概率估计算法
       /// </summary>
       /// <param name="Popu_Table">入样总体表</param>
       /// <param name="Sample_Table">样本表</param>
       /// <param name="Popu_Basis">总体耕地</param>
       /// <param name="Popu_Layer">总体分层</param>
       /// <param name="Sample_Layer">样本分层</param>
       /// <param name="Sample_Basis">样本耕地</param>
       /// <param name="Sample_Survey">样本调查</param>
       /// <param name="Sample_CunCode">村代码</param>
       /// <param name="M_ratioArea">估计总面积</param>
       /// <param name="CV">精度评价CV值</param>
       /// <returns></returns>
        public bool SampleProbability(DataTable Popu_Table, DataTable Sample_Table, string Popu_Basis, string Popu_Layer, string Sample_Layer, string Sample_Basis, string Sample_Survey, string Sample_CunCode,
                                       ref double M_ratioArea, ref double CV)
        {
            bool result;
            try
            {           
                //入样总体样本村数
                int Popu_Sum = Popu_Table.Rows.Count;
                //得出:总体分层的层数Popu_ZoneCount、各层的样本量Popu_ZoneSamplesNum[]、按分层整合的记录ZonePopu[]
                int Popu_ZoneCount = 0;//层数
                int[] Popu_ZoneSamplesNum = null;
                DataTable[] Popu_ZoneSample = SampleSimulation.GetStratifiedSamples(Popu_Table, Popu_Sum, Popu_Layer, ref  Popu_ZoneCount, ref  Popu_ZoneSamplesNum);
                //二级样本的总个数
                int Sample_Sum = Sample_Table.Rows.Count;
                //得出:总体分层的层数Sample_ZoneCount、各层的样本量Sample_ZoneSamplesNum[]、按分层整合的记录ZonePopu[]
                int Sample_ZoneCount = 0;//层数
                int[] Sample_ZoneSamplesNum = null;
                DataTable[] Sam_ZoneSample = SampleSimulation.GetStratifiedSamples(Sample_Table, Sample_Sum, Sample_Layer, ref  Sample_ZoneCount, ref  Sample_ZoneSamplesNum);
                List<double> f = new List<double>();
                List<double> Nh_Num = new List<double>();
                //总面积估计计算
                M_ratioArea = 0;//总面积
                double V_Yr = 0;//估算面积值的方差
                for (int i = 0; i < Sample_ZoneCount; i++)
                {
                    for (int j = 0; j < Popu_ZoneCount; j++)
                    {
                        if (Convert .ToInt32( Sam_ZoneSample[i].Rows[0][Sample_Layer]) == Convert .ToInt32( Popu_ZoneSample[j].Rows[0][Popu_Layer]))
                        {

                            double Mj_BasisArea = Popu_ZoneSample[j].AsEnumerable().Select(t => t.Field<double>(Popu_Basis)).Sum();//j层抽样单元村耕地总面积
                            double M_AreaRotio = Ratio(Sam_ZoneSample[i], Sample_CunCode, Sample_Basis, Sample_Survey);//i层二级样本村计算调查面积与耕地面积的比值和
                            M_ratioArea += M_AreaRotio * Mj_BasisArea / Popu_ZoneSample[j].Rows.Count;
                            int Num = Sam_ZoneSample[i].AsEnumerable().Select(t => t.Field<string>(Sample_CunCode)).Distinct().Count();//i层含有的村的总个数
                            double fi =(Num*1.0F) / (Popu_ZoneSample[j].Rows.Count*1.0F);
                            f.Add(fi);
                            Nh_Num.Add(Popu_ZoneSample[j].Rows.Count);
                        }
                    }
                    //精度评价CV计算
                    double[] arrSample_Basis = Sam_ZoneSample[i].AsEnumerable().Select(d => d.Field<double>(Sample_Basis)).ToArray();
                    double[] arrSample_Survey = Sam_ZoneSample[i].AsEnumerable().Select(d => d.Field<double>(Sample_Survey)).ToArray();
                    //double[] arrSample_Classic = Sam_ZoneSample[i].AsEnumerable().Select(d => d.Field<double>(Sample_classic)).ToArray();
                    int Nh = Sam_ZoneSample[i].Rows.Count;// 是h层的样本数量
                    double Sxh = CalculateStdDev(arrSample_Basis);//h层的样本遥感值的标准差
                    double Syh = CalculateStdDev(arrSample_Survey);//h层的样本调查值的标准差
                    double Rh = arrSample_Survey.Sum() / arrSample_Basis.Sum();//h层样本调查值与耕地面积的比例
                    double Ph = correl(arrSample_Basis, arrSample_Survey);//耕地面积与调查面积的相关系数
                    // Syh是h层样本调查值的方差
                    V_Yr += Math.Pow(Nh_Num[i], 2) * (1 - f[i]) / Nh * (Math.Pow(Syh, 2) + Math.Pow(Sxh, 2) * Math.Pow(Rh, 2) - 2 * Rh * Syh * Sxh * Ph);
              
                }
                //精度评价 
                CV = Math.Sqrt(V_Yr) / M_ratioArea;
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            return result;
        }
       /// <summary>
       /// 计算相关系数
       /// </summary>
       /// <param name="array1"></param>
       /// <param name="array2"></param>
       /// <returns></returns>
        private  double correl(double[] array1, double[] array2)
        {
            double avg1 = array1.Average();
            double stdev1 = CalculateStdDev(array1);
            double avg2 = array2.Average();
            double stdev2 = CalculateStdDev(array2);
            
            List <double >list=new List<double> ();
            for(int i=0;i<array1 .Length&&i<array2 .Length;i++)
            {
                list.Add ((array1[i]-avg1)*(array2[i]-avg2));   
            }
            double COV = list.Average();
            double p = 0;
            if (stdev1 > 0 && stdev2 > 0)
            {
                p = COV / (stdev1 * stdev2);
            }
            coefficient = p;
           return p;
        }
       /// <summary>
       /// 计算标准差
       /// </summary>
       /// <param name="values"></param>
       /// <returns></returns>
        private static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //  计算平均数   
                double avg = values.Average();
                //  计算各数值与平均数的差值的平方，然后求和 
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //  除以数量，然后开方
                ret = Math.Sqrt(sum / values.Count());
            }
            return ret;
        }
       /// <summary>
       /// 按村分层，计算每个村样方的总调查面积与耕地面积的比值
       /// </summary>
       /// <param name="poplution">样本</param>
       /// <param name="Layer">村代码</param>
       /// <param name="Basis_Layer">耕地面积</param>
       /// <param name="Survey_Layer">调查面积</param>
       /// <returns></returns>
        private double Ratio(DataTable poplution, string CunCode, string Basis_Layer, string Survey_Layer)
        {////Layer是村代码，按村分层，计算调查面积与耕地面积的比值
            //分层
            List<double> zones = new List<double>();
            for (int i = 0; i < poplution.Rows.Count; i++)
            {
                double i_temp = Convert.ToDouble(poplution.Rows[i][CunCode].ToString());
                if (!zones.Contains(i_temp))
                    zones.Add(i_temp);
            }
            int i_ZoneCount = zones.Count;
            //int i_ZoneCount1 = poplution.AsEnumerable().Select(t => t.Field<string>(Layer)).Distinct().Count();//层数;

            //获取第i层记录
            DataTable[] ZoneIPopu = new DataTable[i_ZoneCount];
            if (i_ZoneCount == 0)//没有分层
            {
                ZoneIPopu[0] = poplution.Copy();
            }
            for (int i = 0; i < i_ZoneCount; i++)
            {
                ZoneIPopu[i] = poplution.Clone();
            }
            //ZoneIPopu[i]为入样总体的第i层记录
            for (int i = 0; i < poplution.Rows.Count; i++)
            {
                double i_temp = Convert.ToDouble(poplution.Rows[i][CunCode]);
                DataRow drss = poplution.Rows[i];
                int index = zones.FindIndex(item => item == i_temp);
                ZoneIPopu[index].Rows.Add(drss.ItemArray);
            }
            //计算每个二级样本调查面积与每个二级样本的耕地面积的比率
            double Area_ratio = 0;
            for (int i = 0; i < i_ZoneCount; i++)
            {
                //某一列数据的和
                double Basis = ZoneIPopu[i].AsEnumerable().Select(t => t.Field<double>(Basis_Layer)).Sum();//每个二级样本的耕地面积
                double Survey = ZoneIPopu[i].AsEnumerable().Select(t => t.Field<double>(Survey_Layer)).Sum();//计算每个二级样本调查面积
                if (Survey != 0)
                {
                    Area_ratio += Survey / Basis;
                }  
            }
            return Area_ratio;
        }

    
    }
}
