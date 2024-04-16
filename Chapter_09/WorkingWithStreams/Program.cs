
// Writing to text streams.
TextFile();

// Writing to XML streams.
XmlFile();

// Compressing streams.
Compress(algorithm: "gzip");
Compress(algorithm: "brotli");

// Simplifying disposal by using the using statement.
/*
using (FileStream file2 = File.OpenWrite(Path.Combine(path, "file2.txt")))
{
  using (StreamWriter writer2 = new StreamWriter(file2))
  {
    try
    {
        writer2.WriteLine("Welcome, .NET!");
    }
    catch(Exception ex)
    {
        WriteLine($"{ex.GetType()} says {ex.Message}");
    }
  } // Automatically calls Dispose if the object is not null.
} // Automatically calls Dispose if the object is not null.

// Or.
using FileStream file2 = File.OpenWrite(Path.Combine(path, "file2.txt"));
using StreamWriter writer2 = new(file2);

try
{
    writer2.WriteLine("Welcome, .NET!");
}
catch(Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
*/
