namespace CarDealer.App.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Logs;
    using Services.Interfaces;

    [Route("logs")]
    public class LogsController : Controller
    {
        private readonly ILogServices log;
        private const int PageSize = 5;
        public LogsController(ILogServices log)
        {
            this.log = log;
        }

        [Authorize]
        [Route(nameof(All))]
        public IActionResult All(int page = 1)
            => this.View(new LogPageModel
            {
                LogModels = this.log.All(page, PageSize),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.log.Total() / (double)PageSize)
            });

        [Authorize]
        [Route(nameof(Clear))]
        public IActionResult Clear()
        {
            this.log.Clear();

            return this.RedirectToAction(nameof(All));
        }
    }
}
