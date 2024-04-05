using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Models.Services.Foundations.ExternalOrders;
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

        public async ValueTask<Order> CreateOrderAsync(Order order)
        {
            ExternalOrder o = ConvertToOrderCreate(order);
            var newOrder = await this.wooCommerceBroker.CreateOrderRequestAsync(o);
            return null;
        }

        private static ExternalOrder ConvertToOrderCreate(Order order)
        {
            ExternalOrder o = new ExternalOrder
            {
                PaymentMethod = order.PaymentMethod,
                PaymentMethodTitle = order.PaymentMethodTitle,
                SetPaid = order.SetPaid,
                Billing = new ExternalBilling
                {
                    FirstName = order.Billing.FirstName,
                    LastName = order.Billing.LastName,
                    Address1 = order.Billing.Address1,
                    Address2 = order.Billing.Address2,
                    City = order.Billing.City,
                    Company = order.Billing.Company,
                    State   = order.Billing.State,
                    Email = order.Billing.Email,
                    Phone  = order.Billing.Phone,
                    Country = order.Billing.Country,
                    Postcode = order.Billing.Postcode,
                },
                Shipping = new ExternalShipping
                {
                    FirstName = order.Shipping.FirstName,
                    LastName = order.Shipping.LastName,
                    Address1 = order.Shipping.Address1,
                    Address2 = order.Shipping.Address2,
                    City = order.Shipping.City,
                    Company = order.Shipping.Company,
                    State = order.Shipping.State,
                    Country = order.Shipping.Country,
                    Postcode = order.Shipping.Postcode,
                },
                LineItems = order.LineItems.Select(x => new ExternalLineItem
                {
                    Id = x.Id,
                    MetaData = x.MetaData,
                    Sku = x.Sku,
                    Subtotal = x.Subtotal,
                    Name = x.Name,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    VariationId = x.VariationId,
                    SubtotalTax = x.SubtotalTax,
                    TaxClass = x.TaxClass,
                    Taxes = x.Taxes,
                    Total = x.Total,
                    TotalTax = x.TotalTax,
                }).ToArray(),
            };
            return o;
        }
    }
}
