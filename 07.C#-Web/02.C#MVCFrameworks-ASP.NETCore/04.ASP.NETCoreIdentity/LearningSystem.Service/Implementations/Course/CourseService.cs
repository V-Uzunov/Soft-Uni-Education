namespace LearningSystem.Service.Implementations.Course
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces.Course;
    using Microsoft.EntityFrameworkCore;
    using Models.Course;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingViewModel>> ActiveCoursesAsync()
            => await this.db
                .Courses
                .OrderByDescending(x=> x.Id)
                .Where(c=> c.StartDate >= DateTime.UtcNow)
                .ProjectTo<CourseListingViewModel>()
                .ToListAsync();
    }
}
