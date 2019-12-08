using MailSender_WPFTest.Models;
using MailSender_WPFTest.Resources.Text;
using MailSender_WPFTest.ViewModels;
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
        public WPFMailSenderViewModel ViewModel { get; set; } = new WPFMailSenderViewModel();
        public WPFMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            MailSendService sendService = new MailSendService
                (
                  SenderEmail.Text,
                  passwordBox.Password,
                  Texts.smptGmailHost,
                  Texts.smptGmailPort
                );
            try
            {
                sendService.SendMail(tbTitle.Text, tbLetter.Text);
            }
            catch (Exception ex)
            {
                new ErrorMessageView(Errors.CantSendMail+"\n" + ex.ToString()) { Owner=this, Title="Error"}.ShowDialog();
            }

            new SendEndWindow() { Owner = this }.ShowDialog();
        }

        private void btnSMTPSettings_Click(object sender, RoutedEventArgs e)
        {
            SMTP.IsOpen = !SMTP.IsOpen;
        }

    }
}
