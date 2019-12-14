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

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var locator = (ViewModelLocator)FindResource("Locator");

                EmailSendServiceClass serviceClass = PrepairSendClass();
                List<string> list = new List<string>();
                foreach (Email item in locator.Main.Emails) list.Add(item.Value);
                serviceClass.SendMails(list);
            }
            catch (SendClassFillException ex)
            {
                new ErrorWindow(ex.Message) { Owner = this }.ShowDialog();
            }
            catch (Exception ex)
            {
                new ErrorWindow(Texts.CantSendMail + ex.ToString()) { Owner = this }.ShowDialog();
            }
        }

        EmailSendServiceClass PrepairSendClass()
        {
            if (rtbBody.Document == null) throw new SendClassFillException(Texts.LetterNotFilled);

            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();

            if (string.IsNullOrEmpty(strLogin)) throw new SendClassFillException(Texts.LoginNotCorrect);
            if (string.IsNullOrEmpty(strPassword)) throw new SendClassFillException(Texts.PassNotCorrect);

            string smtpHost = ctbiSelector.ComboText;
            int smtpPort = int.Parse(ctbiSelector.ComboSelectedValue.ToString());
            string subject = tbSubject.Text;
            TextRange Letter = new TextRange(rtbBody.Document.ContentStart, rtbBody.Document.ContentEnd);

            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword, smtpHost, smtpPort, subject, Letter.Text);
            return emailSender;
            
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            
            if (tsSendTime == new TimeSpan())
            {
                new ErrorWindow(Texts.DateNotCorrect) { Owner = this }.ShowDialog();
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                new ErrorWindow(Texts.DateAndTimeNotCorrect) { Owner = this }.ShowDialog();
                return;
            }

            try
            {
                var locator = (ViewModelLocator)FindResource("Locator");
                EmailSendServiceClass serviceClass = PrepairSendClass();
                sc.SendEmails(dtSendDateTime, serviceClass, locator.Main.Emails);
            }
            catch (SendClassFillException ex)
            {
                new ErrorWindow(ex.Message) { Owner = this }.ShowDialog();
            }
            catch (Exception ex)
            {
                new ErrorWindow(Texts.CantSendMail + ex.ToString()) { Owner = this }.ShowDialog();
            }
            
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
