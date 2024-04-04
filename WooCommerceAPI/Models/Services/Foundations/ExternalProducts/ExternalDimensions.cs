using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProducts
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    internal class ExternalDimensions
    {
        [JsonProperty("length")]
        public string? Length { get; set; }

        [JsonProperty("width")]
        public string? Width { get; set; }

        [JsonProperty("height")]
        public string? Height { get; set; }
    }
}
