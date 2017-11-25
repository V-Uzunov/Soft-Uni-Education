namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Constants;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Courses;
    using Service.Interfaces.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Controllers;

    public class CoursesController : AdminBaseController
    {
        private readonly IAdminCourseService courses;
        private readonly UserManager<User> userManager;

        public CoursesController(IAdminCourseService courses,
            UserManager<User> userManager)
        {
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Create()
            => this.View(new AdminCoursesModel
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                Trainers = await this.GetTrainers()
            });

        [HttpPost]
        public async Task<IActionResult> Create(AdminCoursesModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers =await this.GetTrainers();
                return this.View(model);
            }

            await this.courses
                 .CreateCourseAsync(model.Name,
                               model.Description,
                               model.StartDate,
                               model.EndDate,
                               model.TrainerId);

            TempData.AddSuccessMessage($"Course {model.Name} added successfully!");

            return RedirectToAction(nameof(HomeController.Index), "Home", new {area=string.Empty});
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
        {
            var trainers = await this.userManager.GetUsersInRoleAsync(WebConstants.TrainerRoleName);

            var trainersListItem = trainers
                .Select(r => new SelectListItem
                {
                    Text = r.UserName,
                    Value = r.Id
                })
                .ToList();

            return trainersListItem;
        }
    }
}
