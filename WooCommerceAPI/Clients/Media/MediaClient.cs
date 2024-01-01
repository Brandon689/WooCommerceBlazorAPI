using WooCommerceAPI.Models.Services.Foundations.Media;
using WooCommerceAPI.Services.Foundations.Media;

namespace WooCommerceAPI.Clients.Media
{
    internal class MediaClient : IMediaClient
    {
        private readonly IMediaService mediaService;

        public MediaClient(IMediaService mediaService) => this.mediaService = mediaService;

        public async ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem)
        {
            return await mediaService.SendMediaItemAsync(mediaItem);
        }
    }
}
