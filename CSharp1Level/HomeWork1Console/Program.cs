using System;
namespace HomeWork1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            Console.WriteLine("Вы будете вводить информацию о себе? \n<0 - да\n>0 - нет");
            if (ReadInt() < 0) user.FillUserInfo();

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
                a.FillPoint();
                Console.WriteLine("\nвторая точка");
                b.FillPoint();
            }

            DistanceBetweenPoints(a, b);

            //Задание 4
            int c = 5;
            int g = 8;
            Console.WriteLine("Обмен с третьей переменной");
            Console.WriteLine($"значения переменных до обмена {c} и {g}");
            TurnVarsWithThirdVar(ref c,ref g);
            Console.WriteLine($"значения переменных после обмена {c} и {g}");
            c = 7;
            g = 42;
            Console.WriteLine("Обмен без третьей переменной");
            Console.WriteLine($"значения переменных до обмена {c} и {g}");
            TurnVarsWithoutThirdVar(ref c, ref g);
            Console.WriteLine($"значения переменных после обмена {c} и {g}");
            
            //Задание 5
            PrintMyInfo("Иван","Бармин","НЕ СКАЖУ!!!");
            Console.ReadLine();
        }
        static void PrintMyInfo(string firstName,string lastName,string city)
        {
            int CalcConsoleCenter(string msg)
            {
                return Console.BufferWidth / 2 - msg.Length/2;
            }
            string str = $"моё имя {firstName}";
            Console.CursorLeft += CalcConsoleCenter(str); 
            Console.WriteLine(str);
            str = $"фамилия {lastName}";
            Console.CursorLeft += CalcConsoleCenter(str);
            Console.WriteLine(str);
            str = $"город проживания {city}";
            Console.CursorLeft += CalcConsoleCenter(str);
            Console.WriteLine(str);
        }
        static void TurnVarsWithoutThirdVar(ref int a,ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        static void TurnVarsWithThirdVar(ref int a,ref int b)
        {
            int c = a;
            a = b;
            b = c;
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
        public void FillUserInfo()
        {
            Console.WriteLine("Введите информацию о себе");
            Console.Write("Ваше имя: ");
            FirstName = Console.ReadLine();
            Console.Write("Ваша фамилия: ");
            LastName = Console.ReadLine();
            Console.Write("Ваш возраст: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Ваш рост: ");
            Height = int.Parse(Console.ReadLine());
            Console.Write("Ваш вес: ");
            Weight = int.Parse(Console.ReadLine());
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void FillPoint()
        {
            Console.Write("\nX ");
            X = int.Parse(Console.ReadLine());
            Console.Write("\nY ");
            Y = int.Parse(Console.ReadLine());
        }
    }
}
