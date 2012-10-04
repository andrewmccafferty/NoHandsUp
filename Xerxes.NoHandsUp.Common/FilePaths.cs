using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Xerxes.NoHandsUp.Common
{
    public class FilePaths
    {
        private const string XmlDataFolder = "nohandsup";

        private const string XmlFileName = "pupildata.xml";

        public static string DataFolder
        {
            get
            {
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), XmlDataFolder);
                return folder;
            }
        }

        public static string AvatarsFolder
        {
            get
            {
                return Path.Combine(DataFolder, "images/avatars");
            }
        }

        public static string DataFileName
        {
            get
            {
                return Path.Combine(DataFolder, XmlFileName);
            }
        }

        public static string ExecutingDirectory
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}
