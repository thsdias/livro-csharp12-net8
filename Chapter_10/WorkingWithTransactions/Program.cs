using Northwind.EntityModels; // To use Northwind.
using NorthwindDb db = new();

// Info:
// https://github.com/markjprice/cs12dotnet8/blob/main/docs/ch10-transactions.md

WriteLine($"Provider: {db.Database.ProviderName}");
WriteLine();

/*
// Inserting entities.
var resultAdd = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);

if(resultAdd.affected == 1)
    WriteLine($"Add product successful with ID: {resultAdd.productId}.\n");

ListProducts(productIdsToHighlight: new[] { resultAdd.productId });
*/

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

ListProducts();
