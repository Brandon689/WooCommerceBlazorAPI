using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalPage
    {
        [JsonProperty("page_name")]
        public string? PageName { get; set; }

        [JsonProperty("page_id")]
        public string? PageId { get; set; }

        [JsonProperty("page_set")]
        public bool? PageSet { get; set; }

        [JsonProperty("page_exists")]
        public bool? PageExists { get; set; }

        [JsonProperty("page_visible")]
        public bool? PageVisible { get; set; }

        [JsonProperty("shortcode")]
        public string? Shortcode { get; set; }

        [JsonProperty("shortcode_required")]
        public bool? ShortcodeRequired { get; set; }

        [JsonProperty("shortcode_present")]
        public bool? ShortcodePresent { get; set; }
    }
}
