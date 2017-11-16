namespace _01.OOPIntro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember(int age)
        {
           return this.members.OrderByDescending(m => m.Age).FirstOrDefault();
        }
    }
}
