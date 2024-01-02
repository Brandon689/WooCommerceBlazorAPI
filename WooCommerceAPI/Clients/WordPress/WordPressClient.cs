using Microsoft.Extensions.DependencyInjection;
using WooCommerceAPI.Brokers.WordPresses;
using WooCommerceAPI.Clients.Media;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Services.Foundations.Media;

namespace WooCommerceAPI.Clients.WordPress
{
    public class WordPressClient : IWordPressClient
    {
        public WordPressClient(WordPressConfigurations wordPressConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(wordPressConfigurations);
            InitializeClients(serviceProvider);
        }

        public IMediaClient Media { get; private set; }

        private void InitializeClients(IServiceProvider serviceProvider)
        {
            Media = serviceProvider.GetRequiredService<IMediaClient>();
        }

        private static IServiceProvider RegisterServices(WordPressConfigurations wordPressConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IWordPressBroker, WordPressBroker>()
                .AddTransient<IMediaService, MediaService>()
                .AddTransient<IMediaClient, MediaClient>()
                .AddSingleton(wordPressConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
