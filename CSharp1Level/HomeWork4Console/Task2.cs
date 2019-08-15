using HomeWorkLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork4Console
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
            throw new System.NotImplementedException();
        }

        public static class StaticClass
        {
            public static void Task1Work(int[] array)
            {
                Task1 task = new Task1(array);
                task.Work();
            }

            public static int[] ReadArrayFromTextFile(string filename)
            {
                int[] arr;
                StreamReader sr = new StreamReader(filename);
                List<int> list = new List<int>();
                for (int i = 0; sr.EndOfStream; i++)
                {
                    list.Add(int.Parse(sr.ReadLine()));
                }
                sr?.Close();
                arr = new int[list.Count];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = list[i];
                }
                return arr;

            }
        }
    }
}
