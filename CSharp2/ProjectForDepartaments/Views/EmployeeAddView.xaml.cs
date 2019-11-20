using ProjectForDepartaments.Models;
using System.Windows;

namespace ProjectForDepartaments.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddView.xaml
    /// </summary>
    public partial class EmployeeAddView : Window
    {
        public Employee Employee { get; set; }
        public EmployeeAddView()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Employee = new Employee(tbLastName.Text,tbFirstName.Text);
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
