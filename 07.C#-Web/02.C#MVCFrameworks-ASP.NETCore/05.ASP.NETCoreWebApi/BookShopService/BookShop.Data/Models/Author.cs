using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.AuthorNameMaxLenght)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
