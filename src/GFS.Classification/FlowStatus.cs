// ***********************************************************************
// Assembly         : GFS.Classification
// Author           : Ricker Yan
// Created          : 08-17-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-14-2017
// ***********************************************************************
// <copyright file="FlowStatus.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>enum of flow status</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFS.Classification
{
    public enum FlowStatus
    { Start, btnPrepare, btnSample, btnSingleDate, btnAfter, btnVerification, End }

    public enum TaskState
    { Create = 0 ,DataPrepare = 1,Production = 2,ProductArchiving = 3,Cancel = -1}
}
