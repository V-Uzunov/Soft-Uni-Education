namespace BookShop.Service.Interfaces.Books
{
    using BookShop.Service.Models.Books;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;

    public interface IBooksService
    {
        Task<BooksByIdDetailsServiceMode> GetById(int id);

        Task<IEnumerable<BooksListingServiceModel>> GetBySearch(string word);

        Task<int> Create(string title, string description, int? ageRestriction, string categories, int copies, int? edition, int authorId, DateTime releaseDate, decimal price);

        Task<int> Edit(int id, string title, string description, int? ageRestriction, int copies, int? edition, int authorId, DateTime releaseDate, decimal price);

        Task<int> Delete(int id);
    }
}
