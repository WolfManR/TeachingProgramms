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

        public int GetSum()
        {
            int sum = 0;
            foreach (var item in array) sum += item;
            return sum;
        }
        public int this[int index1, int index2] { get => array[index1, index2]; set => array[index1, index2] = value; }
        public int Max
        {
            get
            {
                int max = array[0, 0];
                for (int i = 0; i < array.Rank; i++)
                    for (int j = 1; j < DimensionSize; j++)
                        if (array[i, j] > max) max = array[i, j];

                return max;
            }
        }

        public TwoRankArray(uint size)
        {
            array = new int[size, size];
            DimensionSize = Convert.ToInt32(size);
        }



        public override string ToString()
        {
            string result = "";
            foreach (var item in array) result += item + " ";
            return result;
        }
    }
}
