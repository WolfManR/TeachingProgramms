using System;

namespace HWConsoleLibrary
{
    public static class ConsoleMsg
    {
        public static void WriteMsgInCenter(string prefix, string variable)
        {
            int CalcConsoleCenter(string str) => Console.BufferWidth / 2 - str.Length / 2;
            string msg = $"{prefix} {variable}";
            Console.CursorLeft += CalcConsoleCenter(msg);
            Console.WriteLine(msg);
        }
        public static void PrintColoredMsg(string msg, ConsoleColor BackColor, ConsoleColor ForeColor)
        {
            var defaultBack = Console.BackgroundColor;
            var defaultFore = Console.ForegroundColor;
            Console.BackgroundColor = BackColor;
            Console.ForegroundColor = ForeColor;
            Console.WriteLine($"\n{msg}\n");
            Console.BackgroundColor = defaultBack;
            Console.ForegroundColor = defaultFore;
        }

        public static void ProgramEnded()
        {
            PrintColoredMsg($"\nПрограмма завершила свою работу.\nНажмите любую кнопку для выхода.", ConsoleColor.White, ConsoleColor.Red);
            Console.ReadKey();
        }

        public static string GetValueAfterMsgLine(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        public static string GetValueInMsgLine(string msg)
        {
            Console.Write(msg + " ");
            return Console.ReadLine();
        }
    }
}
