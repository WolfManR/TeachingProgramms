﻿using System;
using HomeWorkLib;
using HWConsoleLibrary;

namespace HomeWork2
{
    public class Task3 : HomeWorkTask
    {

        public override string Title => "Сумма нечётных чисел";

        public override int TaskNumber => 3;

        public override string ToDo => "С клавиатуры вводятся числа, пока не будет введен 0.\nПодсчитать сумму всех нечетных положительных чисел.";

        public override void Work()
        {
            Console.WriteLine("Подсчёт колличества введённых нечётных чисел");
            Console.WriteLine("Вводите числа по запросу, завершающим в цепочке должет быть 0");
            int inputNumber;
            int sumNumbers = 0;
            do
            {
                Console.Write("число: ");
                inputNumber = Converters.ReadInt();
                if (inputNumber % 2 > 0) sumNumbers += inputNumber;
            } while (inputNumber != 0);
            Console.WriteLine("сумма нечётных чисел равна " + sumNumbers);
        }
    }
}