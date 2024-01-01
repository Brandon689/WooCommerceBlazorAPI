using Microsoft.Extensions.DependencyInjection;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Clients.Products;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Services.Foundations.Products;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public class WooCommerceClient : IWooCommerceClient
    {
        public WooCommerceClient(WooCommerceConfigurations wooCommerceConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(wooCommerceConfigurations);
            InitializeClients(serviceProvider);
        }

        public IProductsClient Products { get; private set; }

        private void InitializeClients(IServiceProvider serviceProvider)
        {
            Products = serviceProvider.GetRequiredService<IProductsClient>();
        }

        private static IServiceProvider RegisterServices(WooCommerceConfigurations wooCommerceConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IWooCommerceBroker, WooCommerceBroker>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IProductsClient, ProductsClient>()
                .AddSingleton(wooCommerceConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
