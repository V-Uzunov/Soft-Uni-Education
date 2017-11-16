using Startup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new StudySystemContext();

            context.Database.Initialize(true);

            //3.1
            //StudentsAndHomeworks(context);

            //3.2
            //AllCurseWithResource(context);

            //3.3
            //AllCourseWithMoreThan5Res(context);

            //3.5
            //AllCourseInfo(context);
        }

        private static void AllCourseInfo(StudySystemContext context)
        {
            var students = context.Students
                            .OrderByDescending(student => student.Courses.Sum(course => course.Price))
                            .ThenByDescending(student => student.Courses.Count)
                            .ThenBy(student => student.Name);

            foreach (var student in students)
            {
                if (student.Courses.Count != 0)
                {
                    Console.WriteLine(
                        $"{student.Name} - {student.Courses.Count} - {student.Courses.Sum(course => course.Price)} - {student.Courses.Average(course => course.Price)}");
                }
            }
        }

        private static void AllCourseWithMoreThan5Res(StudySystemContext context)
        {
            var courses =
                            context.Courses.Where(course => course.Resources.Count > 5)
                                .OrderByDescending(course => course.Resources.Count)
                                .ThenByDescending(course => course.StartDate);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Resources.Count}");
            }
        }

        private static void AllCurseWithResource(StudySystemContext context)
        {
            var courses = context.Courses.OrderBy(course => course.StartDate).ThenByDescending(course => course.EndDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.Description}");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"--{resource.Name} {resource.Type} {resource.Url}");
                }
            }
        }

        private static void StudentsAndHomeworks(StudySystemContext context)
        {
            foreach (var student in context.Students)
            {
                Console.WriteLine($"{student.Name} write =>");
                foreach (var content in student.Homeworks)
                {
                    Console.WriteLine($"{content.Content} => {content.ContentType}");
                }
            }
        }
    }
}
