using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task3 : ITaskWork
    {
        public void Work()
        {
            int[] numbers = new int[] { };
            int inputNumber = 1;
            Console.WriteLine("Подсчёт колличества введённых нечётных чисел");
            Console.WriteLine("Вводите числа по запросу, завершающим в цепочке должет быть 0");
            do
            {
                Console.Write("число: ");
                Console.ReadLine();
            } while (inputNumber != 0);
        }
    }
}
