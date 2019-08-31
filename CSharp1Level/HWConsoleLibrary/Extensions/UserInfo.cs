using HomeWorkLib;
using System;

namespace HWConsoleLibrary.Extensions
{
    public static class UserInfo
    {
        public static void FillUserInfo(this User user)
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
    }
}
