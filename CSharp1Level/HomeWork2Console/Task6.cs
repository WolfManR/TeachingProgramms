using System;
using HomeWorkLib;

namespace HomeWork2Console
{
    public class Task6 : ITaskWork
    {
        const int startNumber = 1;
        const int endNumber = 1_000_000_000;
        public void Work()
        {
            string iInString;
            int counter = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                iInString = i.ToString();
                int delNumber = 0;
                foreach (var item in iInString) delNumber += int.Parse(item.ToString());
                if (i % delNumber == 0) counter++;
                if (i % 500000 == 0) Console.WriteLine("Working " + i + "  " + counter);
            }
            Console.WriteLine("хороших чисел " + counter);
        }
    }
}
