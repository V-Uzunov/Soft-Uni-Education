namespace BookShop.Service.Models.Books
{
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;

    public class BooksListingServiceModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
