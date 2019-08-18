using HomeWorkLib;
using HomeWorkLib.ConsoleWork;
using System.Collections.Generic;

namespace HomeWork5Console
{
    internal class Task3 : HomeWorkTask
    {
        public override string Title => "Строки перевёртыши";

        public override int TaskNumber => 3;

        public override string ToDo => "*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. " +
                                       "\nРегистр можно не учитывать:" +
                                       "\nа) с использованием методов C#;" +
                                       "\nб) *разработав собственный алгоритм." +
                                       "\nНапример: badc являются перестановкой abcd.";

        public override void Work()
        {
            System.Console.WriteLine((isRearrangement(Helper.GetValueInMsgLine("первая строка "),Helper.GetValueInMsgLine("вторая строка ")))?"являются анаграммой друг друга":"не являются анаграммой друг друга");
        }

        public bool isRearrangement(string first, string second)
        {
            first = first.ToLower();
            second = second.ToLower();
            if (first != second)
            {
                Dictionary<char, int> firstChars = getChars(first);
                Dictionary<char, int> secondChars = getChars(second);
                Dictionary<char, int> getChars(string str)
                {
                    Dictionary<char, int> result = new Dictionary<char, int>();
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (result.ContainsKey(str[i])) result[str[i]]++;
                        else result.Add(str[i], 1);
                    }
                    return result;
                }
                int counter = 0;
                if (firstChars.Count == secondChars.Count)
                {
                    foreach (var item in firstChars)
                        if (!secondChars.ContainsKey(item.Key)) return false;
                        else if (secondChars[item.Key] != item.Value) return false;
                        else counter++;
                    if (counter == secondChars.Count) return true;
                }
                else return false;
            }
            return false;
        }
    }
}