namespace _04.ShopHierarchy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new ShopHirarchyDBContext())
            {
                DeleteCreateDB(db);
                FillSalesman(db);
                ReadItemCommand(db);
                ReadCommands(db);
                // PrintSalesmanWithCustomers(db);
                // PrintCustomersWithOrdersAndReviews(db);
                // PrintCustomersOrdersEndReviews(db);
                //PrintCustomerData(db);
                PrintOrdersWithMoreThanOneItem(db);
            }
        }

        private static void PrintOrdersWithMoreThanOneItem(ShopHirarchyDBContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var orders = db.Orders
                .Where(x => x.CustomerId == customerId)
                .Count(x => x.Item.Count > 1);

            Console.WriteLine($"Orders: {orders}");
        }

        private static void PrintCustomerData(ShopHirarchyDBContext db)
        {
            var customerId = int.Parse(Console.ReadLine());

            var customerData = db
                .Customers
                .Where(x => x.Id == customerId)
                .Select(x => new
                {
                    x.Name,
                    Orders =x.Orders.Count,
                    Reviews = x.Reviews.Count,
                    SalesmanName= x.Salesman.Name
                });
            foreach (var customer in customerData)
            {
                Console.WriteLine($"Customer: {customer.Name}");
                Console.WriteLine($"Orders count: {customer.Orders}");
                Console.WriteLine($"Reviews: {customer.Reviews}");
                Console.WriteLine($"Salesman: {customer.SalesmanName}");
            }
        }

        private static void PrintCustomersOrdersEndReviews(ShopHirarchyDBContext db)
        {
            var id = int.Parse(Console.ReadLine());

            var customer = db
                .Customers
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    Order = x.Orders.Select(s => new
                    {
                        s.Id,
                        Items = s.Item.Count
                    })
                        .OrderBy(i => i.Id),
                    Reviews = x.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var customerKVP in customer.Order)
            {
                Console.WriteLine($"order {customerKVP.Id}: {customerKVP.Items} items");
            }
            Console.WriteLine($"reviews: {customer.Reviews}");
        }

        private static void ReadItemCommand(ShopHirarchyDBContext db)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(';');
                var name = tokens[0];
                var price = decimal.Parse(tokens[1]);

                db.Items.Add(new Item
                {
                    Name = name,
                    Price = price
                });
            }
            db.SaveChanges();
        }

        private static void PrintCustomersWithOrdersAndReviews(ShopHirarchyDBContext db)
        {
            var customer = db.Customers
                .Select(x => new
                {
                    x.Name,
                    Orders = x.Orders.Count,
                    Reviews = x.Reviews.Count
                })
                .OrderByDescending(x => x.Orders)
                .ThenByDescending(x => x.Reviews)
                .ToList();

            foreach (var cust in customer)
            {
                Console.WriteLine($"{cust.Name}");
                Console.WriteLine($"Orders: {cust.Orders}");
                Console.WriteLine($"Reviews: {cust.Reviews}");
            }
        }

        private static void PrintSalesmanWithCustomers(ShopHirarchyDBContext db)
        {
            var salesman = db
                .Salesmans.Select(s => new
                {
                    s.Name,
                    Customer = s.Customers.Count
                })
                .OrderByDescending(x => x.Customer)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var sMan in salesman)
            {
                Console.WriteLine($"{sMan.Name} - {sMan.Customer} customers");
            }
        }

        private static void ReadCommands(ShopHirarchyDBContext db)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                var cmd = tokens[0];
                var args = tokens[1];

                switch (cmd)
                {
                    case "register":
                        RegisterCustomer(db, args);
                        break;
                    case "order":
                        RegisterOrder(db, args);
                        break;
                    case "review":
                        RegisterReview(db, args);
                        break;
                }
            }
        }

        private static void RegisterReview(ShopHirarchyDBContext db, string args)
        {
            var tokens = args.Split(';');
            var id = int.Parse(tokens[0]);
            var itemId = int.Parse(tokens[1]);

            db.Reviews.Add(new Review
            {
                CustomerId = id,
                ItemId = itemId
            });

            db.SaveChanges();
        }

        private static void RegisterOrder(ShopHirarchyDBContext db, string args)
        {
            var tokens = args.Split(';');
            var id = int.Parse(tokens[0]);

            var order = new Order
            {
                CustomerId = id
            };
            for (int i = 1; i < tokens.Length; i++)
            {
                var itemId = int.Parse(tokens[i]);
                order.Item.Add(new ItemOrder
                {
                    ItemId = itemId
                });
            }
            db.Add(order);
            db.SaveChanges();
        }

        private static void RegisterCustomer(ShopHirarchyDBContext db, string args)
        {
            var tokens = args.Split(';');
            var name = tokens[0];
            var salesmanId = int.Parse(tokens[1]);

            db.Customers.Add(new Customer
            {
                Name = name,
                SalesmanId = salesmanId
            });
            db.SaveChanges();
        }

        private static void FillSalesman(ShopHirarchyDBContext db)
        {
            var inputSalesmans = Console.ReadLine().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sMan in inputSalesmans)
            {
                var salesman = new Salesman
                {
                    Name = sMan
                };
                db.Salesmans.Add(salesman);
            }
            db.SaveChanges();
        }

        private static void DeleteCreateDB(ShopHirarchyDBContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
