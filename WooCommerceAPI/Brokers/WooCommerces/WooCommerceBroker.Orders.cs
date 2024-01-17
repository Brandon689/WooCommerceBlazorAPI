using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial class WooCommerceBroker
    {
        private const string OrdersRelativeUrl = "/wp-json/wc/v3/orders";

        public async ValueTask<Order> GetOrderRequestAsync(int id)
        {
            return await GetAsync<Order>(relativeUrl: $"{OrdersRelativeUrl}/{id}");
        }
    }
}
