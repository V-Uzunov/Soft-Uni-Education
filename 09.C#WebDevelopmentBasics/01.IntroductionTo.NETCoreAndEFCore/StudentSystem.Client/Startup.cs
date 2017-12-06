namespace _01.StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::StudentSystem.Data;
    using global::StudentSystem.Model.Models;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                db.Database.Migrate();
                // DeleteCreateDb(db);
                // SeedData(db);
                // SeedLicenses(db);
                // PrintStudentsWithHomeworks(db);
                // PrintCourcesWithResources(db);
                // PrintCoursesWithMoreThan5Resources(db);
                // PrintStudentsNumberOfCourseAndPrice(db);
                // PrintAllCourseWithResourses(db);
                // PrintStudentWithNameAndResourses(db);
            }
        }

        private static void PrintStudentWithNameAndResourses(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Select(a => new
                {
                    a.Name,
                    CourseCount = a.Courses.Count,
                    ResoursesCount = a.Courses.Sum(s=> s.Course.Resources.Count),
                    LicenseCount=a.Courses.Select(d=> d.Course.Resources.Sum(f=> f.Licenses.Count))
                });
            foreach (var res in result)
            {
                Console.WriteLine($"{res.Name}");
                Console.WriteLine($"Course count: {res.CourseCount}");
                Console.WriteLine($"Total resourses: {string.Join("", res.ResoursesCount)}");
                Console.WriteLine($"Total licenses: {string.Join("", res.LicenseCount.Sum())}");
            }
        }

        private static void PrintAllCourseWithResourses(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .Select(x => new
                {
                    x.Name,
                    Resourses = x.Resources.Select(r => new
                    {
                        r.Name,
                        LicenseCount= r.Licenses.Count,
                        LicensesName = r.Licenses.Select(l => l.Name)
                    })
                    .OrderByDescending(a=> a.LicenseCount)
                    .ThenBy(n=> n.Name)
                    .ToList()
                })
                .OrderByDescending(x => x.Resourses.Count())
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var res in result)
            {
                Console.WriteLine($"Course name: {res.Name}");
                foreach (var re in res.Resourses)
                {
                    Console.WriteLine($" {re.Name} -- {string.Join(", ", re.LicensesName.ToList())}");
                }
            }
        }

        private static void SeedLicenses(StudentSystemDbContext db)
        {
            var resoursesId = db
                .Resources
                .Select(x => x.Id)
                .ToList();

            for (int i = 0; i < resoursesId.Count; i++)
            {
                var totalLicenses = random.Next(1, 4);
                for (int j = 0; j < totalLicenses; j++)
                {
                    db.Licenses.Add(new License
                    {
                        Name = $"License {i}{j}",
                        ResoursesId = resoursesId[i]
                    });
                }
                db.SaveChanges();
            }
        }
        
        private static void PrintStudentsNumberOfCourseAndPrice(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Select(x => new
                {
                    x.Name,
                    NumberOfCourses = x.Courses.Count,
                    TotalPrice = x.Courses.Sum(s=> s.Course.Price),
                    AveragePrice = x.Courses.Average(a=> a.Course.Price)
                })
                .OrderByDescending(x=> x.TotalPrice)
                .ThenByDescending(x=> x.NumberOfCourses)
                .ThenBy(x=> x.Name)
                .ToList();

            foreach (var res in result)
            {
                Console.WriteLine($"Student name: {res.Name}");
                Console.WriteLine($"---Number of course: {res.NumberOfCourses}");
                Console.WriteLine($"----Total price: {res.TotalPrice:f2} ---Average price: {res.AveragePrice:f2}");
                Console.WriteLine();
            }
        }

        private static void PrintCoursesWithMoreThan5Resources(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .Where(x => x.Resources.Count > 5)
                .OrderByDescending(x => x.Resources.Count)
                .ThenByDescending(x => x.StartDate)
                .Select(x => new
                {
                    x.Name,
                    ResourceCount = x.Resources.Count,
                })
                .OrderByDescending(x => x.ResourceCount)
                .ToList();

            foreach (var res in result)
            {
                Console.WriteLine($"Course name: {res.Name}");
                Console.WriteLine($"Resource count: {res.ResourceCount}");
            }
        }

        private static void PrintCourcesWithResources(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .OrderBy(x => x.StartDate)
                .ThenByDescending(x => x.EndDate)
                .Select(x => new
                {
                    x.Name,
                    x.Desctiption,
                    Resources = x.Resources
                    .Select(r => new
                    {
                        r.Name,
                        r.TypeOfRecurces,
                        r.Url
                    })
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"Course name: {course.Name}");
                Console.WriteLine($"Desctiption: {course.Desctiption}");
                foreach (var res in course.Resources)
                {
                    Console.WriteLine($"---Resource name: {res.Name} ");
                    Console.WriteLine($"----Resource type: {res.TypeOfRecurces}");
                    Console.WriteLine($"-----Resource URL: {res.Url}");
                }
                Console.WriteLine();
            }
        }

        private static void PrintStudentsWithHomeworks(StudentSystemDbContext db)
        {
            var studentsWithHomeworks = db
                .Students
                .Select(x => new
                {
                    x.Name,
                    Homeworks = x.Homeworks.Select(c => new
                    {
                        c.Content,
                        c.ContentType
                    })
                })
                .ToList();

            foreach (var students in studentsWithHomeworks)
            {
                Console.WriteLine($"Student name: {students.Name}");
                foreach (var homework in students.Homeworks)
                {
                    Console.WriteLine($"--- {homework.Content} --- {homework.ContentType}");
                }
            }
        }

        private static void SeedData(StudentSystemDbContext db)
        {
            const int totalStudents = 25;
            const int totalCourses = 12;
            var currentDate = DateTime.Now;

            // Add Students
            for (int i = 0; i < totalStudents; i++)
            {
                db.Add(new Student
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDate.AddDays(i),
                    Birthday = currentDate.AddYears(-20).AddDays(i),
                    PhoneNumber = $"Phone number : +359{i}"
                });
            }
            db.SaveChanges();

            // Add Courses
            var addedCourses = new List<Course>();

            for (int i = 0; i < totalCourses; i++)
            {
                var course = new Course
                {
                    Name = $"Curse {i}",
                    Desctiption = $"Curse Details {i}",
                    StartDate = currentDate.AddDays(i),
                    EndDate = currentDate.AddDays(i + 20),
                    Price = 100 * i
                };
                addedCourses.Add(course);
                db.Courses.Add(course);
            }
            db.SaveChanges();

            // Student in Course
            var studentsIds = db
                .Students
                .Select(x => x.Id)
                .ToList();

            for (int i = 0; i < totalCourses; i++)
            {
                var studentInCourse = random.Next(2, totalStudents / 2);
                var currentCourse = addedCourses[i];
                for (int j = 0; j < studentInCourse; j++)
                {
                    var studentsId = studentsIds[random.Next(0, studentsIds.Count)];

                    if (!currentCourse.Students.Any(x => x.StudentId == studentsId))
                    {
                        currentCourse.Students.Add(new StudentCourse
                        {
                            StudentId = studentsId
                        });
                    }
                    else
                    {
                        j--;
                    }

                }
                var resourcesInCourse = random.Next(2, 20);
                var type = new[] { 0, 1, 2, 999 }.ToArray();
                for (int j = 0; j < resourcesInCourse; j++)
                {
                    currentCourse.Resources.Add(new Resource
                    {
                        Name = $"Resource {i} {j}",
                        Url = $"URL {i} {j}",
                        TypeOfRecurces = (ResourceType)type[random.Next(0, type.Length)]
                    });
                }
            }
            db.SaveChanges();

            // Homeworks
            for (int i = 0; i < totalCourses; i++)
            {
                var currentCourse = addedCourses[i];
                var studentInCourseIds = currentCourse
                    .Students
                    .Select(x => x.StudentId)
                    .ToList();

                for (int j = 0; j < studentInCourseIds.Count; j++)
                {
                    var totalHomework = random.Next(2, 5);
                    for (int k = 0; k < totalHomework; k++)
                    {
                        db.Homeworks.Add(new Homework
                        {
                            Content = $"Content Homework {i}",
                            ContentType = ContentType.Zip,
                            SubmissionDate = currentDate.AddDays(-i),
                            StudentId = studentInCourseIds[j],
                            CourseId = currentCourse.Id
                        });
                    }
                }
                db.SaveChanges();
            }
        }

        private static void DeleteCreateDb(StudentSystemDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
