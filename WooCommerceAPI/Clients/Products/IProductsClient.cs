using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Clients.Products
{
    public interface IProductsClient
    {
        ValueTask<Product> SendProductAsync(Product Product);
    }
}
