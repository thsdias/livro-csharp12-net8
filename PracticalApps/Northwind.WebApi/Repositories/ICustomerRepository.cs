using Northwind.EntityModels;

namespace Northwind.WebApi.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> CreateAsync(Customer customer);

    Task<Customer[]> RetrieveAllAsync();

    Task<Customer?> RetrieveAsync(string id);

    Task<Customer?> UpdateAsync(Customer customer);

    Task<bool?> DeleteAsync(string id);
}