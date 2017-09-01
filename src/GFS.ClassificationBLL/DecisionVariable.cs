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
