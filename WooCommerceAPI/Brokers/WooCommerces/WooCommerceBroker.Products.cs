using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        public async ValueTask<ExternalProductResponse> PostChatCompletionRequestAsync(
            ExternalProductRequest externalChatCompletionRequest)
        {
            return await PostAsync<ExternalProductRequest, ExternalProductResponse>(
                relativeUrl: "v3/products",
                content: externalChatCompletionRequest);
        }
    }
}
