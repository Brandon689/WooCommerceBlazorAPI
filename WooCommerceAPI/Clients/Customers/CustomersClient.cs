using WooCommerceAPI.Models.Services.Foundations.Customers;
using WooCommerceAPI.Services.Foundations.Settings;

namespace WooCommerceAPI.Clients.Customers
{
    internal partial class CustomersClient : ICustomersClient
    {
        private readonly ICustomerService customerService;

        public CustomersClient(ICustomerService customerService) =>
            this.customerService = customerService;

        public async ValueTask<Customer> GetCustomer(int customerId)
        {
            return await customerService.GetCustomer(customerId);
        }

        public async ValueTask<Customer[]> GetCustomers(string context, int page, int perPage, string search,
            int[] exclude, int[] include, int offset, string order, string orderBy, string email, string role)
        {
            return await customerService.GetCustomers(context, page, perPage, search, exclude, include, offset, order, orderBy, email, role);
        }

        public async ValueTask<Customer> CreateCustomer(Customer customer)
        {
            return await customerService.CreateCustomer(customer);
        }
    }
}
