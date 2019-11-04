using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWorkersLibrary
{
    public abstract class Person:IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(object obj)
        {
            return LastName.CompareTo(obj);
        }
    }
}
