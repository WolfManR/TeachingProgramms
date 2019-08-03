using System;
using HomeWorkLib.ConsoleWork;

namespace HomeWorkLib
{
    public partial class HomeWorkTask
    {
        public void DecorativeWorkInConsole()
        {
            Console.Clear();
            Helper.TaskTitle(TaskNumber);
            Helper.PrintToDo(ToDo);
            Work();
            Helper.TaskEnded(TaskNumber);
        }
    }
}
