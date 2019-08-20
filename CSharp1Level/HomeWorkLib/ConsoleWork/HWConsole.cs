using System;

namespace HomeWorkLib.ConsoleWork
{
    public abstract class HWConsole:IHWTask
    {
        public abstract string Title { get; }

        public abstract int TaskNumber { get; }

        public abstract string ToDo { get; }

        public delegate void ConsoleColoredMsg(string msg, ConsoleColor BackColor, ConsoleColor ForeColor);
        ConsoleColoredMsg Del;
        
        public void DecorativeWork()
        {
            Console.Clear();
            Del = new ConsoleColoredMsg(Helper.PrintColoredMsg);
            Del?.Invoke($"\nЗадача {TaskNumber}", ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            Del?.Invoke(ToDo + "\n", ConsoleColor.Gray, ConsoleColor.DarkMagenta);
            Work();
            Del?.Invoke($"\nЗадача {TaskNumber} завершила свою работу.\nНажмите любую кнопку для продолжения работы основной программы.", ConsoleColor.White, ConsoleColor.Black);
            Console.ReadKey();
        }

        public abstract void Work();
    }
}
