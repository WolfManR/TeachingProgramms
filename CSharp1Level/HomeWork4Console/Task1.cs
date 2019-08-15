using HomeWorkLib;
using System;

namespace HomeWork4Console
{
    public class Task1 : HomeWorkTask
    {
        public override string Title => "Колличество пар в массиве";

        public override int TaskNumber => 1;

        public override string ToDo => "Дан целочисленный  массив из 20 элементов." +
                                       "\nЭлементы массива могут принимать целые значения от –10 000 до 10 000 включительно." +
                                       "\nЗаполнить случайными числами." +
                                       "\n\nНаписать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3." +
                                       "\n\n!!!В данной задаче под парой подразумевается два подряд идущих элемента массива." +
                                       "\nНапример, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.";
        public int[] Numbers { get; set; } = new int[20];
        public Task1() { }
        public Task1(int[] array)
        {
            Numbers = array;
        }
        public override void Work()
        {
            int defaultCount = 0;
            foreach (var item in Numbers) if (item == 0) defaultCount++;
            if (defaultCount==Numbers.Length)
            {
                Random rand = new Random();
                for (int i = 0; i < Numbers.Length; i++) Numbers[i] = rand.Next(-10_000, 10_000);
            }

            int oldNumber = Numbers[0], newNumber = 0, counter = 0;
            for (int i = 1; i < Numbers.Length; i++)
            {
                newNumber = Numbers[i];
                if ((oldNumber % 3 == 0 & newNumber % 3 != 0) || (oldNumber % 3 != 0 & newNumber % 3 == 0)) counter++;
                oldNumber = newNumber;
            }

            Console.WriteLine("Массив состоит из чисел:");
            foreach (var item in Numbers) Console.Write(item + " ");
            Console.WriteLine("\n");
            Console.WriteLine("Количество пар чисел "+counter);
        }
    }
}
