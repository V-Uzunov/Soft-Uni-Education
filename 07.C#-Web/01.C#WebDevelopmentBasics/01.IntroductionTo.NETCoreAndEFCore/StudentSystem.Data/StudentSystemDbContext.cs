namespace StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Model.Models;

    public class StudentSystemDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=(LocalDb)\MSSQLLocalDB;Database=StudentSystemDB;Integrated Security=True;");

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                .HasKey(x => new {x.CourseId, x.StudentId});

            builder.Entity<Student>()
                .HasMany(x => x.Courses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(x => x.StudentId);

            builder.Entity<Course>()
                .HasMany(x => x.Students)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            builder.Entity<Course>()
                .HasMany(x => x.Resources)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            builder
                .Entity<Course>()
                .HasMany(c => c.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);

            builder
                .Entity<Student>()
                .HasMany(s => s.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);

            builder.Entity<Resource>()
                .HasMany(x => x.Licenses)
                .WithOne(x => x.Resource)
                .HasForeignKey(x => x.ResoursesId);

            base.OnModelCreating(builder);
        }
    }
}
