using System.Windows;

namespace MailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для ErrorMessage.xaml
    /// </summary>
    public partial class ErrorMessage : Window
    {
        public string Msg { get; }
        public string TitleIcon { get; }
        public ErrorMessage(string msg,string titleIcon=null)
        {
            InitializeComponent();
            Msg = msg;
            TitleIcon = titleIcon;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
