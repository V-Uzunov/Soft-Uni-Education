namespace BookShop.Service.Implementations.Category
{
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Service.Interfaces.Category;
    using BookShop.Service.Models.Category;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesService : ICategoriesService
    {
        private readonly BookShopDbContext db;

        public CategoriesService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryDetailsServiceModel>> All()
            => await this.db
            .Categories
            .OrderBy(c=> c.Name)
            .ProjectTo<CategoryDetailsServiceModel>()
            .ToListAsync();

        public async Task<int> Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.db.Add(category);
            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task<int> DeleteById(int id)
        {
            var categoryFind =await this.db.Categories.FindAsync(id);

            this.db.Categories.Remove(categoryFind);
            await this.db.SaveChangesAsync();

            return categoryFind.Id;
        }

        public async Task<bool> Edit(int id, string name)
        {
            var findId = await this.db.Categories.FindAsync(id);

            if (findId == null)
            {
                return false;
            }

            var existName = await this.Exists(name);

            if (existName)
            {
                return false;
            }

            findId.Name = name;
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Exists(string name)
            => await this.db.Categories.AnyAsync(c => c.Name == name);

        public async Task<CategoryByIdServiceModel> FindById(int id)
            => await this.db
            .Categories
            .Where(c => c.Id == id)
            .OrderBy(c => c.Name)
            .ProjectTo<CategoryByIdServiceModel>()
            .FirstOrDefaultAsync();
    }
}
