// ***********************************************************************
// Assembly         : GFS.BLL
// Author           : Ricker Yan
// Created          : 08-14-2017
//
// Last Modified By : Ricker Yan
// Last Modified On : 08-14-2017
// ***********************************************************************
// <copyright file="TaskState.cs" company="BNU">
//     Copyright (c) BNU. All rights reserved.
// </copyright>
// <summary>enum for task state</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFS.BLL
{
    public enum TaskState
    { Create = 0, DataPrepare = 1, Production = 2, ProductArchiving = 3, Cancel = -1 }
}
