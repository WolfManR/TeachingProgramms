using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task4 : HomeWorkTask,ITaskWork
    {
        const string trueUserLogin = "root";
        const string trueUserPass = "GeekBrains";

        public Task4()
        {
            TaskNumber = 4;
            ToDo = "Реализовать метод проверки логина и пароля. " +
                   "На вход подается логин и пароль. " +
                   "На выходе истина, если прошел авторизацию, " +
                   "и ложь, если не прошел (Логин: root, Password: GeekBrains). " +
                   "Используя метод проверки логина и пароля, написать программу: " +
                   "пользователь вводит логин и пароль, " +
                   "программа пропускает его дальше или не пропускает. " +
                   "С помощью цикла do while ограничить ввод пароля тремя попытками.";
        }

        public override void Work()
        {
            bool isUserExist = false;
            int count = 3;
            do
            {
                Console.WriteLine("Введите");
                Console.Write("логин: ");
                string inputLogin = Console.ReadLine();
                Console.Write("пароль: ");
                string inputPass = Console.ReadLine();

                if (CheckUser(inputLogin, inputPass))
                    isUserExist = true;
                else
                {
                    Console.WriteLine("логин или пароль не верны, попробуйте ещё раз\n");
                    count--;
                }
            } while (!isUserExist && count > 0);
            Console.WriteLine("С возвращением, root!");
        }

        bool CheckUser(string login, string pass) => (login == trueUserLogin & pass == trueUserPass) ? true : false;
    }
}
