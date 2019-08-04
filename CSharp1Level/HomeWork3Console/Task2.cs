using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

namespace HomeWork3Console
{
    public class Task2 : HomeWorkTask
    {
        public override string Title => "TryParse";

        public override int TaskNumber => 2;

        public override string ToDo => "а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке)." +
                                       "\nТребуется подсчитать сумму всех нечетных положительных чисел." +
                                       "\nСами числа и сумму вывести на экран, используя tryParse;" +
                                       "\n\nб) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные." +
                                       "\nПри возникновении ошибки вывести сообщение.Напишите соответствующую функцию;";

        public override void Work()
        {
            Console.WriteLine("Подсчёт колличества введённых нечётных чисел");
            Console.WriteLine("Вводите числа по запросу, завершающим в цепочке должет быть 0");
            int inputNumber;
            int sumNumbers = 0;
            do
            {
                Console.Write("число: ");
                int.TryParse(Console.ReadLine(),out inputNumber);
                if (inputNumber % 2 > 0) sumNumbers += inputNumber;
            } while (inputNumber != 0);
            Console.WriteLine("сумма нечётных чисел равна " + sumNumbers);
        }
    }
}
