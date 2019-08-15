using HomeWorkLib;
using System.Collections.Generic;

namespace HomeWork4Console
{
    public class Task3 : HomeWorkTask
    {
        public override string Title => "Дописываем класс работы с одномерным массивом";

        public override int TaskNumber => 3;

        public override string ToDo => "а) Дописать класс для работы с одномерным массивом." +
                                       "\nРеализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом." +
                                       "\nСоздать свойство Sum, которое возвращает сумму элементов массива, " +
                                       "\nметод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений)," +
                                       "\nметод Multi, умножающий каждый элемент массива на определённое число," +
                                       "\nсвойство MaxCount, возвращающее количество максимальных элементов." +
                                       "\n\nб)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки." +
                                       "\n\n*** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }

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

            public Dictionary<int,int> CountSameElements()
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
        }
    }
}
