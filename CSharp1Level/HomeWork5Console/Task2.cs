using HomeWorkLib;
using HomeWorkLib.ConsoleWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
            string msg;
            StreamReader sr = new StreamReader("Msg.txt");
            msg = sr.ReadToEnd();
            sr.Close();
            int countWords = 0;
            Console.WriteLine("Слова содержащие n букв");
            foreach (var item in Message.PrintWordsWithOnlyNSymbols(msg, int.Parse(Helper.GetValueInMsgLine("колличество букв: ")))) Console.WriteLine(item);
            Console.WriteLine();

            try
            {
                Console.Write("Строка после удаления слов");
                Console.WriteLine(Message.DeleteWordsWithSymbolOnEnd(msg, char.Parse(Helper.GetValueInMsgLine(", содержащих символ: ")), out countWords));
                Console.WriteLine("колличество удалённых слов: " + countWords);
            }
            catch (Exception)
            {
                Console.WriteLine("\nВы должны были ввести символ");
            }
            
            Console.WriteLine("\n\nПервое самое длинное слово \n"+Message.FindLongestWord(msg)+"\n");

            Console.WriteLine("Строка из самых длинных слов");
            Console.WriteLine(Message.NewStringWithLongestWords(msg));
        }

        public static class Message
        {
            static string[] SplitMsg(string msg)
            {
                StringBuilder builder = new StringBuilder(msg);
                for (int i = 0; i < builder.Length;)
                    if (char.IsPunctuation(builder[i])) builder.Remove(i, 1);
                    else ++i;
                msg = builder.ToString();
                return msg.Split(new char[] { ' ','\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            public static string[] PrintWordsWithOnlyNSymbols(string msg,int maxLength)
            {
                if (maxLength < 2) throw new Exception("Длинна слова не должна быть меньше 2");
                List<string> list = new List<string>();
                string[] words = SplitMsg(msg);
                foreach (var item in words) if (item.Length <= maxLength&item.Length >= 2 & !list.Contains(item)) list.Add(item);
                return list.ToArray();
            }

            public static string DeleteWordsWithSymbolOnEnd(string msg,char EndSymbol,out int count)
            {
                count = 0;
                string[] words = SplitMsg(msg);
                List<string> list = new List<string>();
                foreach (var item in words) if (item.Length>=2&&(item[item.Length - 1] == EndSymbol & !list.Contains(item))) list.Add(item);
                list.Sort((item1, item2) => (item1.Length < item2.Length) ? 1 : (item1.Length > item2.Length) ? -1 : 0);
                foreach (var item in list)
                {
                    while (msg.Contains(item))
                    {
                        msg=msg.Remove(msg.IndexOf(item), item.Length);
                        count++;
                    }
                }
                return msg;
            }

            public static string FindLongestWord(string msg)
            {
                string[] words = SplitMsg(msg);
                int indexMax = 0;
                for (int i = 0; i < words.Length; i++) if (words[i].Length > words[indexMax].Length) indexMax = i;
                return words[indexMax];
            }

            public static string NewStringWithLongestWords(string msg)
            {
                string[] words = SplitMsg(msg);
                int maXLength = 0;
                foreach (var item in words)if (item.Length > maXLength) maXLength = item.Length;
                List<string> list = new List<string>();
                foreach (var item in words) if (item.Length == maXLength & !list.Contains(item)) list.Add(item);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i != list.Count - 1) builder.Append(list[i] + " ");
                    else builder.Append(list[i]);
                }
                return builder.ToString();
            }
        }
    }
}