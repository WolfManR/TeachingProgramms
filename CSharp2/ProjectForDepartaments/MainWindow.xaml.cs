using ProjectForDepartaments.Commands;
using ProjectForDepartaments.Models;
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
        private ICommand addDepartmentCmd = null;
        private ICommand addEmployeeCmd = null;
        public ICommand AddDepartmentCmd => addDepartmentCmd ?? (addDepartmentCmd = new AddDepartmentCommand());
        public ICommand AddEmployeeCmd => addEmployeeCmd ?? (addEmployeeCmd = new AddEmployeeCommand());

        public ViewModels.OrganizationViewModel Organization { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            var organization = new Organization("GeekBrains")
            {
                Departments = new System.Collections.ObjectModel.ObservableCollection<Department>()
                {
                    new Department("C# Programmers")
                    {
                        Employees = new System.Collections.ObjectModel.ObservableCollection<Employee>()
                        {
                            new Employee("Lork", "Emily"),
                            new Employee("Lork", "Emily"),
                            new Employee("Lork", "Emily"),
                            new Employee("Lork", "Emily")
                        }
                    },
                    new Department("Java Programmers")
                    {
                        Employees = new System.Collections.ObjectModel.ObservableCollection<Employee>()
                        {
                            new Employee("Karat", "Zone"),
                            new Employee("Karat", "Zone"),
                            new Employee("Karat", "Zone"),
                            new Employee("Karat", "Zone")
                        }
                    }
                }
            };
            Organization=new ViewModels.OrganizationViewModel(organization);
            DataContext = Organization;
        }

        private void btnDepartRemove_Click(object sender, RoutedEventArgs e)
        {
            if(((Button)sender).DataContext is Department dep)
                Organization.Organization.Departments.Remove(dep);
        }
        private void btnEmplRemove_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (b.DataContext is Employee empl)
                (lvEmployees.DataContext as Department).Employees.Remove(empl);
        }
        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e) //баги
        {
            if (e.RemovedItems != null && e.RemovedItems.Count>0 && e.RemovedItems[0] is Models.Employee emplRem) emplRem.IsSelected = false;
            if (e.AddedItems != null && e.AddedItems.Count > 0 && e.AddedItems[0] is Models.Employee emplAdd) emplAdd.IsSelected = true;
        }

        private void btnSwitchDepExp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
        
}
