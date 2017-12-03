namespace BookShop.Service.Implementations
{
    using System.Threading.Tasks;
    using BookShop.Data;
    using BookShop.Service.Interfaces;
    using BookShop.Service.Models;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using BookShop.Data.Models;
    using System.Collections.Generic;

    public class AuthorsService : IAuthorsService
    {
        private readonly BookShopDbContext db;

        public AuthorsService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName=firstName,
                LastName=lastName
            };

            this.db.Add(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<bool> Exists(int authorId)
            => await this.db.Authors.AnyAsync(a => a.Id == authorId);

        public async Task<IEnumerable<BooksByAuthorId>> GetBooksById(int authorId)
            => await this.db
            .Books
            .Where(b => b.AuthorId == authorId)
            .ProjectTo<BooksByAuthorId>()
            .ToListAsync();

        public async Task<GetAuthorById> GetById(int id)
            => await this.db
            .Authors
            .Where(a => a.Id == id)
            .OrderBy(a=> a.Id)
            .ProjectTo<GetAuthorById>()
            .FirstOrDefaultAsync();
    }
}
