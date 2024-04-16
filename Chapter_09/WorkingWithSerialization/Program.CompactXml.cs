using System.Xml.Serialization; // To use XmlSerializer.
using Packt.Shared;

partial class Program
{
    private static void CompactXmlFiles()
    {
        SectionTitle("Serializing as Compact XML");

        List<PersonII> people = new()
        {
            new(initialSalary: 30_000M) 
            {
                FirstName = "Alice",
                LastName = "Smith",
                DateOfBirth = new(year: 1974, month: 3, day: 14)
            },
            new(initialSalary: 40_000M) 
            {
                FirstName = "Bob",
                LastName = "Jones",
                DateOfBirth = new(year: 1969, month: 11, day: 23)
            },
            new(initialSalary: 20_000M)
            {
                FirstName = "Charlie",
                LastName = "Cox",
                DateOfBirth = new(year: 1984, month: 5, day: 4),
                Children = new()
                {
                    new(initialSalary: 0M)
                    {
                        FirstName = "Sally",
                        LastName = "Cox",
                        DateOfBirth = new(year: 2012, month: 7, day: 12)
                    }
                }
            }
        };

        // Create serializer to format a "List of Person" as XML.
        XmlSerializer xs = new(type: people.GetType());

        // Create a file to write to.
        string path = Combine(CurrentDirectory, "peopleCompact.xml");

        using(FileStream stream = File.Create(path))
        {
            // Serialize the object graph to the stream.
            xs.Serialize(stream, people);
        } // Closes the stream.

        OutputFileInfo(path);
    }
}