using Northwind.EntityModels;

partial class Program
{
    private static void GetCompanyCustomers()
    {
        SectionTitle("Companies by Customer City");

        NorthwindDb db = new();

        IQueryable<Customer> customers = db.Customers;

        if (customers is not null && customers.Any())
        {
            var cities = customers.OrderBy(c => c.City).Select(c => c.City).Distinct();

            WriteLine($"\nRegistered cities: \n{string.Join(", ", cities)}");
            WriteLine();

            Write("Enter the name of a city: ");
            string? city = ReadLine();

            if(!string.IsNullOrWhiteSpace(city))
            {
                IQueryable<Customer> companies = customers.Where(c => c.City == city);

                if(companies is not null && companies.Any())
                {
                    WriteLine($"\nThere are {companies.Count()} customers in {city}:");

                    foreach(Customer customer in companies)
                    {   
                        WriteLine($"    {customer.CompanyName}");
                    }
                }
                else
                {
                    WriteLine($"\nNo customer found in the {city} city");
                }
            } 
            else
            {
                WriteLine($"\nNo customer found in the {city} city");
            }

            WriteLine();
        }
    }
}