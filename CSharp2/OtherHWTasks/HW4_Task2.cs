using System;
using System.Collections.Generic;
using System.Linq;

namespace OtherHWTasks
{
    public class HW4_Task2 : ITaskWork
    {
        public string Title => "Frequency Array";

        public void Work()
        {
            List<int> list = new List<int>() { 3,4,5,6,2,2,3,4,6,7,1,5,7,5,8 };

            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var item in list)
            {
                if (dict.ContainsKey(item)) dict[item]++;
                else dict.Add(item, 1);
            }

            PrintResult(list, dict);
            ////////////////////////////////////////////////////////////
            List<object> list2 = new List<object>() { 3, 4, 5, 6, 2, 2, 3, 4, 6, 7, 1, 5, 7, 5, 8 };

            Dictionary<object, int> dict2 = Frequency(list2);

            PrintResult(list2, dict2);
            ///////////////////////////////////////////////////////////////////////////////
            List<object> list3 = new List<object>() { 3, 4, 5, 6, 2, 2, 3, 4, 6, 7, 1, 5, 7, 5, 8 };

            var groups1 = list3.GroupBy(p=>p).Select(g => new { g.Key, Count = g.Count() });         //Как это написать развёрнуто

            Console.Write("Base Collection of ints");
            foreach (var item in list) Console.Write(item + " ");
            Console.WriteLine("\nFrequency array:");
            foreach (var item in groups1) Console.WriteLine(item.Key + " times " + item.Count);
        }

        void PrintResult<T>(List<T> list, Dictionary<T,int> dict)
        {
            Console.Write($"Base Collection of {list[0].GetType().Name}");
            foreach (var item in list) Console.Write(item + " ");
            Console.WriteLine("Frequency array:");
            foreach (var item in dict) Console.WriteLine(item.Key + " times " + item.Value);
        }

        public Dictionary<T,int> Frequency<T>(ICollection<T> list)
        {
            Dictionary<T, int> dict = new Dictionary<T, int>();
            foreach (var item in list)
            {
                if (dict.ContainsKey(item)) dict[item]++;
                else dict.Add(item, 1);
            }
            return dict;
        }
    }
}
