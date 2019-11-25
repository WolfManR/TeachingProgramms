using ProjectForDepartaments.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.ViewModels
{
    public class OrganizationViewModel : INotifyPropertyChanged
    {
        private Department selectedDepartment;
        private Organization organization;

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
        public Organization Organization
        {
            get => organization; 
            set
            {
                if (organization == value) return;
                organization = value;
                OnPropertyChanged();
            }
        }

        public OrganizationViewModel() : this(null) { }
        public OrganizationViewModel(Organization organization)
        {
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
