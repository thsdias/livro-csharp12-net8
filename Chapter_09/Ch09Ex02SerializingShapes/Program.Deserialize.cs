using System.Xml.Serialization;
using Packt.Shared;

partial class Program
{
    private static void Deserialize(string path, List<Shape> shapes)
    {
        SectionTitle("Serializing XML");

        if (!string.IsNullOrWhiteSpace(path))
        {
            using (FileStream xml = File.Open(path, FileMode.Open))
            {
                XmlSerializer xs = new(type: shapes.GetType());
                List<Shape>? loadShape = xs.Deserialize(xml) as List<Shape>;

                if(loadShape is not null)
                {
                    foreach (var shape in loadShape)
                    {
                        WriteLine("{0} is {1} and has an area of {2:N2}",
                            shape.GetType().Name, 
                            shape.Colour, 
                            shape.Area);
                    }
                }
            }
        }
    }
}