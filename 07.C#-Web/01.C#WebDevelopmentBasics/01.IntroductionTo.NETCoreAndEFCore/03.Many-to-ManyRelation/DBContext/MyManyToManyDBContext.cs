namespace _03.Many_to_ManyRelation
{
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.EntityFrameworkCore;
    public class MyManyToManyDBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=(LocalDb)\MSSQLLocalDB;Database=EFCoreManyToManyDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(x => new {x.CourseId, x.StudentId});

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Course)
                .WithOne(sc => sc.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(x => x.Student)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
