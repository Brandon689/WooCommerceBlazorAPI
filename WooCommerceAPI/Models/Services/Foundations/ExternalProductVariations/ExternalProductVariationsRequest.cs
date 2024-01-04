using Newtonsoft.Json;
using WooCommerceAPI.Models.Services.Foundations.ExternalMedia;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations
{
    internal class ExternalProductVariationsRequest
    {
        [JsonProperty("create")]
        public ExternalProductVariation[] Create { get; set; }
    }

    internal class ExternalProductVariation
    {
        [JsonProperty("regular_price")]
        public string RegularPrice { get; set; } = string.Empty;

        [JsonProperty("attributes")]
        public ExternalProductVariationAttribute[] Attributes { get; set; }

        [JsonProperty("image")]
        public ExternalMediaItemRequest2 Image { get; set; } = null;
    }

    internal class ExternalProductVariationAttribute
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("option")]
        public string Option { get; set; } = string.Empty;
    }
}
