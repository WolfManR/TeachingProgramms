using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

namespace HomeWork2Console
{
    public class Task2 : HomeWorkTask,ITaskWork
    {
        public Task2()
        {
            TaskNumber = 2;
            ToDo = "Написать метод подсчета количества цифр числа.";
        }

        public override void Work()
        {
            Console.WriteLine("Введите число положительное целочисленное число любой длины");
            string number = Console.ReadLine();
            if (Helper.CheckStringNumber(number))
                Console.WriteLine("в вашем числе " + NumLength(number) + " цифр");
            else Console.WriteLine("вы ввели не запрошенное число");
        }
        int NumLength(string number) => number.Length;
    }
}
