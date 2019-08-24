using System;
using HomeWorkLib;
using HWConsoleLibrary;
using HWConsoleLibrary.Extensions;

// Иван Бармин

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            
            //                             Задание 1
            Console.WriteLine("Вы будете вводить информацию о себе? \n<2 - да\n>=2 - нет");
            if (Converters.ReadInt() < 2) user.FillUserInfo();

            IHWTaskWork[] tasks = {
               new Task1() { user = user },
               new Task2() { user = user },
               new Task3(),
               new Task4(),
               new Task5()
            };
            Helper.WorkTasks(tasks);
            ConsoleMsg.ProgramEnded();
        }
        
    }
    
}
