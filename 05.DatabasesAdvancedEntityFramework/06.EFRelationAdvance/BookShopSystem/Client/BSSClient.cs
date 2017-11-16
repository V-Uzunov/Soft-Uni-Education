namespace BookShopSystem
{
    using BookShopSystem.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BSSClient
    {
        static void Main()
        {
            var ctx = new BookShopSystemContext();

            ctx.Database.Initialize(true);

            //Adding relating books
            AddRelatedBooks(ctx);

            //Show top 3 book relations
            BookRelation(ctx);

        }

        private static void AddRelatedBooks(BookShopSystemContext ctx)
        {
            var books = ctx.Books
                                       .Take(3)
                                       .ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            ctx.SaveChanges();
        }

        private static void BookRelation(BookShopSystemContext ctx)
        {
            var booksFromQuery = ctx.Books.Take(3).ToList();

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}
