using System.Xml.Serialization;
using Packt.Shared;

partial class Program
{
    private static void DeserializeXmlFiles(string path, List<Person> people)
    {
        SectionTitle("Deserializing XML files");

        using (FileStream xmlLoad = File.Open(path, FileMode.Open))
        {
            // Create serializer to format a "List of Person" as XML.
            XmlSerializer xs = new(type: people.GetType());

            // Deserialize and cast the object graph into a "List of Person".
            List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
            
            if (loadedPeople is not null)
            {
                foreach (Person p in loadedPeople)
                {
                    WriteLine("{0} has {1} children.", 
                                p.LastName, 
                                p.Children?.Count ?? 0);
                }
            }
        }
    }
}