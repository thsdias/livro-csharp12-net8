using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using Northwind.EntityModels; // To use NorthwindContext.
using Microsoft.EntityFrameworkCore; // To use the Include and ToListAsync extension methods.
using Microsoft.AspNetCore.Authorization; // To use [Authorize].

namespace Northwind.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext _db;

    public HomeController(ILogger<HomeController> logger, NorthwindContext db)
    {
        _logger = logger;
        _db = db;
    }

    // Add an attribute to cache the response for 10 seconds on the browser or any proxies between the server and browser.
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]    
    public async Task<IActionResult> Index()
    {
        // Console.WriteLine();
        // _logger.LogError("This is a serius error (not really!)");   
        // _logger.LogWarning("This is your first warning!");
        // _logger.LogWarning("Second warning!");
        // _logger.LogInformation("I'm in the Index method of the HomeController.");
        // Console.WriteLine();
        
        HomeIndexViewModel model = new
        (
            VisitorCount: Random.Shared.Next(1, 1001),
            Categories: await _db.Categories.ToListAsync(),
            Products: await _db.Products.ToListAsync()
        );

        return View(model); // Pass the model to the view.
    }

    [Route("private")]  // Simplifies the route 'https://localhost:5141/home/privacy' => 'https://localhost:5141/private'
    [Authorize(Roles = "Administrators")]
    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
    {
        ViewData["alertstyle"] = alertstyle;

        if (!id.HasValue)
            return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");

        Product? model = await _db.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.ProductId == id);

        if(model is null)
            return NotFound($"ProductId {id} not found.");

        return View(model); // Pass model to view and then return result.
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price)
    {
        if (!price.HasValue)
            return BadRequest("You must pass a product price in the query string, for example /Home/ProductsThatCostMoreThan?price=50");

        IEnumerable<Product> model = _db.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => p.UnitPrice > price);

        if (!model.Any())
            return NotFound($"No products cost more than {price:C}.");

        ViewData["MaxPrice"] = price.Value.ToString("C");

        return View(model);
    }

    public async Task<IActionResult> CategoryDetail(int? id)
    {
        if (!id.HasValue)
            return BadRequest("You must pass a category ID in thr route, for example /Home/CategoryDetail/6");

        Category? model = await _db.Categories.Include(p => p.Products)
            .SingleOrDefaultAsync(c => c.CategoryId == id);

        if (model is null)
            return NotFound($"CategoryId {id} not found.");

        // Pass model to view and then return result.
        return View(model);
    }

    // This action method will handle GET and other requests except POST.
    public IActionResult ModelBinding() 
    {
        return View(); // The page with a form to submit.
    }

    [HttpPost]
    public IActionResult ModelBinding(Thing thing)
    {
        HomeModelBindingViewModel model = new
        (
            Thing: thing, HasErrors: !ModelState.IsValid,
            ValidationErrors: ModelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage)
        );

        return View(model); // Show the model bound thing.
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
