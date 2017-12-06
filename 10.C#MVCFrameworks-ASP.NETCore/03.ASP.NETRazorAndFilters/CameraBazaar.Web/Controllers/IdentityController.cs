namespace CameraBazaar.Web.Controllers
{
    using Data.Models;
    using Infrastructure.GlobalConstants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class IdentityController : Controller
    {
        private readonly UserManager<User> users;
        private readonly RoleManager<IdentityRole> roles;
        private readonly IIdentityService identity;

        public IdentityController(UserManager<User> users, RoleManager<IdentityRole> roles, IIdentityService identity)
        {
            this.users = users;
            this.roles = roles;
            this.identity = identity;
        }

        public IActionResult All()
            => this.View(this.identity.AllUsers());
    }
}
