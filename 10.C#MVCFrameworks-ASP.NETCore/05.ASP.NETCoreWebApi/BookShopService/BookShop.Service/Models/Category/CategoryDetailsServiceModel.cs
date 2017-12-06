namespace BookShop.Service.Models.Category
{
    using BookShop.Common.Mapping;
    using BookShop.Data;
    using BookShop.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class CategoryDetailsServiceModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
