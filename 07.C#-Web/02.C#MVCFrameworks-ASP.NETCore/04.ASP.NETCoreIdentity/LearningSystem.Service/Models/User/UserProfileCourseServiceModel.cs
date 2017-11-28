namespace LearningSystem.Service.Models.User
{
    using LearningSystem.Data.Models;

    public class UserProfileCourseServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade? Grade { get; set; }
    }
}
