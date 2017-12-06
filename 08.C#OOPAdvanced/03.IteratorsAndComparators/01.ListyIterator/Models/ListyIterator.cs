namespace _01.ListyIterator.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class ListyIterator<T> : IListyIterator<T>, IEnumerable<T>
    {
        private int index;
        private List<T> elements;


        public ListyIterator(params T[] element)
        {
            this.index = 0;
            this.elements = new List<T>(element);
        }

        public void Add(T elem) => this.elements.Add(elem);

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        } 

        public T Print()
        {
            if (this.elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            return this.elements[this.index];
        }

        public bool HasNext() => this.elements.Count - 1 > this.index;

        public IEnumerator<T> GetEnumerator()
        {
            if (this.elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
