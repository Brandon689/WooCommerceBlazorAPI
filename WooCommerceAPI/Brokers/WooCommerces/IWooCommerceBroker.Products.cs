using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<ExternalProductResponse> PostProductRequestAsync(ExternalProductRequest externalProductRequest);
    }
}
