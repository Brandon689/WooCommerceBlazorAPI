using WooCommerceAPI.Brokers.WordPresses;
using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;
using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Services.Foundations.Media
{
    internal class MediaService : IMediaService
    {
        private readonly IWordPressBroker wordPressBroker;

        public MediaService(IWordPressBroker wordPressBroker)
        {
            this.wordPressBroker = wordPressBroker;
        }

        public async ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem) //=>
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
                Id = mediaItem.Request.Id,
                Src = mediaItem.Request.Src,
                Alt = mediaItem.Request.Alt,
                Name = mediaItem.Request.Name
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
                Src = externalMediaItemResponse.Src,
                Name = externalMediaItemResponse.Name,
                Alt = externalMediaItemResponse.Alt
            };
            return mediaItem;
        }
        //TryCatch(async () =>
        //{
        //    ValidateProductOnSend(product);

        //    ExternalProductRequest externalProductRequest = ConvertToProductRequest(product);
        //    //string f = Newtonsoft.Json.JsonConvert.SerializeObject(externalProductRequest);
        //    ExternalProductResponse externalProductResponse =
        //        await this.wordPressBroker.PostProductRequestAsync(externalProductRequest);

        //    return ConvertToProduct(product, externalProductResponse);
        //});
    }
}
