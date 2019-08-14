using HomeWorkLib;
using HomeWorkLib.ConsoleWork;
using System;

namespace HomeWork4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWorkTask[] tasks = { new Task1(), new Task2(), new Task3(),new Task4(),new Task5() };
            string selectedMenuMember;
            do
            {
                Menu(tasks);
                selectedMenuMember = Console.ReadLine();
                switch (selectedMenuMember)
                {
                    case "1":
                        tasks[0].DecorativeWorkInConsole();
                        break;
                    case "2":
                        tasks[1].DecorativeWorkInConsole();
                        break;
                    case "3":
                        tasks[2].DecorativeWorkInConsole();
                        break;
                    case "4":
                        tasks[3].DecorativeWorkInConsole();
                        break;
                    case "5":
                        tasks[4].DecorativeWorkInConsole();
                        break;
                    case "0":
                        Console.WriteLine("\nДо свидания");
                        break;
                    default:
                        Console.WriteLine("\nУ нас нет задачи с таким номером, проверьте меню и введите команду ещё раз");
                        break;
                }
            } while (selectedMenuMember != "0");

            Helper.ProgramEnded();
        }
        static void Menu(HomeWorkTask[] tasks)
        {
            Console.Clear();
            //int lastTaskNumber = 0;
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskNumber}. {task.Title}");
                //lastTaskNumber = task.TaskNumber;
            }
            Console.WriteLine("0. Exit");
        }
    }
}
