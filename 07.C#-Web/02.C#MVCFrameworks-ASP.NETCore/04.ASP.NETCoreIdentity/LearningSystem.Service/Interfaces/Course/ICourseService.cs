namespace LearningSystem.Service.Interfaces.Course
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Course;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingViewModel>> ActiveCoursesAsync();
    }
}
