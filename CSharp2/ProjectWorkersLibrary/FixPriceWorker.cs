using System;

namespace ProjectWorkersLibrary
{
    public class FixPriceWorker : Worker
    {
        public double? MonthySalary { get; set; }
        public override double AverageMonthySalary()
        {
            return MonthySalary??throw new ArgumentNullException("Нет оплаты!");
        }
    }
}
