namespace CarDealer.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Part;
    using Services.Interfaces;
    using Services.Models.Parts;

    [Route("parts")]
    public class PartsController : Controller
    {

        private const int PageSize = 25;
        private readonly IPartsServices parts;
        private readonly ISuppliersServices suppliers;

        public PartsController(IPartsServices parts, ISuppliersServices suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        [Route(nameof(All))]
        public IActionResult All(int page =1)
            => this.View(new PartsPageListingModel
            {
                Parts = this.parts.AllParts(page, PageSize),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
            });

        [Route(nameof(Create))]
        public IActionResult Create()
            => this.View(new PartsModel
            {
                Suppliers = this.GetSuppliersItems()
            });

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(PartsModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Suppliers = this.GetSuppliersItems();
                return this.View(model);
            }

            this.parts
                .Create(model.Name,
                        model.Price,
                        model.Quantity,
                        model.SupplierId);

            return this.RedirectToAction(nameof(All));
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var findId = parts.ById(id);

            if (findId == null)
            {
                return this.NotFound();
            }

            return this.View(new PartsModel
            {
                Name = findId.Name,
                Price = findId.Price,
                Quantity = findId.Quantity,
                IsEdit = true
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, PartsModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
           
            this.parts.Edit(id,
                            model.Name,
                            model.Price,
                            model.Quantity);

            return this.RedirectToAction(nameof(All));
        }

        [Route(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            var part = this.parts.FindById(id);

            if (parts == null)
            {
                return this.NotFound();
            }

            return this.View(new ListAllParts
            {
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                SupplierName = part.SupplierName
            });
        }

        [HttpPost]
        [Route(nameof(Delete) + "/{id}")]
        public IActionResult Destroy(int id)
        {
            var part = this.parts.FindById(id);

            if (part == null)
            {
                return this.NotFound();
            }

            this.parts.Delete(id);

            return this.RedirectToAction(nameof(All));
        }

        private IEnumerable<SelectListItem> GetSuppliersItems()
          => this.suppliers
            .All()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
    }
}
