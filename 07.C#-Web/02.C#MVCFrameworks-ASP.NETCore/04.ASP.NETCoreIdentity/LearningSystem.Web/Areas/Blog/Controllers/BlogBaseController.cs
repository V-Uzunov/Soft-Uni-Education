namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Infrastructure.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRoleName)]
    public abstract class BlogBaseController : Controller
    {
    }
}
