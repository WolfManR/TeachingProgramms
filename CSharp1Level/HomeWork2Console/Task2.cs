using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

namespace HomeWork2
{
    public class Task2 : HomeWorkTask
    {

        public override string Title => "Колличество цифр в числе";

        public override int TaskNumber => 2;

        public override string ToDo => "Написать метод подсчета количества цифр числа.";

        public override void Work()
        {
            Console.WriteLine("Введите число положительное целочисленное число любой длины");
            string number;
            bool isNumber = false;
            do
            {
                number = Console.ReadLine();
                if (!Helper.CheckStringNumber(number))
                {
                    Console.WriteLine("вы ввели не запрошенное число, повторите ввод числа\nоно должно быть \"положительное целочисленное число любой длины\"");
                }
                else isNumber = true;
            }while (!isNumber);
            Console.WriteLine("в вашем числе " + NumLength(number) + " цифр");
        }
        int NumLength(string number) => number.Length;
    }
}
