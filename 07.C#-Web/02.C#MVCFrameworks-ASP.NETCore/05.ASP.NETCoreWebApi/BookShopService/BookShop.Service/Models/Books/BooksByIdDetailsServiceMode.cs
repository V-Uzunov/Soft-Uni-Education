namespace BookShop.Service.Models.Books
{
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;
    using System.Linq;

    public class BooksByIdDetailsServiceMode : BooksByAuthorId, IMapFrom<Book>, IHaveCustomMapping
    {
        public string Author { get; set; }

        public override void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Book, BooksByIdDetailsServiceMode>()
                .ForMember(b => b.Categories, cfg => cfg
                    .MapFrom(b => b.Categories.Select(c => c.Category.Name)))
                .ForMember(b => b.Author, cfg => cfg
                    .MapFrom(b => b.Author.FirstName + " " + b.Author.LastName));
        }
    }
}
