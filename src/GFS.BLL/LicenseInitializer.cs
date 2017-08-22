// Copyright 2013 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at <your ArcGIS install location>/DeveloperKit10.2/userestrictions.txt.
// 

using System;
using ESRI.ArcGIS;

namespace GFS.BLL
{
  public partial class LicenseInitializer
  {
    public LicenseInitializer()
    {
      ResolveBindingEvent += new EventHandler(BindingArcGISRuntime);
    }

    void BindingArcGISRuntime(object sender, EventArgs e)
    {
      //
      // TODO: Modify ArcGIS runtime binding code as needed; for example, 
      // the list of products and their binding preference order.
      //
      ProductCode[] supportedRuntimes = new ProductCode[] { 
        ProductCode.Desktop};
      foreach (ProductCode c in supportedRuntimes)
      {
        if (RuntimeManager.Bind(c))
          return;
      }

      //
      // TODO: Modify the code below on how to handle bind failure
      //

      // Failed to bind, announce and force exit
      Console.WriteLine("ArcGIS runtime binding failed. Application will shut down.");
      System.Environment.Exit(0);
    }
  }
}