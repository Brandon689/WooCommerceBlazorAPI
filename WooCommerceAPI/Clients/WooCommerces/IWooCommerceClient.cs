using WooCommerceAPI.Clients.Customers;
using WooCommerceAPI.Clients.Orders;
using WooCommerceAPI.Clients.Products;
using WooCommerceAPI.Clients.Settings;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public interface IWooCommerceClient
    {
        IProductsClient Products { get; }
        IOrdersClient Orders { get; }
        ICustomersClient Customers { get; }
        ISettingsClient Settings { get; }
    }
}
