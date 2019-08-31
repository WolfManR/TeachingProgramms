namespace HomeWork8.Code
{
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

        public Student()
        {

        }
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
}
