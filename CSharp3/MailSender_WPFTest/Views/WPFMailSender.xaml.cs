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
        public WPFMailSenderViewModel ViewModel { get; set; } 
        public WPFMailSender()
        {
            ViewModel = new WPFMailSenderViewModel(this);
            InitializeComponent();
        }

        
        private void btnSMTPSettings_Click(object sender, RoutedEventArgs e)
        {
            SMTP.IsOpen = !SMTP.IsOpen;
        }

        private void cmbSMTPTempaltes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var smtp=((ComboBox)sender).SelectedItem as LinqToSQL.SMTP;
            tbHost.Text = smtp.Host;
            tbPort.Text = smtp.Port.ToString();
            cbSSL.IsChecked = smtp.EnableSSL;
        }
    }
}
