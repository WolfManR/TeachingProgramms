using OrganizationEF.EF;
using OrganizationEF.Models;
using OrganizationEF.Repos;
using ProjectForDepartaments.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ProjectForDepartaments.ViewModels
{
    public class OrganizationViewModel : INotifyPropertyChanged
    {
        private readonly Window view;
        static readonly GBOrganizationEntities context = new GBOrganizationEntities();
        readonly DepartmentRepo departRepo = new DepartmentRepo(context);
        readonly EmployeeRepo employeeRepo = new EmployeeRepo(context);
        private Employee selectedEmployee;
        private Department selectedDepartment;
        private RelayCommand addDepartmentCmd = null;
        private RelayCommand<Department> addEmployeeCmd = null;
        private RelayCommand<Department> removeDepartmentCmd = null;
        private RelayCommand<Employee> removeEmployeeCmd = null;
        private RelayCommand<object> swapDepartmentCmd = null;

        public RelayCommand AddDepartmentCmd => addDepartmentCmd ?? (addDepartmentCmd = new RelayCommand(() =>
         {
             var AddView = new Views.DepartmentAddView();
             view.IsEnabled = false;
             switch (AddView.ShowDialog())
             {
                 case true when (AddView.Department != null):
                     //add error "that item exist"
                     departRepo.Add(AddView.Department);
                     Departments.Add(AddView.Department);
                     Departments.Clear();
                     var departments = departRepo.GetAll();
                     departments.ForEach(x => Departments.Add(x));
                     break;
                 default:
                     break;
             }
             view.IsEnabled = true;
         }));
        public RelayCommand<Department> RemoveDepartmentCmd => removeDepartmentCmd ?? (removeDepartmentCmd = new RelayCommand<Department>(
            (parameter) => {
                Departments.Remove(parameter);
            },
            param => param != null && param is Department));
        public RelayCommand<Department> AddEmployeeCmd => addEmployeeCmd ?? (addEmployeeCmd = new RelayCommand<Department>(
            (parameter) => {
                var AddView = new Views.EmployeeAddView(parameter);
                view.IsEnabled = false;
                switch (AddView.ShowDialog())
                {
                    case true when AddView.Employee != null:
                        //add error "that item exist"
                        employeeRepo.Add(AddView.Employee);
                        Employees.Clear();
                        var list = (from x in employeeRepo.GetAll() where x.DepartmentId == parameter.Id select x).ToList();
                        list.ForEach(x => Employees.Add(x));
                        selectedDepartment.IsChanged = true;
                        selectedDepartment.IsChanged = false;
                        break;
                    default:
                        break;
                }
                view.IsEnabled = true;
            },
            param => param != null && param is Department));
        public RelayCommand<Employee> RemoveEmployeeCmd => removeEmployeeCmd ?? (removeEmployeeCmd = new RelayCommand<Employee>(
            (parameter) => {
                employeeRepo.Delete(parameter);
                Employees.Remove(parameter);
                selectedDepartment.IsChanged = true;
                selectedDepartment.IsChanged = false;
            },
            param => param != null && param is Employee));
        public RelayCommand<object> SwapDepartmentCmd => swapDepartmentCmd ?? (swapDepartmentCmd = new RelayCommand<object>(
            (param) =>
            {
                var array = (object[])param;
                Department to = array[0] as Department;
                Employee empl = array[1] as Employee;
                empl.Department = to;
                empl.DepartmentId = to.Id;
                employeeRepo.Save(empl);

                Employees.Remove(empl);
                selectedDepartment.IsChanged = true;
                selectedDepartment.IsChanged = false;
                to.IsChanged = true;
                to.IsChanged = false;
            },
            (param) =>
                param != null && 
                param is object[] array &&
                array.Length == 2 &&
                array[0] is Department dep && dep!=SelectedDepartment && 
                array[1] is Employee
            ));

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
        public string OrganizationName { get; set; } = "GeekBrains";

        public IList<Department> Departments { get; set; } = new ObservableCollection<Department>();
        public IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>();


        public OrganizationViewModel(Window view)
        {
            this.view = view;
            var departments = departRepo.GetAll();
            departments.ForEach(x=>Departments.Add(x));
            (Departments as ObservableCollection<Department>).CollectionChanged += Departments_CollectionChanged;
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
                    //selectedDepartment.IsChanged = true;
                    //selectedDepartment.IsChanged = false;
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
