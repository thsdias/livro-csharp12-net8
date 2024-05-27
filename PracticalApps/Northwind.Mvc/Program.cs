/*
    https://github.com/markjprice/cs12dotnet8/blob/main/docs/aspnetcoremvc.md
*/

#region Import namespaces

using Microsoft.AspNetCore.Identity; // To use IdentityUser.
using Microsoft.EntityFrameworkCore; // To use UseSqlServer method.
using Northwind.Mvc.Data; // To use ApplicationDbContext.
using Northwind.EntityModels; // To use AddNorthwindContext method.
using System.Net.Http.Headers; // To use MediaTypeWithQualityHeaderValue.
using System.Net; // To use HttpVersion.

#endregion

#region Configure the host web server including services

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registers an application database context using SQL Server or SQLite. The database connection string is loaded from the appsettings.json file.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Adds ASP.NET Core Identity for authentication and configures it to use the application database.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Enable role management.
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Adds support for MVC controllers with views.
builder.Services.AddControllersWithViews();

// Add statements to the configuration of the HTTP client for the Northwind.WebApi service to set the default 
// version to 3.0, and to fall back to earlier versions if HTTP/3 is not supported by the web service.
builder.Services.AddHttpClient(name: "Northwind.WebApi",
    configureClient: options =>
    {
        options.DefaultRequestVersion = HttpVersion.Version30;
        options.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower;

        options.BaseAddress = new Uri("https://localhost:5151/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
            mediaType: "application/json", quality: 1.0));
    }
);

#region Connection String

// If you are using SQLite, default is "..\Northwind.db".
//builder.Services.AddNorthwindContext();

// If you are using SQL Server.
string? sqlServerConnection = builder.Configuration.GetConnectionString("NorthwindConnection");

// Todo: Refactor.
const string SQL_USR = "SQL_USR_VALUE";
const string SQL_PWD = "SQL_PWD_VALUE";
Environment.SetEnvironmentVariable(SQL_USR, "sa");
Environment.SetEnvironmentVariable(SQL_PWD, "abc123");

if (sqlServerConnection is null)
{
    Console.WriteLine("SQL Server database connection string is missing!");
}
else
{
    // If you are using SQL Server authentication then disable
    // Windows Integrated authentication and set user and password.
    Microsoft.Data.SqlClient.SqlConnectionStringBuilder sql = new(sqlServerConnection);

    sql.IntegratedSecurity = false;
    sql.UserID = Environment.GetEnvironmentVariable(SQL_USR);
    sql.Password = Environment.GetEnvironmentVariable(SQL_PWD);

    builder.Services.AddNorthwindContext(sql.ConnectionString);

    builder.Services.AddOutputCache(options =>
    {
        options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(20);
        options.AddPolicy("Views", p => p.SetVaryByQuery("alertstyle"));  // Add a statement to define a named policy to disable varying by query string parameters.
    });
}

#endregion

// Add a statement to enable HttpClientFactory with a named client to make calls to the Northwind Web API service 
// using HTTPS on port 5151 and request JSON as the default response format.
builder.Services.AddHttpClient(
    name: "Northwind.WebApi", 
    configureClient: options => 
    {
        options.BaseAddress = new Uri("https://localhost:5151");
        options.DefaultRequestHeaders.Accept.Add
        (
            new MediaTypeWithQualityHeaderValue(mediaType: "application/json", quality: 1.0)
        );
    }
);

// Add a statement to configure an HTTP client to call the minimal service on port 5152 (Minimal API).
builder.Services.AddHttpClient(name: "Northwind.MinimalApi",
    configureClient: options => 
    {
        options.BaseAddress = new Uri("http://localhost:5152/");
        options.DefaultRequestHeaders.Accept.Add
        (
            new MediaTypeWithQualityHeaderValue("application/json", 1.0)
        );
    }
);

var app = builder.Build();

#endregion

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseOutputCache();   // map controllers to use the output cache.

app.MapControllerRoute
(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
); //.CacheOutput(policyName: "views"); // Specify the named policy for cache.

app.MapRazorPages();

// Create two endpoints that respond with plain text, 
// one that is not cached and one that uses the output cache.
app.MapGet("/notcached", () => DateTime.Now.ToString());
app.MapGet("/cached", () => DateTime.Now.ToString()).CacheOutput();

#endregion

#region Start the host web server listening for HTTP requests.

app.Run();

#endregion