using System;
using HomeWorkLib.ConsoleWork;

namespace HomeWork2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectedMenuMember;
            do
            {
                Menu();
                selectedMenuMember = Console.ReadLine();
                switch (selectedMenuMember)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "0":
                        Console.WriteLine("До свидания");
                        break;
                    default:
                        Console.WriteLine("У нас нет задачи с таким номером, проверьте меню и введите команду ещё раз");
                        break;
                }
            } while (selectedMenuMember!="0");







            Helper.ProgramEnded();
        }

        
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Task 5");
            Console.WriteLine("6. Task 6");
            Console.WriteLine("7. Task 7");
            Console.WriteLine("0. Exit");
        }
        

        
    }
}
