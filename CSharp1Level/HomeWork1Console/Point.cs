using System;
namespace HomeWork1Console
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void FillPoint()
        {
            Console.Write("\nX ");
            X = int.Parse(Console.ReadLine());
            Console.Write("\nY ");
            Y = int.Parse(Console.ReadLine());
        }
    }
}
