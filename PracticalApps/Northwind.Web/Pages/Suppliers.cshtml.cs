using Microsoft.AspNetCore.Mvc.RazorPages;  // To use PageModel.
using Northwind.EntityModels; // To use NorthwindContext.
using Microsoft.AspNetCore.Mvc; // To use [BindProperty], IActionResult.

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
    private NorthwindContext _db;
    
    public IEnumerable<Supplier>? Suppliers { get; set; }

    [BindProperty] // attribute so that we can easily connect HTML elements on the web page to properties in the Supplier class.
    public Supplier? Supplier { get; set; }

    public SuppliersModel(NorthwindContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";

        Suppliers = _db.Suppliers
            .OrderBy(s => s.Country)
            .ThenBy(s => s.CompanyName);
    }

    public IActionResult OnPost()
    {
        if(Supplier is not null && ModelState.IsValid)
        {
            _db.Suppliers.Add(Supplier);
            _db.SaveChanges();

            return RedirectToPage("/suppliers");
        }
        else
        {
            // Return to original page.
            return Page();
        }
    }
}
