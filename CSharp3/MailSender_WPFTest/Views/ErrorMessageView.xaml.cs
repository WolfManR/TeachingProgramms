using System.Windows;

namespace MailSender_WPFTest.Views
{
    /// <summary>
    /// Логика взаимодействия для ErrorMessageView.xaml
    /// </summary>
    public partial class ErrorMessageView : Window
    {
        public string Msg { get; }
        public ErrorMessageView(string msg)
        {
            InitializeComponent();
            Msg = msg;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
