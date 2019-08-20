using System;

namespace HWConsoleLibrary
{
    public static class Converters
    {
        public delegate string GetMsg(string msg);
        public static GetMsg funcMsg { get; set; }
        public static int ReadInt() => int.Parse(Console.ReadLine());
        public static int ReadInt(string msg) => int.Parse(funcMsg?.Invoke(msg));
    }
}
