using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Services.Foundations.Products
{
    internal interface IProductService
    {
        ValueTask<Product> SendProductAsync(Product Product);
    }
}
