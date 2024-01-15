using WooCommerceAPI.Clients.WooCommerces;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerce.MudBlazorWebApp.Services
{
    public class WooCommerceService
    {
        private readonly WooCommerceClient _wooCommerceClient;
        private Product? CurrentProduct { get; set; } = null;

        public async Task<Product> GetCachedProductAsync(int id = 0)
        {
            if (CurrentProduct == null)
            {
                if (id == 0)
                    return new Product();
                CurrentProduct = await GetProductAsync(id);
                return CurrentProduct;
            }
            return CurrentProduct;
        }

        public Product GetCurrentProduct()
        {
            return CurrentProduct;
        }

        public void SetCurrentProduct(Product product)
        {
            CurrentProduct = product;
        }

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
            var product = await _wooCommerceClient.Products.GetAllProductsAsync(2, 2);
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product _product, int id)
        {
            var product = await _wooCommerceClient.Products.UpdateProductAsync(_product, id);
            return product;
        }
    }
}
