namespace LearningSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Admin;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUsersModelsView>> AllUsersAsync();
    }
}
