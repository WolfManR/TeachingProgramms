using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectWorkersLibrary
{
    public class Workers:IEnumerable
    {
        Worker[] workers;
        public Workers(Worker[] workers)
        {
            this.workers = workers ?? throw new ArgumentNullException(nameof(workers));
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            for (int i = 0; i < workers.Length; i++)
                yield return workers[i];
        }

    }
}
