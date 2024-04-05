using Microsoft.Extensions.DependencyInjection;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Clients.Orders;
using WooCommerceAPI.Clients.Products;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Services.Foundations.Orders;
using WooCommerceAPI.Services.Foundations.Products;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public class WooCommerceClient : IWooCommerceClient
    {
        public WooCommerceClient(WooCommerceConfigurations wooCommerceConfigurations, bool oAuth)
        {
            IServiceProvider serviceProvider = RegisterServices(wooCommerceConfigurations, oAuth);
            InitializeClients(serviceProvider);
        }

        public IProductsClient Products { get; private set; }
        public IOrdersClient Orders { get; private set; }

        private void InitializeClients(IServiceProvider serviceProvider)
        {
            Products = serviceProvider.GetRequiredService<IProductsClient>();
            Orders = serviceProvider.GetRequiredService<IOrdersClient>();
        }

        private static IServiceProvider RegisterServices(WooCommerceConfigurations wooCommerceConfigurations, bool oAuth)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IWooCommerceBroker>(provider => new WooCommerceBroker(wooCommerceConfigurations, oAuth))
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IProductsClient, ProductsClient>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IOrdersClient, OrdersClient>()
                .AddSingleton(wooCommerceConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
