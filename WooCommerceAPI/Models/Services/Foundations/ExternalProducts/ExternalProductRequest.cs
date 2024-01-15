using Newtonsoft.Json;
using WooCommerceAPI.Models.Services.Foundations.Products;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProducts
{
    internal class ExternalProductRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = "simple";

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("regular_price")]
        public string RegularPrice { get; set; } = string.Empty;

        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalProductAttribute[] Attributes { get; set; } = null;

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalID[] Images { get; set; }

        [JsonProperty("meta_data", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalProductMetadata[] Metadata { get; set; }
    }
}