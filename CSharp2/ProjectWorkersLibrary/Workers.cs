using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWorkersLibrary
{
    public class Workers
    {
        Worker[] workers;

        public Workers(Worker[] workers)
        {
            this.workers = workers ?? throw new ArgumentNullException(nameof(workers));
        }


    }
}
