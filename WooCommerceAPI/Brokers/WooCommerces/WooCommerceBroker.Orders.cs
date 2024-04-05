using WooCommerceAPI.Models.Services.Foundations.ExternalOrders;
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

        public async ValueTask<Order[]> GetAllOrdersRequestAsync(int page, int perPage)
        {
            return await GetAsync<Order[]>(relativeUrl: $"{OrdersRelativeUrl}?page={page}&per_page={perPage}");
        }

        public async ValueTask<ExternalOrder> CreateOrderRequestAsync(ExternalOrder order)
        {
            //var f = await PostAsync<dynamic>(relativeUrl: $"{OrdersRelativeUrl}", order);
            return await PostAsync<ExternalOrder>(relativeUrl: $"{OrdersRelativeUrl}", order);
        }
    }
}
