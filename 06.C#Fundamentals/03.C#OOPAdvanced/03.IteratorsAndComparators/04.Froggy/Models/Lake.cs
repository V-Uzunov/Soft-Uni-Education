namespace _04.Froggy.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private List<int> frogJumps;

        public Lake(List<int> frogJumps)
        {
            this.frogJumps = new List<int>(frogJumps);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.frogJumps.Count; i++)
            {
                if (i % 2 ==0)
                {
                    yield return this.frogJumps[i];
                }
            }

            for (int i = this.frogJumps.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.frogJumps[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
