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

        public static void TaskTitle(int taskNumber)
        {
            Console.WriteLine($"\nЗадача {taskNumber}\n");
        }

        public static void TaskEnded(int taskNumber) //в будущем заменить событием
        {
            Console.WriteLine($"\nЗадача {taskNumber} завершила свою работу.\nНажмите любую кнопку для продолжения работы основной программы.");
            Console.ReadKey();
        }
        public static void ProgramEnded()
        {
            Console.WriteLine($"\nПрограмма завершила свою работу.\nНажмите любую кнопку для выхода.");
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
