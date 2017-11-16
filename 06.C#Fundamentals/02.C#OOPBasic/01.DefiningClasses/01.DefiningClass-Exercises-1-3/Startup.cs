using System;
using System.Collections.Generic;
using System.Reflection;

public class Startup
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }
        Family family = new Family();
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var inpArgs = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var name = inpArgs[0];
            var age = int.Parse(inpArgs[1]);
            var person = new Person(name, age);

            family.AddMember(person);
        }

        family.GetOldestMember();
    }
}