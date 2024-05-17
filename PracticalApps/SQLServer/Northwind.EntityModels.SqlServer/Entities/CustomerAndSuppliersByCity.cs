using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Northwind.EntityModels;

[Keyless]
public partial class CustomerAndSuppliersByCity
{
    [StringLength(15)]
    public string? City { get; set; }

    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [StringLength(30)]
    public string? ContactName { get; set; }

    [StringLength(9)]
    [Unicode(false)]
    public string Relationship { get; set; } = null!;
}
