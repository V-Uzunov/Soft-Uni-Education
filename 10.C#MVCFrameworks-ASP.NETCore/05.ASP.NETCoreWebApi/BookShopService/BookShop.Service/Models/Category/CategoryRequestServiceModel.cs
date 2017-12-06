namespace BookShop.Service.Models.Category
{
    using BookShop.Data;
    using System.ComponentModel.DataAnnotations;

    public class CategoryRequestServiceModel
    {
        [Required]
        [MaxLength(DataConstants.CategoryMaxLenght)]
        public string Name { get; set; }
    }
}
