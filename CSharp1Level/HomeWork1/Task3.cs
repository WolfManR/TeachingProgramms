using System;
using HomeWorkLib;
using HWConsoleLibrary;
using HWConsoleLibrary.Extensions;

namespace HomeWork1
{
    public class Task3 : IHWTaskWork
    {
        public void Work()
        {
            Point a = new Point() { X = 184, Y = 206 };
            Point b = new Point() { X = 345, Y = 251 };
            Console.WriteLine("Вы будете вводить свои точки координат? \n<2 - да\n>=2 - нет");
            if (Converters.ReadInt() < 2)
            {
                Console.WriteLine("первая точка");
                a.FillPoint();
                Console.WriteLine("\nвторая точка");
                b.FillPoint();
            }
            DistanceBetweenPoints(a, b);
        }

        void DistanceBetweenPoints(Point first, Point second)
        {
            var result = Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
            Console.WriteLine($"Расстояние между точками {result:f2}");
        }
    }
}
