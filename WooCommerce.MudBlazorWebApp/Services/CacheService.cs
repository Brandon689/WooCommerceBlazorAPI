using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerce.MudBlazorWebApp.Services
{
    public class CacheService
    {
        private List<Product> products;
        private Product? activeProduct { get; set; } = null;

        public bool Cold()
        {
            return products == null;
        }

        public bool ColdSingle()
        {
            return activeProduct == null;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void SetProducts(IEnumerable<Product> products)
        {
            this.products = products.ToList();
        }

        public Product GetCurrentProduct()
        {
            return activeProduct;
        }

        public void SetCurrentProduct(Product product)
        {
            activeProduct = product;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Response.Id == activeProduct.Response.Id)
                    products[i] = activeProduct;
                break;
            }
        }
    }
}
