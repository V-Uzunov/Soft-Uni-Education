namespace LearningSystem.Service.Models.User
{
    using System;
    using System.Collections.Generic;

    public class UserProfileServiceModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public DateTime Bhirthdate { get; set; }

        public IEnumerable<UserProfileCourseServiceModel> Courses { get; set; }
    }
}
