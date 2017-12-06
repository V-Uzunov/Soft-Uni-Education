namespace BookShop.Service.Models
{
    using BookShop.Data;
    using System.ComponentModel.DataAnnotations;

    public class AuthorRequestServiceModel
    {
        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenght)]
        public string LastName { get; set; }
    }
}
