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

        public int Length => array.Length;

        public int GetSum()
        {
            int sum = 0;
            foreach (var item in array) sum += item;
            return sum;
        }
        public int this[int index1,int index2] { get => array[index1,index2]; set => array[index1,index2] = value; }
        public int Max
        {
            get
            {
                int max = array[0,0];
                for (int i = 1; i < Length; i++) if (array[i] > max) max = array[i];
                foreach (var item in array) if (item == max) count++;
                return count;
            }
        }

        public TwoRankArray(uint size, int minValue, int step)
        {
            array = new int[size];
            for (int j = 0, i = minValue; j < Length; j++, i += step) array[j] = i;
        }

        
        
        public override string ToString()
        {
            string result = "";
            foreach (var item in array) result += item + " ";
            return result;
        }
    }
}
