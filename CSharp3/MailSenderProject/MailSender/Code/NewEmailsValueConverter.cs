using System;
using System.Globalization;
using System.Windows.Data;

namespace MailSender.Code
{
    public class NewEmailsValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return
                (
                    email: values[0] as string,
                    name: values[1] as string
                );
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
