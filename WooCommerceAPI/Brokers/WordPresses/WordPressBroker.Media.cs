using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;

namespace WooCommerceAPI.Brokers.WordPresses
{
    internal partial class WordPressBroker : IWordPressBroker
    {
        private const string MediaRelativeUrl = "/wp-json/wp/v2/media";

        public async ValueTask<ExternalMediaItemResponse> PostMediaRequestAsync(ExternalMediaItemRequest externalMediaItemRequest)
        {
            //var j = await PostFormAsync<ExternalMediaItemRequest, dynamic>(
            //    relativeUrl: MediaRelativeUrl,
            //    content: externalMediaItemRequest);

            return await PostFormAsync<ExternalMediaItemRequest, ExternalMediaItemResponse>(
                relativeUrl: MediaRelativeUrl,
                content: externalMediaItemRequest);
        }
    }
}
