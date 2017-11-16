namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Models;

    public class LocalStoreContext : DbContext
    {
        public LocalStoreContext()
            : base("name=LocalStoreContext")
        {
            Database.SetInitializer(new DBSeed());
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}