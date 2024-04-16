using System.Xml.Serialization; // To use XmlSerializer.
using Packt.Shared;

partial class Program
{
    private static void XmlFiles(List<Person> people)
    {
        SectionTitle("Serializing as Compact XML");

        // Create serializer to format a "List of Person" as XML.
        XmlSerializer xs = new(type: people.GetType());

        // Create a file to write to.
        string path = Combine(CurrentDirectory, "people.xml");

        using(FileStream stream = File.Create(path))
        {
            // Serialize the object graph to the stream.
            xs.Serialize(stream, people);
        } // Closes the stream.

        OutputFileInfo(path);
    }
}
