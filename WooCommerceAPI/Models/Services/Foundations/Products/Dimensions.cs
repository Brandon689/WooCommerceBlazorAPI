using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.Products
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Dimensions
    {
        public string? Length { get; set; }

        public string? Width { get; set; }

        public string? Height { get; set; }
    }
}
