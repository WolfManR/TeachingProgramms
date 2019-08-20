using HomeWorkLib;
using System;

namespace HWConsoleLibrary.Extensions
{
    public static class PointInfo
    {
        public static void FillPoint(this Point point)
        {
            Console.Write("\nX ");
            point.X = int.Parse(Console.ReadLine());
            Console.Write("\nY ");
            point.Y = int.Parse(Console.ReadLine());
        }
    }
}
