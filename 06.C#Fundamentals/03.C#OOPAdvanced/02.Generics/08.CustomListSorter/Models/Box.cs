namespace _01.GenericBoxOfString.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using _08.CustomListSorter.Models;

    public class Box<T> : IBox<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        private List<T> data;

        public Box() : this(Enumerable.Empty<T>())
        {
        }

        public Box(IEnumerable<T> collection)
        {
            this.Data = new List<T>(collection);
        }

        public List<T> Data { get; private set; }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public void Remove(int index)
        {
           this.Data.RemoveAt(index);
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

        public T Max()
        {
            return this.Data.Max();
        }

        public T Min()
        {
            return this.Data.Min();
        }

        public void Print()
        {
            foreach (var value in this.data)
            {
                Console.WriteLine(value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}
