using Microsoft.EntityFrameworkCore; // To use DbContext and so on.

namespace Northwind.EntityModels;

// This manages interactions with the Northwind database.
public class NorthwindDb : DbContext
{
    // These properties map to tables in the database.
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";

        WriteLine($"Connection: {connectionString}\n");

        optionsBuilder
            .UseSqlite(connectionString)
            .UseLazyLoadingProxies() // Call an extension method to use lazy loading proxies.

        #if DEBUG
            // Add statements to log to the console and to include sensitive data like parameter values for 
            // commands being sent to the database if we compile the debug configuration.
            .EnableSensitiveDataLogging() // Include SQL parameters.
            .EnableDetailedErrors()
        #endif
        ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes to limit the length of a category name to 15.
        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(15);

        // Some SQLite-specific configuration.
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            // The decimal type is not supported by the SQLite database 
            // provider for sorting and other operations.
            // This does not actually perform any conversion at runtime.
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasConversion<double>();
        }
    }
}