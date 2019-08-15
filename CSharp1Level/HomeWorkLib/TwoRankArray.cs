using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkLib
{
    class TwoRankArray
    {
        int[,] array;

        public int DimensionSize { get; }

        
        public int this[int index1, int index2] { get => array[index1, index2]; set => array[index1, index2] = value; }
        public int Min
        {
            get
            {
                int min = array[0, 0];
                foreach (var item in array) if (item < min) min = item;
                return min;
            }
        }
        public int Max
        {
            get
            {
                int max = array[0, 0];
                foreach (var item in array) if (item > max) max = item;
                return max;
            }
        }
        public void MaxIndex(out (int index1,int index2) index)
        {
            index = (0, 0);
            int max = array[0, 0];
            for (int i = 0; i < array.Rank; i++)
                for (int j = 0; j < DimensionSize; j++)
                    if (array[i,j] > max)
                    {
                        max = array[i, j];
                        index = (i, j);
                    }
        }
        public TwoRankArray(uint size,int minValue,int maxValue)
        {
            array = new int[size, size];
            DimensionSize = Convert.ToInt32(size);
            Random rand = new Random();
            for (int i = 0; i < array.Rank; i++)
                for (int j = 0; j < DimensionSize; j++)
                    array[i, j] = rand.Next(minValue,maxValue);
        }

        public int GetSum()
        {
            int sum = 0;
            foreach (var item in array) sum += item;
            return sum;
        }
        public int GetSum(int number)
        {
            List<int> higherNumbers = new List<int>();
            foreach (var item in array) if (item > number) higherNumbers.Add(item);
            int sum = 0;
            foreach (var item in higherNumbers) sum += item;
            return sum;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in array) result += item + " ";
            return result;
        }
    }
}
