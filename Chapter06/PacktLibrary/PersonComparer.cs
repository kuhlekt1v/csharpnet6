using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacktLibrary
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x is null || y is null)
            {
                return 0;
            }
            // Compare the name lengths.
            int result = x.Name.Length.CompareTo(y.Name.Length);

            // If they are equal..
            if (result == 0)
            {
                // Then compare by the names
                return x.Name.CompareTo(y.Name);
            }
            else // Result will be -1 or 1.
            {
                // Otherwise compare by lengths.
                return result;
            }
        }
    }
}