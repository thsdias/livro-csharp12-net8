using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Northwind.Blazor.Services;
using System.Net.Http.Headers; // To use MediaTypeWithQualityHeaderValue.

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add a statement to enable HttpClientFactory with a named client to make calls to the Northwind Web API 
// service using HTTPS on port 5151 and request JSON as the default response format.
builder.Services.AddHttpClient(
    name: "Northwind.WebApi",
    configureClient: options =>
    {
        options.BaseAddress = new Uri("https://localhost:5151/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(mediaType: "application/json", quality: 1.0));
    }
);

// Modify the statement to register the Northwind dependency service and set up an HTTP client factory.
builder.Services.AddTransient<INorthwindService, NorthwindServiceClientSide>();

await builder.Build().RunAsync();
