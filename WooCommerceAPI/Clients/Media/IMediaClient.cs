using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Clients.Media
{
    internal interface IMediaClient
    {
        ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem);
    }
}