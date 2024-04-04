using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace WooCommerceAPI.Clients.Products
{
    public interface IProductsClient
    {
        ValueTask<Product> SendProductAsync(Product product);
        ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations product);
        ValueTask<Product> GetProductAsync(int id);
        ValueTask<Product[]> GetAllProductsAsync(int page, int perPage);
        ValueTask<Product> UpdateProductAsync(Product product, int id = 0);
        ValueTask<ProductVariation[]> GetProductVariations(int id = 0);
    }
}
