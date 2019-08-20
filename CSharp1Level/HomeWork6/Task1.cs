using HomeWorkLib;
using HWConsoleLibrary;
using System;

namespace HomeWork6
{
    internal class Task1 : HomeWorkTask
    {
        public override string Title => "Простой делегат";

        public override int TaskNumber => 1;

        public override string ToDo => "Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double)." +
                                       "\nПродемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x)";
        public override void Work()
        {
            Converters.funcMsg = ConsoleMsg.GetValueInMsgLine;
            Func<double,double,double> function;

            Console.WriteLine("Демонстрация взаимодействия делегата и функции с уравнением a*x^2");
            double a = int.Parse("Введите значение переменной a");
            double x = int.Parse("Введите значение переменной x");
            function = (c, d) => c * Math.Pow(d, 2);
            Console.WriteLine($"рельтат уравнения: {function?.Invoke(a, x)}");

            Console.WriteLine("Демонстрация взаимодействия делегата и функции с уравнением a*sin(x)");
            a = int.Parse("Введите значение переменной a");
            x = int.Parse("Введите значение переменной x");
            function = (c, d) => c * Math.Sin(d);
            Console.WriteLine($"рельтат уравнения: {function?.Invoke(a, x)}");
        }
    }
}