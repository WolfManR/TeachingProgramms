﻿using OrganizationEF.Models;
using OrganizationEF.Repos;
using ProjectForDepartaments.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.ViewModels
{
    public class OrganizationViewModel : INotifyPropertyChanged
    {
        private Department selectedDepartment;
        private RelayCommand addDepartmentCmd = null;
        private RelayCommand addEmployeeCmd = null;
        public RelayCommand AddDepartmentCmd => addDepartmentCmd ?? (addDepartmentCmd = new RelayCommand(() =>
         {
             var AddView = new Views.DepartmentAddView();
             switch (AddView.ShowDialog())
             {
                 case true when (AddView.Department != null):
                     //add error "that item exist"
                     departRepo.Add(AddView.Department);
                     Departments.Add(AddView.Department);
                     break;
                 default:
                     break;
             }
         }));
        public RelayCommand AddEmployeeCmd => addEmployeeCmd ?? (addEmployeeCmd = new RelayCommand(() =>
        {
            var AddView = new Views.EmployeeAddView();
            switch (AddView.ShowDialog())
            {
                case true when AddView.Employee != null:
                    //add error "that item exist"
                    employeeRepo.Add(AddView.Employee);
                    Employees.Add(AddView.Employee);
                    break;
                default:
                    break;
            }
        }));
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                if (selectedDepartment == value) return;
                SelectedEmployee = null;
                selectedDepartment = value;
                if (value != null)
                {
                    Employees.Clear();
                    var list = (from x in employeeRepo.GetAll() where x.DepartmentId == value.Id select x).ToList();
                    list.ForEach(x => Employees.Add(x));
                }
                OnPropertyChanged();
            }
        }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee == value) return;
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        DepartmentRepo departRepo = new DepartmentRepo();
        EmployeeRepo employeeRepo = new EmployeeRepo();
        private Employee selectedEmployee;

        public IList<Department> Departments { get; set; }
        public IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public string OrganizationName { get; set; } = "GeekBrains";
        public OrganizationViewModel()
        {
            var departments = new ObservableCollection<Department>(departRepo.GetAll());
            departments.CollectionChanged += Departments_CollectionChanged;
            Departments = departments;
            (Employees as ObservableCollection<Employee>).CollectionChanged += Employees_CollectionChanged;
        }

        private void Departments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;
            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
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

        private void Employees_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;
            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Employee item in e.OldItems)
                    {
                        employeeRepo.Delete(item);
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
