using ProjectWorkersLibrary;

namespace ProjectWorkersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Workers workers = new Workers(
                    new FixPriceWorker { FirstName = "Aloy", LastName = "Fredecha", MonthySalary = 28000 },
                    new HourPriceWorker { FirstName = "Josh", LastName = "Cayne", WorkDays = 22, HourlyRate = null },
                    new FixPriceWorker { FirstName = "Eddi", LastName = "Saidzem", MonthySalary = 35000 },
                    new FixPriceWorker { FirstName = "Enny", LastName = "Caterty", MonthySalary = null },
                    new HourPriceWorker { FirstName = "Billy", LastName = "Broderty", WorkDays = 15, HourlyRate = 82 }
                );
                foreach (var item in workers)
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
