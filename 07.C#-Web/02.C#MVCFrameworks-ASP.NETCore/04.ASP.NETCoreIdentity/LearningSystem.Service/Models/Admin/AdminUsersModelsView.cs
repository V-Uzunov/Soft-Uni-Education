namespace LearningSystem.Service.Models.Admin
{
    using System.ComponentModel.DataAnnotations;
    using Data.Constants;

    public class AdminUsersModelsView
    {
        public string Id { get; set; }

        [Required]
        [MinLength(DataConstants.NameMinLenght)]
        [MaxLength(DataConstants.NameMaxLenght)]
        public string Username { get; set; }

        public string Email { get; set; }
    }
}
