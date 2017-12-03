namespace BookShop.Service.Implementations.Books
{
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Service.Interfaces.Books;
    using BookShop.Service.Models.Books;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System;
    using BookShop.Data.Models;
    using BookShop.Common.Extensions;

    public class BooksService : IBooksService
    {
        private readonly BookShopDbContext db;

        public BooksService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string title,
            string description,
            int? ageRestriction,
            string categories,
            int copies,
            int? edition,
            int authorId,
            DateTime releaseDate,
            decimal price)
        {
            var categoryNames = categories
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var existingCategory = await this.db
                .Categories
                .Where(c => categoryNames.Contains(c.Name))
                .ToListAsync();

            var allCategories = new List<Category>(existingCategory);

            foreach (var categoryName in categoryNames)
            {
                if (existingCategory.All(c=> c.Name !=categoryName))
                {
                    var category = new Category
                    {
                        Name=categoryName
                    };
                    this.db.Add(category);

                    allCategories.Add(category);
                }
            }

            var book = new Book
            {
                Title=title,
                Description=description,
                Copies=copies,
                Price = price,
                Edition=edition,
                AgeRestriction=ageRestriction,
                AuthorId=authorId,
                ReleaseDate=releaseDate
            };

            existingCategory.ForEach(id => book.Categories.Add(new BookCategory
            {
                CategoryId = id.Id
            }));

           this.db.Add(book);
           await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> Edit(int id,
            string title,
            string description,
            int? ageRestriction,
            int copies,
            int? edition,
            int authorId,
            DateTime releaseDate,
            decimal price)
        {
            var bookId = this.db.Books.Find(id);

            if (bookId == null)
            {
               return 0;
            }

            bookId.Title = title;
            bookId.Description = description;
            bookId.Copies = copies;
            bookId.Edition = edition;
            bookId.AgeRestriction = ageRestriction;
            bookId.AuthorId = authorId;
            bookId.ReleaseDate = releaseDate;
            bookId.Price = price;

            await this.db.SaveChangesAsync();
            return bookId.Id;
        }

        public async Task<BooksByIdDetailsServiceMode> GetById(int id)
            => await this.db
            .Books
            .Where(b => b.Id == id)
            .ProjectTo<BooksByIdDetailsServiceMode>()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<BooksListingServiceModel>> GetBySearch(string word)
            => await this.db
            .Books
            .Where(b => b.Title.ToLower().Contains(word.ToLower()))
            .OrderBy(b=> b.Title)
            .Take(10)
            .ProjectTo<BooksListingServiceModel>()
            .ToListAsync();
    }
}
