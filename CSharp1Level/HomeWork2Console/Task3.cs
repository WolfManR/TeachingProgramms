using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

namespace HomeWork2Console
{
    public class Task3 : ITaskWork
    {
        public void Work()
        {
            Console.WriteLine("Подсчёт колличества введённых нечётных чисел");
            Console.WriteLine("Вводите числа по запросу, завершающим в цепочке должет быть 0");
            int inputNumber;
            int sumNumbers = 0;
            do
            {
                Console.Write("число: ");
                inputNumber = Helper.ReadInt();
                if (inputNumber % 2 > 0) sumNumbers += inputNumber;
            } while (inputNumber != 0);
            Console.WriteLine("сумма нечётных чисел равна " + sumNumbers);
        }
    }
}
