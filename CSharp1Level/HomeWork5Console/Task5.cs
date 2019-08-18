using HomeWorkLib;
using HomeWorkLib.ConsoleWork;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork5Console
{
    internal class Task5 : HomeWorkTask
    {
        public override string Title => "«Верю. Не верю»";

        public override int TaskNumber => 5;

        public override string ToDo => "**Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. " +
                                       "\nНапример: «Шариковую ручку изобрели в древнем Египте», «Да». " +
                                       "\nКомпьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. " +
                                       "\nИгрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. " +
                                       "\nСписок вопросов ищите во вложении или воспользуйтесь интернетом.";
        public struct Riddles
        {
            public string Question { get; set; }
            public string Answer { get; set; }
            string separator;
            public Riddles(string question,string answer)
            {
                Question = question;
                Answer = answer;
                separator = "%^&";
            }
            public Riddles(string riddle)
            {
                string[] split = riddle.Split(new string[]{ "%^&"},StringSplitOptions.RemoveEmptyEntries);
                Question = split[0];
                Answer = split[1];
                separator = "%^&";
            }
            public override string ToString() => $"{Question}{separator}{Answer}";

            public override bool Equals(object obj) => obj?.ToString() == ToString();

            public override int GetHashCode() => this.ToString().GetHashCode();
        }
        public override void Work()
        {
            List<Riddles> riddlesToAnswer = GetRiddles("Riddles"+".txt");
            Console.WriteLine("Сыграем в игру \"Верю. не верю\"");
            Console.WriteLine("Вам будет задано 5 вопросов и вы должны ответить на них: <2 - да, >=2 - нет");
            Console.WriteLine();
            int counter = 0;
            for (int i = 0; i < riddlesToAnswer.Count; i++)
                if (((int.Parse(Helper.GetValueAfterMsgLine($"Вопрос {i}\n{riddlesToAnswer[i].Question}")) < 2) ? "да" : "нет") == riddlesToAnswer[i].Answer) counter++;
            Console.WriteLine($"\n\nВы ответили правильно {counter} раз и заработали {counter*2} баллов из 10") ;
        }

        public List<Riddles> GetRiddles(string filename)
        {
            List<Riddles> list = new List<Riddles>();
            StreamReader sr = new StreamReader(filename);
            for (int i = 0; !sr.EndOfStream; i++) list.Add(new Riddles(sr.ReadLine()));
            sr?.Close();
            Random r = new Random();
            List<Riddles> riddlesToAnswer = new List<Riddles>();
            for (int i = 0; i < 5; i++)
            {
                Riddles next;
                do
                {
                    next = list[r.Next(list.Count)];
                } while (riddlesToAnswer.Contains(next));
                riddlesToAnswer.Add(next);
            }
            return riddlesToAnswer;
        }
    }
}