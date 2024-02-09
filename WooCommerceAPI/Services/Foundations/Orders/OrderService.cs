using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Services.Foundations.Orders
{
    internal class OrderService : IOrderService
    {
        private readonly IWooCommerceBroker wooCommerceBroker;

        public OrderService(IWooCommerceBroker wooCommerceBroker)
        {
            this.wooCommerceBroker = wooCommerceBroker;
        }

        public async ValueTask<Order> GetOrderAsync(int orderId)
        {
            Order order = await this.wooCommerceBroker.GetOrderRequestAsync(orderId);
            return order;
            //return ConvertToProduct(new Product(), order);
        }

        public async ValueTask<Order[]> GetAllOrdersAsync(int page, int perPage)
        {
            Order[] orders = await this.wooCommerceBroker.GetAllOrdersRequestAsync(page, perPage);
            return orders;
        }
    }
}
