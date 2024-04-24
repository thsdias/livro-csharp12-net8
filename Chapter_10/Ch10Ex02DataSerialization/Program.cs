using Microsoft.EntityFrameworkCore; // Include extension method
using Northwind.EntityModels;

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");

// Get all categories and their related products.
IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

if (categories is null)
{
    WriteLine("No categories found.");
    return;
}

GenerateXmlFile(categories);
GenerateXmlFile(categories, useAttributes: false);
GenerateCsvFile(categories);
GenerateJsonFile(categories);

WriteLine($"\nCurrent directory: {Environment.CurrentDirectory}");
WriteLine();
