using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ProductMetadata
    {
        public int? Id { get; set; }

        public string? Key { get; set; }

        public string? Value { get; set; }
    }
}
