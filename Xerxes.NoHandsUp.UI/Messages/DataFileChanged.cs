using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xerxes.NoHandsUp.UI.Messages
{
    public class DataFileChanged
    {
        public string FileName { get; private set; }

        public DataFileChanged(string fileName)
        {
            this.FileName = fileName;
        }
    }
}
