using _01.OOPIntro;
using System;
using System.Collections.Generic;
using System.Linq;

class OOPIntroExercises
{
    static void Main()
    {
        //01.
        //DefineAClassPerson();

        //02.
        //CreatePersonConstructors();

        //04.
        //Students();

        //06.
        //MathUtilis();
    }

    private static void MathUtilis()
    {
        var input = Console.ReadLine().Split().ToList();
        var num = 0.0;
        while (input[0] != "End")
        {
            switch (input[0])
            {
                case "Sum":
                    num = MathUtil.Sum(int.Parse(input[1]), int.Parse(input[2]));
                    break;

                case "Subtract":
                    num = MathUtil.Substract(int.Parse(input[1]), int.Parse(input[2]));
                    break;

                case "Multiply":
                    num = MathUtil.Multiply(int.Parse(input[1]), int.Parse(input[2]));
                    break;

                case "Divide":
                    num = MathUtil.Divide(int.Parse(input[1]), int.Parse(input[2]));
                    break;

                case "Precentage":
                    num = MathUtil.Percentage(int.Parse(input[1]), int.Parse(input[2]));
                    break;
                default:
                    break;
            }
            input = Console.ReadLine().Split().ToList();
        }
        Console.WriteLine($"{num:F2}");
    }

    private static void Students()
    {
        var input = Console.ReadLine();
        while (input != "End")
        {
            Student stu = new Student(input);
            input = Console.ReadLine();
        }
        Console.WriteLine(Student.count);
    }

    private static void CreatePersonConstructors()
    {
        var inputArgs = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        if (inputArgs.Count == 0)
        {

            //02.01 Take no argument
            Person p1 = new Person();
            Console.WriteLine($"{p1.Name} {p1.Age}");
        }
        else if (inputArgs.Count == 1)
        {
            var argument = inputArgs[0];
            var age = -1;
            if (int.TryParse(argument, out age))
            {
                //02.02 Take age argument
                Person p3 = new Person(age);
                Console.WriteLine($"{p3.Name} {p3.Age}");
            }
            else
            {
                //02.03 Take name argument
                Person p2 = new Person(argument);
                Console.WriteLine($"{p2.Name} {p2.Age}");
            }
        }
        else if (inputArgs.Count == 2)
        {
            //02.04 Take name and age arguments
            var name = inputArgs[0];
            var age = int.Parse(inputArgs[1]);

            Person p3 = new Person(name, age);
            Console.WriteLine($"{p3.Name} {p3.Age}");
        }
    }

    private static void DefineAClassPerson()
    {
        Person p = new Person() { Name = "Pesho", Age = 20 };
        //p.Name = "Pesho";
        //p.Age = 20;
    }
}