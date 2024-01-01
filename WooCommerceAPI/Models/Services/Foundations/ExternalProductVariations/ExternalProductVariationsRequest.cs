using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations
{
    internal class ExternalProductVariationsRequest
    {
        [JsonProperty("create")]
        public ExternalF[] Create { get; set; }
    }

    internal class ExternalF
    {
        [JsonProperty("regular_price")]
        public string RegularPrice { get; set; } = string.Empty;

        [JsonProperty("attributes")]
        public ExternalA[] Attributes { get; set; }
    }

    internal class ExternalA
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("option")]
        public string Option { get; set; } = string.Empty;
    }
}
