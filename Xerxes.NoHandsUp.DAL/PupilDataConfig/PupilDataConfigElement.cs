using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Xerxes.NoHandsUp.Model.PupilDataConfig
{
    public class PupilDataConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("className", IsRequired = true, IsKey = true)]
        public string ClassName 
        {
            get
            {
                return (string)this["className"];
            }
        }

        [ConfigurationProperty("fileName", IsRequired = true)]
        public string FileName
        {
            get
            {
                return (string)this["fileName"];
            }
        }
    }
}
