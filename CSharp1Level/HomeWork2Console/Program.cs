using System;
using HomeWorkLib.ConsoleWork;

namespace HomeWork2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Min(new int[] { 2, 4, 7 }));
            Console.WriteLine(Min(4, 98, 8));

            Console.WriteLine("Введите число положительное целочисленное число любой длины");
            string number = Console.ReadLine();
            if (Helper.CheckStringNumber(number))
                Console.WriteLine("в вашем числе " + NumLength(number) + " цифр");
            else Console.WriteLine("вы ввели не запрошенное число");

            int[] numbers = new int[] { };
            int inputNumber = 1;
            Console.WriteLine("Подсчёт колличества введённых нечётных чисел");
            Console.WriteLine("Вводите числа по запросу, завершающим в цепочке должет быть 0");
            do
            {
                Console.Write("число: ");
                Console.ReadLine();
            } while (inputNumber != 0);

            bool isUserExist = false;
            int count = 3;
            do
            {
                Console.WriteLine("Введите");
                Console.Write("логин: ");
                string inputLogin = Console.ReadLine();
                Console.Write("пароль: ");
                string inputPass = Console.ReadLine();
                if (CheckUser(inputLogin, inputPass))
                    isUserExist = true;
                else
                {
                    Console.WriteLine("логин или пароль не верны, попробуйте ещё раз\n");
                    count--;
                }
            } while (!isUserExist || count > 0);
            Console.WriteLine("С возвращением, root!");

            Console.ReadKey();
        }

        static int Min(params int[] numbers)
        {
            int min = numbers[0];
            if (numbers.Length > 1)
                foreach (var item in numbers)
                {
                    if (item < min) min = item;
                }
            return min;
        }

        static int NumLength(string number) => number.Length;

        static bool CheckUser(string login, string pass)
        {
            string trueUserLogin = "root";
            string trueUserPass = "GeekBrains";
            return (login == trueUserLogin & pass == trueUserPass) ? true : false;
        }
    }
}
