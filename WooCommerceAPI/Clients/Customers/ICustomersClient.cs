using WooCommerceAPI.Models.Services.Foundations.Customers;

namespace WooCommerceAPI.Clients.Customers
{
    public interface ICustomersClient
    {
        ValueTask<Customer> GetCustomer(int customerId);
        ValueTask<Customer[]> GetCustomers(string context = "", 
            int page = 1, 
            int perPage = 10, 
            string search = "", 
            int[] exclude = null, 
            int[] include = null, 
            int offset = 0, 
            string order = "", 
            string orderBy = "", 
            string email = "", 
            string role = "");
        ValueTask<Customer> CreateCustomer(Customer customer);
    }
}
