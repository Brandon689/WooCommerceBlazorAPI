using WooCommerceAPI.Clients.WordPress;
using WooCommerceAPI.Models.Configurations;
using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerce.MudBlazorWebApp.Services
{
    public class WordPressService
    {
        private readonly WordPressClient _wordpressClient;

        public WordPressService(WordPressConfigurations config)
        {
            _wordpressClient = new WordPressClient(config);
        }

        public async Task<MediaItem> UploadMediaAsync(string src)
        {
            try
            {
                var product = await _wordpressClient.Media.SendMediaItemAsync(new MediaItem()
                {
                    Request = new MediaItemRequest()
                    {
                        Src = src
                    }
                });
                await Console.Out.WriteLineAsync(product.Response.Src);
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
