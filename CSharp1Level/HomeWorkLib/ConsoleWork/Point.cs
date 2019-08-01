using System;

namespace HomeWorkLib
{
    public partial struct Point
    {
        public void FillPoint()
        {
            Console.Write("\nX ");
            X = int.Parse(Console.ReadLine());
            Console.Write("\nY ");
            Y = int.Parse(Console.ReadLine());
        }
    }
}
