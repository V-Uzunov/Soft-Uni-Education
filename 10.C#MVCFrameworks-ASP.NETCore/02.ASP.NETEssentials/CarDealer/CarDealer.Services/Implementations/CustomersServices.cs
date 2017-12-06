namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Interfaces;
    using Models;

    public class CustomersServices : ICustomersServices
    {
        private readonly CarDealerDbContext db;

        public CustomersServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public CustomersById CustomersById(string id)
        {
            return this.db
                       .Customers
                       .Where(c => c.Id.ToString() == id)
                       .Select(c => new CustomersById
                       {
                           Name = c.Name,
                           IsYoungerDriver = c.IsYoungDriver,
                           BoughtCars = c.Sales.Select(b => new SalesModel
                           {
                               Price = b.Car.Parts.Sum(x => x.Part.Price),
                               Discount = b.Discount
                           })
                           .ToList()
                       })
                       .FirstOrDefault();
        }

        public void Create(string name, DateTime birthDay, bool isYoungDriver)
        {

            var customer = new Customer
            {
                Name = name,
                BirthDate = birthDay,
                IsYoungDriver = isYoungDriver
            };

            this.db
                .Customers
                .Add(customer);
            db.SaveChanges();
        }

        public CustomerModel ById(int id)
            => this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id=c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();

        public void Edit(int id, string name, DateTime birthDate, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(id);

            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDate = birthDate;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public bool Exist(int id)
            => this.db.Customers.Any(c => c.Id == id);

        public ICollection<CustomerModel> OrderedCustomers(OrderType order)
        {
            var custommerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    custommerQuery = custommerQuery.OrderBy(c => c.BirthDate).ThenBy(x => x.Name);
                    break;
                case OrderType.Descending:
                    custommerQuery = custommerQuery.OrderByDescending(c => c.BirthDate).ThenBy(x => x.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid operation {order}");
            }

            return custommerQuery
                .Select(x => new CustomerModel
                {
                    Id=x.Id,
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();
        }
    }
}
