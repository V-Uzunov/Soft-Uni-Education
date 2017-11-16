namespace _02.Photographer
{
    using _02.Photographer.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographerContext : DbContext
    {
        // Your context has been configured to use a 'PhotographerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_02.Photographer.PhotographerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotographerContext' 
        // connection string in the application configuration file.
        public PhotographerContext()
            : base("name=PhotographerContext")
        {
            Database.SetInitializer(new DbInitializerPhotographerContext());
        }

        public virtual DbSet<Models.Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}