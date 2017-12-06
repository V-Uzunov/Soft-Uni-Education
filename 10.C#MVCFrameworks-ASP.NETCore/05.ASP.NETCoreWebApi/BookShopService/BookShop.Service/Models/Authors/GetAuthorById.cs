namespace BookShop.Service.Models
{
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class GetAuthorById : IMapFrom<Book>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> BooksTitle { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Author, GetAuthorById>()
                .ForMember(a => a.BooksTitle, cfg => cfg
                .MapFrom(a => a.Books.Select(b => b.Title)));
    }
}
