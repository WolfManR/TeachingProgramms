using HomeWorkLib;
using HWConsoleLibrary;
using HWConsoleLibrary.Arrays;
using System;

namespace HomeWork4
{
    public class Task5 : HomeWorkTask
    {
        public override string Title => "Библиотека двумерного массива";

        public override int TaskNumber => 5;

        public override string ToDo => "*а) Реализовать библиотеку с классом для работы с двумерным массивом." +
                                       "\nРеализовать конструктор, заполняющий массив случайными числами." +
                                       "\nСоздать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, " +
                                       "\nсвойство, возвращающее минимальный элемент массива, " +
                                       "\nсвойство, возвращающее максимальный элемент массива, " +
                                       "\nметод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)." +
                                       "\n\n**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл." +
                                       "\n\n**в) Обработать возможные исключительные ситуации при работе с файлами.";

        public override void Work()
        {
            TwoRankArray two = new TwoRankArray(20, 5, 15);

            Console.WriteLine("Массив\n"+two.ToString());

            Console.WriteLine("\nСумма всех элементов массива "+two.GetSum());
            int borderValue = int.Parse(ConsoleMsg.GetValueAfterMsgLine("\nВведите число нижнюю границу чисел входящих в сумму"));
            Console.WriteLine("\nСумма всех элементов массива выше заданного "+two.GetSum(borderValue));

            Console.WriteLine("\nНаименьшее число в массиве "+two.Min);
            Console.WriteLine("\nНаибольшее число в массиве "+two.Max);
            (int index1, int index2) maxIndex=(0,0);
            two.MaxIndex(out maxIndex);
            Console.WriteLine("Максимальное число массива по его индексу "+two[maxIndex.index1,maxIndex.index2]);

            string filename = ConsoleMsg.GetValueInMsgLine("\nПробуем записать сгенерированный массив в файл, укажите имя файла");
            two = new TwoRankArray(20, 5, 15);
            two.WriteToFile(filename);

            filename = ConsoleMsg.GetValueInMsgLine("\nПробуем получить массив из файла, укажите имя файла");
            two = new TwoRankArray(filename);
            Console.WriteLine("Массив\n" + two.ToString());
        }
    }
}
