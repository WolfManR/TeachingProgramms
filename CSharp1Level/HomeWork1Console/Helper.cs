using System;

namespace HomeWork1Console
{
    public static class Helper
    {
        public static int ReadInt() => int.Parse(Console.ReadLine());
        public static void WriteMsgInCenter(string prefix, string variable)
        {
            int CalcConsoleCenter(string str)
            {
                return Console.BufferWidth / 2 - str.Length / 2;
            }
            string msg = $"{prefix} {variable}";
            Console.CursorLeft += CalcConsoleCenter(msg);
            Console.WriteLine(msg);
        }
        public static void PrintColoredMsg(string msg,ConsoleColor BackColor,ConsoleColor ForeColor)
        {
            var defaultBack = Console.BackgroundColor;
            var defaultFore = Console.ForegroundColor;
            Console.BackgroundColor = BackColor;
            Console.ForegroundColor = ForeColor;
            Console.WriteLine($"\n{msg}\n");
            Console.BackgroundColor = defaultBack;
            Console.ForegroundColor = defaultFore;
        }
        public static void TaskTitle(int taskNumber)
        {
            PrintColoredMsg($"\nЗадача {taskNumber}", ConsoleColor.DarkBlue, ConsoleColor.Yellow);
        }

        public static void TaskEnded(int taskNumber) //в будущем заменить событием
        {
            PrintColoredMsg($"\nЗадача {taskNumber} завершила свою работу.\nНажмите любую кнопку для продолжения работы основной программы.", ConsoleColor.White, ConsoleColor.Black);
            Console.ReadKey();
        }
        public static void ProgramEnded()
        {
            PrintColoredMsg($"\nПрограмма завершила свою работу.\nНажмите любую кнопку для выхода.", ConsoleColor.White, ConsoleColor.Red);
            Console.ReadKey();
        }
        public static void WorkTasks(TaskWork[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                TaskTitle(i + 1);
                tasks[i].Work();
                TaskEnded(i + 1);
            }
        }
    }
    public interface TaskWork
    {
        void Work();
    }
}
