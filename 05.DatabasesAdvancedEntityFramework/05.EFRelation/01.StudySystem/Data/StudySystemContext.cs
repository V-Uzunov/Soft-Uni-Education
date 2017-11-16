namespace Startup
{
    using global::Startup.Migrations;
    using global::Startup.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudySystemContext : DbContext
    {
        public StudySystemContext()
            : base("name=StudySystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudySystemContext, Configuration>());
        }


        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Licence> Licences { get; set; }

    }
}