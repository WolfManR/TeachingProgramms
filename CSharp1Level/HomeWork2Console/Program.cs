using System;
using HomeWorkLib.ConsoleWork;

// Иван Бармин

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
                        TaskWork(new Task1());
                        break;
                    case "2":
                        TaskWork(new Task2());
                        break;
                    case "3":
                        TaskWork(new Task3());
                        break;
                    case "4":
                        TaskWork(new Task4());
                        break;
                    case "5":
                        TaskWork(new Task5());
                        break;
                    case "6":
                        TaskWork(new Task6());
                        break;
                    case "7":
                        TaskWork(new Task7());
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

        static void TaskWork(HomeWorkLib.HomeWorkTask taskToWork)
        {
            Console.Clear();
            var task = taskToWork;
            task.DecorativeWorkInConsole();
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
            Console.WriteLine("8. Русский флаг");
            Console.WriteLine("0. Exit");
        }
        

        
    }
}
