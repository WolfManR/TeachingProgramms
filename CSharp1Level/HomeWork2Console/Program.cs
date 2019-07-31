using System;
using HomeWorkLib.ConsoleWork;

namespace HomeWork2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectedMenuMember;
            HomeWorkLib.HomeWorkTask task;
            do
            {
                Menu();
                selectedMenuMember = Console.ReadLine();
                switch (selectedMenuMember)
                {
                    case "1":
                        Console.Clear();
                        task = new Task1();
                        task.DecorativeWorkInConsole();
                        break;
                    case "2":
                        Console.Clear();
                        task = new Task2();
                        task.DecorativeWorkInConsole();
                        break;
                    case "3":
                        Console.Clear();
                        task = new Task3();
                        task.DecorativeWorkInConsole();
                        break;
                    case "4":
                        Console.Clear();
                        task = new Task4();
                        task.DecorativeWorkInConsole();
                        break;
                    case "5":
                        Console.Clear();
                        task = new Task5();
                        task.DecorativeWorkInConsole();
                        break;
                    case "6":
                        Console.Clear();
                        task = new Task6();
                        task.DecorativeWorkInConsole();
                        break;
                    case "7":
                        Console.Clear();
                        task = new Task7();
                        task.DecorativeWorkInConsole();
                        break;
                    case "0":
                        Console.WriteLine("\nДо свидания");
                        break;
                    default:
                        Console.WriteLine("\nУ нас нет задачи с таким номером, проверьте меню и введите команду ещё раз");
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
