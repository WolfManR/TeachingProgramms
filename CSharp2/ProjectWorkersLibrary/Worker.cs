namespace ProjectWorkersLibrary
{
    public abstract class Worker:Person
    {
        public abstract double AverageMonthySalary();

        public override string ToString() => base.ToString() + " Salary is " + AverageMonthySalary();
    }
}
