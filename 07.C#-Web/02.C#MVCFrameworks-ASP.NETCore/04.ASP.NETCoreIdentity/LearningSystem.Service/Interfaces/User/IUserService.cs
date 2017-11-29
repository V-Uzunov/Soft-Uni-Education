namespace LearningSystem.Service.Interfaces.User
{
    using LearningSystem.Service.Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        UserProfileServiceModel Profile(string username);

        Task<IEnumerable<UsersListingServiceModel>> FindAsync(string search);
    }
}
