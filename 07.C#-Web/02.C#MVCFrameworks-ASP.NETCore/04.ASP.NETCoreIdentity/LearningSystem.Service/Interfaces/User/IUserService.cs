namespace LearningSystem.Service.Interfaces.User
{
    using LearningSystem.Service.Models.User;

    public interface IUserService
    {
        UserProfileServiceModel Profile(string username);
    }
}
