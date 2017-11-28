namespace LearningSystem.Service.Implementations.User
{
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Service.Interfaces.User;
    using LearningSystem.Service.Models.User;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;

        public UserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public UserProfileServiceModel Profile(string id)
            =>this.db
            .Users
            .Where(u => u.Id == id)
            .ProjectTo<UserProfileServiceModel>(new { studentId = id })
            .FirstOrDefault();
    }
}
