using System;
namespace HomeWork1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            Console.WriteLine("Вы будете вводить информацию о себе? \n<0 - да\n>0 - нет");
            if (ReadInt() < 0) FillUserInfo(ref user);

            //Задание 1
            ReadUserInfo(user);
            //Задание 2
            Console.WriteLine("Вы хотите узнать индекс массы тела:\n1 - себя(если данные не заполнялись будут использованы значения по умолчанию)\n2 - другого человека");
            if (ReadInt() == 2)
            {
                Console.Write("укажите рост в см: ");
                float h = float.Parse(Console.ReadLine());
                Console.Write("\nукажите вес в кг: ");
                int w = ReadInt();
                IMT(h, w);
            }
            else
            {
                IMT(user.Height, user.Weight);
            }
            //Задание 3
            Point a = new Point() { X = 184, Y = 206 };
            Point b = new Point() { X = 345, Y = 251 };
            Console.WriteLine("Вы будете вводить свои точки координат? \n<0 - да\n>0 - нет");
            if (ReadInt() < 0)
            {
                Console.WriteLine("первая точка");
                
                Console.WriteLine("\nвторая точка");
                
            }

            DistanceBetweenPoints(a, b);
            Console.ReadLine();
        }

        static void DistanceBetweenPoints(Point first, Point second)
        {
            var result = Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
            Console.WriteLine($"Расстояние между точками {result:f2}");
        }
        static void IMT(float height, int weight)
        {
            float h = height / 100;
            Console.WriteLine($"ИМТ равен {weight / (h * h)}");
        }
        static void FillUserInfo(ref User user)
        {
            Console.WriteLine("Введите информацию о себе");
            Console.Write("Ваше имя: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Ваша фамилия: ");
            user.LastName = Console.ReadLine();
            Console.Write("Ваш возраст: ");
            user.Age = ReadInt();
            Console.Write("Ваш рост: ");
            user.Height = ReadInt();
            Console.Write("Ваш вес: ");
            user.Weight = ReadInt();
        }
        static void FillPoint(ref Point point)
        {
            Console.Write("\nX ");
            point.X = ReadInt();
            Console.Write("\nY ");
            point.Y = ReadInt();
        }
        static void ReadUserInfo(User user)
        {
            Console.WriteLine("Конкатенация");
            Console.Write("Это вы: ");
            Console.WriteLine(user.LastName + " " + user.FirstName + " " + user.Age + " лет, вес " + user.Weight + "кг, рост состовляет " + user.Height + "см");
            Console.WriteLine("Форматированный вывод");
            Console.Write("Это вы: ");
            Console.WriteLine("{0} {1} {2:0 лет}, вес {3}кг, {4:рост состовляет 0,0}см", user.LastName, user.FirstName, user.Age, user.Weight, user.Height);
            Console.WriteLine("Интерполяция");
            Console.Write("Это вы: ");
            Console.WriteLine($"{user.LastName} {user.FirstName} {user.Age} лет, вес {user.Weight}кг, рост состовляет {user.Height}см");
        }
        static int ReadInt() => int.Parse(Console.ReadLine());
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
