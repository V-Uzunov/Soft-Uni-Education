namespace _03.Stack.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Interfaces;
    public class MyStack<T> : IStackable<T>, IEnumerable<T>
    {
        private readonly List<T> elements;

        public MyStack(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                this.elements.Add(item);
            }
        }

        public T Pop()
        {
            if (this.elements.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            var lastElementInList = this.elements.Count - 1;
            var itemAtTopOfStack = this.elements[lastElementInList];
            this.elements.RemoveAt(lastElementInList);
            return itemAtTopOfStack;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
