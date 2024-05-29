using Microsoft.AspNetCore.Mvc.Formatters; // To use IOutputFormatter.
using Northwind.EntityModels; // To use AddNorthwindContext method.
using Microsoft.Extensions.Caching.Memory; // To use IMemoryCache and so on.
using Northwind.WebApi.Repositories; // To use ICustomerRepository.
using Swashbuckle.AspNetCore.SwaggerUI; // To use SubmitMethod.
using Microsoft.AspNetCore.HttpLogging; // To use HttpLoggingFields.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpLogging(options => { 
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;     // Default is 32k.
    options.ResponseBodyLogLimit = 4096;    // Default is 32k.
});

// Register an implementation for the in-memory cache as a singleton instance that is constructed immediately.
builder.Services.AddSingleton<IMemoryCache>(new MemoryCache(new MemoryCacheOptions()));

builder.Services.AddNorthwindContext();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers(options => 
{
    WriteLine("\nDefault output formatters:");

    foreach (IOutputFormatter formatter in options.OutputFormatters)
    {
        OutputFormatter? mediaFormatter = formatter as OutputFormatter;

        if (mediaFormatter is null)
            WriteLine($"  {formatter.GetType().Name}");
        else
        {
            WriteLine("  {0}, Media types: {1}",
                arg0: mediaFormatter.GetType().Name,
                arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
        }
    }

    WriteLine();
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a statement to add health checks, including to the Northwind database context.
string? sqlServerConnection = builder.Configuration.GetConnectionString("NorthwindConnection");
builder.Services.AddHealthChecks()
    .AddDbContextCheck<NorthwindContext>()
    // Execute SELECT 1 using the specified connection string.
    .AddSqlServer(sqlServerConnection!);

var app = builder.Build();

// Log Http.
app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
            "Northwind Service API Version 1");

        c.SupportedSubmitMethods(new[] {
            SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete
        });
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Add a statement to use basic health checks.
app.UseHealthChecks(path: "/healthz");

// Add a statement to register the middleware.
app.UseMiddleware<SecurityHeaders>();

app.MapControllers();

app.Run();
