namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using LearningSystem.Web.Models.Home;
    using Service.Interfaces.Course;
    using LearningSystem.Service.Interfaces.User;

    public class HomeController : Controller
    {
        private readonly ICourseService courses;
        private readonly IUserService users;

        public HomeController(ICourseService courses, IUserService users)
        {
            this.users = users;
            this.courses = courses;
        }

        public async Task<IActionResult> Index()
            => View(await this.courses.ActiveCoursesAsync());
        
        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchIndexViewModel
            {
                SearchText = model.SearchText
            };

            if (model.IsSearchingInCourses)
            {
                viewModel.Courses = await this.courses.FindAsync(model.SearchText);
            }

            if (model.IsSearchingInUsers)
            {
                viewModel.Users = await this.users.FindAsync(model.SearchText);
            }

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
