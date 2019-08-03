using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task4 : HomeWorkTask
    {
        const string trueUserLogin = "root";
        const string trueUserPass = "GeekBrains";
        public override string Title => "Аутентификация";

        public override int TaskNumber => 4;

        public override string ToDo => "Реализовать метод проверки логина и пароля. " +
                                       "\n\nНа вход подается логин и пароль. " +
                                       "\nНа выходе истина, если прошел авторизацию, " +
                                       "\nи ложь, если не прошел (Логин: root, Password: GeekBrains). " +
                                       "\n\nИспользуя метод проверки логина и пароля, написать программу: " +
                                       "\nпользователь вводит логин и пароль, " +
                                       "\nпрограмма пропускает его дальше или не пропускает. " +
                                       "\n\nС помощью цикла do while ограничить ввод пароля тремя попытками.";

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
