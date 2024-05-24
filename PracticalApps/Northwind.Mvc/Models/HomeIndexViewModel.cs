using Northwind.EntityModels; // To use Category, Product.

namespace Northwind.Mvc.Models;

/// <summary>
/// Add statements to define an immutable record.
/// </summary>
/// <param name="VisitorCount">Count of the number of visitors.</param>
/// <param name="Categories">Lists of categories</param>
/// <param name="Products">Lists of products</param>
public record HomeIndexViewModel(int VisitorCount, IList<Category> Categories, IList<Product> Products);
