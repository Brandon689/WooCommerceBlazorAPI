using WooCommerceAPI.Models.Services.Foundations.Media;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Clients.Media
{
    internal interface IMediaClient
    {
        ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem);
    }
}