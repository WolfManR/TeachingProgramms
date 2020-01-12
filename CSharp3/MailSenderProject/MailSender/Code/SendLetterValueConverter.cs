using MailSender.Data.Models;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace MailSender.Code
{
    public class SendLetterValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return
            (
                doc: values[0] as FlowDocument,
                subject: values[1] as string,
                password: Encrypter.Encript((values[2] as PasswordBox).Password, Encrypter.EcrypterKey),
                smtp: values[3] as SMTP
            );
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
