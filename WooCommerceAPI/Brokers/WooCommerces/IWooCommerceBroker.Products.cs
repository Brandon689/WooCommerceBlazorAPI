using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations;
using WooCommerceAPI.Models.Services.Foundations.ProductVariations;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<ExternalProduct> PostProductRequestAsync(ExternalProduct externalProductRequest);
        ValueTask<ExternalProduct> PostProductVariationsRequestAsync(ExternalProductVariationsRequest externalProductVariationsRequest, int productId);
        ValueTask<ExternalProduct> GetProductRequestAsync(int id);
        ValueTask<ExternalProduct[]> GetAllProductsRequestAsync(int page, int perPage);
        ValueTask<ExternalProduct> UpdateProductRequestAsync(ExternalProduct product, int id);
        ValueTask<ProductVariation[]> GetProductVariations(int id);
    }
}
