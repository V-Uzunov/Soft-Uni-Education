namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using Models.Sales;
    using Interfaces;
    using Data;
    using System.Linq;
    using Models;

    public class SalesServices : ISalesServices
    {
        private readonly CarDealerDbContext db;

        public SalesServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SalesListModel> All()
            => this.db
            .Sales
            .Select(s => new SalesListModel
            {
                Id = s.Id,
                CustomerName = s.Customer.Name,
                IsYoungDriver = s.Customer.IsYoungDriver,
                Price = s.Car.Parts.Sum(c => c.Part.Price),
                Discount = s.Discount
            })
            .ToList();

        public IEnumerable<SalesDetailModel> Details(int id)
            => this.db
                .Sales
                .Where(x => x.Id == id)
                .Select(s => new SalesDetailModel
                {
                    Id=s.Id,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Sum(c=> c.Part.Price),
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Car = new CarByMake
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    }
                })
                .ToList();
    }
}
