namespace LearningSystem.Service.Implementations.Admin
{
    using Data;
    using Data.Models;
    using Interfaces.Admin;
    using System;
    using System.Threading.Tasks;

    public class AdminCourseService : IAdminCourseService
    {
        private readonly LearningSystemDbContext db;

        public AdminCourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateCourseAsync(string name, string description, DateTime startDate, DateTime endDate, string trainerId)
        {
            var course =new Course
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                TrainerId = trainerId
            };

            await this.db.AddAsync(course);
            await this.db.SaveChangesAsync();
        }
    }
}
