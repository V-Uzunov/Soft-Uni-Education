namespace _05.BorderControl
{
    using System;

    public class Sitizen : IBoearder
    {
        public Sitizen(string name, string age, string id)
        {
            
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
        
        public string Age { get; private set; }
        public string Name { get; private set; }
        public string Id { get; private set; }
        
    }
}
