namespace BookShopSystem
{
    using BookShopSystem.Migrations;
    using BookShopSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;

    public class BookShopSystemContext : DbContext
    {

        public BookShopSystemContext()
            : base("name=BookShopSystemContext")
        {
            Database.SetInitializer<BookShopSystemContext>(new InitVersion());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Id");
                    m.MapRightKey("RelatedBookId");
                    m.ToTable("BooksRelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }
}