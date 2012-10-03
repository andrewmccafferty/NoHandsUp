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

namespace Xerxes.NoHandsUp.DataAccess
{
    public class DataProvider
    {
        public const string XmlDataFolder = "nohandsup";

        private const string XmlFileName = "pupildata.xml";

        public string GetDataFolder()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), XmlDataFolder);
            return folder;
        }

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
            string fileName = this.GetDataFileName();
            FileInfo dataFile = new FileInfo(fileName);
            if (dataFile.Exists && dataFile.Length > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ClassList));
                using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
                {
                    result = (ClassList)serializer.Deserialize(reader);
                }

            }

            return result;
        }

        public void SaveClasses(ClassList classList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ClassList));
            string folder = this.GetDataFolder();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (XmlTextWriter writer = new XmlTextWriter(this.GetDataFileName(), Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, classList);
            }
        }

        private string GetDataFileName()
        {
            string folder = this.GetDataFolder();
            return Path.Combine(folder, XmlFileName);
        }


    }
}
