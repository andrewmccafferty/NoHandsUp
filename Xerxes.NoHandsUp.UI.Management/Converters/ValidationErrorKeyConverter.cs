using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;

namespace Xerxes.NoHandsUp.UI.Management.Converters
{
    public class ValidationErrorKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<ValidationError> errors = value as IEnumerable<ValidationError>;
            string result = null;
            if (errors != null && errors.Count() > 0)
            {
                string resourceKey = errors.First().ErrorContent as string;
                if (resourceKey != null)
                {
                    result = ValidationResources.ResourceManager.GetString(resourceKey);
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
