using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Models.Services.Foundations.Customers
{
    public class Customer
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateCreatedGmt { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateModifiedGmt { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }

        public bool IsPayingCustomer { get; set; }

        public string AvatarUrl { get; set; }

        public List<MetaData> MetaData { get; set; }

        public Links Links { get; set; }
    }
}
