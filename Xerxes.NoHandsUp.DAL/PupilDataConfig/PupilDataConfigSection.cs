using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Xerxes.NoHandsUp.Model.PupilDataConfig
{
    public class PupilDataConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("files")]
        public PupilDataConfigCollection Files
        {
            get
            {
                return (PupilDataConfigCollection)this["files"];
            }
        }

        public string GetFileForClass(string className)
        {
            string result = null;
            foreach (PupilDataConfigElement element in this.Files)
            {
                if (element.ClassName == className)
                {
                    result = element.FileName;
                    break;
                }
            }

            return result;
        }

        public IEnumerable<ClassToXmlFileMapping> GetMappings()
        {
            List<ClassToXmlFileMapping> mappings = new List<ClassToXmlFileMapping>();
            foreach (PupilDataConfigElement element in this.Files)
            {
                mappings.Add(new ClassToXmlFileMapping(element.ClassName, element.FileName));
            }
            return mappings;
        }

        
    }
}
