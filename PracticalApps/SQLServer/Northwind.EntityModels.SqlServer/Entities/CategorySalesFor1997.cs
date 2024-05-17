using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels;

[Keyless]
public partial class CategorySalesFor1997
{
    [StringLength(15)]
    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? CategorySales { get; set; }
}
