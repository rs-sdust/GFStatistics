using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GFS.SampleBLL
{

    public class AutoLayer
    {
        private struct Range          //区间
        {
            public double Max;
            public double Min;
        }
        /// <summary>
        /// 最优分层算法
        /// </summary>
        /// Population     入样总体
        /// ZoneIndex      分层指标字段名称
        /// i_ZoneCount    分层数
        /// <returns>总体分层</returns>
        public DataTable OptimalStratifying(DataTable Population, string ZoneIndex, int i_ZoneCount)
        {
            //DataTable Samples = Population.Copy();
            DataTable Samples = Population;     //直接操作源表减少内存占用
            string layerField = "FCBH";
            if (!Samples.Columns.Contains(layerField))
                Samples.Columns.Add(layerField, typeof(int));
            //获取分层指标的最大值、最小值
            double d_IndexMax = Population.AsEnumerable().Select(t => t.Field<double>(ZoneIndex)).Max();
            double d_IndexMin = Population.AsEnumerable().Select(t => t.Field<double>(ZoneIndex)).Min();
            //设定步长i_StepSize，计算区间数量i_RangeCount
            double i_StepSize = d_IndexMax * 0.0005;
            double d_count = (d_IndexMax - d_IndexMin) / i_StepSize;
            int i_count = (int)Math.Ceiling(d_count);
            int i_RangeCount;
            if (d_count == i_count)
                i_RangeCount = i_count + 1;
            else
                i_RangeCount = i_count;
            //划分步长区间ranges[]
            Range[] ranges = new Range[i_RangeCount];
            ranges[0].Min = d_IndexMin;
            ranges[0].Max = ranges[0].Min + i_StepSize;
            for (int i = 1; i < i_RangeCount - 1; i++)
            {
                ranges[i].Min = ranges[i - 1].Max;
                ranges[i].Max = ranges[i].Min + i_StepSize;
            }
            ranges[i_RangeCount - 1].Min = ranges[i_RangeCount - 2].Max;
            ranges[i_RangeCount - 1].Max = double.MaxValue;
            //计算每个区间内【入样总体】.【分层指标】出现的频率d_Frequency
            double[] d_Frequency = new double[i_RangeCount];//频率
            for (int index = 0; index < i_RangeCount; index++)
            {
                int i_FreCount = 0;
                for (int i = 0; i < Population.Rows.Count; i++)
                {
                    double d_temp = Convert.ToDouble(Population.Rows[i][ZoneIndex]);
                    if (ranges[index].Min <= d_temp && ranges[index].Max > d_temp)
                        i_FreCount++;
                }
                d_Frequency[index] = Convert.ToDouble(i_FreCount) / Convert.ToDouble(Population.Rows.Count);
            }
            //计算频率平方根的累加和
            double[] d_Cumulant = new double[i_RangeCount];
            d_Cumulant[0] = Math.Sqrt(d_Frequency[0]);
            for (int i = 1; i < i_RangeCount; i++)
                d_Cumulant[i] = d_Cumulant[i - 1] + Math.Sqrt(d_Frequency[i]);
            double d_Step = d_Cumulant[i_RangeCount - 1] / Convert.ToDouble(i_ZoneCount);
            //进行分层
            Range[] zoneRanges = new Range[i_ZoneCount];
            zoneRanges[0].Min = ranges[0].Min;
            for (int zone_i = 0; zone_i < i_ZoneCount - 1; zone_i++)
            {
                double d_temp = d_Step * (zone_i + 1);
                for (int i = 1; i < i_RangeCount; i++)
                {
                    if (d_Cumulant[i] >= d_temp)
                    {
                        if ((d_Cumulant[i] - d_temp) >= (d_temp - d_Cumulant[i - 1]))
                        {
                            zoneRanges[zone_i].Max = ranges[i - 1].Max;
                            zoneRanges[zone_i + 1].Min = ranges[i].Min;
                        }
                        else
                        {
                            zoneRanges[zone_i].Max = ranges[i].Max;
                            zoneRanges[zone_i + 1].Min = ranges[i + 1].Min;
                        }
                        break;
                    }
                }
            }
            zoneRanges[i_ZoneCount - 1].Max = double.MaxValue;
            //生成分层字段
            for (int index = 0; index < i_ZoneCount; index++)
                for (int i = 0; i < Population.Rows.Count; i++)
                {
                    double d_temp = Convert.ToDouble(Population.Rows[i][ZoneIndex]);
                    if (zoneRanges[index].Min <= d_temp && zoneRanges[index].Max > d_temp)
                        Samples.Rows[i][layerField] = index + 1;
                }
            return Samples;
        }
    }
}
