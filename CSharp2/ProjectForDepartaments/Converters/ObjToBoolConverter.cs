using OrganizationEF.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ProjectForDepartaments.Converters
{
    public class IListEmplToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as IList<Employee>).Count > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
