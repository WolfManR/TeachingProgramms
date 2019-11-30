using OrganizationEF.Models;
using ProjectForDepartaments.Commands;
using ProjectForDepartaments.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ProjectForDepartaments
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OrganizationViewModel MainOrganization { get; set; }
        public MainWindow()
        {
            MainOrganization = new OrganizationViewModel(this);
            InitializeComponent();
        }

        private void lvDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Department) bEmployees.Visibility = Visibility.Visible;
            else bEmployees.Visibility = Visibility.Hidden;
        }
    }

}
