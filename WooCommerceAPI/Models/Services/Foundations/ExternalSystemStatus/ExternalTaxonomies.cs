using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalTaxonomies
    {
        [JsonProperty("external")]
        public string External { get; set; }

        [JsonProperty("grouped")]
        public string Grouped { get; set; }

        [JsonProperty("simple")]
        public string Simple { get; set; }

        [JsonProperty("variable")]
        public string Variable { get; set; }
    }
}
