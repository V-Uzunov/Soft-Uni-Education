namespace _06.StrategyPattern.Models
{
    using System.Collections.Generic;
    public class SecondPersonComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
