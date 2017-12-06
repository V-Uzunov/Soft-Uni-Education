namespace _06.StrategyPattern.Models
{
    using System.Text;

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Age}");

            return sb.ToString().Trim();
        }
    }
}
