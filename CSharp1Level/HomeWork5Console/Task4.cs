using HomeWorkLib;
using System;

namespace HomeWork5Console
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

            public override string ToString()
            {
                return $"{First} {Second} {Third}";
            }
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
            public Student(string student)
            {
                string[] Info = student.Split(new char[] { ' ' });
                if (Info.Length != 5) throw new Exception("Что-то пошло не так");
                LastName = Info[0];
                FirstName = Info[1];
                Ratings = new Rating(new string[] { Info[2], Info[3], Info[4] });
            }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {Ratings.ToString()}";
            }
        }
        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}