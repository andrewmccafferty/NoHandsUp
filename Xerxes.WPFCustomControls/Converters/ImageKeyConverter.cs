using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Data;
using Xerxes.NoHandsUp.Common;

namespace Xerxes.WPFCustomControls.Converters
{
    public enum MissingImageBehaviour
    {
        None,
        ShowDefault
    }
    [ValueConversion(typeof(string), typeof(string))]
    public class ImageKeyConverter : IValueConverter
    {        
        private const string ImageFolder = "images/avatars";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imageKey = value as string;
            MissingImageBehaviour missingImageBehaviour = MissingImageBehaviour.None;
            if (parameter != null)
            {
                missingImageBehaviour = (MissingImageBehaviour)Enum.Parse(typeof(MissingImageBehaviour), parameter.ToString());
            }
            string defaultPath = Path.Combine(FilePaths.ExecutingDirectory, @"image/user_gray.png");
            if (imageKey == null)
            {
                return missingImageBehaviour == MissingImageBehaviour.ShowDefault ? defaultPath : null;
            }
            string filePath = Path.Combine(FilePaths.AvatarsFolder, imageKey);
            if (File.Exists(filePath))
            {
                return filePath;
            }
            else if (missingImageBehaviour == MissingImageBehaviour.ShowDefault)
            {
                return defaultPath;
            }
            else
            {
                return null;
            }
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
