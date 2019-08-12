using System;
using HomeWorkLib.ConsoleWork;

namespace HomeWorkLib
{
    public partial class HomeWorkTask
    {
        public delegate void ConsoleColoredMsg(string msg, ConsoleColor BackColor, ConsoleColor ForeColor);
        void TaskTitle(int taskNumber)
        {
            Helper.PrintColoredMsg($"\nЗадача {taskNumber}", ConsoleColor.DarkBlue, ConsoleColor.Yellow);
        }
        void PrintToDo(string ToDo)
        {
           Helper.PrintColoredMsg(ToDo + "\n", ConsoleColor.Gray, ConsoleColor.DarkMagenta);
        }
        void TaskEnded(int taskNumber) //в будущем заменить событием
        {
            Helper.PrintColoredMsg($"\nЗадача {taskNumber} завершила свою работу.\nНажмите любую кнопку для продолжения работы основной программы.", ConsoleColor.White, ConsoleColor.Black);
            Console.ReadKey();
        }
        public void DecorativeWorkInConsole()
        {
            Console.Clear();
            TaskTitle(TaskNumber);
            PrintToDo(ToDo);
            Work();
            TaskEnded(TaskNumber);
        }
    }
}
