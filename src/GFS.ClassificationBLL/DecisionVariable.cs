// ***********************************************************************
// Assembly         : GFS.ClassificationBLL
// Author           : Ricker Yan
// Created          : 09-01-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 09-01-2017
// ***********************************************************************
// <copyright file="DecisionVariable.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>决策变量类（已弃用）</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFS.ClassificationBLL
{
    public class DecisionVariable
    {
        public string variableName;
        public string fileName;
        public int bandIndex=-1;
        public DecisionVariable()
        { }
        public DecisionVariable(string variable,string file,int bandIndex)
        {
            this.variableName = variable;
            this.fileName = file;
            this.bandIndex = bandIndex;
        }
        public DecisionVariable(string variable)
        {
            this.variableName = variable; 
        }
    }
}
