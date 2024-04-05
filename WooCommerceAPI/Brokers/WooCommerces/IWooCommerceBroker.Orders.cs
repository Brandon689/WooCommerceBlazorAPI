using WooCommerceAPI.Models.Services.Foundations.ExternalOrders;
using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Brokers.WooCommerces
{
    internal partial interface IWooCommerceBroker
    {
        ValueTask<Order> GetOrderRequestAsync(int id);
        ValueTask<Order[]> GetAllOrdersRequestAsync(int page, int perPage);
        ValueTask<ExternalOrder> CreateOrderRequestAsync(ExternalOrder order);
    }
}
