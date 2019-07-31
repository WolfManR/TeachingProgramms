using HomeWorkLib.ConsoleWork;

namespace HomeWorkLib
{
    public partial class HomeWorkTask
    {
        public void DecorativeWorkInConsole()
        {
            Helper.TaskTitle(TaskNumber);
            Work();
            Helper.TaskEnded(TaskNumber);
        }
    }
}
