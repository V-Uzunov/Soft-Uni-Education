namespace LearningSystem.Service.Interfaces.Course
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Course;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveCoursesAsync();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string search);

        Task<CourseDetailsServiceModel> Details(int id);

        Task<bool> IsSignInCourseAsync(int courseId, string userId);

        Task<bool> SignInUserAsync(int courseId, string userId);

        Task<bool> SignOutUserAsync(int courseId, string userId);
    }
}
