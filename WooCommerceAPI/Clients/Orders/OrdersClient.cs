﻿using WooCommerceAPI.Models.Services.Foundations.Orders;
using WooCommerceAPI.Services.Foundations.Orders;

namespace WooCommerceAPI.Clients.Orders
{
    internal class OrdersClient : IOrdersClient
    {
        private readonly IOrderService orderService;

        public OrdersClient(IOrderService orderService) =>
            this.orderService = orderService;

        public async ValueTask<Order> GetOrderAsync(int orderId)
        {
            return await orderService.GetOrderAsync(orderId);
        }

        public async ValueTask<Order[]> GetAllOrdersAsync(int page, int perPage)
        {
            return await orderService.GetAllOrdersAsync(page, perPage);
        }

        public async ValueTask<Order> CreateOrderAsync(Order order)
        {
            return await orderService.CreateOrderAsync(order);
        }
    }
}
