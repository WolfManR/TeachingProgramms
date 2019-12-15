using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfTestMailSender.DataValidation
{
    public class DemoValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int IntValue;
            try
            {
                IntValue = Convert.ToInt16(value);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Введите число");
            }

            if (IntValue < 0) return new ValidationResult(false, "Введите число больше 0");

            return new ValidationResult(true, null);
        }
    }
}
