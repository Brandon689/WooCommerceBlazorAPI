using WooCommerceAPI.Models.Services.Foundations.Customers;

namespace WooCommerceAPI.Services.Foundations.Settings
{
    internal interface ICustomerService
    {
        ValueTask<Customer> GetCustomer(int customerId);
        ValueTask<Customer[]> GetCustomers(string context, int page, int perPage, string search,
            int[] exclude, int[] include, int offset, string order, string orderBy, string email, string role);
        ValueTask<Customer> CreateCustomer(Customer customer);
    }
}
