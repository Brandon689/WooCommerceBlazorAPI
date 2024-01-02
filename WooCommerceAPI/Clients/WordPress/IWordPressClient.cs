using WooCommerceAPI.Clients.Media;

namespace WooCommerceAPI.Clients.WordPress
{
    public interface IWordPressClient
    {
        IMediaClient Media { get; }
    }
}
