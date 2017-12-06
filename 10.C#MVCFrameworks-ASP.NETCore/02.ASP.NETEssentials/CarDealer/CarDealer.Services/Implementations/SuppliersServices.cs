namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Interfaces;
    using Models.Suppliers;

    public class SuppliersServices : ISuppliersServices
    {
        private readonly CarDealerDbContext db;

        public SuppliersServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public ICollection<FilterSuppliers> AllFilteredSupplierses(bool isInporter)
            => this.db
                .Suppliers
                .Select(s => new FilterSuppliers
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumberOfParts = s.Parts.Count
                })
                .ToList();

        public IEnumerable<AllSuppliers> All()
            => this.db
                .Suppliers
                .OrderByDescending(x => x.Id)
                .Select(s => new AllSuppliers
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
            .ToList();

        public void Add(string name, bool isImporter)
        {
            var supplier = new Supplier
            {
                Name = name,
                IsImporter = isImporter,
            };

            this.db.Suppliers.Add(supplier);
            this.db.SaveChanges();
        }

        public AllSuppliers FindId(int id)
            => this.db
                .Suppliers
                .Where(s => s.Id == id)
                .Select(s => new AllSuppliers
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .FirstOrDefault();

        public void Edit(int id, string name, bool isImporter)
        {
            var supplier = this.db.Suppliers.Find(id);

            if (supplier == null)
            {
                return;
            }

            supplier.Id = id;
            supplier.Name = name;
            supplier.IsImporter = isImporter;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var supp = this.db.Suppliers.Find(id);

            if (supp == null)
            {
                return;
            }

            this.db.Remove(supp);
            this.db.SaveChanges();
        }
    }
}
