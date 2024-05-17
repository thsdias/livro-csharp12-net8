using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels;

[Keyless]
public partial class CurrentProductList
{
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(40)]
    public string ProductName { get; set; } = null!;
}
