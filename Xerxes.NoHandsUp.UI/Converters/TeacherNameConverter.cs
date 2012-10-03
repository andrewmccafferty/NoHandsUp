using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Xerxes.NoHandsUp.UI.Properties;

namespace Xerxes.NoHandsUp.UI.Converters
{
    public class TeacherNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = null;
            string teacherName = value as string;
            if (teacherName != null)
            {
                result = string.Format(Resources.TeacherNameLabel, teacherName);
            }

            return result;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
