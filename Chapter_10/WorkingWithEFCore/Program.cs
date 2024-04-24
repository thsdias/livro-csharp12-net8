using Northwind.EntityModels; // To use Northwind.
using NorthwindDb db = new();

/*
    https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/

    https://learn.microsoft.com/en-us/sql/connect/ado-net/microsoft-ado-net-sql-server
*/

// Execute the SQL script using SQLite to create the Northwind.db database:
// sqlite3 Northwind.db -init Northwind4SQLite.sql

WriteLine($"Provider: {db.Database.ProviderName}");
WriteLine();

ConfigureConsole();
QueryingCategories();
FilteredIncludes();
QueryingProducts();
GettingOneProduct();
QueryingWithLike();
GetRandomProduct();
QueryingCategoriesWithLoadingAndTrackingPatterns();
LazyLoadingWithNoTracking();

/*
// Inserting entities.
var resultAdd = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);

if(resultAdd.affected == 1)
    WriteLine($"Add product successful with ID: {resultAdd.productId}.\n");

ListProducts(productIdsToHighlight: new[] { resultAdd.productId });
*/

/*
// Updating entities.
var resultUpdate = IncreaseProductPrice(productNameStartsWith: "Bob", amount: 20M);

if(resultUpdate.affected == 1)
    WriteLine($"Increase price success for ID: {resultUpdate.productId}.");

ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });
*/

/*
// Deleting entities.
WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");

if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProducts(productNameStartsWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}
*/

/*
// More efficient updates.
var resultUpdateBetter = IncreaseProductPricesBetter(productNameStartsWith: "Bob", amount: 20M);

if (resultUpdateBetter.affected > 0)
    WriteLine("Increase product price successful.");

ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);
*/

// More efficient deletes.
WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");

if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProductsBetter(productNameStartsWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}
