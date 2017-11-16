namespace Startup.Migrations
{
    using global::Startup.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudySystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           
        }

        protected override void Seed(StudySystemContext context)
        {
            Student std = new Student()
            {
                Name="Ivan",
                PhoneNumber="08862166454",
                RegistrationDate=DateTime.Now,
                Birthday= new DateTime(1990, 12, 25)
            };

            Student std2 = new Student()
            {
                Name = "Petkan",
                PhoneNumber = "08862166454",
                RegistrationDate = DateTime.Now,
                Birthday = new DateTime(1990, 12, 22)
            };

            Student std3 = new Student()
            {
                Name = "Dragan",
                PhoneNumber = "08862166454",
                RegistrationDate = DateTime.Now,
                Birthday = new DateTime(1990, 12, 24)
            };

            Course c = new Course()
            {
                Name="C# 101",
                Description="C#",
                StartDate=DateTime.Now,
                EndDate = new DateTime(1990, 12, 24),
                Price=160.00m
            };

            Course c2 = new Course()
            {
                Name = "C# 105",
                Description = "C#",
                StartDate = DateTime.Now,
                EndDate = new DateTime(1990, 12, 24),
                Price = 162.00m
            };

            Course c3 = new Course()
            {
                Name = "C# 102",
                Description = "C#",
                StartDate = DateTime.Now,
                EndDate = new DateTime(1990, 12, 24),
                Price = 161.00m
            };

            Resource r = new Resource()
            {
                Name="Nakov book",
                Type=ResourceType.Document,
                Url="www.nakov.bg"
            };

            Resource r2 = new Resource()
            {
                Name = "Nakov university",
                Type = ResourceType.Presentation,
                Url = "www.softuni.bg"
            };

            Resource r3 = new Resource()
            {
                Name = "Nakov site",
                Type = ResourceType.Video,
                Url = "www.softuni/videos.bg"
            };

            Homework hw = new Homework()
            {
                Content="Kak se stava programist",
                ContentType=ContentType.Zip,
                SubmissionDate=new DateTime(1880, 06, 25)
            };

            Homework hw2 = new Homework()
            {
                Content = "Kak se stava traktoris",
                ContentType = ContentType.Application,
                SubmissionDate = new DateTime(1880, 06, 25)
            };

            Homework hw3 = new Homework()
            {
                Content = "Kak se stava bagerist",
                ContentType = ContentType.Pdf,
                SubmissionDate = new DateTime(1880, 06, 25)
            };

            Licence l1 = new Licence()
            {
                Name="test1"
            };
            Licence l2 = new Licence()
            {
                Name = "test2"
            };
            Licence l3 = new Licence()
            {
                Name = "test3"
            };

            // Add licenses to resources (EXERCISE - 4.Resource Licenses)
            r.Licence.Add(l1);
            r2.Licence.Add(l1);
            r3.Licence.Add(l1);
            r2.Licence.Add(l2);
            r3.Licence.Add(l3);

            // Add courses to students
            std.Courses.Add(c);
            std.Courses.Add(c2);
            std.Courses.Add(c3);
            std2.Courses.Add(c);
            std2.Courses.Add(c2);
            std3.Courses.Add(c);
            
            // Add homeworks to students
            std.Homeworks.Add(hw);
            std2.Homeworks.Add(hw2);
            std3.Homeworks.Add(hw3);

            // Add resources to courses
            c.Resources.Add(r);
            c.Resources.Add(r2);
            c2.Resources.Add(r2);
            c3.Resources.Add(r);
            c3.Resources.Add(r3);

            // Add students to the DB
            context.Students.AddOrUpdate(x => x.Name, std);
            context.Students.AddOrUpdate(x => x.Name, std2);
            context.Students.AddOrUpdate(x => x.Name, std3);

            // Add resources to the DB
            context.Resources.AddOrUpdate(x => x.Name, r);
            context.Resources.AddOrUpdate(x => x.Name, r2);
            context.Resources.AddOrUpdate(x => x.Name, r3);

            // Add homeworks to the DB
            context.Homeworks.AddOrUpdate(x => x.Content, hw);
            context.Homeworks.AddOrUpdate(x => x.Content, hw2);
            context.Homeworks.AddOrUpdate(x => x.Content, hw3);

            // Add courses to the DB
            context.Courses.AddOrUpdate(x => x.Name, c);
            context.Courses.AddOrUpdate(x => x.Name, c2);
            context.Courses.AddOrUpdate(x => x.Name, c3);

            // Add licenses to the DB (EXERCISE - 4.Resource Licenses)
            context.Licences.AddOrUpdate(x => x.Name, l1);
            context.Licences.AddOrUpdate(x => x.Name, l2);
            context.Licences.AddOrUpdate(x => x.Name, l3);
        }
    }
}
