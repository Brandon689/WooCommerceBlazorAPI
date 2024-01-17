using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Orders;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Services.Foundations.Orders
{
    internal interface IOrderService
    {
        ValueTask<Order> GetOrderAsync(int orderId);
        ValueTask<Order[]> GetAllOrdersAsync(int page, int perPage);
    }
}
