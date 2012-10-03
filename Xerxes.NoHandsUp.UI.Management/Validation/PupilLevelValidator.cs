using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Xerxes.NoHandsUp.UI.Management.Validation
{
    public class PupilLevelValidator : ValidationRule
    {
        public override ValidationResult Validate(
            object value, 
            System.Globalization.CultureInfo cultureInfo)
        {
            string valueAsString = value as string;
            ValidationResult result = ValidationResult.ValidResult;
            ushort level;
            if (string.IsNullOrEmpty(valueAsString))
            {
                result = new ValidationResult(false, ValidationResources.NoLevel);
            }
            else if (!ushort.TryParse(valueAsString, out level) || level > 5)
            {
                result = new ValidationResult(false, ValidationResources.InvalidLevel);
            }
            return result;
        }
    }
}
