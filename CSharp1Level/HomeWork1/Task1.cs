﻿using System;
using HomeWorkLib;

namespace HomeWork1
{
    public class Task1:IHWTaskWork
    {
        public User User { get; set; } = new User();
        public void Work()
        {
            WriteInConsoleUserInfo(User);
        }

        void WriteInConsoleUserInfo(User user)
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
    }
}
