using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal interface IProductService
    {
        ValueTask<Product> SendProductAsync(Product product);
        ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations product);
        ValueTask<Product> GetProductAsync(int id);
        ValueTask<Product[]> GetAllProductsAsync(int page, int perPage);
        ValueTask<Product> UpdateProductAsync(Product product, int id);
        ValueTask<ProductVariation2[]> GetProductVariations(int id);
    }
}
