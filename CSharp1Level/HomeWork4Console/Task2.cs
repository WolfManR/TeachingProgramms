using HomeWorkLib;
using HomeWorkLib.ConsoleWork;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork4
{
    public class Task2 : HomeWorkTask
    {
        public override string Title => "StaticClass";

        public override int TaskNumber => 2;
        // спасибо посмеялся
        public override string ToDo => "Реализуйте задачу 1 в виде статического класса StaticClass;" +
                                       "\nа) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;" +
                                       "\nб) * Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;" +
                                       "\n\nв)** Добавьте обработку ситуации отсутствия файла на диске.";

        public override void Work()
        {
            string filename=Helper.GetValueInMsgLine("Укажите имя файла в каталоге исполняемого файла приложения");
            StaticClass.Task1Work(StaticClass.ReadArrayFromTextFile(filename));
        }

        public static class StaticClass
        {
            public static void Task1Work(int[] array)
            {
                Task1 task = new Task1(array);
                try
                {
                    task.Work();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }

            public static int[] ReadArrayFromTextFile(string filename)
            {
                List<int> list = new List<int>();
                try
                {
                    StreamReader sr = new StreamReader(filename + ".txt");

                    for (int i = 0; !sr.EndOfStream; i++)
                    {
                        list.Add(int.Parse(sr.ReadLine()));
                    }
                    sr?.Close();
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так");
                    throw;
                }
                return list.ToArray();
            }
        }
    }
}
