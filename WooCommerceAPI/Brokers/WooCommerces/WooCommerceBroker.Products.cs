using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        private const string ProductsRelativeUrl = "/wp-json/wc/v3/products";

        public async ValueTask<ExternalProduct> PostProductRequestAsync(
            ExternalProduct externalProductRequest)
        {
            return await PostAsync<ExternalProduct>(
                relativeUrl: ProductsRelativeUrl,
                content: externalProductRequest);
        }

        public async ValueTask<ExternalProduct> PostProductVariationsRequestAsync(
            ExternalProductVariationsRequest externalProductVariationsRequest, int productId)
        {
            return await PostAsync<ExternalProductVariationsRequest, ExternalProduct>(
                relativeUrl: $"{ProductsRelativeUrl}/{productId}/variations/batch",
                content: externalProductVariationsRequest);
        }

        public async ValueTask<ExternalProduct> GetProductRequestAsync(int id)
        {
            return await GetAsync<ExternalProduct>(relativeUrl: $"{ProductsRelativeUrl}/{id}");
        }

        public async ValueTask<ExternalProduct[]> GetAllProductsRequestAsync(int page, int perPage)
        {
            //var f = await GetAsync<dynamic[]>(relativeUrl: $"{ProductsRelativeUrl}?page={page}&per_page={perPage}");
            return await GetAsync<ExternalProduct[]>(relativeUrl: $"{ProductsRelativeUrl}?page={page}&per_page={perPage}");
        }

        public async ValueTask<ExternalProduct> UpdateProductRequestAsync(ExternalProduct product, int id)
        {
            return await PutAsync<ExternalProduct>(relativeUrl: $"{ProductsRelativeUrl}/{id}", content: product);
        }
    }
}
