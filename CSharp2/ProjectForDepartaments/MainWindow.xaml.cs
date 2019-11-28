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
        public OrganizationViewModel MainOrganization { get; set; } = new OrganizationViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var organization = new Organization("GeekBrains")
            //{
            //    Departments = new System.Collections.ObjectModel.ObservableCollection<Department>()
            //};
            //var dp1 = new Department("C# Programmers");
            //var dp1Employees = new System.Collections.ObjectModel.ObservableCollection<Employee>()
            //{
            //                new Employee("Lork", "Emily"){ Department=dp1,Organization=organization },
            //                new Employee("Lork", "Emily"){ Department=dp1,Organization=organization },
            //                new Employee("Lork", "Emily"){ Department=dp1,Organization=organization },
            //                new Employee("Lork", "Emily"){ Department=dp1,Organization=organization }
            //            };
            //dp1.Employees = dp1Employees;
            //var dp2 = new Department("Java Programmers");
            //var dp2Employees = new System.Collections.ObjectModel.ObservableCollection<Employee>()
            //            {
            //                new Employee("Karat", "Zone"){ Department=dp2,Organization=organization },
            //                new Employee("Karat", "Zone"){ Department=dp2,Organization=organization },
            //                new Employee("Karat", "Zone"){ Department=dp2,Organization=organization },
            //                new Employee("Karat", "Zone"){ Department=dp2,Organization=organization }
            //            };
            //dp2.Employees = dp2Employees;
            //organization.Departments.Add(dp1);
            //organization.Departments.Add(dp2);
            //MainOrganization.Organization = organization;
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
    }

}
