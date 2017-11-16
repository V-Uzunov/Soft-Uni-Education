namespace _04.ShopHierarchy
{
    using Microsoft.EntityFrameworkCore;
    public class ShopHirarchyDBContext : DbContext
    {
        public DbSet<Salesman> Salesmans { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=(LocalDb)\MSSQLLocalDB;Database=ShopHirarchyDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasOne(x => x.Salesman)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.SalesmanId);

            builder.Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

            builder.Entity<Review>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CustomerId);

            builder.Entity<ItemOrder>()
                .HasKey(x => new {x.ItemId, x.OrderId});

            builder.Entity<Item>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId);

            builder.Entity<Order>()
                .HasMany(x => x.Item)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
