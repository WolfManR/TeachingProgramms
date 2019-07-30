using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task4 : ITaskWork
    {
        const string trueUserLogin = "root";
        const string trueUserPass = "GeekBrains";
        public void Work()
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
            } while (!isUserExist || count > 0);
            Console.WriteLine("С возвращением, root!");
        }

        bool CheckUser(string login, string pass) => (login == trueUserLogin & pass == trueUserPass) ? true : false;
    }
}
