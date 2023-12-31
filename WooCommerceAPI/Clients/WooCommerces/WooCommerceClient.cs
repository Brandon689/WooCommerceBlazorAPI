using Microsoft.Extensions.DependencyInjection;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Clients.Products;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Services.Foundations.Products;

namespace WooCommerceAPI.Clients.WooCommerces
{
    public class WooCommerceClient : IWooCommerceClient
    {
        public WooCommerceClient(WooCommerceConfigurations openAIConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(openAIConfigurations);
            InitializeClients(serviceProvider);
        }

        public IProductsClient Products { get; private set; }

        private void InitializeClients(IServiceProvider serviceProvider)
        {
            Products = serviceProvider.GetRequiredService<IProductsClient>();
        }

        private static IServiceProvider RegisterServices(WooCommerceConfigurations openAIConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IWooCommerceBroker, WooCommerceBroker>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IProductsClient, ProductsClient>()
                .AddSingleton(openAIConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
