namespace CarDealer.App.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Customers;
    using Services.Interfaces;
    using Services.Models;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomersServices customers;

        public CustomersController(ICustomersServices customers)
        {
            this.customers = customers;
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);

            if (customer==null)
            {
                return this.NotFound();
            }

            return this.View(new CustomerModel
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, CustomerModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var customerExists = this.customers.Exist(id);

            if (!customerExists)
            {
                return this.NotFound();
            }

            this.customers
                .Edit(id,
                    model.Name,
                    model.BirthDate,
                    model.IsYoungDriver);

            return this.RedirectToAction(nameof(All), new { order = OrderType.Ascending });
        }

        [Route(nameof(Create))]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CustomerModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.customers
                .Create(model.Name,
                        model.BirthDate,
                        model.IsYoungDriver);

            return this.RedirectToAction(nameof(All), new {order = OrderType.Ascending});
        }

        [HttpGet("all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirections = order.ToLower() == "descending"
                ? OrderType.Descending
                : OrderType.Ascending;

            var customer = customers
                .OrderedCustomers(orderDirections);

            return this.View(new AllCustomersModel
            {
                Customer = customer,
                Type = orderDirections
            });
        }

        [HttpGet("{id}")]
        public IActionResult TotalSales(string id)
            => this.ViewOrNotFound(this.customers.CustomersById(id));
    }
}
