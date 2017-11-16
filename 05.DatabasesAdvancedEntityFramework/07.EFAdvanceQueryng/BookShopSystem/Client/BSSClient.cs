namespace BookShopSystem
{
    using BookShopSystem.Migrations;
    using BookShopSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BSSClient
    {
        static void Main()
        {
            var ctx = new BookShopSystemContext();

            ctx.Database.Initialize(true);

            //1.Books Titles by Age Restriction
            //BooksTitlesByAgeRestriction(ctx);

            //2.Golden Books
            //GoldenBooks(ctx);

            //3.Books by Price
            //BookByPrice(ctx);

            //4.Not Released Books
            //NotReleasedBooks(ctx);

            //5.Book Titles by Category
            //BookTitlesByCategory(ctx);

            //6.Books Released Before Date
            //BooksReleasedBeforeDate(ctx);

            //7.Authors Search
            //AuthorWthNameStartsWith(ctx);

            //8.Books Search
            //BooksTitleWithSearch(ctx);

            //10.Count Books
            //CountBooks(ctx);

            //11.Total Book Copies
            //TotalBookCopies(ctx);

            //12.Find Profit
            //FindProfit(ctx);

            //13.Most Recent Books
            //MostRecentBooks(ctx);

            //14.Increase Book Copies
            //IncreaseBookCopies(ctx);

            //15.Remove Books
            //RemoveBooks(ctx);

            //16.Stored Procedure
            //StoredProcedure(ctx);

            //HAVE PROBLEM WITH OTHER DATABASE.... To Be Continue...
        }
        private static void StoredProcedure(BookShopSystemContext context)
        {
            Console.WriteLine($"-------======= [16.	Stored Procedure] =======-------");

            Console.WriteLine("Please enter first and last name of the author (ex: Wanda Morales):");
            string[] name = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            //CREATE PROCEDURE GetAuthorBooksCount @firstName NVARCHAR(MAX), 
            //@lastName NVARCHAR(MAX),
            //@result INT OUT
            //AS
            //SET @result = (
            //SELECT COUNT(*) AS COUNT FROM Authors AS a
            //inner join Books AS b
            //ON b.Author_Id = a.Id
            //WHERE a.FirstName = @firstName and a.LastName = @lastName)

            SqlParameter firstName = new SqlParameter("@firstName", name[0]);
            SqlParameter secondName = new SqlParameter("@lastName", name[1]);
            SqlParameter result = new SqlParameter();
            result.ParameterName = "@result";
            result.Direction = ParameterDirection.Output;
            result.SqlDbType = SqlDbType.Int;

            context.Database.ExecuteSqlCommand($"execute GetAuthorBooksCount  @firstName, @lastName ,@result output", result, firstName, secondName);
            Console.WriteLine($"{firstName.Value} {secondName.Value} has written {result.Value} books");
        }

        private static void RemoveBooks(BookShopSystemContext context)
        {
            Console.WriteLine($"-------======= [15.	Remove Book] =======-------");

            const int count = 4200;
            var books = context.Books.Where(b => b.Copies < count);
            int counteDeletedBooks = 0;
            foreach (var book in books)
            {
                try
                {
                    context.Books.Remove(book);
                    counteDeletedBooks++;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Cannot delete book: {book.Title}");
                }
            }

            try
            {
                context.SaveChanges();
                Console.WriteLine($"{counteDeletedBooks} books were deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private static void IncreaseBookCopies(BookShopSystemContext context)
        {
            Console.WriteLine($"-------======= [14.	Increase Book Copies] =======-------");

            const int count = 44;
            var books = context.Books.Where(b => b.ReleaseData > new DateTime(2013, 06, 06));
            foreach (var book in books)
            {
                book.Copies += count;
            }
            Console.WriteLine($"{books.Count()} books are released after 6 Jun 2013 so total of {books.Count() * count} book copies were added");
        }

        private static void MostRecentBooks(BookShopSystemContext context)
        {
            Console.WriteLine($"-------======= [13.	Most Recent Books] =======-------");

            foreach (var category in context.Categories.Where(c => c.Books.Count > 35).OrderByDescending(c => c.Books.Count))
            {
                Console.WriteLine($"--{category.Name}: {category.Books.Count} books");
                foreach (var book in context.Books.OrderByDescending(b => b.ReleaseData).ThenBy(b => b.Title).Take(3))
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
        }

        private static void FindProfit(BookShopSystemContext ctx)
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            foreach (var category in ctx.Categories)
            {
                result[category.Name] = 0;
                foreach (var book in ctx.Books)
                {
                    if (book.Categories.Contains(category))
                    {
                        result[category.Name] += book.Copies * book.Price;
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, result
                                                                .OrderByDescending(x => x.Value)
                                                                .ThenBy(x => x.Key)
                                                                .Select(kv => $"{kv.Key} - ${kv.Value}")));
        }

        private static void TotalBookCopies(BookShopSystemContext ctx)
        {
            var result = ctx.Authors
                                .OrderByDescending(a => a.Books)
                                .ToList();
            foreach (var a in result)
            {
                Console.WriteLine($"{a.FirstName} {a.LastName} - {a.Books.ToList().Sum(x => x.Copies)}");
            }
        }

        private static void CountBooks(BookShopSystemContext ctx)
        {
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(ctx.Books.Count(x => x.Title.Length > input));
        }

        private static void BooksTitleWithSearch(BookShopSystemContext ctx)
        {
            var input = Console.ReadLine().ToLower();

            var result = ctx.Books.Where(b => b.Title.Contains(input)).ToList();

            foreach (var b in result)
            {
                Console.WriteLine($"{b.Title}");
            }
        }

        private static void AuthorWthNameStartsWith(BookShopSystemContext ctx)
        {
            var input = Console.ReadLine().ToLower();

            var result = ctx.Authors.Where(b => b.FirstName.EndsWith(input)).ToList();

            foreach (var a in result)
            {
                Console.WriteLine($"{a.FirstName} {a.LastName}");
            }
        }

        private static void BooksReleasedBeforeDate(BookShopSystemContext ctx)
        {
            DateTime date;
            DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null,
                System.Globalization.DateTimeStyles.None, out date);

            var result = ctx.Books.Where(b => b.ReleaseData < date).ToList();

            foreach (var book in result)
            {
                Console.WriteLine($"{book.Title} {book.Type} {book.Price}");
            }
        }

        private static void BookTitlesByCategory(BookShopSystemContext ctx)
        {
            string input = Console.ReadLine().ToLower();
            string[] categories = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var book in ctx.Books)
            {
                if (book.Categories.Any(c => categories.Contains(c.Name)))
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        private static void NotReleasedBooks(BookShopSystemContext ctx)
        {
            var input = int.Parse(Console.ReadLine());

            var result = ctx.Books.Where(y => y.ReleaseData.Year != input).OrderBy(b => b.Id).ToList();

            foreach (var book in result)
            {
                Console.WriteLine($"{book.Title}");
            }
        }

        private static void BookByPrice(BookShopSystemContext ctx)
        {
            var result = ctx.Books
                            .Where(p => p.Price <= 5 || p.Price >= 40)
                            .OrderBy(b => b.Id)
                            .Select(b => new { b.Title, b.Price })
                            .ToList();

            foreach (var book in result)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }

        private static void GoldenBooks(BookShopSystemContext ctx)
        {
            var type = Book.EditionType.Gold;

            var result = ctx.Books
                .Where(c => c.Type == type)
                .Where(c => c.Copies < 5000)
                .OrderBy(b => b.Id)
                .ToList();

            foreach (var cop in result)
            {
                Console.WriteLine($"{cop.Title}");
            }
        }

        private static void BooksTitlesByAgeRestriction(BookShopSystemContext ctx)
        {
            var input = Console.ReadLine().ToLower();

            if (input == "minor")
            {
                var ageRestriction = Book.AgeRestrictions.Minor;
                var books = ctx.Books.Where(x => x.AgeRestriction == ageRestriction).ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"{item.Title}");
                }
            }
            else if (input == "teen")
            {
                var ageRestriction = Book.AgeRestrictions.Teen;
                var books = ctx.Books.Where(x => x.AgeRestriction == ageRestriction).ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"{item.Title}");
                }
            }
            else
            {
                var ageRestriction = Book.AgeRestrictions.Adult;
                var books = ctx.Books.Where(x => x.AgeRestriction == ageRestriction).ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"{item.Title}");
                }
            }
        }
    }
}
