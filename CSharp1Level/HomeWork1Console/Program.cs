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
            Console.WriteLine("Введите информацию о себе");
            Console.Write("Ваше имя: ");
            user.FirstName=Console.ReadLine();
            Console.Write("Ваша фамилия: ");
            user.LastName = Console.ReadLine();
            Console.Write("Ваш возраст: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.Write("Ваш рост: ");
            user.Height = int.Parse(Console.ReadLine());
            Console.Write("Ваш вес: ");
            user.Weight = int.Parse(Console.ReadLine());
            Console.ReadLine();
        }

        void WriteUserInfo(User user)
        {
            Console.WriteLine("Конкатенация");
            Console.Write("Это вы: ");
            Console.WriteLine(user.LastName + " " + user.FirstName + " " + user.Age + " лет, вес " + user.Weight + "кг, рост состовляет " + user.Height + "см");
            Console.WriteLine("Форматированный вывод");
            Console.Write("Это вы: ");
            Console.WriteLine("{1} {2} {3} лет, вес {4}кг, рост состовляет {5:N0}см",user.LastName,user.FirstName,user.Age,user.Weight,user.Height);
            Console.WriteLine("Интерполяция");
            Console.Write("Это вы: ");
            Console.WriteLine($"{user.LastName} {user.FirstName} {user.Age} лет, вес {user.Weight}кг, рост состовляет {user.Height}см");
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
