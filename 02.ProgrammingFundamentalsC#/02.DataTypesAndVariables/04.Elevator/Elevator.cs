using System;

class Elevator
{
    static void Main()
    {
        var people = int.Parse(Console.ReadLine());
        var capacity = int.Parse(Console.ReadLine());
        var courses =(int) Math.Ceiling((double)(people / capacity));
        var remainderCourses = (int)Math.Ceiling((double)(people%capacity)/people);
        if (people % capacity==0)
        {
            Console.WriteLine(courses);
        }
        else 
        {
            Console.WriteLine(courses+remainderCourses);
        }
    }
}

