using HomeWorkLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork6
{
    internal class Task3 : HomeWorkTask
    {
        public override string Title => "Коллекции";

        public override int TaskNumber => 3;

        public override string ToDo => "Переделать программу «Пример использования коллекций» для решения следующих задач:" +
                                       "\nа) Подсчитать количество студентов учащихся на 5 и 6 курсах;" +
                                       "\nб) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);" +
                                       "\nв) отсортировать список по возрасту студента;" +
                                       "\nг) *отсортировать список по курсу и возрасту студента;" +
                                       "\nд) разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.";
        public class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Univercity { get; set; }
            public string Faculty { get; set; }
            public int Course { get; set; }
            public string Department { get; set; }
            public int Group { get; set; }
            public string City { get; set; }
            public int Age { get; set; }

            //Создаем конструктор
            public Student(string firstName, string lastName, string univercity, string faculty, string department, int age, int course, int group, string city)
            {
                this.LastName = lastName;
                this.FirstName = firstName;
                this.Univercity = univercity;
                this.Faculty = faculty;
                this.Department = department;
                this.Course = course;
                this.Age = age;
                this.Group = group;
                this.City = city;
            }

            public override string ToString() => $"{FirstName,20} {LastName,20} {Univercity,26} {Faculty,24} {Department,26} возраст:{Age,3} курс:{Course,2} {Group,2} {City,20}";
            public override bool Equals(object obj) => obj?.ToString() == ToString();
            public override int GetHashCode() => this.ToString().GetHashCode();
        }

        #region Способ примера
        delegate bool Is(Student s);
        static int MyMethod(Student st1, Student st2)//Создаем метод для сравнения экземпляров
        {
            //Сравниваем две строки return String.Compare(st1.firstName, st2.firstName);
            if (st1.Course > st2.Course) return 1;
            if (st1.Course < st2.Course) return -1;
            return 0;
        }

        static int CountStudents(List<Student> students, Is IS)
        {
            int count = 0;
            foreach (Student student in students) if (IS(student)) count++;
            return count;
        }
        #endregion

        public int CountListMembers<T>(List<T> students, Predicate<T> func)
        {
            int count = 0;
            foreach (var student in students) if (func(student)) count++;
            return count;
        }
        public override void Work()
        {
            int bakalav = 0, magistr = 0, fiveCourseStudents = 0;
            //Создаем список студентов
            List<Student> list = new List<Student>();

            //Создаём словарь колличества студентов от 18 до 20 лет на своих курсах
            Dictionary<int, int> studentsNumbers = new Dictionary<int, int>();

            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_4.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    //Добавляем в список новый экземляр класса Student
                    Student t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                    list.Add(t);
                    //Одновременно подсчитываем кол-во бакалавров и магистров
                    if (t.Course == 4) bakalav++;
                    if (t.Course == 6) magistr++;

                    if (t.Course == 5) fiveCourseStudents++;
                    if (t.Age >= 18 & t.Age <= 20 & studentsNumbers.ContainsKey(t.Course)) studentsNumbers[t.Course]++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();

            //для вывода всех студентов
            void PrintAllStudents(List<Student> students)
            {
                foreach (var v in students) Console.WriteLine(v.ToString());
            }

            Console.WindowWidth = 170;
            Console.BufferWidth = 170;
            //Можно оставить просто MyMethod, но помнить, что мы создаем объект-делегат, который передается в метод Sort
            list.Sort(MyMethod);
            //PrintAllStudents(list); 
            Console.WriteLine("Всего студентов:" + list.Count);

            Console.WriteLine("\nКолличество студентов на каждом курсе:");
            foreach (var item in studentsNumbers) Console.WriteLine($"курс {item.Key} студентов {item.Value}");
            Console.WriteLine("\nСтудентов на пятом курсе: {0}", fiveCourseStudents);
            list.Sort((st1, st2) => (st1.Age > st2.Age) ? 1 : (st1.Age < st2.Age) ? -1 : 0);
            //PrintAllStudents(list);
            Console.WriteLine("\n\nсортировка по курсу и возрасту");
            list.Sort((st1, st2) =>
            {
                int course = MyMethod(st1, st2);
                if (course != 0) return course;
                else
                {
                    if (st1.Age > st2.Age) return 1;
                    else if (st1.Age < st2.Age) return -1;
                    else return 0;
                }
            });
            //PrintAllStudents(list);

            Console.WriteLine("\n\nБакалавров: {0}", bakalav);
            Console.WriteLine("Магистров: {0}", magistr);
            Console.WriteLine("Кол-во студентов старше 18 {0}", CountStudents(list, s => s.Age > 18));

            Console.WriteLine("Кол-во студентов старше 18 {0}", CountListMembers(list, s => s.Age > 18));

            Console.WriteLine($"Время работы программы: {DateTime.Now - dt}");
        }
    }
}