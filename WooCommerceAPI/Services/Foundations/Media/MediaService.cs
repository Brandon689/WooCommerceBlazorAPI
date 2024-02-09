using WooCommerceAPI.Brokers.WordPresses;
using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;
using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Services.Foundations.Media
{
    internal partial class MediaService : IMediaService
    {
        private readonly IWordPressBroker wordPressBroker;

        public MediaService(IWordPressBroker wordPressBroker)
        {
            this.wordPressBroker = wordPressBroker;
        }

        public async ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem)
        {
            ExternalMediaItemRequest externalMediaItemRequest = Convert(mediaItem);

            ExternalMediaItemResponse externalMediaItemResponse =
                await this.wordPressBroker.PostMediaRequestAsync(externalMediaItemRequest);
            return ConvertToMediaItem(mediaItem, externalMediaItemResponse);
        }

        private ExternalMediaItemRequest Convert(MediaItem mediaItem)
        {
            return new ExternalMediaItemRequest()
            {
                File = new FileStream(mediaItem.Request.Src, FileMode.Open),
                FileName = Path.GetFileName(mediaItem.Request.Src),
                AltText = "alt"
            };
        }
        private MediaItem ConvertToMediaItem(
            MediaItem mediaItem,
            ExternalMediaItemResponse externalMediaItemResponse
            )
        {
            mediaItem.Response = new MediaItemResponse()
            {
                Id = externalMediaItemResponse.Id,
                Src = externalMediaItemResponse.Guid.rendered,
                Name = externalMediaItemResponse.Title.Rendered,
                Alt = externalMediaItemResponse.alt_text
            };
            return mediaItem;
        }
    }
}
