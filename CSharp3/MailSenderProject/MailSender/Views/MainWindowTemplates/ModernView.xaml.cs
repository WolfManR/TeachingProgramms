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
            gDates.Visibility = Visibility.Collapsed;
            gEmails.Visibility = Visibility.Collapsed;
        }


        enum ControlBarSwitcher
        {
            Scheduler, Emails, None
        }
        enum ElementShow
        {
            Shown, Hided
        }
        void ControlMoveMargin(Thickness? From, Thickness? To, ThicknessAnimation animation, UIElement element)
        {
            animation.From = From;
            animation.To = To;
            element.BeginAnimation(MarginProperty, animation);
        }

        Thickness controlsUp = new Thickness(0, -800, 0, 0);
        Thickness controlDown = new Thickness(0);
        Thickness loginUp = new Thickness(0, -140, 0, 0);
        Thickness smtpUp = new Thickness(0, -240, 0, 0);
        ElementShow login = ElementShow.Hided;
        ElementShow smtp = ElementShow.Hided;
        ThicknessAnimation controlsAnim = new ThicknessAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 800)) };
        ThicknessAnimation loginAnim = new ThicknessAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300)) };
        ThicknessAnimation smtpAnim = new ThicknessAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300)) };
        ControlBarSwitcher switcher = ControlBarSwitcher.None;

        private void iEmails_Click(object sender, RoutedEventArgs e)
        {
            switch (switcher)
            {
                case ControlBarSwitcher.Scheduler:
                    switcher = ControlBarSwitcher.Emails;
                    gDates.Visibility = Visibility.Collapsed;
                    gEmails.Visibility = Visibility.Visible;
                    break;
                case ControlBarSwitcher.Emails:
                    switcher = ControlBarSwitcher.None;
                    ControlMoveMargin(controlDown, controlsUp, controlsAnim, bControls);
                    gEmails.Visibility = Visibility.Collapsed;
                    break;
                case ControlBarSwitcher.None:
                    gEmails.Visibility = Visibility.Visible;
                    ControlMoveMargin(controlsUp, controlDown, controlsAnim, bControls);
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
                    ControlMoveMargin(controlDown, controlsUp, controlsAnim, bControls);
                    gDates.Visibility = Visibility.Collapsed;
                    break;
                case ControlBarSwitcher.Emails:
                    switcher = ControlBarSwitcher.Scheduler;
                    gDates.Visibility = Visibility.Visible;
                    gEmails.Visibility = Visibility.Collapsed;
                    break;
                case ControlBarSwitcher.None:
                    gDates.Visibility = Visibility.Visible;
                    ControlMoveMargin(controlsUp, controlDown, controlsAnim, bControls);
                    switcher = ControlBarSwitcher.Scheduler;
                    break;
                default:
                    break;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            switch (login)
            {
                case ElementShow.Shown:
                    ControlMoveMargin(controlDown, loginUp, loginAnim, LoginForm);
                    if (smtp == ElementShow.Shown)
                    {
                        ControlMoveMargin(controlDown, smtpUp, smtpAnim, SMTPSettings);
                        smtp = ElementShow.Hided;
                    }
                    login = ElementShow.Hided;
                    break;
                case ElementShow.Hided:
                    ControlMoveMargin(loginUp, controlDown, loginAnim, LoginForm);
                    login = ElementShow.Shown;
                    break;
                default:
                    break;
            }
        }

        private void btnSMTPSettings_Click(object sender, RoutedEventArgs e)
        {
            switch (smtp)
            {
                case ElementShow.Shown:
                    ControlMoveMargin(controlDown, smtpUp, smtpAnim, SMTPSettings);
                    smtp = ElementShow.Hided;
                    break;
                case ElementShow.Hided:
                    ControlMoveMargin(smtpUp, controlDown, smtpAnim, SMTPSettings);
                    smtp = ElementShow.Shown;
                    break;
                default:
                    break;
            }
        }
    }
}
