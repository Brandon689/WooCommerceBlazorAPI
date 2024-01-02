using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Clients.Media
{
    public interface IMediaClient
    {
        ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem);
    }
}