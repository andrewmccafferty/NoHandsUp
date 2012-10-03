using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xerxes.NoHandsUp.Model
{
    public class ClassToXmlFileMapping : DataObject
    {
        

        public string ClassName 
        { 
            get; 
            private set; 
        }

        public string FileName { get; private set; }
        
        public ClassToXmlFileMapping(string className, string fileName)
        {
            this.ClassName = className;
            this.FileName = fileName;
        }
    }
}
