using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            FillUserInfo(ref user);
            //Задание 1
            ReadUserInfo(user);
            //Задание 2
            Console.WriteLine("Вы хотите узнать индекс массы тела:\n1 - себя\n2 - другого человека");
            if(int.Parse(Console.ReadLine()) == 2)
            {
                Console.Write("укажите рост в см: ");
                float h = float.Parse(Console.ReadLine());
                Console.Write("\nукажите вес в кг: ");
                int w = int.Parse(Console.ReadLine());
                IMT(h, w);
            }
            else
            {
                IMT(user.Height, user.Weight);
            }
            Console.ReadLine();
        }
        static void IMT(float height,int weight)
        {
            float h = height / 100;
            Console.WriteLine($"ИМТ равен {weight / h * h}");
        }
        static void FillUserInfo(ref User user)
        {
            Console.WriteLine("Введите информацию о себе");
            Console.Write("Ваше имя: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Ваша фамилия: ");
            user.LastName = Console.ReadLine();
            Console.Write("Ваш возраст: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.Write("Ваш рост: ");
            user.Height = int.Parse(Console.ReadLine());
            Console.Write("Ваш вес: ");
            user.Weight = int.Parse(Console.ReadLine());
        }
        static void ReadUserInfo(User user)
        {
            Console.WriteLine("Конкатенация");
            Console.Write("Это вы: ");
            Console.WriteLine(user.LastName + " " + user.FirstName + " " + user.Age + " лет, вес " + user.Weight + "кг, рост состовляет " + user.Height + "см");
            Console.WriteLine("Форматированный вывод");
            Console.Write("Это вы: ");
            Console.WriteLine("{0} {1} {2:0 лет}, вес {3}кг, {4:рост состовляет 0,0}см", user.LastName,user.FirstName,user.Age,user.Weight,user.Height);
            Console.WriteLine("Интерполяция");
            Console.Write("Это вы: ");
            Console.WriteLine($"{user.LastName} {user.FirstName} {user.Age} лет, вес {user.Weight}кг, рост состовляет {user.Height}см");
        }
    }

    public class User
    {
        public string FirstName { get; set; } = "Karl";
        public string LastName { get; set; } = "Sorze";
        public int Age { get; set; } = 47;
        public int Height { get; set; } = 1830;
        public int Weight { get; set; } = 102;
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
