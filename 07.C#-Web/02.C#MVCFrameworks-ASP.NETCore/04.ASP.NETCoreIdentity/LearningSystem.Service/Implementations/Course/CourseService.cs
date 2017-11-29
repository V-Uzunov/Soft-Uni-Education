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
    using LearningSystem.Data.Models;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveCoursesAsync()
            => await this.db
                .Courses
                .OrderByDescending(x=> x.Id)
                .Where(c=> c.StartDate >= DateTime.UtcNow)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

        public async Task<CourseDetailsServiceModel> Details(int id)
            => await this.db
            .Courses
            .Where(c => c.Id == id)
            .ProjectTo<CourseDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<CourseListingServiceModel>> FindAsync(string search)
            => await this.db
            .Courses
            .OrderBy(c => c.Name)
            .Where(c => c.Name.ToLower().Contains(search.ToLower()))
            .ProjectTo<CourseListingServiceModel>()
            .ToListAsync();

        public async Task<bool> IsSignInCourseAsync(int courseId, string userId)
            => await this.db
            .Courses
            .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == userId));

        public async Task<bool> SignInUserAsync(int courseId, string userId)
        {
            var courseInfo = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new CourseDetailsSignModel
                {
                    StartDate=c.StartDate,
                    IsSignInCourse=c.Students.Any(s=> s.StudentId == userId)
                })
                .FirstOrDefaultAsync();

            if (courseInfo==null 
                || courseInfo.StartDate < DateTime.UtcNow 
                || courseInfo.IsSignInCourse)
            {
                return false;
            }


            var studentCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = userId
            };

            this.db.Add(studentCourse);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutUserAsync(int courseId, string userId)
        {
            var courseInfo = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new CourseDetailsSignModel
                {
                    StartDate = c.StartDate,
                    IsSignInCourse = c.Students.Any(s => s.StudentId == userId)
                })
                .FirstOrDefaultAsync();

            if (courseInfo == null
                || courseInfo.StartDate < DateTime.UtcNow
                || !courseInfo.IsSignInCourse)
            {
                return false;
            }

            var course= await this.db.FindAsync<StudentCourse>(courseId, userId);

            this.db.Remove(course);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
