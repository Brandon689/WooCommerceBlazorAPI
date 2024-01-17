using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Orders;

namespace WooCommerceAPI.Clients.Orders
{
    public interface IOrdersClient
    {
        ValueTask<Order> GetOrderAsync(int orderId);
    }
}
