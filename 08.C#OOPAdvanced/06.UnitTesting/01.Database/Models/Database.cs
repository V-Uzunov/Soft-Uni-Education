namespace _01.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database : IDatabase
    {
        private IList<int> capacity;

        public Database()
        {
            this.Capacity = new List<int>();
        }

        private IList<int> Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value.Count > 16)
                {
                    throw new InvalidOperationException();
                }
                this.capacity = value;
            }
        }

        public int CountOfElements()
        {
            return this.Capacity.Count;
        }

        public void Add(int element)
        {
            if (this.Capacity.Count > 16)
            {
                throw new InvalidOperationException("Cannot add element more than 16 elements");
            }
            this.Capacity.Add(element);
        }

        public void Remove()
        {
            var maxIndex = this.Capacity.Count-1;
            this.Capacity.RemoveAt(maxIndex);
        }

        public int[] Fetch()
        {
            var list = new List<int>();

            foreach (var cap in this.Capacity)
            {
                list.Add(cap);
            }
            return list.ToArray();
        }
    }
}
