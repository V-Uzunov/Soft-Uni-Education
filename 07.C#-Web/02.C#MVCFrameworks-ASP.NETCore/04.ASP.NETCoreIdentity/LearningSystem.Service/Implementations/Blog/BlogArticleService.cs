namespace LearningSystem.Service.Implementations.Blog
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Interfaces.Blog;
    using Microsoft.EntityFrameworkCore;
    using Models.Blog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogArticleService : IBlogArticleService
    {
        private readonly LearningSystemDbContext db;

        public BlogArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, string content, string userId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = userId
            };

            await this.db.AddAsync(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogArticleListingViewModel>> AllAsync(int page = 1, int pageSize = 6)
            => await this.db
                .Articles
                .OrderBy(a => a.PublishDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogArticleListingViewModel>()
                .ToListAsync();

        public async Task<int> TotalAsync() => await this.db.Articles.CountAsync();

        public async Task<BlogArticleDetailsViewModel> ByIdAsync(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<BlogArticleDetailsViewModel>()
                .FirstOrDefaultAsync();
    }
}
