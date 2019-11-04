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
            return (WorkDays ?? throw new ArgumentNullException("Not Work"))* 8 * (HourlyRate ?? throw new ArgumentNullException("Salary not set"));
        }
    }
}
