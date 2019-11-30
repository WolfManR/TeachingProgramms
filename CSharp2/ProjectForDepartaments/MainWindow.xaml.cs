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

        private void btnDepartRemove_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Department dep)
                MainOrganization.Departments.Remove(dep);
        }
        private void btnEmplRemove_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b.DataContext is Employee empl)
                MainOrganization.Employees.Remove(empl);
        }

        private void btnEmplSwitchDepart_Click(object sender, RoutedEventArgs e)
        {
            var button = (ContentControl)sender;
            Department selectedDep = null;
            var parentStackPanelChildrens = ((Panel)button.Parent).Children;
            foreach (var item in parentStackPanelChildrens)
            {
                if (item is ComboBox combo)
                {
                    selectedDep = combo.SelectedItem as Department;
                    break;
                }
            }
            Employee empl = button.DataContext as Employee;
            if (selectedDep != null && empl.Department != selectedDep) OrganizationViewModel.SwitchDepartment(empl.Department, selectedDep, empl);
        }

        private void lvDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Department) bEmployees.Visibility = Visibility.Visible;
            else bEmployees.Visibility = Visibility.Hidden;
        }
    }

}
