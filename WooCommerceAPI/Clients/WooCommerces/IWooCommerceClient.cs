using WooCommerceAPI.Clients.Customers;
using WooCommerceAPI.Clients.Orders;
using WooCommerceAPI.Clients.Products;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public interface IWooCommerceClient
    {
        IProductsClient Products { get; }
        IOrdersClient Orders { get; }
        ICustomersClient Customers { get; }
    }
}
