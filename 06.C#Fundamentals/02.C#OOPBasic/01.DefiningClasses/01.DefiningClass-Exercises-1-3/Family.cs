using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Family
{
    private List<Person> persons;

    public Family()
    {
        this.persons = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.persons.Add(member);
    }

    public void GetOldestMember()
    {
        var result = persons.OrderByDescending(x => x.age).FirstOrDefault();

        Console.WriteLine($"{result.name} {result.age}");
    }
}
