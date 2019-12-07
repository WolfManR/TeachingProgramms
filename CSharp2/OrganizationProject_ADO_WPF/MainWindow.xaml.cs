using OrganizationProject_ADO_WPF.ViewModels;
using System.Windows;

namespace OrganizationProject_ADO_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        
    }
}
