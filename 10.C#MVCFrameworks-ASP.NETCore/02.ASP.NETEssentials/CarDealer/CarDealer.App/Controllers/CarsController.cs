namespace CarDealer.App.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Cars;
    using Services.Interfaces;
    using Services.Models;

    [Route("cars")]
    public class CarsController : Controller
    {
        private const int PageSize = 25;
        private readonly ICarServices cars;
        private readonly IPartsServices parts;
        private readonly ILogServices logs;

        public CarsController(ICarServices cars, IPartsServices parts, ILogServices logs)
        {
            this.cars = cars;
            this.parts = parts;
            this.logs = logs;
        }

        [Authorize]
        [Route(nameof(Create))]
        public IActionResult Create()
            => this.View();

        [Authorize]
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CarByMake carModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.cars
                .Create(carModel.Model,
                        carModel.Make,
                        carModel.TravelledDistance);
            AddLoggs(nameof(Create));

            return this.RedirectToAction(nameof(All));
        }

        private void AddLoggs(string operation)
            => this.logs
                            .AddLog(this.User.Identity.Name,
                                    operation,
                                    "Car",
                                    DateTime.UtcNow);

        [HttpGet("{make}")]
        public IActionResult CarsByMakes(string make)
        {
            var result = cars
                .AllCarsByMakes(make);

            return this.View(result);
        }

        [HttpGet("{id}/parts")]
        public IActionResult Parts(string id)
        {
            var result = this.cars.CarWithParts(id);

            return this.View(result);
        }

        [HttpGet("all")]
        public IActionResult All(int page =1)
            => this.View(new CarsListingModel
            {
                Cars = this.cars.All(page, PageSize),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.cars.Total() / (double)PageSize)
            });
    }
}
