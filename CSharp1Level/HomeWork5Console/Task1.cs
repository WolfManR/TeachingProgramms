using HomeWorkLib;
using HomeWorkLib.ConsoleWork;
using System;
using System.Text.RegularExpressions;

namespace HomeWork5
{
    internal class Task1 : HomeWorkTask
    {
        public override string Title => "Проверка логина на соответсвие правилу";

        public override int TaskNumber => 1;

        public override string ToDo => "Создать программу, которая будет проверять корректность ввода логина. " +
                                       "\nКорректным логином будет строка от 2 до 10 символов, " +
                                       "\nсодержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:" +
                                       "\n\nа) без использования регулярных выражений;" +
                                       "\nб) с использованием регулярных выражений.";
        enum Choice { withRegex, withoutRegex }
        public override void Work()
        {
            string login;
            bool isCorrect=false;
            do
            {
                login = Helper.GetValueAfterMsgLine("Придумайте логин, по следующему правилу:" +
                                                    "\nлогин должен содержать от 2 до 10 символов латинского алфавита или цифр, при этом цифра не может быть первой");
                Choice choice = (int.Parse(Helper.GetValueInMsgLine("Введите для проверки:" +
                                                            "\n  <2 для использования регулярного выражения," +
                                                            "\n  >=2 без регулярного выражения\n")) < 2) ? Choice.withRegex : Choice.withoutRegex;
                try
                {
                    switch (choice)
                    {
                        case Choice.withRegex:
                            isCorrect=CheckMsgWithRegex(login);
                            break;
                        case Choice.withoutRegex:
                            isCorrect=CheckMsgWithoutRegex(login);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Helper.PrintColoredMsg(e.Message,ConsoleColor.Black,ConsoleColor.Red);
                }
            } while (!isCorrect);
            Console.WriteLine("\nВы ввели корректный логин");
        }

        public bool CheckMsgWithRegex(string Msg)
        {
            Regex regex = new Regex(@"^[A-Za-z]+[A-Za-z0-9]+$");
            if (Msg.Length < 10 && Msg.Length > 2)
            {
                if (regex.IsMatch(Msg)) return true;
                else throw new Exception("В логине должны содержаться только буквы латинского алфавита или цифры, при этом цифра не может быть первой\n");
            }
            throw new Exception("логин должен содержать от 2 до 10 символов\n");
        }
        public bool CheckMsgWithoutRegex(string Msg)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string upCaseLetters = letters.ToUpper();
            string numbers = "0123456789";
            if (Msg.Length < 10 && Msg.Length > 2)
            {
                if (!numbers.Contains(Msg[0].ToString()))
                {
                    int counter = 0;
                    for (int i = 1; i < Msg.Length; i++)
                        if (!letters.Contains(Msg[i].ToString()) && !upCaseLetters.Contains(Msg[i].ToString()) && !numbers.Contains(Msg[i].ToString()))
                        {
                            counter++;
                            break;
                        }
                    if (counter == 0) return true;
                }
                throw new Exception("В логине должны содержаться только буквы латинского алфавита или цифры, при этом цифра не может быть первой\n");
            }
            throw new Exception("логин должен содержать от 2 до 10 символов\n");
        }
    }
}