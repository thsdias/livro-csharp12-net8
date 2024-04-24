using Microsoft.EntityFrameworkCore.Storage;
using Northwind.EntityModels; // To use IDbContextTransaction.

partial class Program
{
    private static void ListProducts(int[]? productIdsToHighlight = null)
    {
        using NorthwindDb db = new();

        if(db.Products is null || !db.Products.Any())
        {
            Fail("There are no products.");
            return;
        }

        WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |", "Id", "Product Name", "Cost", "Stock", "Disc.");

        foreach (Product p in db.Products)
        {
            ConsoleColor previusColor = ForegroundColor;

            if(productIdsToHighlight is not null && productIdsToHighlight.Contains(p.ProductId))
            {
                ForegroundColor = ConsoleColor.Green;
            }

            // {1,-35} means left-align argument 1 within a 35-character-wide column.
            // {3,5} means right-align argument 3 within a 5-character-wide column.
            WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
                p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
            
            ForegroundColor = previusColor;
        }

        WriteLine();
    }

    private static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price, short? stock)
    {
        using NorthwindDb db = new();

        if (db.Products is null)
            return (0, 0);

        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            Cost = price,
            Stock = stock
        };

        // Set product as added in change tracking.
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> entity = db.Products.Add(p);
        WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

        // Save tracked change to database.
        int affected = db.SaveChanges();
        WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

        return (affected, p.ProductId);
    }

    static int DeleteProducts(string productNameStartsWith)
    {
        using(NorthwindDb db = new())
        {
            using(IDbContextTransaction t = db.Database.BeginTransaction())
            {
                WriteLine("Transaction isolation level: {0}", arg0: t.GetDbTransaction().IsolationLevel);

                IQueryable<Product>? products = 
                    db.Products.Where(p => p.ProductName.StartsWith(productNameStartsWith));

                if(products is null || !products.Any())
                {
                    WriteLine("No products found to delete.");
                    return 0;
                }
                else
                {
                    db.Products.RemoveRange(products);
                }

                int affected = db.SaveChanges();
                t.Commit();

                return affected;
            }
        }
    }
}