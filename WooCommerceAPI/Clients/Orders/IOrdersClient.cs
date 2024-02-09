using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Clients.Orders
{
    public interface IOrdersClient
    {
        ValueTask<Order> GetOrderAsync(int orderId);
        ValueTask<Order[]> GetAllOrdersAsync(int page, int perPage);
    }
}
