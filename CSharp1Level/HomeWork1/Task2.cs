using System;
using HomeWorkLib;
using HWConsoleLibrary;

namespace HomeWork1
{
    public class Task2 : IHWTaskWork
    {
        public User user { get; set; } = new User();
        public void Work()
        {
            Console.WriteLine("Вы хотите узнать индекс массы тела:\n1 - по введённым данным в начале программы\n2 - другого человека");
            if (Converters.ReadInt() == 2)
            {
                Console.Write("укажите рост в см: ");
                float h = float.Parse(Console.ReadLine());
                Console.Write("\nукажите вес в кг: ");
                int w = Converters.ReadInt();
                IMT(h, w);
            }
            else
            {
                IMT(user.Height, user.Weight);
            }
        }
        void IMT(float height, int weight)
        {
            float h = height / 100;
            Console.WriteLine($"ИМТ равен {weight / (h * h)}");
        }
    }
}
