using System;

namespace ProjectWorkersLibrary
{
    public class HourPriceWorker : Worker
    {
        public double? HourlyRate { get; set; }
        public double? WorkDays { get; set; }
        public override double AverageMonthySalary()
        {
            return (WorkDays ?? throw new ArgumentNullException("Not Work days"))* 8 * (HourlyRate ?? throw new ArgumentNullException("Houly Rate not set"));
        }
    }
}
