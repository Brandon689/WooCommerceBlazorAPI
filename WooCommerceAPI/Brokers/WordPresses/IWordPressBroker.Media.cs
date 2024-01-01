using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;

namespace WooCommerceAPI.Brokers.WordPresses
{
    internal partial interface IWordPressBroker
    {
        ValueTask<ExternalMediaItemResponse> PostMediaRequestAsync(ExternalMediaItemRequest externalProductRequest);
    }
}
