using HomeWorkLib.ConsoleWork;

namespace HomeWorkLib
{
    public partial class HomeWorkTask
    {
        public void DecorativeWorkInConsole()
        {
            Helper.TaskTitle(TaskNumber);
            Helper.PrintToDo(ToDo);
            Work();
            Helper.TaskEnded(TaskNumber);
        }
    }
}
