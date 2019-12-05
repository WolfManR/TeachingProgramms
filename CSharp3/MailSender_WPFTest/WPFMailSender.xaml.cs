using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender_WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WPFMailSender : Window
    {
        public WPFMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "testEmail@gmail.com", "email@yandex.ru" };
            string strPassword = passwordBox.Password;

            foreach (string mail in listStrMails)
            {
                using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
                {
                    mm.Subject = "Привет из C#";
                    mm.Body = "Hello, World!";
                    mm.IsBodyHtml = false;

                    using (SmtpClient sc=new SmtpClient("smtp.yandex.ru",25))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("sender@yandex.ru", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            MessageBox.Show("Работа завершена.");
        }
    }
}
