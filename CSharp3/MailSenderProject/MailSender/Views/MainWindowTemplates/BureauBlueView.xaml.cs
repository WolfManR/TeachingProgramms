using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender.Views.MainWindowTemplates
{
    /// <summary>
    /// Логика взаимодействия для BureauBlueView.xaml
    /// </summary>
    public partial class BureauBlueView : Window
    {
        
        public BureauBlueView()
        {
            InitializeComponent();
        }

        private void btnSMTPSettings_Click(object sender, RoutedEventArgs e)
        {
            SMTP.IsOpen = !SMTP.IsOpen;
        }

        private void cmbSMTPTempaltes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var smtp = ((ComboBox)sender).SelectedItem as LinqToSQL.SMTP;
            //tbHost.Text = smtp.Host;
            //tbPort.Text = smtp.Port.ToString();
            //cbSSL.IsChecked = smtp.EnableSSL;
        }
    }
}
