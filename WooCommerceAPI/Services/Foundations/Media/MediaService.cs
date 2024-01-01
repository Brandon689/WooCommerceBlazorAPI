using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Brokers.WooCommerces;
using WooCommerceAPI.Brokers.WordPresses;
using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;
using WooCommerceAPI.Models.Services.Foundations.Media;
using WooCommerceAPI.Models.Services.Foundations.Products;

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

            ExternalMediaItemRequest externalMediaItemRequest = new ExternalMediaItemRequest();

            var r = await this.wordPressBroker.PostMediaRequestAsync(null);
            return null;
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
