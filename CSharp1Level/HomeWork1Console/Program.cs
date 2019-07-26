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
