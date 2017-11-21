namespace CameraBazaar.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.Users;

    public interface IIdentityService
    {
        IEnumerable<UserModel> AllUsers();
    }
}
