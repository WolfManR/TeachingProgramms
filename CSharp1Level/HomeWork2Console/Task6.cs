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
            ToDo = "*Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000." +
                   "\nХорошим называется число, которое делится на сумму своих цифр. " +
                   "\nРеализовать подсчет времени выполнения программы, используя структуру DateTime.";
        }

        public override void Work()
        {
            string iInString;
            int counter = 0;
            var startTime = DateTime.Now;
            for (int i = startNumber; i <= endNumber; i++)
            {
                iInString = i.ToString();
                int delNumber = 0;
                foreach (var item in iInString) delNumber += (int)char.GetNumericValue(item);
                if (i % delNumber == 0) counter++;
                if (i % 1_000_000 == 0) Console.WriteLine($"Working... Мы сейчас на числе { i: 0,0} ,  хороших чисел сейчас: {counter:0,0}");
            }
            var endTime = DateTime.Now;
            TimeSpan workTime = endTime - startTime;
            Console.WriteLine($"\n Процедура заняла: {workTime.Days} дней, {workTime.Hours} часов, {workTime.Minutes} минут и {workTime.Seconds} секунд");
            Console.WriteLine($"\nхороших чисел {counter:0,0}");
        }
    }
}
