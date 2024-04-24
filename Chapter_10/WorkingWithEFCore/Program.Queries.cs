using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, Product.
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use CollectionEntry.

partial class Program
{
    /*
        Entity SQL reference:
        https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/entity-sql-reference
    
        Loading Related Data:
        https://learn.microsoft.com/en-us/ef/core/querying/related-data/
    */

    /// <summary>
    /// Query for all categories that includes their related products.
    /// </summary>
    private static void QueryingCategories()
    {
        SectionTitle("Categories and how many products they have");

        using NorthwindDb db = new();

        // A query to get all categories and their related products.
        IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

        if(categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        // Execute query and enumerate results.
        foreach(Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }

        WriteLine();
    }

    /// <summary>
    /// Query for categories that have products with that minimum number of units in stock.
    /// </summary>
    private static void FilteredIncludes()
    {
        SectionTitle("Products with a minimum number of units in stock");

        string? input;
        int stock;
        using NorthwindDb db = new();
    
        do
        {
            Write("Enter a minimum for units in stock: ");
            input = ReadLine();
        } 
        while(!int.TryParse(input, out stock));

        IQueryable<Category>? categories = 
            db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));

        if(categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        // Getting the generated SQL.
        Info($"ToQueryString: {categories.ToQueryString()}");

        // Enumerate through the categories and products, outputting the name and units in stock for each one.
        foreach (Category c in categories)
        {
            WriteLine("{0} has {1} products with a minimum {2} units in stock.",
                arg0: c.CategoryName, arg1: c.Products.Count, arg2: stock);

            foreach(Product p in c.Products)
            {
                WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
            }

            WriteLine();
        }
    }

    /// <summary>
    /// Query for categories that have products with that minimum number of units in stock.
    /// </summary>
    private static void QueryingProducts()
    {
        SectionTitle("Products that cost more than a price, highest at top");

        string? input;
        decimal price;
        using NorthwindDb db = new();

        do
        {
            Write("Enter a product price: ");
            input = ReadLine();
        }
        while (!decimal.TryParse(input, out price));
    
        IQueryable<Product>? products = db.Products?
            .TagWith("Products filtered by price and sorted.")  // Add a SQL comment to the log.
            .Where(p => p.Cost > price)
            .OrderByDescending(p => p.Cost);

        if(products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }

        // Getting the generated SQL.
        Info($"ToQueryString: {products.ToQueryString()}");

        foreach (Product p in products)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.", 
                p.ProductId, p.ProductName, p.Cost, p.Stock);
        }

        WriteLine();
    }

    /// <summary>
    /// Query for products with that product ID using the First and Single methods.
    /// </summary>
    private static void GettingOneProduct()
    {
        SectionTitle("Getting a single product");

        string? input;
        int id;
        using NorthwindDb db = new();
        
        do
        {
            Write("Enter a product ID: ");
            input = ReadLine();
        } while (!int.TryParse(input, out id));

        Product? product = db.Products?
            .First(product => product.ProductId == id);
        
        Info($"First: {product?.ProductName}");
        
        if (product is null) 
            Fail("No product found using First.");
        
        product = db.Products?
            .Single(product => product.ProductId == id);
        
        Info($"Single: {product?.ProductName}");
        
        if (product is null) 
            Fail("No product found using Single.");
    }

    /// <summary>
    /// Method to search anywhere in the ProductName property.
    /// </summary>
    private static void QueryingWithLike()
    {
        SectionTitle("Pattern matching with LIKE");

        using NorthwindDb db = new();

        Write("Enter part of a product name: ");
        string? input = ReadLine();

        if(string.IsNullOrWhiteSpace(input))
        {
            Fail("You did not enter part of a product name.");
            return;
        }

        IQueryable<Product>? products = db.Products?
            .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

        if(products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }

        foreach(Product p in products)
        {
            WriteLine("{0} has {1} units in stock. Discontinued: {2}",
                p.ProductName, p.Stock, p.Discontinued);
        }

        WriteLine();
    }

    private static void GetRandomProduct()
    {
        SectionTitle("Get a random product");
        
        using NorthwindDb db = new();
        int? rowCount = db.Products?.Count();
        
        if (rowCount is null)
        {
            Fail("Products table is empty.");
            return;
        }

        Product? p = db.Products?.FirstOrDefault(p => p.ProductId == (int)(EF.Functions.Random() * rowCount));

        if(p is null)
        {
            Fail("Product not found");
            return;
        }

        WriteLine($"Random product: {p.ProductId} - {p.ProductName}");
        WriteLine();
    }

    private static void QueryingCategoriesWithLoadingAndTrackingPatterns()
    {
        /*
            Loading and tracking patterns with EF Core:
            - Eager loading: Load data early.
            - Lazy loading: Load data automatically just before it is needed.
            - Explicit loading: Load data manually.
        */

        SectionTitle("Categories and how many products they have");

        using NorthwindDb db = new();
        IQueryable<Category>? categories;

        // Enabling lazy loading.
        //categories = db.Categories;

        // Explicit loading entities using the Load method.
        // To enable eager loading and explicit loading.
        db.ChangeTracker.LazyLoadingEnabled = false;

        Write("Enable eager loading? (Y/N): ");
        bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
        bool explicitLoading = false;
        WriteLine();

        if(eagerLoading)
        {
            categories = db.Categories?.Include(c => c.Products);
        }
        else
        {
            categories = db.Categories;
            Write("Enable explicit loading? (Y/N): ");
            explicitLoading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
        }

        if(categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        // Execute query and enumerate results.
        foreach(Category c in categories)
        {
            if (explicitLoading)
            {
                Write($"Explicitly load products for {c.CategoryName}? (Y/N): "); 
                ConsoleKeyInfo key = ReadKey();
                WriteLine();

                if (key.Key == ConsoleKey.Y)
                {
                    CollectionEntry<Category, Product> products = db.Entry(c).Collection(c2 => c2.Products);
                    if (!products.IsLoaded) products.Load();
                }
            }

            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }

        WriteLine();
    }

    private static void LazyLoadingWithNoTracking()
    {
        SectionTitle("Lazy-loading with no tracking");

        using NorthwindDb db = new();

        IQueryable<Product>? products = db.Products?.AsNoTracking();

        if(products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }

        foreach (Product p in products)
        {
            WriteLine("\n{0} is in category named {1}.\n", p.ProductName, p.Category.CategoryName);
        }
    }
}