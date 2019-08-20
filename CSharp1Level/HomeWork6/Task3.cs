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
        class Student
        {
            public string lastName;
            public string firstName;
            public string univercity;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;

            //Создаем конструктор
            public Student(string firstName, string lastName, string univercity, string faculty, string department, int age, int course, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.univercity = univercity;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }

            public override string ToString() => $"{firstName,15}{lastName,15}{univercity,15}{faculty,15}{department,15}{age,15}{course,15}{group,5}{city,10}";
        }
        delegate bool Is(Student s);
        static int MyMethod(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
        {
            //Сравниваем две строки
            // return String.Compare(st1.firstName, st2.firstName);
            if (st1.course > st2.course) return 1;
            if (st1.course < st2.course) return -1;
            return 0;
        }

        static bool IsAgeBigger18(Student student)
        {
            return student.age > 18;
        }

        static int CountStudents(List<Student> students, Is IS)
        {
            int count = 0;
            foreach (Student student in students)
            {
                if (IS(student)) count++;
            }
            return count;
        }
        public override void Work()
        {
            int bakalav = 0;
            int magistr = 0;
            //Создаем список студентов
            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_4.csv");
            //File.ReadAllLines("students_4.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    //Добавляем в список новый экземляр класса Student
                    Student t;
                    t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                    list.Add(t);
                    //Одновременно подсчитываем кол-во бакалавров и магистров
                    if (t.course == 4) bakalav++;
                    if (t.course == 6) magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();
            Console.WindowWidth = 160;
            Console.BufferWidth = 160;
            //Можно оставить просто MyMethod, но помнить, что мы создаем объект-делегат, который передается в метод Sort
            list.Sort(MyMethod);
            //foreach (var v in list) Console.WriteLine(v.ToString());
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalav);
            Console.WriteLine("Кол-во студентов старше 18", CountStudents(list, delegate (Student s)
            {
                return s.age > 18;
            }));
            Console.WriteLine("Кол-во студентов старше 18", CountStudents(list, IsAgeBigger18));
            Console.WriteLine(DateTime.Now - dt);
        }
    }
}