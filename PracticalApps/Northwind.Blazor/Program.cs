using Northwind.Blazor.Components;
using Northwind.Blazor.Services; // To use INorthwindService.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()  // Add a call to a method to enable server-side interactivity.
    .AddInteractiveWebAssemblyComponents(); // Add a call to a method to enable client-side interactivity.

// Register the Northwind database context in the dependency services collection.
builder.Services.AddNorthwindContext();

// Add a statement to register NorthwindServiceServerSide as a transient service that implements the INorthwindService interface.
builder.Services.AddTransient<INorthwindService, NorthwindServiceServerSide>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()  // Add a call to a method to enable server-side interactivity.
    .AddInteractiveWebAssemblyRenderMode();  // Add a call to a method to enable server-side interactivity.

app.Run();
