using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        private const string ProductsRelativeUrl = "/wp-json/wc/v3/products";

        public async ValueTask<ExternalProductResponse> PostProductRequestAsync(
            ExternalProductRequest externalProductRequest)
        {
            var ke = await PostAsync<ExternalProductRequest, dynamic>(
                relativeUrl: ProductsRelativeUrl,
                content: externalProductRequest);

            return await PostAsync<ExternalProductRequest, ExternalProductResponse>(
                relativeUrl: ProductsRelativeUrl,
                content: externalProductRequest);
        }

        public async ValueTask<ExternalProductResponse> PostProductVariationsRequestAsync(
            ExternalProductVariationsRequest externalProductVariationsRequest, int productId)
        {
            return await PostAsync<ExternalProductVariationsRequest, ExternalProductResponse>(
                relativeUrl: $"{ProductsRelativeUrl}/{productId}/variations/batch",
                content: externalProductVariationsRequest);
        }

        public async ValueTask<ExternalProductResponse> GetProductRequestAsync(int id)
        {
            return await GetAsync<ExternalProductResponse>(relativeUrl: $"{ProductsRelativeUrl}/{id}");
        }

        public async ValueTask<ExternalProductResponse[]> GetAllProductsRequestAsync(int page, int perPage)
        {
            var v = await GetAsync<ExternalProductResponse[]>(relativeUrl: $"{ProductsRelativeUrl}?page={page}&per_page={perPage}");
            return v;
        }

        public async ValueTask<ExternalProductRequest> UpdateProductRequestAsync(ExternalProductRequest product, int id)
        {
            var v = await PutAsync<ExternalProductRequest>(relativeUrl: $"{ProductsRelativeUrl}/{id}", content: product);
            return v;
        }
    }
}
