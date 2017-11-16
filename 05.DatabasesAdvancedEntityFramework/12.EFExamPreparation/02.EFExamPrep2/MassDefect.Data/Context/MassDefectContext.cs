namespace MassDefect.Data
{
    using MassDefect.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Anomaly> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Anomalies)
                .WithMany(a => a.Victims)
                .Map(av =>
                {
                    av.ToTable("AnomalyVictims");
                    av.MapRightKey("PersonId");
                    av.MapLeftKey("AnomalyId");
                });

            modelBuilder.Entity<Person>()
                .ToTable("Persons");

            base.OnModelCreating(modelBuilder);
        }
    }
}