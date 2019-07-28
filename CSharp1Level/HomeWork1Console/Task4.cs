using System;

namespace HomeWork1Console
{
    public class Task4 : TaskWork
    {
        public void Work()
        {
            int c = 5;
            int g = 8;
            Console.WriteLine("Обмен с третьей переменной");
            Console.WriteLine($"значения переменных до обмена {c} и {g}");
            TurnVarsWithThirdVar(ref c, ref g);
            Console.WriteLine($"значения переменных после обмена {c} и {g}");
            c = 7;
            g = 42;
            Console.WriteLine("\nОбмен без третьей переменной");
            Console.WriteLine($"значения переменных до обмена {c} и {g}");
            TurnVarsWithoutThirdVar(ref c, ref g);
            Console.WriteLine($"значения переменных после обмена {c} и {g}");
        }
        void TurnVarsWithoutThirdVar(ref int a, ref int b)
        {
            a ^= b;
            b = a ^ b;
            a ^= b;
        }

        void TurnVarsWithThirdVar(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
    }
}
