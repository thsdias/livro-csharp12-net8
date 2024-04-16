using Packt.Shared;
using FastJson = System.Text.Json.JsonSerializer;

partial class Program
{
    private static async void DeserializeFile(string jsonPath)
    {
        SectionTitle("Deserializing JSON files");

        await using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
        {
            // Deserialize object graph into a "List of Person".
            List<Person>? loadedPeople = await FastJson.DeserializeAsync(utf8Json: jsonLoad,
                                                                            returnType: typeof(List<Person>)) as List<Person>;

            if (loadedPeople is not null)
            {
                foreach (Person p in loadedPeople)
                {
                    WriteLine("{0} has {1} children.",
                        p.LastName, 
                        p.Children?.Count ?? 0);
                }

                WriteLine();
            }
        }
    }
}