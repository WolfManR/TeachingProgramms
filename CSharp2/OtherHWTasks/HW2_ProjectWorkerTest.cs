using ProjectWorkersLibrary;
using System;

namespace OtherHWTasks
{
    public class HW2_ProjectWorkerTest:ITaskWork
    {
        public string Title => "Project Worker Test";

        public void Work()
        {
            try
            {
                Worker[] array ={
                    new FixPriceWorker { FirstName = "Aloy", LastName = "Fredecha", MonthySalary = 28000 },
                    new HourPriceWorker { FirstName = "Josh", LastName = "Cayne", WorkDays = 22, HourlyRate = 100 },
                    new FixPriceWorker { FirstName = "Eddi", LastName = "Saidzem", MonthySalary = 35000 },
                    new FixPriceWorker { FirstName = "Enny", LastName = "Caterty", MonthySalary = 22000 },
                    new HourPriceWorker { FirstName = "Billy", LastName = "Broderty", WorkDays = null, HourlyRate = 82 },    // намеренная ошибка
                    new FixPriceWorker { FirstName = "Anna", LastName = "Caterty", MonthySalary = 24000 }
                };
                Workers workers = new Workers(array);
                foreach (var item in workers)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine();
                Array.Sort(array);
                foreach (var item in array)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n" + e.Message + "\n\n");
            }
        }
    }
}
