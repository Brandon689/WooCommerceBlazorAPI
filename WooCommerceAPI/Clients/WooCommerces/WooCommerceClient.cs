using Microsoft.Extensions.DependencyInjection;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Clients.Customers;
using WooCommerceAPI.Clients.Orders;
using WooCommerceAPI.Clients.Products;
using WooCommerceAPI.Clients.Settings;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Services.Foundations.Orders;
using WooCommerceAPI.Services.Foundations.Products;
using WooCommerceAPI.Services.Foundations.Settings;

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
        public ICustomersClient Customers { get; private set; }
        public ISettingsClient Settings { get; private set; }

        private void InitializeClients(IServiceProvider serviceProvider)
        {
            Products = serviceProvider.GetRequiredService<IProductsClient>();
            Orders = serviceProvider.GetRequiredService<IOrdersClient>();
            Customers = serviceProvider.GetRequiredService<ICustomersClient>();
            Settings = serviceProvider.GetRequiredService<ISettingsClient>();
        }

        private static IServiceProvider RegisterServices(WooCommerceConfigurations wooCommerceConfigurations, bool oAuth)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IWooCommerceBroker>(provider => new WooCommerceBroker(wooCommerceConfigurations, oAuth))
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IProductsClient, ProductsClient>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IOrdersClient, OrdersClient>()
                .AddTransient<ICustomersClient, CustomersClient>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<ISettingsClient, SettingsClient>()
                .AddTransient<ISettingsService, SettingsService>()
                .AddSingleton(wooCommerceConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
