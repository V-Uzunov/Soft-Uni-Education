namespace BookShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.BookTitleMinLenght)]
        [MaxLength(DataConstants.BookTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.BookDescriptionMinLenght)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();

    }
}
