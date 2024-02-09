using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Services.Foundations.Orders
{
    internal interface IOrderService
    {
        ValueTask<Order> GetOrderAsync(int orderId);
        ValueTask<Order[]> GetAllOrdersAsync(int page, int perPage);
    }
}
