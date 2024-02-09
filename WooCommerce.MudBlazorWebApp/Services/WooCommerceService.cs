using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerce.MudBlazorWebApp.Services
{
    public class WooCommerceService
    {
        private readonly WooCommerceClient _wooCommerceClient;

        //public async Task<Product> GetCachedProductAsync(int id = 0)
        //{
        //    if (CurrentProduct == null)
        //    {
        //        if (id == 0)
        //            throw new Exception("No valid product Id and no product selected.");
        //        CurrentProduct = await GetProductAsync(id);
        //    }
        //    CurrentProduct.Request = new();
        //    return CurrentProduct;
        //}

        public WooCommerceService(WooCommerceConfigurations config)
        {
            _wooCommerceClient = new WooCommerceClient(config);
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            try
            {
                var product = await _wooCommerceClient.Products.GetProductAsync(productId);
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Product[]> GetAllProductsAsync()
        {
            var product = await _wooCommerceClient.Products.GetAllProductsAsync(9, 20);
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product _product, int id = 0)
        {
            var product = await _wooCommerceClient.Products.UpdateProductAsync(_product, id);
            return product;
        }
    }
}
