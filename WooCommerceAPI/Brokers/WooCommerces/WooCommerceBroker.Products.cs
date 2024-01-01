﻿using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        private const string ProductsRelativeUrl = "/wp-json/wc/v3/products";

        public async ValueTask<ExternalProductResponse> PostProductRequestAsync(
            ExternalProductRequest externalProductRequest)
        {
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
    }
}
