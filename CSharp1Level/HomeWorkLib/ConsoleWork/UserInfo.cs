using System;

namespace HomeWorkLib
{
    public partial class User
    {
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
