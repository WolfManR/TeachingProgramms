using HomeWorkLib;
using System;
using System.Collections.Generic;

namespace HomeWork5Console
{
    internal class Task2 : HomeWorkTask
    {
        public override string Title => "Обработка текста";

        public override int TaskNumber => 2;

        public override string ToDo => "Разработать класс Message, содержащий следующие статические методы для обработки текста:" +
                                       "\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                                       "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                                       "\nв) Найти самое длинное слово сообщения." +
                                       "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения." +
                                       "\n\nПродемонстрируйте работу программы на текстовом файле с вашей программой.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }

        public static class Message
        {
            static string[] SplitMsg(string msg)=> msg.Split(new char[] { ' ', ',', '.', '?', '"', '!', '(', ')', '{', '}', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            public static string[] PrintWordsWithOnlyNSymbols(string msg,int maxLength)
            {
                if (maxLength < 2) throw new Exception("Длинна слова не должна быть меньше 2");
                List<string> list = new List<string>();
                string[] words = SplitMsg(msg);
                foreach (var item in words) if (item.Length <= maxLength & list.Contains(item)) list.Add(item);
                return list.ToArray();
            }

            public static string DeleteWordsWithSymbolOnEnd(string msg,char EndSymbol)
            {
                string[] words = SplitMsg(msg);
                List<string> list = new List<string>();
                foreach (var item in words) if (item[item.Length - 1] != EndSymbol) list.Add(item);
                return list.ToArray().ToString();
            }

            public static void FindLongestWord(string msg)
            {

            }

            public static void NewStringWithLongestWords(string msg)
            {

            }
        }
    }
}