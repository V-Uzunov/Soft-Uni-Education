namespace LearningSystem.Service.Implementations.User
{
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Service.Interfaces.User;
    using LearningSystem.Service.Models.User;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UsersListingServiceModel>> FindAsync(string search)
            => await this.db
            .Users
            .OrderBy(c => c.UserName)
            .Where(c => c.Name.ToLower().Contains(search.ToLower()))
            .ProjectTo<UsersListingServiceModel>()
            .ToListAsync();

        public UserProfileServiceModel Profile(string id)
            =>this.db
            .Users
            .Where(u => u.Id == id)
            .ProjectTo<UserProfileServiceModel>(new { studentId = id })
            .FirstOrDefault();
    }
}
