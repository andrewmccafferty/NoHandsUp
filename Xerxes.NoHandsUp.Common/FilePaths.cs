using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Xerxes.NoHandsUp.Common
{
    public class FilePaths
    {
        public const string XmlDataFolder = "nohandsup";

        public static string GetDataFolder()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), XmlDataFolder);
            return folder;
        }
    }
}
