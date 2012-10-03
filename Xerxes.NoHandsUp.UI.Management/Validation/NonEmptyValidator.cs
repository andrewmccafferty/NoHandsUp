using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Xerxes.NoHandsUp.UI.Management.Validation
{
    public class NonEmptyValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationResult result = ValidationResult.ValidResult;
            if (string.IsNullOrEmpty(value as string))
            {
                result = new ValidationResult(false, ValidationResources.NoClassName);
            }

            return result;
        }
    }
}
