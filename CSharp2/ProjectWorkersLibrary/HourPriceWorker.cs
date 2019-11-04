using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWorkersLibrary
{
    public class HourPriceWorker : Worker
    {
        public double? HourlyRate { get; set; }
        public double? WorkDays { get; set; }
        public override double AverageMonthySalary()
        {
            return (WorkDays ?? throw new Exception("Not Work"))* 8 * (HourlyRate ?? throw new Exception("Salary not set"));
        }
    }
}
