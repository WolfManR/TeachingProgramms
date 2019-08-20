using System;
using System.Collections.Generic;

namespace HWConsoleLibrary.Arrays
{
    public class OneRankArray
    {
        int[] array;
        private int sum;

        public int Length => array.Length;
        public int Sum
        {
            get
            {
                sum = 0;
                foreach (var item in array) sum += item;
                return sum;
            }
        }
        public int this[int index] { get => array[index]; set => array[index] = value; }
        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = array[0];
                for (int i = 1; i < Length; i++) if (array[i] > max) max = array[i];
                foreach (var item in array) if (item == max) count++;
                return count;
            }
        }

        public OneRankArray(uint size, int minValue, int step)
        {
            array = new int[size];
            for (int j = 0, i = minValue; j < Length; j++, i += step) array[j] = i;
        }

        public OneRankArray(uint size)
        {
            array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < Length; i++) array[i] = rand.Next(15, 40);
        }

        public int[] Inverse()
        {
            int[] arr = new int[Length];
            for (int i = 0; i < Length; i++) arr[i] = array[i] * -1;
            return arr;
        }

        public void Multi(int number)
        {
            for (int i = 0; i < Length; i++) array[i] *= number;
        }

        public Dictionary<int, int> CountSameElements()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            result.Add(array[0], 1);
            for (int i = 1; i < Length; i++)
            {
                if (result.ContainsKey(array[i])) result[array[i]]++;
                else result.Add(array[i], 1);
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in array) result += item + " ";
            return result;
        }
    }
}
