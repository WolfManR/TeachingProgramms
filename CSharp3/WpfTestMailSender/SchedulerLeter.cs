using System;
using System.Collections.Generic;

namespace WpfTestMailSender
{
    public class SchedulerLeter
    {
        public DateTime Date { get; set; }
        public string Letter { get; set; }

        public SchedulerLeter(DateTime date, string letter = null)
        {
            Date = date;
            Letter = letter;
        }

        public override bool Equals(object obj)
        {
            return obj is SchedulerLeter leter &&
                   Date == leter.Date &&
                   Letter == leter.Letter;
        }

        public override int GetHashCode()
        {
            var hashCode = 1793338590;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Letter);
            return hashCode;
        }
    }
}