using HomeWorkLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork4Console
{
    public class Task4 : HomeWorkTask
    {
        public override string Title => "Account";

        public override int TaskNumber => 4;

        public override string ToDo => "Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив." +
                                       "\nСоздайте структуру Account, содержащую Login и Password.";

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
        bool CheckUser(string login, string pass)
        {
            foreach (var item in GetAccounts("Accounts"))
                if (login == item.Login & pass == item.Password) return true;
            return false;
        }
        Account[] GetAccounts(string filename)
        {
            List<Account> accounts = new List<Account>();
            try
            {
                StreamReader sr = new StreamReader(filename + ".txt");
                accounts.Add(new Account(sr.ReadLine()));
                sr?.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return accounts.ToArray();
        }

        public struct Account
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public Account(string login, string pass)
            {
                Login = login;
                Password = pass;
            }
            public Account(string loginPass)
            {
                string[] str = loginPass.Split(',');
                Login = str[0];
                Password = str[1];
            }
            public override string ToString()
            {
                return Login + "," + Password;
            }
        }
    }
}
