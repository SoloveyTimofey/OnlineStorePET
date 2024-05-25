using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagementApplication.Infrastructure.ValidationRules
{
    public class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is decimal)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Entered Price is invalid");
        }
    }
}
