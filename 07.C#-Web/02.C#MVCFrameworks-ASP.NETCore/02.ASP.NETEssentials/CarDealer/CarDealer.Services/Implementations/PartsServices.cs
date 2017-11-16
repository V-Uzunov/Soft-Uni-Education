namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Interfaces;
    using Models.Parts;

    public class PartsServices : IPartsServices
    {
        private const int PageSize = 25;

        private readonly CarDealerDbContext db;

        public PartsServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, double price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity : 1,
                SupplierId = supplierId
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, string name, double price, int quantity)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Name = name;
            part.Price = price;
            part.Quantity = quantity;

            this.db.SaveChanges();
        }

        public PartsDitailModel ById(int id)
            => this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new PartsDitailModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();


        public ListAllParts FindById(int id)
            => this.db
                .Parts
                .OrderByDescending(x => x.Id)
            .Where(p => p.Id == id)
            .Select(p => new ListAllParts
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                SupplierName = p.Supplier.Name
            })
            .FirstOrDefault();

        public IEnumerable<ListAllParts> AllParts(int page = 1, int pageSize = 10)
            => this.db
                .Parts
                .OrderByDescending(x => x.Id)
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .Select(p => new ListAllParts
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                SupplierName = p.Supplier.Name
            })
            .ToList();

        public IEnumerable<PartsIdModel> AllPartsIdModels()
            => this.db
                .Parts
                .Select(p => new PartsIdModel
                {
                    Name = p.Name,
                    Id = p.Id
                })
                .ToList();

        public int Total() => this.db.Parts.Count();
    }
}
