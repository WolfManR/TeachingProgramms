using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task6 : HomeWorkTask,ITaskWork
    {
        const int startNumber = 1;
        const int endNumber = 1_000_000_000;

        public Task6()
        {
            TaskNumber = 6;
            ToDo = "*Написать программу подсчета количества «Хороших» чисел " +
                   "в диапазоне от 1 до 1 000 000 000. " +
                   "Хорошим называется число, которое делится на сумму своих цифр. " +
                   "Реализовать подсчет времени выполнения программы, используя структуру DateTime.";
        }

        public override void Work()
        {
            string iInString;
            int counter = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                iInString = i.ToString();
                int delNumber = 0;
                foreach (var item in iInString) delNumber += (int)char.GetNumericValue(item);
                if (i % delNumber == 0) counter++;
                if (i % 1_000_000 == 0) Console.WriteLine("Working... Мы сейчас на числе " + i + ",  хороших чисел сейчас: " + counter);
            }
            Console.WriteLine("\nхороших чисел " + counter);
        }
    }
}
