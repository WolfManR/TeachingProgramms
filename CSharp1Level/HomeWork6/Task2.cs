using HomeWorkLib;
using HWConsoleLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork6
{
    internal class Task2 : HomeWorkTask
    {
        const string filename = "data.bin";
        public override string Title => "Делегат как параметр";

        public override int TaskNumber => 2;

        public override string ToDo => "Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата." +
                                       "\nа) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум." +
                                       "\nб) Используйте массив(или список) делегатов, в котором хранятся различные функции." +
                                       "\nв) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.";
        public List<Delegate> Functions { get; set; } = new List<Delegate>()
        {
            new Delegate(){ ID = 1, Title = "Базовая функция", Desc = "да фиг её знает для чего она!", Function = F },
            new Delegate(){ ID = 2, Title = "Новая функция", Desc = "то же что и с первой фиг её знает", Function = (x) => x * 2 + 40 }
        };

        public struct Delegate
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Desc { get; set; }
            public Function Function { get; set; }
        }

        public delegate double Function(double x);

        #region SaveFunc
        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            //            StreamWriter sw = new StreamWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                //                sw.WriteLine(F(x));
                x += h;//x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static void SaveFunc(string fileName, double a, double b, double h, Function func)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(func(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        #endregion

        #region Load
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                //Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        public static double[] Load(string fileName, out double min)
        {
            List<double> result = new List<double>();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                result.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return result.ToArray();
        }
        #endregion

        public static double F(double x) => x * x - 50 * x + 10;


        public Function MenuOfFunctions(List<Delegate> delegates)
        {
            Function result = (x) =>
            {
                Console.WriteLine("Это пустышка");
                return 0;
            };
            Converters.funcMsg = ConsoleMsg.GetValueInMsgLine;

            Console.WriteLine("Меню выбора функции:");
            foreach (var item in delegates) Console.WriteLine($"функция {item.ID}: {item.Title} имеет назначение \"{item.Desc}\"");
            int userInput = Converters.ReadInt("Выберите номер функции для обработки файла ");
            int counter = 0;
            foreach (var item in delegates)
            {
                if (userInput == item.ID) result = item.Function;
                else counter++;
            }
            if (counter == delegates.Count) throw new Exception("у нас нет такой функции");
            return result;
        }
        public override void Work()
        {
            SaveFunc("data.bin", -100, 100, 0.5);
            Console.WriteLine(Load("data.bin"));

            double[] data;
            Converters.funcMsg = ConsoleMsg.GetValueAfterMsgLine;
            Console.WriteLine("Укажите на каком отрезке находить минимум:");
            SaveFunc(filename, 
                     Converters.ReadInt("Укажите стартовое значение отрезка"), 
                     Converters.ReadInt("Укажите финальное значение отрезка"), 
                     Converters.ReadDouble("Укажите шаг для прохождения по отрезку"),
                     MenuOfFunctions(Functions));
            data = Load(filename, out double min);
            Console.WriteLine($"Минимальное значение в {filename} является {min}");
            Console.WriteLine("\nВсе значения что были найдены в файле \"{filename}\"");
            for (int i = 0; i < data.Length; i++) Console.WriteLine($"значение {i} равно {data[i]}");
        }

    }
}