using OrganizationEF.Models;
using ProjectForDepartaments.ViewModels;
using System.Windows;
using System.Windows.Controls;


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

        private void btnShowNotHiredList_Click(object sender, RoutedEventArgs e)
        {
            btnHideNotHiredList.Visibility = Visibility.Visible;
            btnShowNotHiredList.Visibility = Visibility.Collapsed;
        }

        private void btnHideNotHiredList_Click(object sender, RoutedEventArgs e)
        {
            btnHideNotHiredList.Visibility = Visibility.Collapsed;
            btnShowNotHiredList.Visibility = Visibility.Visible;
        }

        private void btnShowEmployeesAdd_Click(object sender, RoutedEventArgs e)
        {
            btnShowEmployeesAdd.Visibility = Visibility.Collapsed;
            btnHideEmployeesAdd.Visibility = Visibility.Visible;
        }

        private void btnHideEmployeesAdd_Click(object sender, RoutedEventArgs e)
        {
            btnShowEmployeesAdd.Visibility = Visibility.Visible;
            btnHideEmployeesAdd.Visibility = Visibility.Collapsed;
        }
    }

}
