﻿using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<ExternalProductResponse> PostProductRequestAsync(ExternalProductRequest externalProductRequest);
        ValueTask<ExternalProductResponse> PostProductVariationsRequestAsync(ExternalProductVariationsRequest externalProductVariationsRequest, int productId);

        ValueTask<ExternalProductResponse> GetProductRequestAsync(int id);
        ValueTask<ExternalProductResponse[]> GetAllProductsRequestAsync(int page, int perPage);

        ValueTask<ExternalProductResponse> UpdateProductRequestAsync(ExternalProductRequest product, int id);
    }
}
