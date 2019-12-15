using System.Windows;
using System.Windows.Documents;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для LetterWindow.xaml
    /// </summary>
    public partial class LetterWindow : Window
    {
        public LetterWindow()
        {
            InitializeComponent();
        }

        public FlowDocument Letter { get => rtb.Document; }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
