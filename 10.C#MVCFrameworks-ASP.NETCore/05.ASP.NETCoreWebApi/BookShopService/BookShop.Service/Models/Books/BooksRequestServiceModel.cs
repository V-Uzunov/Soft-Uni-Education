namespace BookShop.Service.Models.Books
{
    using BookShop.Data;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BooksRequestServiceModel
    {
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

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public string Categories { get; set; } 
    }
}
