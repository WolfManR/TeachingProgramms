using HomeWorkLib;
using System;

namespace HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        void TaskMenu(HomeWorkTask[] array, int arrLength)
        {
            for (int i = 0; i < arrLength; i++)
            {
                Console.Write($"COMMAND: {i} 		Task №: {array[i].TaskNumber}\n The task: \n{array[i].ToDo}\n\n");
                Console.Write("***********************************************************************************************\n");
            }
            Console.Write("Exit command: -1\n");

            Console.Write("Enter the task command: ");
            int userInput = int.Parse(Console.ReadLine());

            PlayTask(userInput, array);
        }

        void PlayTask(int input, HomeWorkTask[] tasks)
        {
            if (input >= 0 && input < tasks.Length)
                tasks[input].Work();
            else if (input == -1)
                Console.Write("Goodbye!");
            else
                Console.Write("Something went wrong\n");
        }

        void HWMenu(HomeWork[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("////////////////////////////////////////////////////////////////////////////////////\n");
                Console.Write($"COMMAND: {i}		HW Number: {array[i].Number}\n  Theme: {array[i].Theme}\n\n");
            }
            Console.Write("Exit command: -1\n");
        }
    }

    public class HomeWork
    {
        public int Number { get; set; }
        public string Theme { get; set; }
        public delegate void Menu();
    }
}
