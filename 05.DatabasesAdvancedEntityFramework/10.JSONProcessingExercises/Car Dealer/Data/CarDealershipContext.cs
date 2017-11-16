using Car_Dealer.Models;

namespace Car_Dealer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarDealershipContext : DbContext
    {
        // Your context has been configured to use a 'CarDealershipContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Car_Dealer.CarDealershipContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CarDealershipContext' 
        // connection string in the application configuration file.
        public CarDealershipContext()
            : base("name=CarDealershipContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

    }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<User>().HasMany(u => u.SoldProducts).WithRequired(p => p.Seller);

    //    modelBuilder.Entity<User>().HasMany(u => u.Products).WithOptional(p => p.Buyer);

    //    modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(mc =>
    //    {
    //        mc.MapLeftKey("UserId");
    //        mc.MapRightKey("FriendId");
    //        mc.ToTable("UserFriends");
    //    });
    //    base.OnModelCreating(modelBuilder);
    //}
}