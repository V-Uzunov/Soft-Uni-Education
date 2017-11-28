namespace LearningSystem.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Models.Blog;
    using LearningSystem.Service.Models.Course;
    using LearningSystem.Service.Models.User;
    using System.Linq;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Course, CourseDetailsServiceModel>()
                .ForMember(c => c.Trainer, cfg => cfg.MapFrom(c => c.Trainer.Name))
                .ForMember(c => c.Students, cfg => cfg.MapFrom(c => c.Students.Count));

            string studentId = null;
            this.CreateMap<Course, UserProfileCourseServiceModel>()
                .ForMember(p => p.Grade, cfg => cfg
                .MapFrom(c => c.Students
                .Where(s => s.StudentId == studentId)
                .Select(s=> s.Grade)
                .FirstOrDefault()));

            this.CreateMap<User, UserProfileServiceModel>()
                .ForMember(c => c.Courses, cfg => cfg.MapFrom(s => s.Courses.Select(c => c.Course)));
        }
    }
}
