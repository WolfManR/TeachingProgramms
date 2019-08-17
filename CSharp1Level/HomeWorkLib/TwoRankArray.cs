using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkLib
{
    public class TwoRankArray
    {
        int[,] array;
        int Columns;

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

        public TwoRankArray(uint columns,int minValue,int maxValue)
        {
            array = new int[2, columns];
            Columns = Convert.ToInt32(columns);
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < columns; j++)
                    array[i, j] = rand.Next(minValue,maxValue);
        }
        public TwoRankArray(string filename)
        {
            array = ReadFromFile(filename,out Columns);
        }
        public void MaxIndex(out (int index1,int index2) index)
        {
            index = (0, 0);
            int max = array[0, 0];
            for (int i = 0; i <2; i++)
                for (int j = 0; j < Columns; j++)
                    if (array[i,j] > max)
                    {
                        max = array[i, j];
                        index = (i, j);
                    }
        }
        public void WriteToFile(string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename + ".txt");
                sw.WriteLine(Columns);
                foreach (var item in array) sw.WriteLine(item);
                sw.Close();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(PathTooLongException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }
        public int[,] ReadFromFile(string filename,out int columns)
        {
            columns= 0;
            List<int> firstDimention = new List<int>();
            List<int> secondDimention = new List<int>();
            try
            {
                StreamReader sr = new StreamReader(filename + ".txt");
                columns = int.Parse(sr.ReadLine());
                for (int i = 0; i < columns; i++)
                    firstDimention.Add(int.Parse(sr.ReadLine()));
                for (int i = 0; i < columns; i++)
                    secondDimention.Add(int.Parse(sr.ReadLine()));
                sr?.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так");
            }
            
            int[,] arr = new int[2, columns];
            for (int j = 0; j < columns; j++) arr[0, j] = firstDimention[j];
            for (int j = 0; j < columns; j++) arr[1, j] = secondDimention[j];
            return arr;
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
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += array[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
