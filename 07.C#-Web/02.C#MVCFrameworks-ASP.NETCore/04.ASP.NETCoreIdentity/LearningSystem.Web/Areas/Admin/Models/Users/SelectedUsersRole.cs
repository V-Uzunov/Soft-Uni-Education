namespace LearningSystem.Web.Areas.Admin.Models.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Service.Models.Admin;

    public class SelectedUsersRole
    {
        public IEnumerable<AdminUsersModelsView> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
