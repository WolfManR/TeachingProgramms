using ProjectForDepartaments.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectForDepartaments.Commands
{
    class AddDepartmentCommand : BaseCommand, ICommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ObservableCollection<Department>;
        }

        public override void Execute(object parameter)
        {
            if(parameter is ObservableCollection<Department> Depart)
            {
                var AddView = new Views.DepartmentAddView();
                switch (AddView.ShowDialog())
                {
                    case true when !String.IsNullOrEmpty(AddView.DepartmentName):
                        Depart?.Add(new Department(AddView.DepartmentName));
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
