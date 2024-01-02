using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Services.Foundations.Media
{
    internal interface IMediaService
    {
        ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem);
    }
}
