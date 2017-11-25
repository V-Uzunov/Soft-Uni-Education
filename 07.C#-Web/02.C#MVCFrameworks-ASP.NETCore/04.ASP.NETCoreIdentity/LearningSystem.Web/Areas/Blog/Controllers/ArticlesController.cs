namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Data.Models;
    using Infrastructure.Constants;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Service.Interfaces.Blog;
    using Service.Interfaces.Html;
    using Service.Models.Blog;
    using Web.Controllers;

    public class ArticlesController : BlogBaseController
    {
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;
        private readonly ISanitizerHtml html;
        

        public ArticlesController(IBlogArticleService articles, UserManager<User> userManager, ISanitizerHtml html)
        {
            this.articles = articles;
            this.userManager = userManager;
            this.html = html;
        }

        public IActionResult Create()
            => this.View();

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var articleById =await this.articles.ByIdAsync(id);
            if (articleById==null)
            {
                return NotFound();
            }

            return View(await this.articles.ByIdAsync(id));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticlesListingPageModel
            {
                Articles = await this.articles.AllAsync(page),
                CurrentPage = page,
                TotalPages =(int)Math.Ceiling((double)await this.articles.TotalAsync() / WebConstants.PageSize)
            });

        [HttpPost]
        public async Task<IActionResult> Create(BlogArticlesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles
                .CreateAsync(model.Title,
                             model.Content,
                             userId);

            TempData.AddSuccessMessage($"Article {model.Title} has published successfully!");

            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }
    }
}
