using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Links
    {
        public Self[] Self { get; set; }

        public Collection[] Collection { get; set; }
    }
}
