using System;

namespace ProjectWorkersLibrary
{
    public abstract class Person:IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Person person)
            {
                int result = LastName.CompareTo(person.LastName);
                if (result != 0) return result;
                else
                {
                    result = FirstName.CompareTo(person.FirstName);
                    return result;
                }

            }
            else throw new ArgumentException("Parameter is not a Person!");
        }

        public override string ToString() => $"{LastName} {FirstName}";
    }
}
