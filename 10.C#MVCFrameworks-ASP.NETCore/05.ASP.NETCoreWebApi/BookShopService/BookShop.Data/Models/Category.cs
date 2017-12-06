using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CategoryMaxLenght)]
        public string Name { get; set; }

        public ICollection<BookCategory> Books { get; set; } = new List<BookCategory>();
    }
}
