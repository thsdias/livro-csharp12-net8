using Packt.Shared;

partial class Program
{
    private static void JsonSerializationFormat(string jsonPath, List<Person> people)
    {
        SectionTitle("Serializing with JSON");
        
        using (StreamWriter jsonStream = File.CreateText(jsonPath))
        {
            Newtonsoft.Json.JsonSerializer jss = new();

            // Serialize the object graph into a string.
            jss.Serialize(jsonStream, people);
        } // Closes the file stream and release resources.

        OutputFileInfo(jsonPath);
    }
}