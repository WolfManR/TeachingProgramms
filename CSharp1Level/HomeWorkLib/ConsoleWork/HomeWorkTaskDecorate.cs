using HomeWorkLib.ConsoleWork;

namespace HomeWorkLib
{
    public partial class HomeWorkTask
    {
        public void DecorativeWorkInConsole()
        {
            Helper.TaskTitle(TaskNumber);
            System.Console.WriteLine(ToDo+"\n");
            Work();
            Helper.TaskEnded(TaskNumber);
        }
    }
}
