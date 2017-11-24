namespace LearningSystem.Service.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Admin;

    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUsersModelsView>> AllUsersAsync()
            => await this.db
                .Users
                .ProjectTo<AdminUsersModelsView>()
            .ToListAsync();
    }
}
