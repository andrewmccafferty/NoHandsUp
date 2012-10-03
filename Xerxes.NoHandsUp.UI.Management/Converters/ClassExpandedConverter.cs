using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Xerxes.NoHandsUp.Model;

namespace Xerxes.NoHandsUp.UI.Management.Converters
{
    public class ClassExpandedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Class currentClass = value as Class;
            return currentClass != null && currentClass.IsExpanded;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
