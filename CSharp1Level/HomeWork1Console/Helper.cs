using System;

namespace HomeWork1Console
{
    public static class Helper
    {
        public static int ReadInt() => int.Parse(Console.ReadLine());
        public static void WriteMsgInCenter(string prefix, string variable)
        {
            int CalcConsoleCenter(string str)
            {
                return Console.BufferWidth / 2 - str.Length / 2;
            }
            string msg = $"{prefix} {variable}";
            Console.CursorLeft += CalcConsoleCenter(msg);
            Console.WriteLine(msg);
        }
    }
    public interface TaskWork
    {
        void Work();
    }
}
