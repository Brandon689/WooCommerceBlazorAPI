using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalSystemStatus
    {
        [JsonProperty("environment")]
        public ExternalEnvironment? Environment { get; set; }

        [JsonProperty("database")]
        public ExternalDatabase? Database { get; set; }

        [JsonProperty("active_plugins")]
        public List<ExternalActivePlugin>? ActivePlugins { get; set; }

        [JsonProperty("theme")]
        public ExternalTheme? Theme { get; set; }

        [JsonProperty("settings")]
        public ExternalSettings? Settings { get; set; }

        [JsonProperty("security")]
        public ExternalSecurity? Security { get; set; }

        [JsonProperty("pages")]
        public ExternalPage[]? Pages { get; set; }
    }
}
