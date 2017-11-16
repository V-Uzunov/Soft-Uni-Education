namespace PlanetHunter.Data
{
    using PlanetHunter.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHunterContext : DbContext
    {

        public PlanetHunterContext()
            : base("name=PlanetHunterContext")
        {
        }

        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.PioneerDiscoveries)
                .WithMany(p => p.Pioneers)
                .Map
                (a =>
                {
                    a.MapLeftKey("PioneerId");
                    a.MapRightKey("DiscoveryId");
                    a.ToTable("PioneerDiscovery");
                }
                );

            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.ObservationDiscoveries)
                .WithMany(b => b.Observes)
                .Map(a =>
                {
                    a.MapLeftKey("ObserverId");
                    a.MapRightKey("DiscoveryId");
                    a.ToTable("ObserverDiscovery");
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}