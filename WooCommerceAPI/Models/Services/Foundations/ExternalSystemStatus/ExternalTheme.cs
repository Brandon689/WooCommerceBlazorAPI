using Newtonsoft.Json;

namespace WooCommerceAPI.Models.Services.Foundations.ExternalSystemStatus
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExternalTheme
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("version_latest")]
        public string VersionLatest { get; set; }

        [JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        [JsonProperty("is_child_theme")]
        public bool? IsChildTheme { get; set; }

        [JsonProperty("has_woocommerce_support")]
        public bool? HasWoocommerceSupport { get; set; }

        [JsonProperty("has_woocommerce_file")]
        public bool? HasWoocommerceFile { get; set; }

        [JsonProperty("has_outdated_templates")]
        public bool? HasOutdatedTemplates { get; set; }

        [JsonProperty("overrides")]
        public List<object> Overrides { get; set; }

        [JsonProperty("parent_name")]
        public string ParentName { get; set; }

        [JsonProperty("parent_version")]
        public string ParentVersion { get; set; }

        [JsonProperty("parent_version_latest")]
        public string ParentVersionLatest { get; set; }

        [JsonProperty("parent_author_url")]
        public string ParentAuthorUrl { get; set; }
    }
}
