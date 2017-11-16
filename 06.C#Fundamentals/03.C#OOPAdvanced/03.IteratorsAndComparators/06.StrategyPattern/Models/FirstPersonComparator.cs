namespace _06.StrategyPattern.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstPersonComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result==0)
            {
                result = x.Name.Substring(0, 1).ToLower().CompareTo(y.Name.Substring(0, 1).ToLower());
            }
            return result;
        }
    }
}
