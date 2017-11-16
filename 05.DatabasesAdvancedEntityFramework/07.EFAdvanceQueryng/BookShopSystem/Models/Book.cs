namespace BookShopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Book
    {
        //Add edition types
        public enum EditionType
        {
            Normal,
            Promo,
            Gold
        }

        public enum AgeRestrictions
        {
            Minor,
            Teen,
            Adult
        }
        public Book()
        {
            this.Categories = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }

        //Add property
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(51)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public AgeRestrictions AgeRestriction { get; set; }


        [Required]
        public EditionType Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime ReleaseData { get; set; }

        public virtual Author AuthorId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}
