using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Xerxes.NoHandsUp.Model.PupilDataConfig
{
    public class PupilDataConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PupilDataConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PupilDataConfigElement)element).ClassName;
        }
    }
}
