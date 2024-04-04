using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProductVariations
{
    internal class ExternalVariationAttribute
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("option")]
        public string Option { get; set; }
    }
}
