using System;
using System.Collections.Generic;
using System.Text;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] author)
    {
        this.Title = title;
        this.Year = year;
        this.Author = author;
    }

    public string Title { get; private set; }

    public int Year { get; private set; }

    public IReadOnlyList<string> Author { get; private set; }

    public int CompareTo(Book other)
    {
        var result = this.Year.CompareTo(other.Year);

        if (result==0)
        {
           result= this.Title.CompareTo(other.Title);
        }
        
        return result;
    }

    public override string ToString()
    {
        
        return $"{this.Title} - {this.Year}";
    }
}