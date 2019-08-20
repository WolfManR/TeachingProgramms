using System;
using System.Collections.Generic;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

namespace HomeWork3
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
            try
            {
                List<int> OddNumbers = GetOddNumbers(out int sumNumbers);
                Console.WriteLine("сумма нечётных чисел равна " + sumNumbers);
                Console.WriteLine("Введённые нечётные числа");
                foreach (int OddNumber in OddNumbers)
                {
                    Console.Write(OddNumber + " ");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<int> GetOddNumbers(out int sum)
        {
            List<int> OddNumbers = new List<int>();
            int inputNumber;
            sum = 0;
            do
            {
                if (int.TryParse(Helper.GetValueInMsgLine("число:"), out inputNumber))
                {
                    if (inputNumber % 2 > 0)
                    {
                        OddNumbers.Add(inputNumber);
                        sum += inputNumber;
                    }
                }
                else throw new FormatException("Надо было вводить целые числа");
            } while (inputNumber != 0);
            return OddNumbers;
        }
    }
}
