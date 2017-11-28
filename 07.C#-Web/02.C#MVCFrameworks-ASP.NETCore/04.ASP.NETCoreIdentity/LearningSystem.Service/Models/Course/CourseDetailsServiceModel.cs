namespace LearningSystem.Service.Models.Course
{
    using System;

    public class CourseDetailsServiceModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Trainer { get; set; }

        public int Students { get; set; }


    }
}
