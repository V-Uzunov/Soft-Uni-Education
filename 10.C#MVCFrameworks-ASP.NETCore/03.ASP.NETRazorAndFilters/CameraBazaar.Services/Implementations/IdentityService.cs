namespace CameraBazaar.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Interfaces;
    using Models.Users;

    public class IdentityService : IIdentityService
    {
        private readonly CameraBazaarDbContext db;

        public IdentityService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserModel> AllUsers()
            => this.db
                .Users
                .OrderBy(u => u.Email)
                .Select(u => new UserModel
                {
                    Email = u.Email,
                    Password = u.PasswordHash,
                    Phone = u.PhoneNumber,
                    Username = u.UserName
                })
                .ToList();

    }
}
