namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Interfaces;
    using Models;
    using Models.Parts;

    public class CarServices : ICarServices
    {
        private readonly CarDealerDbContext db;
        private const int PageSize = 25;

        public CarServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string model, string make, long travelledDistance)
        {
            var car = new Car
            {
                Model = model,
                Make = make,
                TravelledDistance = travelledDistance
            };

            this.db.Add(car);
            this.db.SaveChanges();
        }

        public ICollection<CarByMake> AllCarsByMakes(string makes)
            => this.db
                .Cars
            .Where(c=> c.Make.ToLower()==makes.ToLower())
            .OrderBy(c=> c.Model)
            .ThenByDescending(c=> c.TravelledDistance)
            .Select(c => new CarByMake
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance
            })
            .ToList();

        public ICollection<CarByMake> All(int page = 1, int pageSize = 10)
            => this.db
                .Cars
                .OrderByDescending(c => c.Id)
                .ThenByDescending(c => c.TravelledDistance)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(c => new CarByMake
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

        public ICollection<CarsWithPartsModel> CarWithParts(string id)
            => this.db
                .Cars
                .Where(c=> c.Id.ToString()==id)
                .OrderByDescending(c => c.Id)
                .Select(c=> new CarsWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Parts = c.Parts.Select(p=> new PartsModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                })
                .ToList();

        public int Total() => this.db.Cars.Count();
    }
}
