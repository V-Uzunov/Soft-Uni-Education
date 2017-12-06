namespace CarDealer.App.Controllers
{
    using Services.Interfaces;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    [Route("sales")]
    public class SalesController : Controller
    {
        private ISalesServices sales;

        public SalesController(ISalesServices sales)
        {
            this.sales = sales;
        }

        [Route("all")]
        public IActionResult All()
            => this.View(this.sales.All());

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.sales.Details(id));
    }
}
