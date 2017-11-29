namespace LearningSystem.Web.Models.Home
{
    using LearningSystem.Service.Models.Course;
    using LearningSystem.Service.Models.User;
    using System.Collections.Generic;

    public class SearchIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }

        public IEnumerable<UsersListingServiceModel> Users { get; set; }

        public string SearchText { get; set; }
    }
}
