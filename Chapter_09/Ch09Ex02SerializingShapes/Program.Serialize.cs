using System.Xml.Serialization; // To use XmlSerializer.
using Packt.Shared;

partial class Program
{
    private static void Serialize(string path, List<Shape> shapes)
    {
        SectionTitle("Serializing XML");

        if (!string.IsNullOrWhiteSpace(path))
        {
            XmlSerializer xs = new(type: shapes.GetType());
            
            using(FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, shapes);
            }

            OutputFileInfo(path);
        }
    }
}