using System;
using HomeWorkLib;

namespace HomeWork2
{
    public class Task1 : HomeWorkTask
    {
        public override string Title { get; } = "Минимальное число";
        public override int TaskNumber { get; } = 1;
        public override string ToDo { get; } = "Написать метод, возвращающий минимальное из трех чисел.";

        public override void Work()
        {
            Console.WriteLine("находим минимальное число передавая массив целых чисел (2, 4, 7) в параметре метода.\nМинимальное число "+Min(new int[] { 2, 4, 7 }));
            Console.WriteLine("находим минимальное число перечислением чисел (4, 98, 8) в параметре метода.\nМинимальное число " + Min(4, 98, 8));
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
