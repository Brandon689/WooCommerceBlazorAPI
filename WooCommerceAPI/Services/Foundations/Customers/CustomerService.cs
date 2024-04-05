using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.Customers;
using WooCommerceAPI.Models.Services.Foundations.ExternalCustomers;

namespace WooCommerceAPI.Services.Foundations.Settings
{
    internal class CustomerService(IWooCommerceBroker wooCommerceBroker) : ICustomerService
    {
        private readonly IWooCommerceBroker wooCommerceBroker = wooCommerceBroker;

        public async ValueTask<Customer> GetCustomer(int customerId)
        {
            return await this.wooCommerceBroker.GetCustomerRequestAsync(customerId);
        }

        public async ValueTask<Customer[]> GetCustomers(string context, int page, int perPage, string search,
            int[] exclude, int[] include, int offset, string order, string orderBy, string email, string role)
        {
            return await this.wooCommerceBroker.GetCustomers(context, page, perPage, search, exclude, include, offset, order, orderBy, email, role);
        }

        public async ValueTask<Customer> CreateCustomer(Customer customer)
        {
            var e = ConvertToCustomer(customer);
            var f = await this.wooCommerceBroker.CreateCustomerRequestAsync(e);
            return null;
        }

        private ExternalCustomer ConvertToCustomer(Customer customer)
        {
            return new ExternalCustomer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateCreated = customer.DateCreated,
                DateCreatedGmt = customer.DateCreatedGmt,
                DateModified = customer.DateModified,
                DateModifiedGmt = customer.DateModifiedGmt,
                Email = customer.Email,
                AvatarUrl = customer.AvatarUrl,
                Id = customer.Id,
                IsPayingCustomer = customer.IsPayingCustomer,
                Role = customer.Role,
                Username = customer.Username,
                Shipping = new Models.Services.Foundations.Orders.ExternalShipping
                {
                    Address1 = customer.Shipping.Address1,
                    Address2 = customer.Shipping.Address2,
                    City = customer.Shipping.City,
                    Company = customer.Shipping.Company,
                    Country = customer.Shipping.Country,
                    FirstName = customer.Shipping.FirstName,
                    LastName = customer.Shipping.LastName,
                    Postcode = customer.Shipping.Postcode,
                    State = customer.Shipping.State,
                },
                Billing = new Models.Services.Foundations.Orders.ExternalBilling
                {
                    Address1 = customer.Billing.Address1,
                    Address2 = customer.Billing.Address2,
                    City = customer.Billing.City,
                    Country = customer.Billing.Country,
                    FirstName = customer.Billing.FirstName,
                    LastName = customer.Billing.LastName,
                    State = customer.Billing.State,
                    Company = customer.Billing.Company,
                    Email = customer.Billing.Email,
                    Phone = customer.Billing.Phone,
                    Postcode = customer.Billing.Postcode
                }
            };
        }
    }
}