using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Views.MainWindowTemplates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ModernView : Window
    {
        public ModernView()
        {
            InitializeComponent();
            gSchedulers.Visibility = Visibility.Collapsed;
            gEmails.Visibility = Visibility.Collapsed;
        }


        Thickness controlsUp = new Thickness(0, -800, 0, 0);
        Thickness controlsDown = new Thickness(0);
        ThicknessAnimation controlsAnim = new ThicknessAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 800)) };

        ControlBarSwitcher switcher = ControlBarSwitcher.None;
        private void iEmails_Click(object sender, RoutedEventArgs e)
        {
            switch (switcher)
            {
                case ControlBarSwitcher.Scheduler:
                    switcher = ControlBarSwitcher.Emails;
                    gSchedulers.Visibility = Visibility.Collapsed;
                    gEmails.Visibility = Visibility.Visible;
                    break;
                case ControlBarSwitcher.Emails:
                    switcher = ControlBarSwitcher.None;
                    ControlPanel_Up();
                    gEmails.Visibility = Visibility.Collapsed;
                    break;
                case ControlBarSwitcher.None:
                    gEmails.Visibility = Visibility.Visible;
                    ControlPanel_Down();
                    switcher = ControlBarSwitcher.Emails;
                    break;
                default:
                    break;
            }
        }
        private void iScheduler_Click(object sender, RoutedEventArgs e)
        {
            switch (switcher)
            {
                case ControlBarSwitcher.Scheduler:
                    switcher = ControlBarSwitcher.None;
                    ControlPanel_Up();
                    gSchedulers.Visibility = Visibility.Collapsed;
                    break;
                case ControlBarSwitcher.Emails:
                    switcher = ControlBarSwitcher.Scheduler;
                    gSchedulers.Visibility = Visibility.Visible;
                    gEmails.Visibility = Visibility.Collapsed;
                    break;
                case ControlBarSwitcher.None:
                    gSchedulers.Visibility = Visibility.Visible;
                    ControlPanel_Down();
                    switcher = ControlBarSwitcher.Scheduler;
                    break;
                default:
                    break;
            }
        }

        void ControlPanel_Up()
        {
            controlsAnim.From = controlsDown;
            controlsAnim.To = controlsUp;
            bControls.BeginAnimation(MarginProperty, controlsAnim);
        }
        void ControlPanel_Down()
        {
            controlsAnim.From = controlsUp;
            controlsAnim.To = controlsDown;
            bControls.BeginAnimation(MarginProperty, controlsAnim);
        }
        enum ControlBarSwitcher
        {
            Scheduler, Emails, None
        }
        enum LoginShow
        {
            Shown, Hided
        }

        LoginShow login = LoginShow.Hided;
        Thickness loginUp = new Thickness(0, -140, 0, 0);
        Thickness loginDown = new Thickness(0);
        ThicknessAnimation loginAnim = new ThicknessAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500)) };
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            switch (login)
            {
                case LoginShow.Shown:
                    loginAnim.From = loginDown;
                    loginAnim.To = loginUp;
                    LoginForm.BeginAnimation(MarginProperty, loginAnim);
                    login = LoginShow.Hided;
                    break;
                case LoginShow.Hided:
                    loginAnim.From = loginUp;
                    loginAnim.To = loginDown;
                    LoginForm.BeginAnimation(MarginProperty, loginAnim);
                    login = LoginShow.Shown;
                    break;
                default:
                    break;
            }
        }

        private void btnSMTPSettings_Click(object sender, RoutedEventArgs e)
        {
            SMTP.IsOpen = !SMTP.IsOpen;
        }
    }
}
