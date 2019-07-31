using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task7 : ITaskWork
    {
        public void Work()
        {
            int a, b;
            do
            {
                Console.WriteLine("Введите два числа, одно должно быть меньше другого");
                Console.WriteLine("введите первое число");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("введите второе число");
                b = int.Parse(Console.ReadLine());
                if (a == b)
                    Console.WriteLine("числа не должны быть равны");
            } while (a == b);

            if (a > b)
            {
                printBetweenNumbers(b, a);
                Console.WriteLine("\nсумма чисел равна " + sumBetweenNumbers(b, a));
            }
            else
            {
                printBetweenNumbers(a, b);
                Console.WriteLine("\nсумма чисел равна " + sumBetweenNumbers(a, b));
            }
        }
        void printBetweenNumbers(int a, int b)
        {
            a++;
            if (a == b) return;
            else
            {
                Console.Write(a + " ");
                printBetweenNumbers(a, b);
            }
        }

        int sumBetweenNumbers(int a, int b)
        {
            a++;
            if (a == b) return 0;
            else return a + sumBetweenNumbers(a, b);
        }
    }
}
