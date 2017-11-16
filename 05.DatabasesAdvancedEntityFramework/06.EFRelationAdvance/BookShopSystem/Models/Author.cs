namespace BookShopSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        //Adding constructor
        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        //Add property
        [Key]
        [Required]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
