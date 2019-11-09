using ProjectWorkersLibrary;

namespace ProjectWorkersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Worker[] array={
                    new FixPriceWorker { FirstName = "Aloy", LastName = "Fredecha", MonthySalary = 28000 },
                    new HourPriceWorker { FirstName = "Josh", LastName = "Cayne", WorkDays = 22, HourlyRate = 100 },
                    new FixPriceWorker { FirstName = "Eddi", LastName = "Saidzem", MonthySalary = 35000 },
                    new FixPriceWorker { FirstName = "Enny", LastName = "Caterty", MonthySalary = 22000 },
                    new HourPriceWorker { FirstName = "Billy", LastName = "Broderty", WorkDays = null, HourlyRate = 82 },
                    new FixPriceWorker { FirstName = "Anna", LastName = "Caterty", MonthySalary = 24000 }
                };
                Workers workers = new Workers(array);
                foreach (var item in workers)
                {
                    System.Console.WriteLine(item.ToString());
                }
                System.Console.WriteLine();
                System.Array.Sort(array);
                foreach (var item in array)
                {
                    System.Console.WriteLine(item.ToString());
                }

            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("\n\n" + e.Message + "\n\n");
            }

        }
    }
}
