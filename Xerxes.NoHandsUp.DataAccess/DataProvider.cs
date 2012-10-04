using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xerxes.NoHandsUp.Model;
using System.Xml.Linq;
using Xerxes.NoHandsUp.DataAccess;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Xerxes.NoHandsUp.Common;

namespace Xerxes.NoHandsUp.DataAccess
{
    public class DataProvider
    {
        public List<Class> GetAllClasses()
        {
            List<Class> classes = new List<Class>();
            ClassList list = this.GetClassListObject();
            if (list != null)
            {
                classes = new List<Class>(list.Classes.OrderBy(c => c.Name));
            }

            return classes;
        }

        public ClassList GetClassListObject()
        {
            ClassList result = new ClassList();
            FileInfo dataFile = new FileInfo(FilePaths.DataFileName);
            if (dataFile.Exists && dataFile.Length > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ClassList));
                using (StreamReader reader = new StreamReader(FilePaths.DataFileName, Encoding.UTF8))
                {
                    result = (ClassList)serializer.Deserialize(reader);
                }

            }

            return result;
        }

        public void SaveClasses(ClassList classList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ClassList));
            string folder = FilePaths.DataFolder;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (XmlTextWriter writer = new XmlTextWriter(FilePaths.DataFileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, classList);
            }
        }



    }
}
