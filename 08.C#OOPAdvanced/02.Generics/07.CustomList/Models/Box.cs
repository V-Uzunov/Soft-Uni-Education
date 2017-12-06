namespace _01.GenericBoxOfString.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public void Remove(int index)
        {
            this.data.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var current = this.data[index1];
            this.data[index1] = this.data[index2];
            this.data[index2] = current;
        }

        public int Greater(T element)
        {
            var counter = 0;
            foreach (var elem in this.data)
            {
                if (elem.CompareTo(element) > 0)
                {
                    counter++;
                }                
            }
            return counter;
        }

        public void Max()
        {
            Console.WriteLine(this.data.Max());
        }

        public void Min()
        {
            Console.WriteLine(this.data.Min());

        }

        public void Print()
        {
            foreach (var value in this.data)
            {
                Console.WriteLine(value);
            }
        }
    }
}
