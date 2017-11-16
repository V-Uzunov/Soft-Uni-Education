namespace _03.Many_to_ManyRelation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<StudentCourse> Student { get; set; } = new List<StudentCourse>();
    }
}
