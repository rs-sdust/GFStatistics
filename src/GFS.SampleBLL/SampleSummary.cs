// ***********************************************************************
// Assembly         : GFS.SampleBLL
// Author           : Ricker Yan
// Created          : 10-24-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 10-26-2017
// ***********************************************************************
// <copyright file="SampleSummary.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using GFS.Common;
using System.Data;
using GFS.BLL;
using System.Runtime.InteropServices;
using System.IO;
using ESRI.ArcGIS.Carto;

/// <summary>
/// The SampleBLL namespace.
/// </summary>
namespace GFS.SampleBLL
{
    /// <summary>
    /// Class SampleSummary.
    /// </summary>
    public class SampleSummary
    {
        /// <summary>
        /// 二级样方文件
        /// </summary>
        private IFeatureLayer _pSampleLyr;
        /// <summary>
        /// 野外调查文件
        /// </summary>
        private IFeatureLayer _pSurveyLyr;
        /// <summary>
        /// 村名字段名
        /// </summary>
        private string _fieldVillage;
        /// <summary>
        /// 样本编号字段名
        /// </summary>
        private string _fieldID;
        /// <summary>
        /// 作物类型字段名
        /// </summary>
        private string _fieldCrop;
        /// <summary>
        /// 用户选择的目标作物
        /// </summary>
        private string _cropSelected;
        /// <summary>
        /// 调查面积字段
        /// </summary>
        private string _fieldArea;
        /// <summary>
        /// 输出的 汇总样本文件
        /// </summary>
        private string _outSample;
        /// <summary>
        /// 汇总统计的唯一值字段
        /// </summary>
        private string _unque = "uniqueid";

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleSummary"/> class.
        /// </summary>
        /// <param name="sampleLyr">The sample lyr.</param>
        /// <param name="surveyLyr">The survey lyr.</param>
        /// <param name="fieldVillage">The field village.</param>
        /// <param name="fieldID">The field identifier.</param>
        /// <param name="fieldCrop">The field crop.</param>
        /// <param name="crop">The crop.</param>
        /// <param name="fieldArea">The field area.</param>
        /// <param name="outSample">The out sample.</param>
        public SampleSummary(IFeatureLayer sampleLyr, IFeatureLayer surveyLyr, string fieldVillage, string fieldID, string fieldCrop, string crop, string fieldArea, string outSample)
        {
            _pSampleLyr = sampleLyr;
            _pSurveyLyr = surveyLyr;
            _fieldVillage = fieldVillage;
            _fieldID = fieldID;
            _fieldCrop = fieldCrop;
            _cropSelected = crop;
            _fieldArea = fieldArea;
            _outSample = outSample;
        }

        /// <summary>
        /// 参数检查
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ChkPara(out string msg)
        {
            if (_pSampleLyr == null)
            {
                msg = "二级抽样框文件为空！";
                return false;
            }
            else if (_pSurveyLyr == null)
            {
                msg = "野外调查样本文件为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_fieldVillage))
            {
                msg = "村名字段为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_fieldID))
            {
                msg = "样本编号字段为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_fieldCrop))
            {
                msg = "作物类型字段为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_cropSelected))
            {
                msg = "汇总作物为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(_fieldArea))
            {
                msg = "调查面积字段为空！";
                return false;
            }
            //else if (string.IsNullOrEmpty(_outSample))
            //{
            //    msg = "输出样本文件为空！";
            //    return false;
            //}
            else
            {
                msg = "";
                return true;
            }
        }

        /// <summary>
        /// survey sample summaries .
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception">
        /// </exception>
        public bool Summary(out string msg)
        {
            if (!ChkPara(out msg))
                return false;

            IFeatureClass pSampleFC = _pSampleLyr.FeatureClass;
            IFeatureClass pSurveyFC = _pSurveyLyr.FeatureClass;
            try
            {
                //copy second sample to tempfile;
                //string tempSummary = Path.Combine(ConstDef.PATH_TEMP, DateTime.Now.ToFileTime().ToString() + ".shp");
                //CommonAPI.CopyShpFile(_sampleFile, tempSummary);

                ////open tempfile and add field
                //pOutFC = EngineAPI.OpenFeatureClass(tempSummary);
                IField newField = new FieldClass();
                IFieldEdit pFieldEdit = newField as IFieldEdit;
                pFieldEdit.Name_2 = _fieldArea;
                pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                if (pSampleFC.FindField(_fieldArea) < 0)
                    pSampleFC.AddField(newField);

                //open survey sample and summarize area
                //pFieldFC = EngineAPI.OpenFeatureClass(_fieldFile);
                TableConversion conver = new TableConversion();
                DataTable fieldDT = conver.AETableToDataTable(pSurveyFC);
                
                //remove unSelected crop
                DataRow[] rows = fieldDT.Select(_fieldCrop + " <> '" + _cropSelected + "'");
                foreach (DataRow row in rows)
                {
                    fieldDT.Rows.Remove(row);
                }

                //add unique column
                DataColumn refColum= new DataColumn(_unque,typeof(string));
                if (!fieldDT.Columns.Contains("uniqueid"))
                    fieldDT.Columns.Add(refColum);

                foreach (DataRow row in fieldDT.Rows)
                {
                    row[_unque] = row[_fieldVillage].ToString() + row[_fieldID.ToString()].ToString();
                }

                Summarize sum = new Summarize(fieldDT);
                DataTable sumDT = sum.Sum(fieldDT.Columns.IndexOf(_fieldArea), fieldDT.Columns.IndexOf(_unque));

                //set tempfile area field value
                IFeatureCursor pCursor = null;
                pCursor = pSampleFC.Update(null, false);
                IFeature pFeature = null;
                int villageIndex = pSampleFC.FindField(_fieldVillage);
                if (villageIndex < 0)
                {
                    throw new Exception(string.Format("二级样本不包含名为：{0} 的字段", _fieldVillage));
                }
                int idIndex = pSampleFC.FindField(_fieldID);
                if (idIndex < 0)
                {
                    throw new Exception(string.Format("二级样本不包含名为：{0} 的字段", _fieldID));
                }
                int areaIndex = pSampleFC.FindField(_fieldArea);
                while ((pFeature = pCursor.NextFeature()) != null)
                {                   
                    foreach (DataRow row in sumDT.Rows)
                    {
                        string unique = pFeature.get_Value(villageIndex).ToString() + pFeature.get_Value(idIndex).ToString();
                        if (unique == row[_unque].ToString())
                        {
                            pFeature.set_Value(areaIndex, row[1]);
                            pFeature.Store();
                        }
                    }
                }
                if (pCursor != null)
                    Marshal.ReleaseComObject(pCursor);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if(pOutFC!=null)
                //    Marshal.ReleaseComObject(pOutFC);
                //if (pFieldFC != null)
                //    Marshal.ReleaseComObject(pFieldFC);
            }
        }

    }
}
