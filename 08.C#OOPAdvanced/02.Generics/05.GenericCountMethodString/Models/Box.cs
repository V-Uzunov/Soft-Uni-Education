namespace _01.GenericBoxOfString.Models
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
        where T : IComparable
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public int CompareCounter(string element)
        {
            var count = 0;

            foreach (var elem in this.data)
            {
                if (elem.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
