using WooCommerceAPI.Clients.Products;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public interface IWooCommerceClient
    {
        IProductsClient Products { get; }
    }
}
