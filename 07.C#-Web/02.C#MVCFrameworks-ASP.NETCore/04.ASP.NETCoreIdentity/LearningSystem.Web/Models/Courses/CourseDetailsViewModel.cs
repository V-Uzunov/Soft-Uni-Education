namespace LearningSystem.Web.Models.Courses
{
    using LearningSystem.Service.Models.Course;

    public class CourseDetailsViewModel
    {
        public CourseDetailsServiceModel Courses { get; set; }

        public bool IsSignInCourse { get; set; }
    }
}
