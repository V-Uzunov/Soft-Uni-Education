using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBSeed : DropCreateDatabaseAlways<LocalStoreContext>
    {
        protected override void Seed(LocalStoreContext context)
        {
            Customer customer1 = new Customer()
            {
                CreditCardNumber = "1234567",
                Email = "user@test.com",
                Name = "User"
            };

            Customer customer2 = new Customer()
            {
                CreditCardNumber = "0123456",
                Email = "user2@test.com",
                Name = "User2"
            };

            Customer customer3 = new Customer()
            {
                CreditCardNumber = "11111",
                Email = "user3@test.com",
                Name = "User3"
            };

            Customer customer4 = new Customer()
            {
                CreditCardNumber = "4444",
                Email = "user4@test.com",
                Name = "User4"
            };

            Customer customer5 = new Customer()
            {
                CreditCardNumber = "5555",
                Email = "user5@test.com",
                Name = "User5"
            };
            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Customers.Add(customer5);

            Product product1 = new Product()
            {
                ProductName = "Mlqko",
                Price = 10.00m,
                Quantity = 1
            };

            Product product2 = new Product()
            {
                ProductName = "Qica",
                Price = 12.00m,
                Quantity = 12
            };

            Product product3 = new Product()
            {
                ProductName = "Sol",
                Price = 110.00m,
                Quantity = 1
            };

            Product product4 = new Product()
            {
                ProductName = "Qgoda",
                Price = 0.09m,
                Quantity = 11232
            };

            Product product5 = new Product()
            {
                ProductName = "Krusha",
                Price = 9.99m,
                Quantity = 1
            };

            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);

            StoreLocation location1 = new StoreLocation()
            {
                Location = "Carefurr"
            };

            StoreLocation location2 = new StoreLocation()
            {
                Location = "Kaufland"
            };

            StoreLocation location3 = new StoreLocation()
            {
                Location = "Pazar"
            };

            StoreLocation location4 = new StoreLocation()
            {
                Location = "Triumf"
            };

            StoreLocation location5 = new StoreLocation()
            {
                Location= "Banq"
            };

            context.StoreLocations.Add(location1);
            context.StoreLocations.Add(location2);
            context.StoreLocations.Add(location3);
            context.StoreLocations.Add(location4);
            context.StoreLocations.Add(location5);


            Sale sale1 = new Sale()
            {
                Customer = customer1,
                Date = new DateTime(2017, 03, 03),
                Product = product1,
                StoreLocation = location1
            };

            Sale sale2 = new Sale()
            {
                Customer = customer1,
                Date = new DateTime(2017, 03, 03),
                Product = product2,
                StoreLocation = location1
            };

            Sale sale3 = new Sale()
            {
                Customer = customer2,
                Date = new DateTime(2016, 03, 03),
                Product = product1,
                StoreLocation = location2
            };

            Sale sale4 = new Sale()
            {
                Customer = customer2,
                Date = new DateTime(2016, 03, 03),
                Product = product2,
                StoreLocation = location2
            };

            Sale sale5 = new Sale()
            {
                Customer = customer1,
                Date = new DateTime(2016, 03, 03),
                Product = product3,
                StoreLocation = location1
            };

            context.Sales.Add(sale1);
            context.Sales.Add(sale2);
            context.Sales.Add(sale3);
            context.Sales.Add(sale4);
            context.Sales.Add(sale5);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
