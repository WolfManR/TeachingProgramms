using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1Console
{
    public class Task3 : TaskWork
    {
        public void Work()
        {
            Point a = new Point() { X = 184, Y = 206 };
            Point b = new Point() { X = 345, Y = 251 };
            Console.WriteLine("Вы будете вводить свои точки координат? \n<2 - да\n>=2 - нет");
            if (Helper.ReadInt() < 2)
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
