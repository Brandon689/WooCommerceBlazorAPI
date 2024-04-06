using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalActivePlugin
    {
        [JsonProperty("plugin")]
        public string? Plugin { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("version_latest")]
        public string? VersionLatest { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("author_name")]
        public string? AuthorName { get; set; }

        [JsonProperty("author_url")]
        public string? AuthorUrl { get; set; }

        [JsonProperty("network_activated")]
        public bool? NetworkActivated { get; set; }
    }
}
