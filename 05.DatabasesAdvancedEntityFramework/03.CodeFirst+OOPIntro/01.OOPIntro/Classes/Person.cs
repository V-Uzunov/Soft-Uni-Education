namespace _01.OOPIntro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Person
    {

        private string name;
        private int age;

        public Person() : this("No Name", 1)
        {
            //this.Name = "No Name";
            //this.Age = 1;
        }
        public Person(int age) : this("No Name", age)
        {
            //this.Name = "No Name";
            //this.Age = age;
        }
        public Person(string name) : this(name, 1)
        {
            //this.Name = name;
            //this.Age = 1;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
