using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization; // To use [XmlIgnore].

namespace Northwind.EntityModels;

[Index("City", Name = "City")]
[Index("CompanyName", Name = "CompanyName")]
[Index("PostalCode", Name = "PostalCode")]
[Index("Region", Name = "Region")]
public partial class Customer
{
    [Key]
    [Required]
    [Column("CustomerID")]
    [StringLength(5)]
    [RegularExpression("[A-Z]{5}")]
    public string CustomerId { get; set; } = null!;

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [StringLength(30)]
    public string? ContactName { get; set; }

    [StringLength(30)]
    public string? ContactTitle { get; set; }

    [StringLength(60)]
    public string? Address { get; set; }

    [StringLength(15)]
    public string? City { get; set; }

    [StringLength(15)]
    public string? Region { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }

    [StringLength(15)]
    public string? Country { get; set; }

    [Phone]
    [StringLength(24)]
    public string? Phone { get; set; }

    [StringLength(24)]
    public string? Fax { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Customers")]
    [XmlIgnore]
    public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; } = new List<CustomerDemographic>();

    /*
        Controlling XML serialization:
        The XmlSerializer cannot serialize interfaces, and our entity classes use ICollection<T> to define 
        related child entities. This causes a warning at runtime, for example, for the Customer class and 
        its Orders property, as shown in the following output:

        warn: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter[1]
        An error occurred while trying to create an XmlSerializer for the type 'Northwind.EntityModels.Customer'.
        System.InvalidOperationException: There was an error reflecting type 'Northwind.EntityModels.Customer'.
        ---> System.InvalidOperationException: Cannot serialize member 'Northwind.EntityModels.Customer.Orders' 
        of type 'System.Collections.Generic.ICollection`1[[Northwind.EntityModels.Order, 
        Northwind.EntityModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]', 
        see inner exception for more details.   

        using System.Xml.Serialization; // To use [XmlIgnore].  
    */
}
