using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Data;

namespace Xerxes.WPFCustomControls.Converters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class ImageKeyConverter : IValueConverter
    {
        private const string ImageFolder = "image/avatars";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imageKey = value as string;
            if (imageKey == null)
                return null;
            string filePath = Path.Combine(ImageFolder, imageKey);
            if (!File.Exists(filePath))
            {
                return null;
            }
            else
            {
                var source = new BitmapImage();
                source.BeginInit();
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    source.StreamSource = stream;
                    source.EndInit();
                }

                return source;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
