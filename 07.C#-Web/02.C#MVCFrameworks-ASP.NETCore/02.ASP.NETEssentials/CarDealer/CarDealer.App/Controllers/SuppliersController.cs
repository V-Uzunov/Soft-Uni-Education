namespace CarDealer.App.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.Models.Suppliers;

    [Route("suppliers")]
    public class SuppliersController : Controller
    {
        private const string Suppliers = "Suppliers";
        private readonly ISuppliersServices suppliers;
        private readonly ILogServices logs;

        public SuppliersController(ISuppliersServices suppliers, ILogServices logs)
        {
            this.suppliers = suppliers;
            this.logs = logs;
        }
        
        [Route(nameof(All))]
        public IActionResult All()
            => this.View(this.suppliers.All());

        [Authorize]
        [Route(nameof(Create))]
        public IActionResult Create()
            => this.View();

        [Authorize]
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(AllSuppliers model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.suppliers
                .Add(model.Name,
                    model.IsImporter);
           this.AddLogg(nameof(Create));

            return this.RedirectToAction(nameof(All));
        }

        

        [Authorize]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var findSupp = suppliers.FindId(id);

            if (findSupp == null)
            {
                return this.NotFound();
            }

            return this.View(new AllSuppliers
            {
                Name = findSupp.Name,
                IsImporter = findSupp.IsImporter,
                IsEdit = true
            });
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, AllSuppliers model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.suppliers
                .Edit(id,
                model.Name,
                model.IsImporter);
            this.AddLogg(nameof(Edit));


            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        [Route(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            var findId = suppliers.FindId(id);
            if (findId == null)
            {
                return this.NotFound();
            }

            return this.View(new AllSuppliers
            {
                Name = findId.Name,
                IsImporter = findId.IsImporter
            });
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(Delete) + "/{id}")]
        public IActionResult Destroy(int id)
        {
            var findId = suppliers.FindId(id);
            if (findId == null)
            {
                return this.NotFound();
            }

            this.suppliers
                .Delete(id);

            this.AddLogg(nameof(Delete));

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Local()
            => View(Suppliers, this.GetSuppliers(true));

        public IActionResult Importers()
            => View(Suppliers, this.GetSuppliers(false));

        private SuppliersModel GetSuppliers(bool importers)
        {
            var type = importers ? "Importrs" : "Local";

            var suppliers = this.suppliers.AllFilteredSupplierses(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }

        private void AddLogg(string operation)
            => this.logs
                .AddLog(
                    this.User.Identity.Name,
                    operation,
                    Suppliers,
                    DateTime.UtcNow);
    }
}
