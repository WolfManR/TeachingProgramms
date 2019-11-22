using ProjectForDepartaments.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectForDepartaments.Commands
{                                                       //Как реализовать??????????????????????????
    public class RemoveDepartmentCommand : BaseCommand, ICommand
    {
        public ObservableCollection<Department> Departments { get; set; }
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is Department;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Department Depart) Departments?.Remove(Depart);
        }
    }
}
