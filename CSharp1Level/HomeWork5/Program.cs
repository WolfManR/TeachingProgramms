using HomeWorkLib;
using HWConsoleLibrary;
using HWConsoleLibrary.Extensions;
using System;
//Иван Бармин
namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWorkTask[] tasks = { new Task1(), new Task2(), new Task3(), new Task4(), new Task5() };
            string selectedMenuMember;
            do
            {
                Menu(tasks);
                selectedMenuMember = Console.ReadLine();
                switch (selectedMenuMember)
                {
                    case "1":
                        tasks[0].DecorativeWork();
                        break;
                    case "2":
                        tasks[1].DecorativeWork();
                        break;
                    case "3":
                        tasks[2].DecorativeWork();
                        break;
                    case "4":
                        tasks[3].DecorativeWork();
                        break;
                    case "5":
                        tasks[4].DecorativeWork();
                        break;
                    case "0":
                        Console.WriteLine("\nДо свидания");
                        break;
                    default:
                        Console.WriteLine("\nУ нас нет задачи с таким номером, проверьте меню и введите команду ещё раз");
                        break;
                }
            } while (selectedMenuMember != "0");

            ConsoleMsg.ProgramEnded();
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
