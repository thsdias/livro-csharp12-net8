using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Keyless]
public partial class EmployeeTerritory
{
    [Column(TypeName = "INT")]
    public int EmployeeId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar] (20")]
    public string TerritoryId { get; set; } = null!;
}
