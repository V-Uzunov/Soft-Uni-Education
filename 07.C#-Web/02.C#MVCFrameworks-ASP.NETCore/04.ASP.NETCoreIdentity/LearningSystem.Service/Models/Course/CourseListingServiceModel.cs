namespace LearningSystem.Service.Models.Course
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Constants;

    public class CourseListingServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.NameMinLenght)]
        [MaxLength(DataConstants.NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseDescriptionMaxLenght)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
