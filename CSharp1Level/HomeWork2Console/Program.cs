using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

// Иван Бармин

namespace HomeWork2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWorkTask[] tasks={new Task1(),new Task2(),new Task3(),new Task4(),new Task5(),new Task6(),new Task7()};
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
                    case "6":
                        tasks[5].DecorativeWorkInConsole();
                        break;
                    case "7":
                        tasks[6].DecorativeWorkInConsole();
                        break;
                    case "8":
                        Console.Clear();
                        Flag();
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

        static void Flag()
        {
            int height = 24;
            int width = 3 * height;
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.BackgroundColor=(i < Convert.ToInt32(height/3)) ? ConsoleColor.White :(i< Convert.ToInt32(height/3)*2) ? ConsoleColor.Blue:ConsoleColor.Red;
                    Console.WriteLine(" ");
                }
            }
            Console.ReadLine();
            Console.ResetColor();
        }

        static void Menu(HomeWorkTask[] tasks)
        {
            Console.Clear();
            int lastTaskNumber=0;
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskNumber}. {task.Title}");
                lastTaskNumber=task.TaskNumber;
            }
            Console.WriteLine($"{lastTaskNumber+1}. Русский флаг");
            Console.WriteLine("0. Exit");
        }
        

        
    }
}
