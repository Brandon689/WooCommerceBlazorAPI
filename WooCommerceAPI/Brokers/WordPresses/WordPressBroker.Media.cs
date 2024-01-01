using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Brokers.WordPresses
{
    internal partial class WordPressBroker : IWordPressBroker
    {
        private const string MediaRelativeUrl = "/wp/v2/media";

        public async ValueTask<ExternalMediaItemResponse> PostMediaRequestAsync(ExternalMediaItemRequest externalMediaItemRequest)
        {
            return await PostAsync<ExternalMediaItemRequest, ExternalMediaItemResponse>(
                relativeUrl: MediaRelativeUrl,
                content: externalMediaItemRequest);
        }
    }
}
