using Packt.Shared; // To use Person.

/*
    https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to#table-of-differences-between-newtonsoftjson-and-systemtextjson.

    Migrating from Newtonsoft to new JSON
    If you have existing code that uses the Newtonsoft Json.NET library and you want to migrate to the new System.Text.Json namespace, then Microsoft has specific documentation for that that you can find at the following link:

    https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to
*/

List<Person> people = new()
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

// Create a file to write to.
string jsonPath = Combine(CurrentDirectory, "people.json");

// Serializing with JSON.
JsonSerializationFormat(jsonPath, people);

// Deserializing JSON files.
DeserializeFile(jsonPath);
