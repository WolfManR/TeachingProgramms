﻿using HomeWorkLib;
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

        // Описываем делегат. В делегате описывается сигнатура методов, на
        // которые он сможет ссылаться в дальнейшем (хранить в себе)
        public delegate double Fun(double x);

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public override void Work()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double x) { return x * x; }, 0, 3);



            Converters.funcMsg = ConsoleMsg.GetValueInMsgLine;
            Func<double,double,double> function;

            Console.WriteLine("Демонстрация взаимодействия делегата и функции с уравнением a*x^2");
            double n = int.Parse("Введите значение переменной a");
            double q = int.Parse("Введите значение переменной x");
            function = (c, d) => c * Math.Pow(d, 2);
            Console.WriteLine($"рельтат уравнения: {function?.Invoke(n, q)}");

            Console.WriteLine("Демонстрация взаимодействия делегата и функции с уравнением a*sin(x)");
            n = int.Parse("Введите значение переменной a");
            q = int.Parse("Введите значение переменной x");
            function = (c, d) => c * Math.Sin(d);
            Console.WriteLine($"рельтат уравнения: {function?.Invoke(n, q)}");
        }
    }
}