using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

// Иван Бармин

namespace HomeWork1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            
            //                             Задание 1
            Console.WriteLine("Вы будете вводить информацию о себе? \n<2 - да\n>=2 - нет");
            if (Helper.ReadInt() < 2) user.FillUserInfo();

            ITaskWork[] tasks = {
               new Task1() { user = user },
               new Task2() { user = user },
               new Task3(),
               new Task4(),
               new Task5()
            };
            Helper.WorkTasks(tasks);
            Helper.ProgramEnded();
        }
        
    }
    
}
