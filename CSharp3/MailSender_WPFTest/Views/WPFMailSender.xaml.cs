using MailSender_WPFTest.Models;
using MailSender_WPFTest.Resources.Text;
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

namespace MailSender_WPFTest.Views
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
            EmailSendServiceClass sendService = new EmailSendServiceClass
                (
                  Texts.senderEmail,
                  passwordBox.Password,
                  Texts.smptHostYandex,
                  25,
                  new List<string> { Texts.ToGmailEmail, Texts.ToYandexEmail }
                );
            sendService.SendMail(Texts.MailTitle, Texts.MailLetter);
            new SendEndWindow().ShowDialog();
        }
    }
}
