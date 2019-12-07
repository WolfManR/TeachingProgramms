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

            void PrintMenu(ITaskWork[] array)
            {
                System.Console.WriteLine("Command      Title");
                for (int i = 0; i < array.Length; i++)
                    System.Console.WriteLine($" {i,-11} {array[i].Title}");
            }

            PrintMenu(tasks);
            System.Console.Write("Your Command: ");
            int input = int.Parse(System.Console.ReadLine());
            tasks[input].Work();
        }
    }
}
