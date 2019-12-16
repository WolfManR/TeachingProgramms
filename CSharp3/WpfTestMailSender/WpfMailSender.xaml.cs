using EmailSendDLL;
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
using WpfTestMailSender.ViewModel;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            var locator = (ViewModelLocator)FindResource("Locator");
            locator.Main.View = this;
            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";

            ctbiSelector.Items = locator.Main.Smtps;
            ctbiSelector.ComboDisplayMemberPath = "Key";
            ctbiSelector.ComboSelectedValuePath = "Value";
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex+1 == tabControl.Items.Count-1)
            {
                tabControl.SelectedIndex++;
                tscTabSwitcher.IsHideBtnNext = true;
                tscTabSwitcher.IsHidebtnPrevious = false;
                return;
            }
            tabControl.SelectedIndex++;
        }

        private void tscTabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex-1 == 0)
            {
                tabControl.SelectedIndex--;
                tscTabSwitcher.IsHideBtnNext = false;
                tscTabSwitcher.IsHidebtnPrevious = true;
                return;
            }
            tabControl.SelectedIndex--;
        }

        
    }
}
