namespace LearningSystem.Service.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces.Admin;
    using Microsoft.EntityFrameworkCore;
    using Models.Admin;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
