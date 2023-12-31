using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<ExternalProductResponse> PostProductRequestAsync(ExternalProductRequest externalProductRequest);
    }
}
