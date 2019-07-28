using System;
namespace HomeWork1Console
{
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
}
