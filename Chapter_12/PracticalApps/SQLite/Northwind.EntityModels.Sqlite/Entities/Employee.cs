using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Index("LastName", Name = "LastName")]
[Index("PostalCode", Name = "PostalCodeEmployees")]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar (20)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar (10)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar (30)")]
    public string? Title { get; set; }

    [Column(TypeName = "nvarchar (25)")]
    public string? TitleOfCourtesy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

    [Column(TypeName = "nvarchar (60)")]
    public string? Address { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string? City { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string? Region { get; set; }

    [Column(TypeName = "nvarchar (10)")]
    public string? PostalCode { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string? Country { get; set; }

    [Column(TypeName = "nvarchar (24)")]
    public string? HomePhone { get; set; }

    [Column(TypeName = "nvarchar (4)")]
    public string? Extension { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Photo { get; set; }

    [Column(TypeName = "ntext")]
    public string? Notes { get; set; }

    [Column(TypeName = "INT")]
    public int? ReportsTo { get; set; }

    [Column(TypeName = "nvarchar (255)")]
    public string? PhotoPath { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
