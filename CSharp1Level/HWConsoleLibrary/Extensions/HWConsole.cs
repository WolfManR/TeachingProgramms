using HomeWorkLib;
using System;

namespace HWConsoleLibrary.Extensions
{
    public static class HWConsole
    {
        public delegate void ConsoleColoredMsg(string msg, ConsoleColor BackColor, ConsoleColor ForeColor);
        static ConsoleColoredMsg Del;

        public static void DecorativeWork(this IHWTask task)
        {
            Console.Clear();
            Del = new ConsoleColoredMsg(ConsoleMsg.PrintColoredMsg);
            Del?.Invoke($"\nЗадача {task.TaskNumber}", ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            Del?.Invoke(task.ToDo + "\n", ConsoleColor.Gray, ConsoleColor.DarkMagenta);
            task.Work();
            Del?.Invoke($"\nЗадача {task.TaskNumber} завершила свою работу.\nНажмите любую кнопку для продолжения работы основной программы.", ConsoleColor.White, ConsoleColor.Black);
            Console.ReadKey();
        }
    }
}
