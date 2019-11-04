using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWorkersLibrary
{
    public class FixPriceWorker : Worker
    {
        public double? MonthySalary { get; set; }
        public override double AverageMonthySalary()
        {
            return MonthySalary??throw new Exception("Нет оплаты!");
        }
    }
}
