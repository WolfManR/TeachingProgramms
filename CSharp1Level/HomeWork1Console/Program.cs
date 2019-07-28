using System;
using static HomeWork1Console.Helper;
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
            if (ReadInt() < 2) user.FillUserInfo();

            TaskWork[] tasks = {
               new Task1() { user = user },
               new Task2() { user = user },
               new Task3(),
               new Task4(),
               new Task5()
            };
            WorkTasks(tasks);
            ProgramEnded();
        }
        
    }
    
}
