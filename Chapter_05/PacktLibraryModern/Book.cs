using System.Diagnostics.CodeAnalysis; // To use [SetsRequiredMembers].

namespace Packt.Shared;

public class Book
{
    // Needs .NET 7 or later as well as C# 11 or later.
    public required string? Isbn;
    public required string? Title;

    // Works with any version of .NET.
    public string? Author;
    public int PageCount;

    // Constructor for use with object initializer syntax.
    public Book() 
    {
    }

    // Constructor with parameters to set required fields.
    [SetsRequiredMembers] // Decorate the constructor with the attribute to tell the compiler that it sets all the required properties and fields, as highlighted in the following code.
    public Book(string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}
