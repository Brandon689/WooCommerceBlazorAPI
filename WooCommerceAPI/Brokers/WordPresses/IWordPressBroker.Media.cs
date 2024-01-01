using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Brokers.WordPresses
{
    internal partial interface IWordPressBroker
    {
        ValueTask<ExternalMediaItemResponse> PostMediaRequestAsync(ExternalMediaItemRequest externalProductRequest);
    }
}
