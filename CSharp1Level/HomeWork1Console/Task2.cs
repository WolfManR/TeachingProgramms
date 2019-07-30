using System;

namespace HomeWork1Console
{
    public class Task2 : TaskWork
    {
        public User user { get; set; } = new User();
        public void Work()
        {
            Console.WriteLine("Вы хотите узнать индекс массы тела:\n1 - по введённым данным в начале программы\n2 - другого человека");
            if (Helper.ReadInt() == 2)
            {
                Console.Write("укажите рост в см: ");
                float h = float.Parse(Console.ReadLine());
                Console.Write("\nукажите вес в кг: ");
                int w = Helper.ReadInt();
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
