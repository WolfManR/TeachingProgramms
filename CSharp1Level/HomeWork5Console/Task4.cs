using HomeWorkLib;
using HWConsoleLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork5
{
    internal class Task4 : HomeWorkTask
    {
        public override string Title => "Задача ЕГЭ";

        public override int TaskNumber => 4;

        public override string ToDo => "* На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы." +
                                       "\n\nВ первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, " +
                                       "\nкаждая из следующих N строк имеет следующий формат: <Фамилия> <Имя> <оценки>, где " +
                                       "\n<Фамилия> — строка, состоящая не более чем из 20 символов, " +
                                       "\n<Имя> — строка, состоящая не более чем из 15 символов, " +
                                       "\n<оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. " +
                                       "\n<Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом." +
                                       "\nПример входной строки: Иванов Петр 4 5 3" +
                                       "\n\nТребуется написать как можно более эффективную программу, " +
                                       "\nкоторая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. " +
                                       "\nЕсли среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших," +
                                       "\nследует вывести и их фамилии и имена. " +
                                       "\n\nДостаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы. " +
                                       "\nПереписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении. " +
                                       "\nДля решения задач используйте неизменяемые строки (string)";
        public struct Rating
        {
            public int First { get; }
            public int Second { get; }
            public int Third { get; }
            public float AverageMark { get; }
            public Rating(int mark1, int mark2, int mark3)
            {
                if (mark1 < 1 || mark1 > 5 || mark2 < 1 || mark2 > 5 || mark3 < 1 || mark3 > 5) throw new Exception("Неверные оценки");
                First = mark1;
                Second = mark2;
                Third = mark3;
                AverageMark = (First + Second + Third) / 3.0f;
            }
            public Rating(string[] ratings)
            {
                int[] marks = new int[3];
                int counter = 0;
                for (int i = 0; i < ratings.Length; i++)
                    if (int.TryParse(ratings[i], out marks[i]))
                    {
                        if (marks[i] < 1 || marks[i] > 5) counter++;
                    }
                    else counter++;
                if (counter > 0) throw new Exception("Неверные оценки");
                First = marks[0];
                Second = marks[1];
                Third = marks[2];
                AverageMark = (First + Second + Third) / 3.0f;
            }

            public override string ToString()=> $"{First} {Second} {Third}";
        }
        public class Student
        {
            private string firstName;
            private string lastName;

            public string LastName
            {
                get => lastName;
                set
                {
                    if (value.Length > 20) throw new Exception("слишком длинная фамилия");
                    lastName = value;
                }
            }
            public string FirstName
            {
                get => firstName;
                set
                {
                    if (value.Length > 15) throw new Exception("слишком длинное имя");
                    firstName = value;
                }
            }
            public Rating Ratings { get; set; }
            public Student(string _lastName, string _firstName, int mark1, int mark2, int mark3)
            {
                LastName = _lastName;
                FirstName = _firstName;
                Ratings = new Rating(mark1, mark2, mark3);
            }
            public Student(string student)
            {
                string[] Info = student.Split(new char[] { ' ' });
                if (Info.Length != 5) throw new Exception("Что-то пошло не так");
                LastName = Info[0];
                FirstName = Info[1];
                Ratings = new Rating(new string[] { Info[2], Info[3], Info[4] });
            }

            public override string ToString()=> $"{LastName} {FirstName} {Ratings.ToString()}";

            public override bool Equals(object obj) => obj?.ToString() == ToString();

            public override int GetHashCode() => this.ToString().GetHashCode();
        }
        public override void Work()
        {
            string filename = "Students";
            if (ConsoleMsg.GetValueInMsgLine("Создать новый файл студентов? ").Length >4 ) WriteToFile(filename, 50);
            List<Student> students = ReadFromFile(filename);
            List<Student> worsts = new List<Student>();
            List<Student> sameWorsts = new List<Student>();
            float[] worstMarks = { 5, 5, 5 };

            foreach (var item in students)
                if (item.Ratings.AverageMark < worstMarks[2])
                {
                    if (item.Ratings.AverageMark < worstMarks[1])
                    {
                        if (item.Ratings.AverageMark < worstMarks[0]) worstMarks[0] = item.Ratings.AverageMark;
                        else worstMarks[1] = item.Ratings.AverageMark;
                    }
                    else worstMarks[2] = item.Ratings.AverageMark;
                }

            foreach (var item in students)
            {
                if (worsts.Count == 3) break;
                for (int i = 0; i < worstMarks.Length; i++)
                    if (worstMarks[i] == item.Ratings.AverageMark)
                    {
                        worsts.Add(item);
                        break;
                    }
            }

            foreach (var item in students)
                if (!worsts.Contains(item))
                    for (int i = 0; i < worsts.Count; i++)
                        if (worsts[i].Ratings.AverageMark == item.Ratings.AverageMark)
                        {
                            sameWorsts.Add(item);
                            break;
                        }

            Console.WriteLine("\nТрое худших учеников\n");
            foreach (var item in worsts) Console.WriteLine(item.ToString());
            Console.WriteLine("\nОстальные худших учеников\n");
            foreach (var item in sameWorsts) Console.WriteLine(item.ToString());
        }

        // однако ж интересно почему возвращает одинаковые предшедстующим строки
        string GenerateString(int charNumbers)
        {
            string chars = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            string lowerChars = chars.ToLower();
            Random r = new Random();
            StringBuilder result = new StringBuilder(chars[r.Next(chars.Length)].ToString());

            for (int i = 1; i < charNumbers; i++) result.Append(lowerChars[r.Next(lowerChars.Length)]);
            return result.ToString();
        }

        void WriteToFile(string filename, int stringCounts)
        {
            Random r = new Random();
            Student student;
            StreamWriter sw = new StreamWriter(filename + ".txt");
            for (int i = 0; i < stringCounts; i++)
            {
                student = new Student(
                    GenerateString(20),
                    GenerateString(15),
                    r.Next(1, 6),
                    r.Next(1, 6),
                    r.Next(1, 6)
                    );
                sw.WriteLine(student.ToString());
            }
            sw.Close();
        }
        List<Student> ReadFromFile(string filename)
        {
            Random r = new Random();
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader(filename + ".txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                list.Add(new Student(sr.ReadLine()));
            }
            sr?.Close();
            return list;
        }
    }
}