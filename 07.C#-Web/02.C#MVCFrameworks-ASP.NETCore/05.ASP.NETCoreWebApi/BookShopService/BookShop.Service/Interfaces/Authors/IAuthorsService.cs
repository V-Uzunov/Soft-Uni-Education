namespace BookShop.Service.Interfaces
{
    using BookShop.Service.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorsService
    {
        Task<GetAuthorById> GetById(int id);

        Task<int> Create(string firstName, string lastName);

        Task<IEnumerable<BooksByAuthorId>> GetBooksById(int authorId);

        Task<bool> Exists(int authorId);
    }
}
