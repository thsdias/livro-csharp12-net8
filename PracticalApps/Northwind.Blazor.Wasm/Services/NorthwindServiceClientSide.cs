using Northwind.EntityModels;
using System.Net.Http.Json;

namespace Northwind.Blazor.Services;

public class NorthwindServiceClientSide : INorthwindService
{
  private const string _api = "Northwind.WebApi";

  private readonly IHttpClientFactory _clientFactory;

  public NorthwindServiceClientSide(IHttpClientFactory httpClientFactory)
  {
    _clientFactory = httpClientFactory;
  }

  public Task<List<Customer>> GetCustomersAsync()
  {
    HttpClient client = _clientFactory.CreateClient(name: _api);
    return client.GetFromJsonAsync<List<Customer>>($"api/customers")!;
  }

  public Task<List<Customer>> GetCustomersAsync(string country)
  {
    HttpClient client = _clientFactory.CreateClient(name: _api);
    return client.GetFromJsonAsync<List<Customer>>($"api/customers/in/{country}")!;
  }

  public Task<Customer?> GetCustomerAsync(string id)
  {
    HttpClient client = _clientFactory.CreateClient(name: _api);
    return client.GetFromJsonAsync<Customer>($"api/customers/{id}");
  }

  public async Task<Customer> CreateCustomerAsync(Customer customer)
  {
    HttpClient client = _clientFactory.CreateClient(name: _api);
    HttpResponseMessage response = await client.PostAsJsonAsync("api/customers", customer);

    return (await response.Content.ReadFromJsonAsync<Customer>())!;
  }

  public async Task<Customer> UpdateCustomerAsync(Customer customer)
  {
    HttpClient client = _clientFactory.CreateClient(name: _api);
    HttpResponseMessage response = await client.PutAsJsonAsync("api/customers", customer);

    return (await response.Content.ReadFromJsonAsync<Customer>())!;
  }

  public async Task DeleteCustomerAsync(string id)
  {
    HttpClient client = _clientFactory.CreateClient(name: _api);
    HttpResponseMessage response = await client.DeleteAsync($"api/customers/{id}");
  }
}