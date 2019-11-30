using OrganizationEF.Models;
using System.Windows;

namespace ProjectForDepartaments.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddView.xaml
    /// </summary>
    public partial class EmployeeAddView : Window
    {
        public Employee Employee { get; set; }
        public EmployeeAddView(Department depart)
        {
            InitializeComponent();
            Employee = new Employee() { Department = depart,DepartmentId=depart.Id };
            this.DataContext = Employee;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
