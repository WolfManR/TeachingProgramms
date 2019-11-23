using ProjectForDepartaments.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.ViewModels
{
    public class OrganizationViewModel : INotifyPropertyChanged
    {
        private string name;
        private Department selectedDepartment;

        public string Name
        {
            get => name;
            private set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged();
            }
        }
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                if (selectedDepartment == value) return;
                selectedDepartment = value;
                OnPropertyChanged();
            }
        }
        public Organization Organization { get; private set; }
        public OrganizationViewModel(Organization organization)
        {
            Name = organization.Name;
            Organization = organization;
        }

        [System.Obsolete("Work of Method will be changed in future!")]
        public static void SwitchDepartment(Department from, Department to, Employee employee)
        {
            from.Employees.Remove(employee);
            to.Employees.Add(employee);
            employee.Department = to;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
