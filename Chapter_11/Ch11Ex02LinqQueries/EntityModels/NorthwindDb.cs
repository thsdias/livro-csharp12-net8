using Microsoft.EntityFrameworkCore; // To use DbContext, DbSet<T>.

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string database = "Northwind.db";
        string dir = Environment.CurrentDirectory;
        string path = string.Empty;

        if (dir.EndsWith("net8.0"))
            path = Path.Combine("..", "..", "..", database);    // Running in the <project>\bin\<Debug|Release>\net8.0 directory.
        else
            path = database;    // Running in the <project> directory.

        // Convert to absolute path.
        path = Path.GetFullPath(path);

        WriteLine($"SQLite databse path: {path}");

        if (!File.Exists(path))
            throw new FileNotFoundException(message: $"{path} not found.", fileName: path);
        
        optionsBuilder.UseSqlite($"Data Source={path}");
    }
}