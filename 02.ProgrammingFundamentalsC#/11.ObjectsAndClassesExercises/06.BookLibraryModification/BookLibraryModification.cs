using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }

    public static Book ReadBook()
    {
        var bookInfo = Console.ReadLine().Split(' ').ToList();
        DateTime date = DateTime.ParseExact(bookInfo[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        Book book = new Book()
        {
            Title = bookInfo[0],
            Author = bookInfo[1],
            Publisher = bookInfo[2],
            ReleaseDate = date,
            ISBN = bookInfo[4],
            Price = decimal.Parse(bookInfo[5])
        };
        return book;
    }
}

class Library
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}


class BookLibraryModification
{
    static void Main(string[] args)
    {
        int numberOfBooks = int.Parse(Console.ReadLine());
        Library lib = new Library();
        lib.Books = new List<Book>();

        for (int i = 0; i < numberOfBooks; i++)
        {
            Book currentBook = Book.ReadBook();
            lib.Books.Add(currentBook);
        }
        var inputDate = Console.ReadLine();
        DateTime newDate = DateTime.ParseExact(inputDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        Dictionary<string, DateTime> libDict = new Dictionary<string, DateTime>();
        foreach (var book in lib.Books)
        {
            if (!libDict.ContainsKey(book.Title) && newDate < book.ReleaseDate)
            {
                libDict.Add(book.Title, book.ReleaseDate);
            }
        }

        var result = libDict.OrderBy(r => r.Value).ThenBy(r => r.Key);

        foreach (var pair in result)
        {
            Console.WriteLine("{0} -> {1:dd.MM.yyyy}", pair.Key, pair.Value);
        }
    }
}