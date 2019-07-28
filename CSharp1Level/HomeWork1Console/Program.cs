using System;
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
            TaskWork task = new Task1() { user = user };
            task.Work();

            Console.WriteLine();

            //                             Задание 2
            task = new Task2() { user = user };
            task.Work();

            Console.WriteLine();

            //                             Задание 3
            task = new Task3();
            task.Work();

            Console.WriteLine();

            //                             Задание 4
            task = new Task4();
            task.Work();

            Console.WriteLine();

            //                             Задание 5
            task = new Task5();
            task.Work();

            Console.ReadLine();
        }
    }
}
