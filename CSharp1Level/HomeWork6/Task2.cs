using HomeWorkLib;
using System;
using System.IO;

namespace HomeWork6
{
    internal class Task2 : HomeWorkTask
    {
        public override string Title => "Делегат как параметр";

        public override int TaskNumber => 2;

        public override string ToDo => "Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата." +
                                       "\nа) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум." +
                                       "\nб) Используйте массив(или список) делегатов, в котором хранятся различные функции." +
                                       "\nв) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.";
        public static double F(double x) => x * x - 50 * x + 10;

        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        public override void Work()
        {
            SaveFunc("data.bin", -100, 100, 0.5);
            Console.WriteLine(Load("data.bin"));
        }
    }
}