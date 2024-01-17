using Newtonsoft.Json;
using System.Text.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalProducts
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalProductMetadata
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }
    }
}
