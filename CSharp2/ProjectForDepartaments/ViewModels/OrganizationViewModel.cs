
using OrganizationEF.Models;
using OrganizationEF.Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.ViewModels
{
    public class OrganizationViewModel : INotifyPropertyChanged
    {
        private Department selectedDepartment;

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

        DepartmentRepo departRepo = new DepartmentRepo();
        EmployeeRepo EmployeeRepo = new EmployeeRepo();

        public IList<Department> Departments { get; set; }
        public IList<Employee> Employees { get; set; }

        public OrganizationViewModel()
        {
            var departments = new ObservableCollection<Department>(departRepo.GetAll());
            departments.CollectionChanged += Departments_CollectionChanged;
            Departments = departments;
        }

        private void Departments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;
            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Department item in e.NewItems)
                    {
                        departRepo.Add(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Department item in e.OldItems)
                    {
                        departRepo.Delete(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
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
