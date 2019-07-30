using System;

namespace HomeWork2Console
{
    class Program
    {
        static void Main(string[] args)
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

        

        

        static bool CheckUser(string login, string pass)
        {
            string trueUserLogin = "root";
            string trueUserPass = "GeekBrains";
            return (login == trueUserLogin & pass == trueUserPass) ? true : false;
        }
    }
}
