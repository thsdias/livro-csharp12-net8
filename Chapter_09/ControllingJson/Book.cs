using System.Text.Json.Serialization; // To use [JsonInclude].

namespace Packt.Shared;

public class Book
{
    public string Title { get; set; }

    public string? Author { get; set; }

    // Fields.
    [JsonInclude]
    public DateTime PublishDate;

    [JsonInclude]
    public DateTimeOffset Created;

    public ushort Pages;

    // Constructor to set non-nullable property.
    public Book(string title)
    {
        Title = title;
    }
}