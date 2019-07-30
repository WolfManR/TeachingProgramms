using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task1 : ITaskWork
    {
        public void Work()
        {
            Console.WriteLine("находим минимальное число передавая массив целых чисел (2, 4, 7) в параметре метода "+Min(new int[] { 2, 4, 7 }));
            Console.WriteLine("находим минимальное число перечислением чисел (4, 98, 8) в параметре метода " + Min(4, 98, 8));
        }
        int Min(params int[] numbers)
        {
            int min = numbers[0];
            if (numbers.Length > 1)
                foreach (var item in numbers)
                {
                    if (item < min) min = item;
                }
            return min;
        }
    }
}
