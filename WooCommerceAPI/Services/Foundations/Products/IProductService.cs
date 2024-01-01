using WooCommerceAPI.Models.Services.Foundations.Products;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal interface IProductService
    {
        ValueTask<Product> SendProductAsync(Product Product);
        ValueTask<ProductVariations> SendProductVariationsAsync(ProductVariations Product);
    }
}
