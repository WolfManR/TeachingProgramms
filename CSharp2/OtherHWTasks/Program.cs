namespace OtherHWTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaskWork[] tasks =
            {
                new HW2_ProjectWorkerTest(),
                new HW3_Lesson3Project(),
                new HW4_Task2(),
                new HW4_Task3()
            };

            tasks[3].Work();
        }
    }
}
