namespace BookShopSystem.Migrations
{
    using BookShopSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled= true;
            this.ContextKey = "BookShopSystem.Data.BookShopSystemContext";
        }
    }
}
