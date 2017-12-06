namespace _01.StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|",
                "Name", "CAdv", "COOP", "AdvOOP", "Average");

            for (var i = 0; i < n; i++)
            {
                var students = Console.ReadLine()
                    .Split(new[] {"-", " ", ","}, StringSplitOptions.RemoveEmptyEntries);

                var name = students[0];
                var firstRes = double.Parse(students[1]);
                var secondRes = double.Parse(students[2]);
                var thirdRes = double.Parse(students[3]);

                var averageRes = (firstRes + secondRes + thirdRes) / 3;

                Console.WriteLine($"{name,-10}|{firstRes,7:f2}|{secondRes,7:f2}|{thirdRes,7:f2}|{averageRes,7:f4}|");
            }
        }
    }
}
