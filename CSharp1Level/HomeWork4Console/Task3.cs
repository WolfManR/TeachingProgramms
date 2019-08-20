using HomeWorkLib;
using HWConsoleLibrary;
using HWConsoleLibrary.Arrays;
using System;

namespace HomeWork4
{
    public class Task3 : HomeWorkTask
    {
        public override string Title => "Дописываем класс работы с одномерным массивом";

        public override int TaskNumber => 3;

        public override string ToDo => "а) Дописать класс для работы с одномерным массивом." +
                                       "\nРеализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом." +
                                       "\nСоздать свойство Sum, которое возвращает сумму элементов массива, " +
                                       "\nметод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений)," +
                                       "\nметод Multi, умножающий каждый элемент массива на определённое число," +
                                       "\nсвойство MaxCount, возвращающее количество максимальных элементов." +
                                       "\n\nб)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки." +
                                       "\n\n*** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)";

        public override void Work()
        {
            OneRankArray one = new OneRankArray(
                uint.Parse(ConsoleMsg.GetValueInMsgLine("Укажите размер массива")),
                int.Parse(ConsoleMsg.GetValueInMsgLine("Укажите число с которого начнётся заполнение массива")),
                int.Parse(ConsoleMsg.GetValueInMsgLine("Укажите шаг заполнения")));

            Console.WriteLine("\nМассив \n" + one.ToString());

            Console.WriteLine("\nСумма элементов массива " + one.Sum);

            int[] inverse = one.Inverse();
            Console.WriteLine("\nИнверсированный массив");
            foreach (var item in inverse) Console.Write(item + " ");

            int number = int.Parse(ConsoleMsg.GetValueInMsgLine("\n\nУкажите число на которое будут умножены значения массива"));
            one.Multi(number);
            Console.WriteLine($"\nМассив после умножения на {number}\n" + one.ToString());


            Console.WriteLine("\nСоздаём новый массив со случайными числами для демонстрации остальных методов задачи");
            one = new OneRankArray(100);
            Console.WriteLine("\nНовый массив\n"+one.ToString()+"\n");
            Console.WriteLine("\nКолличество максимальных элементов "+one.MaxCount);

            Console.WriteLine("\nЧастота вхождения элементов в массиве");
            foreach (var item in one.CountSameElements()) Console.WriteLine("элемент: "+item.Key+" повторяется: "+item.Value);
        }

        
    }
}
