using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.ExternalProducts;
using WooCommerceAPI.Models.Services.Foundations.Orders;
using WooCommerceAPI.Models.Services.Foundations.Products;

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
            Order order =
                await this.wooCommerceBroker.GetOrderRequestAsync(orderId);

            return order;
            //return ConvertToProduct(new Product(), order);
        }

        //public async ValueTask<Order[]> GetAllOrdersAsync(int page, int perPage)
        //{

        //}
    }
}
