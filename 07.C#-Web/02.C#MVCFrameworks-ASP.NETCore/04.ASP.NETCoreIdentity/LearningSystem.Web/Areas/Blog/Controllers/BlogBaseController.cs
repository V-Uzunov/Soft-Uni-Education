namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Infrastructure.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area(WebConstants.BlogArea)]
    public abstract class BlogBaseController : Controller
    {
    }
}
