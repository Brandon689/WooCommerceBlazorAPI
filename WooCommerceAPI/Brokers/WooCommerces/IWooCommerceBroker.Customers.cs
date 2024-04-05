using WooCommerceAPI.Models.Services.Foundations.Customers;
using WooCommerceAPI.Models.Services.Foundations.ExternalCustomers;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<Customer> GetCustomerRequestAsync(int customerId);
        ValueTask<Customer[]> GetCustomers(string context, int page, int perPage, string search,
            int[] exclude, int[] include, int offset, string order, string orderBy, string email, string role);
        ValueTask<ExternalCustomer> CreateCustomerRequestAsync(ExternalCustomer customer);
    }
}
