using System;

namespace HomeWorkLib
{
    public partial class HomeWorkTask
    {
        public delegate void ConsoleColoredMsg(string msg, ConsoleColor BackColor, ConsoleColor ForeColor);
        ConsoleColoredMsg Del;
        void PrintColoredMsg(string msg, ConsoleColor BackColor, ConsoleColor ForeColor)
        {
            var defaultBack = Console.BackgroundColor;
            var defaultFore = Console.ForegroundColor;
            Console.BackgroundColor = BackColor;
            Console.ForegroundColor = ForeColor;
            Console.WriteLine($"\n{msg}\n");
            Console.BackgroundColor = defaultBack;
            Console.ForegroundColor = defaultFore;
        }
        public void DecorativeWorkInConsole()
        {
            Console.Clear();
            Del = new ConsoleColoredMsg(PrintColoredMsg);
            Del?.Invoke($"\nЗадача {TaskNumber}", ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            Del?.Invoke(ToDo + "\n", ConsoleColor.Gray, ConsoleColor.DarkMagenta);
            Work();
            Del?.Invoke($"\nЗадача {TaskNumber} завершила свою работу.\nНажмите любую кнопку для продолжения работы основной программы.", ConsoleColor.White, ConsoleColor.Black);
            Console.ReadKey();
        }
    }
}
