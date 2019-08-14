using HomeWorkLib;
using System;

namespace HomeWork4Console
{
    public class Task1 : HomeWorkTask
    {
        public override string Title => "Колличество пар в массиве";

        public override int TaskNumber => 1;

        public override string ToDo => "Дан целочисленный  массив из 20 элементов." +
                                       "\nЭлементы массива могут принимать целые значения от –10 000 до 10 000 включительно." +
                                       "\nЗаполнить случайными числами." +
                                       "\n\nНаписать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3." +
                                       "\n\n!!!В данной задаче под парой подразумевается два подряд идущих элемента массива." +
                                       "\nНапример, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.";

        public override void Work()
        {
            throw new NotImplementedException();
        }
    }
}
