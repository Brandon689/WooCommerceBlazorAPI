using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceAPI.Models.Services.Foundations.Media;

namespace WooCommerceAPI.Services.Foundations.Media
{
    internal interface IMediaService
    {
        ValueTask<MediaItem> SendMediaItemAsync(MediaItem mediaItem);
    }
}
