using System;

namespace HomeWorkLib.ConsoleWork
{
    // разделить класс на логические части
    public static class Helper
    {
        public static int ReadInt() => int.Parse(Console.ReadLine());

        //можно расширить возможно для обработки не только целочисленного положительного числа
        public static bool CheckStringNumber(string number)
        {
            char[] charNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool isNumber = true;
            
            for (int i = 0; isNumber && i < number.Length; i++)
            {
                int correctNumber = 0;
                for (int j = 0; isNumber && j < charNumbers.Length; j++)
                    if (number[i] == charNumbers[j])
                    {
                        correctNumber++;
                        break;
                    }
                if (correctNumber==0) isNumber = false;
            }
                
                   
            return isNumber;
        }
        public static double IMT(int weight,double height) => weight / (height * height);

        #region Работа с сообщениями в консоли
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
        public static void TaskTitle(int taskNumber)
        {
            PrintColoredMsg($"\nЗадача {taskNumber}", ConsoleColor.DarkBlue, ConsoleColor.Yellow);
        }
        public static void PrintToDo(string ToDo)
        {
            PrintColoredMsg(ToDo + "\n", ConsoleColor.Gray, ConsoleColor.DarkMagenta);
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

        public static string GetValueAfterMsgLine(string msg)
        {
            Console.WriteLine("\n"+msg);
            return Console.ReadLine();
        }
        public static string GetValueInMsgLine(string msg)
        {
            Console.Write("\n"+msg+" ");
            return Console.ReadLine();
        }
        #endregion
        public static void WorkTasks(ITaskWork[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                TaskTitle(i + 1);
                tasks[i].Work();
                TaskEnded(i + 1);
            }
        }
    }
}
