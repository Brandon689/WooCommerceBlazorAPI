using WooCommerceAPI.Models.Services.Foundations.Customers;
using WooCommerceAPI.Models.Services.Foundations.ExternalCustomers;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        private const string CustomersRelativeUrl = "/wp-json/wc/v3/customers";

        public async ValueTask<Customer> GetCustomerRequestAsync(int customerId)
        {
            return await GetAsync<Customer>(relativeUrl: $"{CustomersRelativeUrl}/{customerId}");
        }

        public async ValueTask<Customer[]> GetCustomers(string context, int page, int perPage, string search,
            int[] exclude, int[] include, int offset, string order, string orderBy, string email, string role)
        {
            return await GetAsync<Customer[]>(relativeUrl: $"{CustomersRelativeUrl}");
        }

        public async ValueTask<ExternalCustomer> CreateCustomerRequestAsync(ExternalCustomer customer)
        {
            return await PostAsync<ExternalCustomer>(relativeUrl: $"{CustomersRelativeUrl}", customer);
        }
    }
}
